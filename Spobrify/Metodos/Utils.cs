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
