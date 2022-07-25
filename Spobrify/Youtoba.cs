using Jurassic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
namespace Spobrify
{
    public class Youtoba
    {
        public Youtoba()
        {

        }



        public string Decipher(string id)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = null;
                    
                    // Utilizando um WebClient, fazemos o download da página do Youtube (o conteúdo HTML mesmo) como string
                    string PaginaWebYoutube = wc.DownloadString(string.Concat("https://www.youtube.com/watch?v=", id));

                    // Localizamos na página baixada anteriormente uma variável Javascript chamada "ytInitialPlayerResponse"
                    // Para isso, simplesmente localizamos a posição de início da cadeia "ytInitialPlayerResponse"
                    // e a posição da primeira ocorrência da cadeia "};"
                    int InicioPlayerResponse = PaginaWebYoutube.IndexOf("ytInitialPlayerResponse") + "ytInitialPlayerResponse".Length + 3;
                    int FimPlayerResponse = PaginaWebYoutube.IndexOf("};", InicioPlayerResponse) + 1;

                    string ytInitialPlayerResponse = "";
                    if (InicioPlayerResponse > -1 && FimPlayerResponse > -1)
                    {
                        int len = FimPlayerResponse - InicioPlayerResponse;
                        ytInitialPlayerResponse = PaginaWebYoutube.Substring(InicioPlayerResponse, len);

                    }

                    // A função abaixo, escrita em Javascript, é responsável por pegar o primeiro formato de áudio presente no ytInitialPlayerResponse que extraímos no passo anterior
                    // Antes era feita via regex, era meio bagunçado e difícil de entender
                    string FuncaoJavascriptPegarAudio =
                    @"function getFirstAudio()
                    {
	                    var ytInitialPlayerResponse = @RESPONSE_HERE;
	                    var adaptiveFormats = ytInitialPlayerResponse.streamingData.adaptiveFormats;
	                    for(var i = 0; i < adaptiveFormats.length; i++)
	                    {
		                    var mimeType = adaptiveFormats[i].mimeType;
		                    if(mimeType.indexOf('audio/') > -1)
		                    {
			                    if(adaptiveFormats[i].signatureCipher != undefined)
			                    {
				                    return adaptiveFormats[i].signatureCipher;
			                    }
			                    else
			                    {
				                    if(adaptiveFormats[i].url != undefined)
				                    {
					                    return adaptiveFormats[i].url;
				                    }				
			                    }
			
		                    }
	                    }
                    }";

                    // Insere o ytInitialPlayerResponse que extraímos anteriormente em nossa função Javascript
                    FuncaoJavascriptPegarAudio = FuncaoJavascriptPegarAudio.Replace("@RESPONSE_HERE", ytInitialPlayerResponse);

                    // Instancia uma nova ScriptEngine do Jurassic e roda um eval no nosso código JS
                    ScriptEngine Engine = new ScriptEngine();
                    Engine.Evaluate(FuncaoJavascriptPegarAudio);

                    // Utiliza a função CallGlobalFunction<T> do Jurassic com retorno string para pegar as informações do formato de áudio
                    string PrimeiroFormatoDeAudio = (Engine.CallGlobalFunction<string>("getFirstAudio"));

                    // Converte a string do formato de áudio em dicionário
                    Dictionary<string, string> CipherDict = Metodos.Utils.cifraToDict(PrimeiroFormatoDeAudio);

                    // Checa se o dicionário foi separado em 3(se não = a string da informação de áudio não precisa ser desembaralhada)
                    if(CipherDict.Count == 3)
                    {

                        // Aqui pegamos a URL do player.js (Mesmo processo de captura do ytInitialPlayerResponse)
                        int InicioJSURL = PaginaWebYoutube.IndexOf("jsUrl") + "jsUrl".Length + 3;
                        int FimJSURL = PaginaWebYoutube.IndexOf("\"", InicioJSURL);
                        string BasePlayerURL = "";


                        if (InicioJSURL > -1 && FimJSURL > -1)
                        {
                            int len = FimJSURL - InicioJSURL;
                            BasePlayerURL = PaginaWebYoutube.Substring(InicioJSURL, len);
                        }
                        string BasePlayerJS = wc.DownloadString(string.Concat("https://youtube.com", BasePlayerURL));

                        // Infelizmente ainda dependemos de expressões regulares para buscar a função JS que realiza o desembaralhamento da string 
                        Regex JsFunction = new Regex(Patterns.JsFunctionPattern1);
                        Match RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);
                        string FuncaoJavascriptDecipher = RegexFuncaoJavascript.Groups[1].Value;

                        JsFunction = new Regex(string.Concat(Regex.Escape(FuncaoJavascriptDecipher), Patterns.JsFunctionPattern2));
                        RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);

                        // Separamos os argumentos e o "corpo da função"(que chamei de algoritmo)
                        string ArgumentosFuncaoJavascript = RegexFuncaoJavascript.Groups[1].Value;

                        string AlgoritmoFuncaoJavascript = RegexFuncaoJavascript.Groups[2].Value;

                        // Montamos a função completa com as informações capturadas anteriormente e depois separamos as instruções por linha
                        string FuncaoJavascriptMontada = string.Concat("var unscramble = function(", ArgumentosFuncaoJavascript, ") { ", AlgoritmoFuncaoJavascript, " };");
                        string[] LinhasAlgoritmoJavascript = AlgoritmoFuncaoJavascript.Split(';');

                        HashSet<string> VariaveisFuncaoJavascript = new HashSet<string>();

                        // Capturamos todos os nomes de variáveis(que podem ou não fazer parte de uma função escondida dentro de 1.5 MB de Javascript ofuscado)
                        foreach (string LinhaAlgoritmoJavascript in LinhasAlgoritmoJavascript)
                            if (!LinhaAlgoritmoJavascript.StartsWith(string.Concat(ArgumentosFuncaoJavascript, "=")) && !LinhaAlgoritmoJavascript.StartsWith("return "))
                                VariaveisFuncaoJavascript.Add(LinhaAlgoritmoJavascript.Split('.')[0]);

                        JsFunction = new Regex(string.Concat("var ", VariaveisFuncaoJavascript.Where(c => !c.Contains(")")).FirstOrDefault(), Patterns.JsFunctionPattern3), RegexOptions.Singleline);
                        RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);

                        AlgoritmoFuncaoJavascript = RegexFuncaoJavascript.Groups[0].Value;

                        // Por fim unimos funções e chamada da função em uma mesma string
                        FuncaoJavascriptMontada = string.Concat(AlgoritmoFuncaoJavascript, "\n", FuncaoJavascriptMontada);

                        // Assim como fizemos com ytInitialPlayerResponse, damos um eval e chamamos CallGlobalFunction<T> retornando string
                        Engine.Evaluate(FuncaoJavascriptMontada);
                        string UnscambledCipher = (Engine.CallGlobalFunction<string>("unscramble", CipherDict["s"]));

                        // Se deu tudo certo, retorna o parâmetro "url" + a a cifra desembaralhada anteriormente
                        if (!string.IsNullOrEmpty(UnscambledCipher))
                        {
                            return Uri.UnescapeDataString($"{CipherDict["url"]}&{CipherDict["sp"]}={UnscambledCipher}");
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    // Caso o dicionário não contenha 3 entradas, provavelmente significa que ytInitialPlayerResponse retornou a URL do áudio em um estado não ofuscado, não sendo necessário o processo de desembaralhamento. 
                    else
                    {
                        return Uri.UnescapeDataString(PrimeiroFormatoDeAudio);
                    }
                }
            }
            catch(Exception ex)
            {
                string a = ex.Message;
                return "";
            }
        }


        public List<Musica> GetPlayList(string id)
        {
            List<Musica> Playlist = new List<Musica>();
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = null;
                    string PaginaWebYoutube = Encoding.UTF8.GetString(wc.DownloadData($"https://www.youtube.com/playlist?list={id}"));
                    int InicioInitialData = PaginaWebYoutube.IndexOf("ytInitialData") + "ytInitialData".Length + 3;
                    int FimInitialData = PaginaWebYoutube.IndexOf("};", InicioInitialData) + 1;
                    string JsonInitialData = "";
                    if (InicioInitialData > -1 && FimInitialData > -1)
                    {
                        int len = FimInitialData - InicioInitialData;
                        JsonInitialData = PaginaWebYoutube.Substring(InicioInitialData, len);

                    }

                    string FuncaoJavascriptPegarVideos =
                    @"function returnList()
                    {
	                    var ytInitialData = @RESPONSE_HERE;
	                    var plVideoContents = ytInitialData.contents.twoColumnBrowseResultsRenderer.tabs[0].tabRenderer.content.sectionListRenderer.contents[0].itemSectionRenderer.contents[0].playlistVideoListRenderer.contents;
	                    var final = [];
	                    for(var i = 0; i < plVideoContents.length; i++)
	                    {
		                    var title = plVideoContents[i].playlistVideoRenderer.title.runs[0].text.split(';').join('').split('|').join('');
		                    var id = plVideoContents[i].playlistVideoRenderer.videoId;
		                    var duration = new Date(plVideoContents[i].playlistVideoRenderer.lengthSeconds * 1000).toISOString().substring(14, 19);
		                    final.push(id+'||'+title+'||'+duration);
	                    }
	                    return final.join(';');
                    }";
                    FuncaoJavascriptPegarVideos = FuncaoJavascriptPegarVideos.Replace("@RESPONSE_HERE", JsonInitialData);

                    ScriptEngine Engine = new ScriptEngine();
                    Engine.Evaluate(FuncaoJavascriptPegarVideos);
                    string ListaDeVideosRaw = (Engine.CallGlobalFunction<string>("returnList"));
                    string[] ListaDeVideos = ListaDeVideosRaw.Split(';');

                    foreach(string Video in ListaDeVideos)
                    {
                        string[] InfoVideo = Video.Split(new[] { "||" }, StringSplitOptions.None);
                        string IdDoVideo = InfoVideo[0];
                        string NomeDoVideo = InfoVideo[1];
                        string DuracaoDoVideo = InfoVideo[2];
                        Musica EstaMusica = new Musica(Metodos.Utils.LimparNomeDoArtista(NomeDoVideo), IdDoVideo, "");
                        Playlist.Add(EstaMusica);
                    }
                }
            }
            catch (Exception ex)
            {
                
                if(Playlist.Count > 0)
                {
                    return Playlist;
                }
                else
                {
                    return Playlist;
                }
            }
            return Playlist;
        }
    }
}
