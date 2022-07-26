using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Spobrify.Metodos
{
    public static class Utils
    {
        private static string[] TermosParaRemover = { "MV", "M/V", "PV", "Official", "Lyrics", "Music", "Video" , "Legendado", };
        public static string PlaylistParaString(List<Musica> Playlist)
        {
            StringBuilder sb = new StringBuilder();
            foreach(Musica m in Playlist)
            {
                sb.AppendLine($"{m.ID}|_|{m.Nome}|_|{m.Thumb}");
            }
            return sb.ToString();
        }

        public static string LimparNomeDoArtista(string entrada)
        {
            //『』
            entrada = Regex.Replace(entrada, @"\([^()]*\)", string.Empty);
            entrada = Regex.Replace(entrada, @"\[(.*?)\]", string.Empty);
           
            entrada = LimparDaString(entrada);
            entrada = entrada.Trim();
            entrada = entrada.Replace("『", "");
            entrada = entrada.Replace("』", "");
            entrada = entrada.Replace("_", "");
            entrada = entrada.Replace("\"", "");
            entrada = entrada.Replace("/", "");
            entrada = entrada.Replace("\\", "");
            entrada = entrada.Replace("+++", "");
            entrada = entrada.Replace("+", " ");
            entrada = entrada.Replace("'", " ");
            entrada = entrada.Replace("‘", " ");
            entrada = entrada.Replace("‘", " ");
            entrada = entrada.Replace("’", " ");
            
            entrada = entrada.Replace("  ", "");
            entrada = entrada.Replace(" - - ", " - ");
            return entrada;

        }

        public static string LimparDaString(string entrada)
        {
            string temp = entrada.ToUpper();
            foreach(string s in TermosParaRemover)
            {
                if(temp.Contains(s.ToUpper()))
                {
                    entrada = Regex.Replace(entrada, Regex.Escape(s),"", RegexOptions.IgnoreCase);
                }
            }
            return entrada;
        }



        public static Dictionary<string, string> cifraToDict(string s)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            string[] s1 = s.Split('&');
            for(int i = 0; i < s1.Length; i++)
            {
                string[] s2 = s1[i].Split(new[] { '='}, 2);
                if(s2.Length > 1)
                {
                    d.Add(s2[0], Uri.UnescapeDataString(s2[1]));
                }
            }
            return d;
        }


    }
}
