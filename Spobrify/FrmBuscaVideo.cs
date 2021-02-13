using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Spobrify
{
    public partial class FrmBuscaVideo : DefaultForm
    {
        public FrmBuscaVideo()
        {
            InitializeComponent();
            txtBusca.KeyUp += TxtBusca_KeyUp;
            txtBusca.KeyDown += TxtBusca_KeyDown;
            DataTable dtTipoPesq = new DataTable();
            dtTipoPesq.Columns.Add("Descr", typeof(string));
            dtTipoPesq.Columns.Add("ID", typeof(string));
            dtTipoPesq.Rows.Add(new object[] { "Videos", "sp=EgIQAQ%253D%253D" });
            dtTipoPesq.Rows.Add(new object[] { "Playlists", "sp=EgIQAw%253D%253D" });
            cmbTipoPesquisa.DataSource = dtTipoPesq;
            cmbTipoPesquisa.DisplayMember = "Descr";
            cmbTipoPesquisa.ValueMember = "ID";
            redimensionar();
        }

        private void TxtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void redimensionar()
        {
            pnlResults.Left = 0;
            pnlResults.Top = pnlBarraBusca.Bottom;
            pnlResults.Height = ClientSize.Height - pnlBarraBusca.Height;
            pnlResults.Width = ClientSize.Width;
        }
        private void TxtBusca_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string tPesquisa = (string)cmbTipoPesquisa.SelectedValue;
                int tipo = cmbTipoPesquisa.SelectedIndex > 0 ? 2 : 1;
                var t = new Thread(() => busca(tPesquisa, tipo));
                e.SuppressKeyPress = true;
                e.Handled = true;
                t.Start();
            }
        }

        private void FrmBuscaVideo_Resize(object sender, EventArgs e)
        {
            redimensionar();
        }

        private void btBuscar_Click(object sender, EventArgs e)
        {
            string tPesquisa = (string)cmbTipoPesquisa.SelectedValue;
            int tipo = cmbTipoPesquisa.SelectedIndex > 0 ? 2 : 1;
            busca(tPesquisa, tipo);

        }


        private void busca(string tPesquisa, int type)
        {
            int alt = Convert.ToInt32(pnlResults.Width * 0.8);
            try
            {
                clearResult(pnlResults);
                using (WebClient wc = new WebClient())
                {
                    wc.Proxy = null;
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.116 Safari/537.36");
                    string dpage = Encoding.UTF8.GetString(wc.DownloadData($"http://youtube.com/results?search_query={Uri.EscapeDataString(txtBusca.Text)}&{tPesquisa}&app=desktop"));
                    var dreg = new Regex(Patterns.YtInitialData);
                    var dm = dreg.Match(dpage);
                    string teste = $@"{(dm.Groups[0].Value)}";
                    
                    switch(type)
                    {
                        case 1:

                            var rgVideos = new Regex(Patterns.VideoRendererBlock);
                            var objVideos = rgVideos.Matches(teste);
                            foreach(Match v in objVideos)
                            {
                                string video = v.Value;
                                Regex rgId = new Regex(Patterns.VideoName);
                                string sNome = rgId.Match(video).Value;
                                rgId = new Regex(Patterns.VideoID);
                                string sID = rgId.Match(video).Value;
                                rgId = new Regex(Patterns.VideoViewCount);
                                sNome += $"({rgId.Match(video).Value})";

                                lblPlaylist ll = new lblPlaylist(sID, 0, Regex.Unescape(sNome));
                                ll.Width = alt;
                                //ll.Height *= 2;
                                addResult(pnlResults, ll);

                            }
                            break;
                        case 2:
                            var plRenderer = new Regex(Patterns.PlaylistRenderer);
                            MatchCollection objPlaylists = plRenderer.Matches(teste);
                            foreach(Match objPlayList in objPlaylists)
                            {
                                string sPlaylist = objPlayList.Value;
                                Regex rTitulo = new Regex(Patterns.PlaylistName);
                                //videoCount
                                Match mTitulo = rTitulo.Match(sPlaylist);
                                rTitulo = new Regex(Patterns.PlaylistVideoCount);
                                Match mVideoCount = rTitulo.Match(sPlaylist);
                                rTitulo = new Regex(Patterns.PlaylistID);
                                Match mID = rTitulo.Match(sPlaylist);
                                lblPlaylist ll = new lblPlaylist(mID.Value, 1, Regex.Unescape($"{mTitulo.Value}({mVideoCount.Value} videos)"));
                                ll.Width = alt;
                                //ll.Height *= 2;
                                addResult(pnlResults, ll);
                            }
                            break;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "Spobrify", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void addResult(Control pai, Control filho)
        {
            if (pai.InvokeRequired)
            {
                pai.Invoke(new MethodInvoker(delegate ()
                {
                    pai.Controls.Add(filho);
                }));
            }
            else
            {
                pai.Controls.Add(filho);
            }
        }

        private void clearResult(Control pai)
        {
            if (pai.InvokeRequired)
            {
                pai.Invoke(new MethodInvoker(delegate ()
                {
                    foreach (IDisposable control in pai.Controls)
                    {
                        
                        control.Dispose();
                        
                    }

                    pai.Controls.Clear();
                }));
            }
            else
            {
                foreach (IDisposable control in pai.Controls)
                    control.Dispose();

                pai.Controls.Clear();
            }

        }

        private void FrmBuscaVideo_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}
