using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
//ytm-compact-video-renderer
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
                    string dpage = wc.DownloadString(string.Concat("https://www.youtube.com/watch?v=", id));

                    Regex dreg = new Regex(Patterns.YoutubeInitialResponse);
                    Match dm;

                    string _playerResponse = (dreg.Match(dpage).Value);
                    dreg = new Regex(Patterns.AdaptiveFormats1);

                    string AdaptiveFormats = dreg.Match((_playerResponse)).Value;
                    dreg = new Regex(Patterns.AdaptiveFormats2);
                    string[] mc = dreg.Matches(AdaptiveFormats).Cast<Match>().Select(m => m.Value).ToArray();
                    int AudioMaisProximo = Metodos.Utils.PartialIndexOf(mc, "audio/");
                    if (AudioMaisProximo > -1)
                    {
                        dreg = new Regex(Patterns.SignatureCipher);
                        MatchCollection SignatureCipher = dreg.Matches(mc[AudioMaisProximo]);
                        if (SignatureCipher.Count > 0)
                        {
                            string r_cifra = Regex.Unescape(SignatureCipher[0].Value);
                            Dictionary<string, string> CipherDetails = Metodos.Utils.cifraToDict(r_cifra);


                            //match the player .js file
                            dreg = new Regex(Patterns.JsURL);
                            dm = dreg.Match(dpage);
                            string BasePlayer = Regex.Unescape(dm.Groups[1].Value);
                            string djloc = string.Concat("https://youtube.com", BasePlayer);
                            string djs = wc.DownloadString(djloc);

                            //match the descrambling function in the downloaded javascript
                            dreg = new Regex(Patterns.JsFunctionPattern1);
                            //(?:\b|[^a-zA-Z0-9$])(?P<sig>[a-zA-Z0-9$]{2})\s*=\s*function\(\s*a\s*\)\s*{\s*a\s*=\s*a\.split\(\s*\"\"\s*\).*};
                            dm = dreg.Match(djs);
                            string dfunc = dm.Groups[1].Value;
                            dreg = new Regex(string.Concat(Regex.Escape(dfunc), Patterns.JsFunctionPattern2));
                            dm = dreg.Match(djs);

                            string dargn = dm.Groups[1].Value;
                            string dalg = dm.Groups[2].Value;

                            //pretty prints it for later usage
                            string djsfunc = string.Concat("var unscramble = function(", dargn, ") { ", dalg, " };");
                            string[] dalgps = dalg.Split(';');
                            HashSet<string> dalgrs = new HashSet<string>();
                            foreach (string dalgp in dalgps)
                                if (!dalgp.StartsWith(string.Concat(dargn, "=")) && !dalgp.StartsWith("return "))
                                    dalgrs.Add(dalgp.Split('.')[0]);

                            dreg = new Regex(string.Concat("var ", dalgrs.Where(c => !c.Contains(")")).FirstOrDefault(), Patterns.JsFunctionPattern3), RegexOptions.Singleline);
                            dm = dreg.Match(djs);

                            dalg = dm.Groups[0].Value;
                            djsfunc = string.Concat(dalg, "\n", djsfunc, "");

                            //instantiates the JS engine,calls the js function and returns the deciphered URL
                            Jurassic.ScriptEngine engine = new Jurassic.ScriptEngine();
                            engine.Evaluate(djsfunc);
                            string UnscambledCipher = (engine.CallGlobalFunction<string>("unscramble", CipherDetails["s"]));

                            if (!string.IsNullOrEmpty(UnscambledCipher))
                            {
                                return Uri.UnescapeDataString($"{CipherDetails["url"]}&{CipherDetails["sp"]}={UnscambledCipher}");
                            }
                            else
                            {
                                return string.Empty;
                            }

                        }
                        else
                        {
                            dreg = new Regex(Patterns.FileURL);
                            MatchCollection URL = dreg.Matches(mc[AudioMaisProximo]);
                            if (URL.Count > 0)
                            {
                                return Uri.UnescapeDataString(Regex.Unescape(URL[0].Value));
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    else
                    {
                        return "";
                    }
                }
                return "";
            }
            catch(Exception ex)
            {
                string a = ex.Message;
                return "";
            }
        }


        private string GetResponseContext(string id)
        {
            using (WebClient client = new WebClient())
            {
                client.Proxy = null;
                return client.DownloadString($"https://youtube.com/get_video_info?video_id={id}&el=detailpage");
            }
        }

        public List<Musica> GetPlayList(string id)
        {
            List<Musica> playlist = new List<Musica>();
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = null;
                    string doc = Encoding.UTF8.GetString(wc.DownloadData($"https://www.youtube.com/playlist?list={id}"));
                    Regex dreg = new Regex(@"(?<=var ytInitialData = )(.*)(?=;)");
                    Match dm = dreg.Match(doc);
                    string teste = $@"{(dm.Groups[0].Value)}";
                    Regex plRenderer = new Regex("(\\[\\{\"playlistVideoRenderer\":)(.*)(?=\\],\"playlistId\":)");
                    Match lets_gooo = plRenderer.Match(teste);

                    Regex objVideo = new Regex("(\\{\"playlistVideoRenderer\":)(.*?)(?=\\},\\{\"playlistVideoRenderer\":)");
                    MatchCollection letsgo2 = objVideo.Matches(lets_gooo.Value);
                    foreach(Match c in letsgo2)
                    {
                        string objSingleVideo = c.Value;
                        Regex rId = new Regex("(?<=\"videoId\":\").*?(?=\")");
                        string sID = rId.Match(objSingleVideo).Value;
                        rId = new Regex("(?<=\"url\":\").*?(?=\")");
                        string sThumbURL = rId.Match(objSingleVideo).Value;
                        rId = new Regex("(?<=\"text\":\")(.*?)(?=\"\\})");
                        string sNome = rId.Match(objSingleVideo).Value;
                        Musica m = new Musica(Metodos.Utils.LimparNomeDoArtista(sNome), sID, Regex.Unescape(sThumbURL));
                        playlist.Add(m);
                    }
                }
            }
            catch (Exception ex)
            {
                
                if(playlist.Count > 0)
                {
                    return playlist;
                }
                else
                {
                    return playlist;
                }
            }
            return playlist;
        }


    }
}
