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
        private static string[] aRemover = { "MV", "M/V", "PV", "Official", "Lyrics", "Music", "Video" , "Legendado", };
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
            entrada = entrada.Replace("『", " - ");
            entrada = entrada.Replace("_", " - ");
            entrada = entrada.Replace("\"", " ");
            entrada = entrada.Replace("/", "");
            entrada = entrada.Replace("\\", "");
            entrada = entrada.Replace("+++", "");
            entrada = entrada.Replace("+", " ");
            entrada = entrada.Replace("'", " ");
            entrada = entrada.Replace("‘", " ");
            entrada = entrada.Replace("‘", " ");
            entrada = entrada.Replace("’", " ");
            entrada = entrada.Replace("』", "");
            entrada = entrada.Replace("  ", " - ");
            entrada = entrada.Replace(" - - ", " - ");
            return entrada;

        }

        public static string LimparDaString(string entrada)
        {
            string temp = entrada.ToUpper();
            foreach(string s in aRemover)
            {
                if(temp.Contains(s.ToUpper()))
                {
                    entrada = Regex.Replace(entrada, Regex.Escape(s),"", RegexOptions.IgnoreCase);
                }
            }
            return entrada;
        }

        public static void ShowMsg(string header, string content, MessageBoxIcon icon)
        {
            MessageBox.Show(content, header, MessageBoxButtons.OK, icon);
        }

        public static Image Cortar4_3(Image img)
        {
            // 4:3 Aspect Ratio. You can also add it as parameters
            double aspectRatio_X = 4;
            double aspectRatio_Y = 3;

            double imgWidth = Convert.ToDouble(img.Width);
            double imgHeight = Convert.ToDouble(img.Height);

            if (imgWidth / imgHeight > (aspectRatio_X / aspectRatio_Y))
            {
                double extraWidth = imgWidth - (imgHeight * (aspectRatio_X / aspectRatio_Y));
                double cropStartFrom = extraWidth / 2;
                Bitmap bmp = new Bitmap((int)(img.Width - extraWidth), img.Height);
                Graphics grp = Graphics.FromImage(bmp);
                grp.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                grp.DrawImage(img, new Rectangle(0, 0, (int)(img.Width - extraWidth), img.Height), new Rectangle((int)cropStartFrom, 0, (int)(imgWidth - extraWidth), img.Height), GraphicsUnit.Pixel);
                img.Dispose();
                return (Image)bmp;
            }
            else
                return null;
        }

        public static string queryStringToDict(string s)
        {
            
            string[] s1 = s.Split('&');
            for(int i = 0; i < s1.Length; i++)
            {
                string[] s2 = s1[i].Split(new[] { '='}, 2);
                if(s2.Length > 1 && s2[0] == "player_response")
                {
                    return s2[1];
                }
            }
            return "";
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

        //Função para a procura de strings parciais dentro de um vetor de strings
        public static int PartialIndexOf(string[] strings, string searchFor)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                if (strings[i].IndexOf(searchFor) != -1)
                    return i;
            }
            return -1;
        }

        //metodos para a decodificação de cifras

        //equivalente ao 'swap', pega um caracter da string e move para uma nova posição
        public static string swap(string entrada, int pos1, int pos2)
        {
            char[] arr = entrada.ToCharArray();
            char c1 = arr[pos1];
            char c2 = arr[pos2];
            arr[pos1] = c2;
            arr[pos2] = c1;
            return new string(arr);
        }

        public static string reverse(string entrada)
        {
            char[] arr = entrada.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static string MoverChar(this string text, int oldIndex, int newIndex)
        {

                var chars = new List<char>(text.ToCharArray(0, text.Length));
                var value = chars[oldIndex];
                chars.RemoveAt(oldIndex);
                chars.Insert(newIndex, value);
                return new string(chars.ToArray());
        }

    }
}
