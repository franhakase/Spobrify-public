using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using WMPLib;
using Spobrify.Metodos;

namespace Spobrify
{
    public partial class FrmMain : DefaultForm
    {
        //private Youtoba yt;
        private Random GeradorNumeroRandom;
        private WindowsMediaPlayer Player;
        private bool SeekbarFoiClicado = false;
        bool bSeek;
        
        
        public FrmMain()
        {
            
            InitializeComponent();

            CarregarRegexes();

            Redimensionar();
            lblNomeDaMusica.Text = "...";
            GeradorNumeroRandom = new Random();
            Player = new WindowsMediaPlayer();
            Player.PlayStateChange += Player_PlayStateChange;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(btPesquisar, "Add song (Search)");
            tt.SetToolTip(btBaixoLista, "Mover song down");
            tt.SetToolTip(btCimaLista, "Move song up");
            tt.SetToolTip(btRemoverDaLista, "Remove from list");
            tt.SetToolTip(btSalvarPlaylist, "Save playlist to file");
            tt.SetToolTip(btCarregarPlaylist, "Load playlist from file");
            tt.SetToolTip(btJanelaStream, "Open live streaming overlay window");
            tt.SetToolTip(lblVolume, "Volume");
            tt.SetToolTip(brVolume, "Volume");
            tt.SetToolTip(cbShuffle, "Shuffle");
            tt.SetToolTip(btPlayPause, "Play/Pause");
            tt.SetToolTip(btPrev, "Previous");
            tt.SetToolTip(btNext, "Next");

        }

        public void CarregarRegexes()
        {
            try
            {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Proxy = null;
                        File.WriteAllText("regex.txt", wc.DownloadString("https://raw.githubusercontent.com/DoctorFran/Spobrify-public/master/Spobrify/regex.txt"));
                    }
                    string[] ListaRegexTemp = File.ReadAllLines("regex.txt");
                    if (ListaRegexTemp.Length == 19)
                    {
                        Patterns.AdaptiveFormats1 = ListaRegexTemp[1];
                        Patterns.AdaptiveFormats2 = ListaRegexTemp[2];
                        Patterns.SignatureCipher = ListaRegexTemp[3];
                        Patterns.FileURL = ListaRegexTemp[4];
                        Patterns.JsURL = ListaRegexTemp[5];
                        Patterns.JsFunctionPattern1 = ListaRegexTemp[6];
                        Patterns.JsFunctionPattern2 = ListaRegexTemp[7];
                        Patterns.JsFunctionPattern3 = ListaRegexTemp[8];
                        Patterns.YtInitialData = ListaRegexTemp[9];
                        Patterns.VideoRendererBlock = ListaRegexTemp[10];
                        Patterns.VideoName = ListaRegexTemp[11];
                        Patterns.VideoID = ListaRegexTemp[12];
                        Patterns.VideoViewCount = ListaRegexTemp[13];
                        Patterns.PlaylistRenderer = ListaRegexTemp[14];
                        Patterns.PlaylistName = ListaRegexTemp[15];
                        Patterns.PlaylistVideoCount = ListaRegexTemp[16];
                        Patterns.PlaylistID = ListaRegexTemp[17];
                        Patterns.YoutubeInitialResponse = ListaRegexTemp[18];
                    }
            }
            catch(Exception ex)
            {
                File.WriteAllText("error.log", ex.StackTrace);
            }
        }
        private void Player_PlayStateChange(int NewState)
        {
            switch((WMPPlayState)NewState)
            {
                case WMPPlayState.wmppsMediaEnded:
                    break;
                case WMPPlayState.wmppsStopped:
                    break;
            }
            Debug.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToShortTimeString(), Enum.GetName(typeof(WMPPlayState), Player.playState)));
        }

        public void ReproduzirMusica(string id)
        {
            string VideoToPlay = ExtratorYT.Decipher(id);//yt.Extract(id);
            if(VideoToPlay.Length > 0)
            {
                PlayFile(VideoToPlay);
                SetVisuals();
            }
        }

        private void SetVisuals()
        {
            int PosicaoDaGrade = grdPlayList.SelectedRows.Count > 0 ? grdPlayList.SelectedRows[0].Index : 0;
            string NomeDaMusica = (string)grdPlayList.SelectedRows[0].Cells["Nome"].Value;
            lblNomeDaMusica.Text = NomeDaMusica;
            lblNomeDaMusica.Left = ((ClientSize.Width + grdPlayList.Width) - lblNomeDaMusica.Width) / 2;
            var f = Application.OpenForms.OfType<frmNomeMusica>().ToList();
            if (f.Any())
            {
                f.First().setNome(lblNomeDaMusica.Text);
            }
            Text = $"Spobrify - Now Playing: {NomeDaMusica}";            
        }


        public void GetPlayList(string id, bool bAnnex = false)
        {
            if (!bAnnex)
            {
                grdPlayList.Rows.Clear();
            }

            List<Musica> PlaylistDoYoutube = ExtratorYT.GetPlayList(id);
            foreach(Musica MusicaDaPlaylist in PlaylistDoYoutube)
            {
                grdPlayList.Rows.Add(new object[] {MusicaDaPlaylist.Nome, MusicaDaPlaylist.ID, MusicaDaPlaylist.Thumb});
            }
            
        }

        public void AddToPlaylist(string Nome, string ID)
        {
            int MusicaAnterior = grdPlayList.Rows.Count > 0 ? grdPlayList.SelectedRows[0].Index : 0;
            grdPlayList.Rows.Add(new object[] { Nome, ID, "" });
            JumpToRow(MusicaAnterior);     
        }

        private void PlayFile(string url)
        {

           if(Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.pause();                
            }            
            brTempo.Value = 0;
            Player.URL = url;
            Player.controls.play();
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            Redimensionar();
        }

        private void Redimensionar()
        {

            grdPlayList.Top = 0;
            grdPlayList.Left = 0;
            grdPlayList.Width = Convert.ToInt32(ClientSize.Width * 0.45);
            grdPlayList.Height = ClientSize.Height;

            pnlHeader.Left = grdPlayList.Right;
            pnlHeader.Top = 0;


            pnlControles2.Top = ClientSize.Height - pnlControles2.Height;
            pnlControles2.Left = ((ClientSize.Width + grdPlayList.Right) - pnlControles2.Width) / 2;

            pnlControles.Top = ClientSize.Height - pnlControles2.Height - pnlControles.Height;
            pnlControles.Left = ((ClientSize.Width + grdPlayList.Right) - pnlControles.Width) / 2;

            brTempo.Top = ClientSize.Height - pnlControles2.Height - pnlControles.Height - brTempo.Height;
            brTempo.Left = ((ClientSize.Width + grdPlayList.Right) - brTempo.Width) / 2;

            lblZero.Left = brTempo.Left - (lblZero.Width + 15);
            lblTotal.Left = brTempo.Right + 15;
            lblZero.Top = brTempo.Top;
            lblTotal.Top = brTempo.Top;

            lblNomeDaMusica.Top = brTempo.Top - (lblNomeDaMusica.Height + 15);


        }

        private void JumpToRow(int rowNumber, bool shuffle = false)
        {
                rowNumber = shuffle ? GeradorNumeroRandom.Next(grdPlayList.RowCount-1) : rowNumber;
                grdPlayList.Rows[rowNumber].Selected = true;
                grdPlayList.Focus();   
        }

        private void JumpToRowAndPlay(int rowNumber, bool shuffle = false)
        {
                rowNumber = shuffle ? GeradorNumeroRandom.Next(grdPlayList.RowCount-1) : rowNumber;
                grdPlayList.Rows[rowNumber].Selected = true;
                grdPlayList.Focus();
                ReproduzirMusica((string)grdPlayList.SelectedRows[0].Cells[1].Value);

        }

        private void timerSeekbar_Tick(object sender, EventArgs e)
        {
            if(Player != null && Player.controls.currentItem != null && Player.controls.currentItem.duration > 0 && !SeekbarFoiClicado)
            {
                if((brTempo.Value + 1) < (int)Player.controls.currentItem.duration)
                {
                    brTempo.Maximum = (int)Player.controls.currentItem.duration;
                    brTempo.Value = (int)Player.controls.currentPosition;
                    TimeSpan atual = TimeSpan.FromSeconds(brTempo.Value);
                    TimeSpan total = TimeSpan.FromSeconds(Player.controls.currentItem.duration);
                    lblZero.Text = $"{atual.Minutes.ToString("00")}:{atual.Seconds.ToString("00")}";
                    lblTotal.Text = $"{total.Minutes.ToString("00")}:{total.Seconds.ToString("00")}";
                }
            }
        }

        private void brTempo_ValueChanged(object sender, decimal value)
        {
            bSeek = false;
        }

        private void brTempo_MouseClick(object sender, MouseEventArgs e)
        {
            bSeek = true;
            if(Player != null && Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.currentPosition = brTempo.Value;
            }
            else
            {
                brTempo.Value = 0;
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Player.PlayStateChange -= Player_PlayStateChange;
            Player.controls.stop();
            Application.Exit();
        }

        private void grdPlayList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ReproduzirMusica((string)grdPlayList.SelectedRows[0].Cells[1].Value);
        }

        private void btSalvarPlaylist_Click(object sender, EventArgs e)
        {
            SaveFileDialog DialogoSalvarPlaylist = new SaveFileDialog();
            DialogoSalvarPlaylist.Filter = "Spobrify playlist|*.pobre";
            DialogoSalvarPlaylist.Title = "Save playlist";
            DialogoSalvarPlaylist.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogoSalvarPlaylist.ShowDialog();
            if (DialogoSalvarPlaylist.FileName != "")
            {
                StringBuilder StringPlaylist = new StringBuilder();
                foreach (DataGridViewRow dgv in grdPlayList.Rows)
                {
                    StringPlaylist.AppendLine($"{dgv.Cells["ID"].Value}|_|{dgv.Cells["Nome"].Value}|_|{dgv.Cells["Thumb"].Value}");
                }
                File.WriteAllText(DialogoSalvarPlaylist.FileName,StringPlaylist.ToString());
            }
        }

        private void btCarregarPlaylist_Click(object sender, EventArgs e)
        {
            OpenFileDialog DialogoAbrirPlaylist = new OpenFileDialog();
            DialogoAbrirPlaylist.Filter = "Spobrify playlist|*.pobre";
            DialogoAbrirPlaylist.Title = "Open playlist";
            DialogoAbrirPlaylist.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            DialogoAbrirPlaylist.ShowDialog();
            if (DialogoAbrirPlaylist.FileName != "")
            {
                try
                {
                    string[] DadosPlaylistRaw = File.ReadAllLines(DialogoAbrirPlaylist.FileName);
                    foreach(string Faixa in DadosPlaylistRaw)
                    {
                        string[] DadosDaFaixa = Faixa.Split(new string[] { "|_|" }, StringSplitOptions.None);
                        grdPlayList.Rows.Add(new object[]{DadosDaFaixa[1], DadosDaFaixa[0], DadosDaFaixa[2]});
                    }
                    JumpToRow(0);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Spobrify", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btCimaPlaylist_Click(object sender, EventArgs e)
        {
            if(grdPlayList.SelectedRows.Count > 0 && grdPlayList.SelectedRows[0].Index > 0)
            {
                int PosicaoAtual = grdPlayList.SelectedRows[0].Index;
                DataGridViewRow RowSelecionada = grdPlayList.SelectedRows[0];
                grdPlayList.Rows.Remove(RowSelecionada);
                grdPlayList.Rows.Insert(PosicaoAtual - 1, RowSelecionada);
                JumpToRow(PosicaoAtual - 1);
            }
        }

        private void btBaixoPlaylist_Click(object sender, EventArgs e)
        {
            if (grdPlayList.SelectedRows.Count > 0 && grdPlayList.SelectedRows[0].Index < grdPlayList.RowCount - 1)
            {
                int PosicaoAtual = grdPlayList.SelectedRows[0].Index;

                DataGridViewRow RowSelecionada = grdPlayList.SelectedRows[0];
                grdPlayList.Rows.Remove(RowSelecionada);
                grdPlayList.Rows.Insert(PosicaoAtual + 1, RowSelecionada);
                JumpToRow(PosicaoAtual + 1);
            }

        }

        private void btRemoverDaLista_Click(object sender, EventArgs e)
        {
            if(grdPlayList.SelectedRows.Count > 0)
             {
                var PosicaoAtual = grdPlayList.SelectedRows[0].Index;
                grdPlayList.Rows.RemoveAt(PosicaoAtual);
             }
        }




        private void btJanelaStream_Click(object sender, EventArgs e)
        {
            var FrmJanelaStream = Application.OpenForms.OfType<frmNomeMusica>().ToList();
            if(FrmJanelaStream.Any())
            {

                FrmJanelaStream.First().WindowState = FormWindowState.Normal;
                FrmJanelaStream.First().BringToFront();
                FrmJanelaStream.First().setNome(lblNomeDaMusica.Text);
            }
            else
            {
                frmNomeMusica Form = new frmNomeMusica();
                Form.Show();
                Form.setNome(lblNomeDaMusica.Text);
            }
        }

        private void brVolume_ValueChanged(object sender, EventArgs e)
        {
            Player.settings.volume = brVolume.Value;
        }

        private void mediaControls_Click(object sender, EventArgs e)
        {
            if (Player == null)
                return;

            Button BotaoPressionado = (Button)sender;
            int FaixaAtual = grdPlayList.SelectedRows.Count > 0 ? grdPlayList.SelectedRows[0].Index : -1;
            bool EhUltimaFaixa = FaixaAtual >= grdPlayList.RowCount-1;
            bool EhPrimeiraFaixa = FaixaAtual == 0;
            switch (BotaoPressionado.Name)
            {
                case "btPrev":
                    if(!EhPrimeiraFaixa)
                    {
                        JumpToRowAndPlay(FaixaAtual - 1, cbShuffle.Checked);
                    }
                    break;
                case "btPlayPause":
                    if (Player.playState == WMPPlayState.wmppsPlaying)
                        Player.controls.pause();
                    else
                        Player.controls.play();
                    break;
                case "btNext":
                    if (!EhUltimaFaixa)
                    {
                        JumpToRowAndPlay(FaixaAtual + 1, cbShuffle.Checked);
                    }
                    break;
            }
        }

        private void timerNextSong_Tick(object sender, EventArgs e)
        {
            if(Player.playState == WMPPlayState.wmppsStopped)
            {
                int current_track = grdPlayList.SelectedRows.Count > 0 ? grdPlayList.SelectedRows[0].Index : -1;
                bool ultima = current_track >= grdPlayList.RowCount - 1;
                if(ultima)
                {
                    if(cbShuffle.Checked)
                    {
                        JumpToRowAndPlay(current_track, cbShuffle.Checked);
                    }
                }
                else
                {
                    JumpToRowAndPlay(current_track + 1, cbShuffle.Checked);
                }
            }
        }

        private void brTempo_MouseUp(object sender, MouseEventArgs e)
        {
            SeekbarFoiClicado = false;
        }

        private void brTempo_MouseDown(object sender, MouseEventArgs e)
        {
            SeekbarFoiClicado = true;
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            IEnumerable<FrmBuscaVideo> f = Application.OpenForms.OfType<FrmBuscaVideo>();
            if (f.Any())
            {
                f.First().WindowState = FormWindowState.Normal;
                f.First().BringToFront();
            }
            else
            {
                FrmBuscaVideo frm = new FrmBuscaVideo();
                frm.Show();
            }
        }
    }
}
