using Jurassic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Spobrify
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        /// 
        //public static ScriptEngine Engine;
        [STAThread]
        static void Main()
        {
            //.net 4.0 tls12 kludge
            //Engine = new ScriptEngine();
           
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)0x00000C00 | SecurityProtocolType.Tls;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }
    }
}
