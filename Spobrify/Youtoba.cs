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
                    //downloads the whole page
                    string PaginaWebYoutube = wc.DownloadString(string.Concat("https://www.youtube.com/watch?v=", id));

                    int InicioPlayerResponse = PaginaWebYoutube.IndexOf("ytInitialPlayerResponse") + "ytInitialPlayerResponse".Length + 3;
                    int FimPlayerResponse = PaginaWebYoutube.IndexOf("};", InicioPlayerResponse) + 1;

                    string ytInitialPlayerResponse = "";
                    if (InicioPlayerResponse > -1 && FimPlayerResponse > -1)
                    {
                        int len = FimPlayerResponse - InicioPlayerResponse;
                        ytInitialPlayerResponse = PaginaWebYoutube.Substring(InicioPlayerResponse, len);

                    }

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
                    FuncaoJavascriptPegarAudio = FuncaoJavascriptPegarAudio.Replace("@RESPONSE_HERE", ytInitialPlayerResponse);

                    ScriptEngine Engine = new ScriptEngine();
                    Engine.Evaluate(FuncaoJavascriptPegarAudio);
                    string ScrambledCipher = (Engine.CallGlobalFunction<string>("getFirstAudio"));
                    Dictionary<string, string> CipherDict = Metodos.Utils.cifraToDict(ScrambledCipher);
                    if(CipherDict.Count == 3)
                    {
                        int InicioJSURL = PaginaWebYoutube.IndexOf("jsUrl") + "jsUrl".Length + 3;
                        int FimJSURL = PaginaWebYoutube.IndexOf("\"", InicioJSURL);
                        string BasePlayerURL = "";
                        if (InicioJSURL > -1 && FimJSURL > -1)
                        {
                            int len = FimJSURL - InicioJSURL;
                            BasePlayerURL = PaginaWebYoutube.Substring(InicioJSURL, len);
                        }
                        string BasePlayerJS = wc.DownloadString(string.Concat("https://youtube.com", BasePlayerURL));

                        Regex JsFunction = new Regex(Patterns.JsFunctionPattern1);
                        //(?:\b|[^a-zA-Z0-9$])(?P<sig>[a-zA-Z0-9$]{2})\s*=\s*function\(\s*a\s*\)\s*{\s*a\s*=\s*a\.split\(\s*\"\"\s*\).*};
                        Match RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);
                        string FuncaoJavascriptDecipher = RegexFuncaoJavascript.Groups[1].Value;

                        JsFunction = new Regex(string.Concat(Regex.Escape(FuncaoJavascriptDecipher), Patterns.JsFunctionPattern2));
                        RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);


                        string ArgumentosFuncaoJavascript = RegexFuncaoJavascript.Groups[1].Value;
                        string AlgoritmoFuncaoJavascript = RegexFuncaoJavascript.Groups[2].Value;

                        //pretty prints it for later usage
                        string FuncaoJavascriptMontada = string.Concat("var unscramble = function(", ArgumentosFuncaoJavascript, ") { ", AlgoritmoFuncaoJavascript, " };");
                        string[] LinhasAlgoritmoJavascript = AlgoritmoFuncaoJavascript.Split(';');

                        HashSet<string> VariaveisFuncaoJavascript = new HashSet<string>();
                        foreach (string LinhaAlgoritmoJavascript in LinhasAlgoritmoJavascript)
                            if (!LinhaAlgoritmoJavascript.StartsWith(string.Concat(ArgumentosFuncaoJavascript, "=")) && !LinhaAlgoritmoJavascript.StartsWith("return "))
                                VariaveisFuncaoJavascript.Add(LinhaAlgoritmoJavascript.Split('.')[0]);

                        JsFunction = new Regex(string.Concat("var ", VariaveisFuncaoJavascript.Where(c => !c.Contains(")")).FirstOrDefault(), Patterns.JsFunctionPattern3), RegexOptions.Singleline);
                        RegexFuncaoJavascript = JsFunction.Match(BasePlayerJS);

                        AlgoritmoFuncaoJavascript = RegexFuncaoJavascript.Groups[0].Value;
                        FuncaoJavascriptMontada = string.Concat(AlgoritmoFuncaoJavascript, "\n", FuncaoJavascriptMontada, "");


                        Engine.Evaluate(FuncaoJavascriptMontada);
                        string UnscambledCipher = (Engine.CallGlobalFunction<string>("unscramble", CipherDict["s"]));

                        if (!string.IsNullOrEmpty(UnscambledCipher))
                        {
                            return Uri.UnescapeDataString($"{CipherDict["url"]}&{CipherDict["sp"]}={UnscambledCipher}");
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }
                    else
                    {
                        return Uri.UnescapeDataString(ScrambledCipher);
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
