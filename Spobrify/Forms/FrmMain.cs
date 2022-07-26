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
        private int IndiceDaMusicaAtual = 0;
        
        
        
        public FrmMain()
        {
            
            InitializeComponent();

            CarregarRegexes();

            Redimensionar();
            LabelNomeDaFaixaAtual.Text = "...";
            GeradorNumeroRandom = new Random();
            Player = new WindowsMediaPlayer();
            Player.PlayStateChange += Player_PlayStateChange;
            ToolTip tt = new ToolTip();
            tt.SetToolTip(BotaoPesquisarFaixa, "Add song (Search)");
            tt.SetToolTip(BotaoDescerFaixaSelecionada, "Mover song down");
            tt.SetToolTip(BotaoSubirFaixaSelecionada, "Move song up");
            tt.SetToolTip(BotaoRemoverFaixaSelecionada, "Remove from list");
            tt.SetToolTip(BotaoSalvarPlaylist, "Save playlist to file");
            tt.SetToolTip(BotaoCarregarPlaylist, "Load playlist from file");
            tt.SetToolTip(BotaoAbrirJanelaOverlayStream, "Open live streaming overlay window");
            tt.SetToolTip(LabelVolume, "Volume");
            tt.SetToolTip(TrackBarVolume, "Volume");
            tt.SetToolTip(CheckBoxShuffle, "Shuffle");
            tt.SetToolTip(BotaoPlayPause, "Play/Pause");
            tt.SetToolTip(BotaoFaixaAnterior, "Previous");
            tt.SetToolTip(BotaoProximaFaixa, "Next");

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
            int PosicaoDaGrade = GradePlaylist.SelectedRows.Count > 0 ? GradePlaylist.SelectedRows[0].Index : 0;
            string NomeDaMusica = (string)GradePlaylist.SelectedRows[0].Cells["Nome"].Value;
            LabelNomeDaFaixaAtual.Text = NomeDaMusica;
            LabelNomeDaFaixaAtual.Left = ((ClientSize.Width + GradePlaylist.Width) - LabelNomeDaFaixaAtual.Width) / 2;
            var f = Application.OpenForms.OfType<FrmNomeMusica>().ToList();
            if (f.Any())
            {
                f.First().setNome(LabelNomeDaFaixaAtual.Text);
            }
            Text = $"Spobrify - Now Playing: {NomeDaMusica}";            
        }


        public void GetPlayList(string id, bool bAnnex = false)
        {
            if (!bAnnex)
            {
                GradePlaylist.Rows.Clear();
            }

            List<Musica> PlaylistDoYoutube = ExtratorYT.GetPlayList(id);
            foreach(Musica MusicaDaPlaylist in PlaylistDoYoutube)
            {
                GradePlaylist.Rows.Add(new object[] {MusicaDaPlaylist.Nome, MusicaDaPlaylist.ID, MusicaDaPlaylist.Thumb});
            }
            
        }

        public void AddToPlaylist(string Nome, string ID)
        {
            int MusicaAnterior = GradePlaylist.Rows.Count > 0 ? GradePlaylist.SelectedRows[0].Index : 0;
            GradePlaylist.Rows.Add(new object[] { Nome, ID, "" });
            JumpToRow(MusicaAnterior);     
        }

        private void PlayFile(string url)
        {

           if(Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.pause();                
            }            
            TrackBarTempoFaixaAtual.Value = 0;
            Player.URL = url;
            Player.controls.play();
        }



        private void Form1_Resize(object sender, EventArgs e)
        {
            Redimensionar();
        }

        private void Redimensionar()
        {

            GradePlaylist.Top = 0;
            GradePlaylist.Left = 0;
            GradePlaylist.Width = Convert.ToInt32(ClientSize.Width * 0.45);
            GradePlaylist.Height = ClientSize.Height;

            PanelBotoesCabecalho.Left = GradePlaylist.Right;
            PanelBotoesCabecalho.Top = 0;


            pnlControles2.Top = ClientSize.Height - pnlControles2.Height;
            pnlControles2.Left = ((ClientSize.Width + GradePlaylist.Right) - pnlControles2.Width) / 2;

            PanelControlesDeMidia.Top = ClientSize.Height - pnlControles2.Height - PanelControlesDeMidia.Height;
            PanelControlesDeMidia.Left = ((ClientSize.Width + GradePlaylist.Right) - PanelControlesDeMidia.Width) / 2;

            TrackBarTempoFaixaAtual.Top = ClientSize.Height - pnlControles2.Height - PanelControlesDeMidia.Height - TrackBarTempoFaixaAtual.Height;
            TrackBarTempoFaixaAtual.Left = ((ClientSize.Width + GradePlaylist.Right) - TrackBarTempoFaixaAtual.Width) / 2;

            LabelPosicaoZeroFaixaAtual.Left = TrackBarTempoFaixaAtual.Left - (LabelPosicaoZeroFaixaAtual.Width + 15);
            LabelTempoTotalFaixaAtual.Left = TrackBarTempoFaixaAtual.Right + 15;
            LabelPosicaoZeroFaixaAtual.Top = TrackBarTempoFaixaAtual.Top;
            LabelTempoTotalFaixaAtual.Top = TrackBarTempoFaixaAtual.Top;

            LabelNomeDaFaixaAtual.Top = TrackBarTempoFaixaAtual.Top - (LabelNomeDaFaixaAtual.Height + 15);


        }

        private void JumpToRow(int rowNumber, bool shuffle = false)
        {
                rowNumber = shuffle ? GeradorNumeroRandom.Next(GradePlaylist.RowCount-1) : rowNumber;
                GradePlaylist.Rows[rowNumber].Selected = true;
                GradePlaylist.Focus();   
        }

        private void JumpToRowAndPlay(int rowNumber, bool shuffle = false)
        {
            rowNumber = shuffle ? GeradorNumeroRandom.Next(GradePlaylist.RowCount-1) : rowNumber;
            GradePlaylist.Rows[rowNumber].Selected = true;
            GradePlaylist.Focus();
            IndiceDaMusicaAtual = rowNumber;
            ReproduzirMusica((string)GradePlaylist.SelectedRows[0].Cells[1].Value);
        }

        private void timerSeekbar_Tick(object sender, EventArgs e)
        {
            if(Player != null && Player.controls.currentItem != null && Player.controls.currentItem.duration > 0 && !SeekbarFoiClicado)
            {
                if((TrackBarTempoFaixaAtual.Value + 1) < (int)Player.controls.currentItem.duration)
                {
                    TrackBarTempoFaixaAtual.Maximum = (int)Player.controls.currentItem.duration;
                    TrackBarTempoFaixaAtual.Value = (int)Player.controls.currentPosition;
                    TimeSpan atual = TimeSpan.FromSeconds(TrackBarTempoFaixaAtual.Value);
                    TimeSpan total = TimeSpan.FromSeconds(Player.controls.currentItem.duration);
                    LabelPosicaoZeroFaixaAtual.Text = $"{atual.Minutes.ToString("00")}:{atual.Seconds.ToString("00")}";
                    LabelTempoTotalFaixaAtual.Text = $"{total.Minutes.ToString("00")}:{total.Seconds.ToString("00")}";
                }
            }
        }

        private void brTempo_ValueChanged(object sender, decimal value)
        {
            SeekbarFoiClicado = false;
        }

        private void brTempo_MouseClick(object sender, MouseEventArgs e)
        {
            SeekbarFoiClicado = true;
            if(Player != null && Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.currentPosition = TrackBarTempoFaixaAtual.Value;
            }
            else
            {
                TrackBarTempoFaixaAtual.Value = 0;
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
            if(GradePlaylist.SelectedRows.Count > 0)
            {
                IndiceDaMusicaAtual = GradePlaylist.SelectedRows[0].Index;
                ReproduzirMusica((string)GradePlaylist.SelectedRows[0].Cells[1].Value);
            }            
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
                foreach (DataGridViewRow dgv in GradePlaylist.Rows)
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
                        GradePlaylist.Rows.Add(new object[]{DadosDaFaixa[1], DadosDaFaixa[0], DadosDaFaixa[2]});
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
            if(GradePlaylist.SelectedRows.Count > 0 && GradePlaylist.SelectedRows[0].Index > 0)
            {
                int PosicaoAtual = GradePlaylist.SelectedRows[0].Index;
                DataGridViewRow RowSelecionada = GradePlaylist.SelectedRows[0];
                GradePlaylist.Rows.Remove(RowSelecionada);
                GradePlaylist.Rows.Insert(PosicaoAtual - 1, RowSelecionada);
                JumpToRow(PosicaoAtual - 1);
            }
        }

        private void btBaixoPlaylist_Click(object sender, EventArgs e)
        {
            if (GradePlaylist.SelectedRows.Count > 0 && GradePlaylist.SelectedRows[0].Index < GradePlaylist.RowCount - 1)
            {
                int PosicaoAtual = GradePlaylist.SelectedRows[0].Index;

                DataGridViewRow RowSelecionada = GradePlaylist.SelectedRows[0];
                GradePlaylist.Rows.Remove(RowSelecionada);
                GradePlaylist.Rows.Insert(PosicaoAtual + 1, RowSelecionada);
                JumpToRow(PosicaoAtual + 1);
            }

        }

        private void btRemoverDaLista_Click(object sender, EventArgs e)
        {
            if(GradePlaylist.SelectedRows.Count > 0)
             {
                var PosicaoAtual = GradePlaylist.SelectedRows[0].Index;
                GradePlaylist.Rows.RemoveAt(PosicaoAtual);
             }
        }




        private void btJanelaStream_Click(object sender, EventArgs e)
        {
            var FrmJanelaStream = Application.OpenForms.OfType<FrmNomeMusica>().ToList();
            if(FrmJanelaStream.Any())
            {

                FrmJanelaStream.First().WindowState = FormWindowState.Normal;
                FrmJanelaStream.First().BringToFront();
                FrmJanelaStream.First().setNome(LabelNomeDaFaixaAtual.Text);
            }
            else
            {
                FrmNomeMusica Form = new FrmNomeMusica();
                Form.Show();
                Form.setNome(LabelNomeDaFaixaAtual.Text);
            }
        }

        private void brVolume_ValueChanged(object sender, EventArgs e)
        {
            Player.settings.volume = TrackBarVolume.Value;
        }

        private void mediaControls_Click(object sender, EventArgs e)
        {
            if (Player == null)
                return;

            Button BotaoPressionado = (Button)sender;
            bool EhUltimaFaixa = IndiceDaMusicaAtual >= GradePlaylist.RowCount-1;
            bool EhPrimeiraFaixa = IndiceDaMusicaAtual == 0;
            switch (BotaoPressionado.Name)
            {
                case "BotaoFaixaAnterior":
                    if(!EhPrimeiraFaixa)
                    {
                        IndiceDaMusicaAtual--;
                        JumpToRowAndPlay(IndiceDaMusicaAtual, CheckBoxShuffle.Checked);
                    }
                    break;
                case "BotaoPlayPause":
                    if (Player.playState == WMPPlayState.wmppsPlaying)
                        Player.controls.pause();
                    else
                        Player.controls.play();
                    break;
                case "BotaoProximaFaixa":
                    if (!EhUltimaFaixa)
                    {
                        IndiceDaMusicaAtual++;
                        JumpToRowAndPlay(IndiceDaMusicaAtual, CheckBoxShuffle.Checked);
                    }
                    break;
            }
        }

        private void timerNextSong_Tick(object sender, EventArgs e)
        {
            if(Player.playState == WMPPlayState.wmppsStopped)
            {
                bool EhUltimaFaixa = IndiceDaMusicaAtual >= GradePlaylist.RowCount - 1;
                if(EhUltimaFaixa)
                {
                    if(CheckBoxShuffle.Checked)
                    {
                        JumpToRowAndPlay(IndiceDaMusicaAtual, CheckBoxShuffle.Checked);
                    }
                }
                else
                {
                    IndiceDaMusicaAtual++;
                    JumpToRowAndPlay(IndiceDaMusicaAtual, CheckBoxShuffle.Checked);
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
