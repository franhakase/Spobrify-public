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

namespace Spobrify
{
    public partial class FrmMain : DefaultForm
    {
        private Youtoba yt;
        private Random r;
        private WindowsMediaPlayer Player;
        private List<Musica> MyPlaylist;
        private bool _tbClicked = false;
        bool bSeek;
        
        
        public FrmMain()
        {
            
            InitializeComponent();
            LoadRegex();
            redimensionar();
            MyPlaylist = new List<Musica>();
            lblNomeDaMusica.Text = "...";
            r = new Random();
            yt = new Youtoba();
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

        public void LoadRegex()
        {
            try
            {
                if (File.Exists("regex.txt"))
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Proxy = null;
                        File.WriteAllText("regex.txt", wc.DownloadString("https://raw.githubusercontent.com/DoctorFran/Spobrify-public/master/Spobrify/regex.txt"));
                    }
                    string[] _regex = File.ReadAllLines("regex.txt");
                    if (_regex.Length == 9)
                    {
                        Patterns.AdaptiveFormats1 = _regex[1];
                        Patterns.AdaptiveFormats2 = _regex[2];
                        Patterns.SignatureCipher = _regex[3];
                        Patterns.FileURL = _regex[4];
                        Patterns.JsURL = _regex[5];
                        Patterns.JsFunctionPattern1 = _regex[6];
                        Patterns.JsFunctionPattern2 = _regex[7];
                        Patterns.JsFunctionPattern3 = _regex[8];
                    }
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

        public void AttemptPlay(string id)
        {
            string VideoToPlay = yt.Extract(id);
            if(VideoToPlay.Length > 0)
            {
                PlayFile(VideoToPlay);
                SetVisuals();
            }
        }

        private void SetVisuals()
        {
            int selr = grdPlayList.SelectedRows.Count > 0 ? grdPlayList.SelectedRows[0].Index : 0;
            
            lblNomeDaMusica.Text = MyPlaylist[selr].Nome;
            lblNomeDaMusica.Left = ((ClientSize.Width + grdPlayList.Width) - lblNomeDaMusica.Width) / 2;
            var f = Application.OpenForms.OfType<frmNomeMusica>().ToList();
            if (f.Any())
            {
                f.First().setNome(lblNomeDaMusica.Text);
            }
            this.Text = $"Spobrify - Now Playing: {MyPlaylist[selr].Nome}";            
        }


        public void GetPlayList(string id, bool bAnnex = false)
        {
            if (!bAnnex)
            {
                MyPlaylist.Clear();
                MyPlaylist = yt.GetPlayList(id);
            }
            else
            {
                MyPlaylist.AddRange(yt.GetPlayList(id));
            }
            grdPlayList.DataSource = null;
            grdPlayList.DataSource = MyPlaylist;
            grdPlayList.Columns[1].Visible = false;
            grdPlayList.Columns[2].Visible = false;
            grdPlayList.Refresh();
            if (grdPlayList.Rows.Count > 0)
            {
                JumpToRow(0);
            }
        }

        public void AddToPlaylist(string Nome, string ID)
        {
            int voltar = 0;
            if(grdPlayList.Rows.Count > 0)
            {
                voltar = grdPlayList.SelectedRows[0].Index;
            }
            Musica m = new Musica(Nome, ID);
            MyPlaylist.Add(m);
            grdPlayList.DataSource = null;
            grdPlayList.DataSource = MyPlaylist;
            grdPlayList.Columns[1].Visible = false;
            grdPlayList.Columns[2].Visible = false;
            grdPlayList.Refresh();            
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
            redimensionar();
        }

        private void redimensionar()
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
                rowNumber = shuffle ? r.Next(grdPlayList.RowCount-1) : rowNumber;
                grdPlayList.Rows[rowNumber].Selected = true;
                grdPlayList.Focus();   
        }

        private void JumpToRowAndPlay(int rowNumber, bool shuffle = false)
        {
                rowNumber = shuffle ? r.Next(grdPlayList.RowCount-1) : rowNumber;
                grdPlayList.Rows[rowNumber].Selected = true;
                grdPlayList.Focus();
                AttemptPlay((string)grdPlayList.SelectedRows[0].Cells[1].Value);

        }

        private void timerSeekbar_Tick(object sender, EventArgs e)
        {
            if(Player != null && Player.controls.currentItem != null && Player.controls.currentItem.duration > 0 && !_tbClicked)
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
            AttemptPlay((string)grdPlayList.SelectedRows[0].Cells[1].Value);
        }

        private void btSalvarPlaylist_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Spobrify playlist|*.pobre";
            saveFileDialog1.Title = "Save playlist";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
               File.WriteAllText(saveFileDialog1.FileName,Metodos.Utils.PlaylistParaString(MyPlaylist));
            }
        }

        private void btCarregarPlaylist_Click(object sender, EventArgs e)
        {
            MyPlaylist = new List<Musica>();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Spobrify playlist|*.pobre";
            openFileDialog1.Title = "Open playlist";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                try
                {
                    string[] p_intemediate = File.ReadAllLines(openFileDialog1.FileName);
                    foreach(string s in p_intemediate)
                    {
                        string[] ss = s.Split(new string[] { "|_|" }, StringSplitOptions.None);
                        MyPlaylist.Add(new Musica(ss[1], ss[0], ss[2]));
                    }
                    grdPlayList.DataSource = null;
                    grdPlayList.DataSource = MyPlaylist;
                    grdPlayList.Columns[1].Visible = false;
                    grdPlayList.Columns[2].Visible = false;
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
                int guarda = grdPlayList.SelectedRows[0].Index;
                Musica item = MyPlaylist[grdPlayList.SelectedRows[0].Index];
                MyPlaylist.RemoveAt(grdPlayList.SelectedRows[0].Index);
                MyPlaylist.Insert(grdPlayList.SelectedRows[0].Index - 1, item);
                grdPlayList.DataSource = null;
                grdPlayList.DataSource = MyPlaylist;
                grdPlayList.Columns[1].Visible = false;
                grdPlayList.Columns[2].Visible = false;
                JumpToRow(guarda - 1);
            }
        }

        private void btBaixoPlaylist_Click(object sender, EventArgs e)
        {
            if (grdPlayList.SelectedRows.Count > 0 && grdPlayList.SelectedRows[0].Index < grdPlayList.RowCount - 1)
            {
                int guarda = grdPlayList.SelectedRows[0].Index;
                Musica item = MyPlaylist[grdPlayList.SelectedRows[0].Index];
                MyPlaylist.RemoveAt(grdPlayList.SelectedRows[0].Index);
                MyPlaylist.Insert(grdPlayList.SelectedRows[0].Index + 1, item);
                grdPlayList.DataSource = null;
                grdPlayList.DataSource = MyPlaylist;
                grdPlayList.Columns[1].Visible = false;
                grdPlayList.Columns[2].Visible = false;
                JumpToRow(guarda + 1);
            }

        }

        private void btRemoverDaLista_Click(object sender, EventArgs e)
        {
           if(grdPlayList.SelectedRows.Count > 0)
            {
                var guarda = grdPlayList.SelectedRows[0].Index;
                MyPlaylist.RemoveAt(guarda);
                grdPlayList.DataSource = null;
                grdPlayList.DataSource = MyPlaylist;
                grdPlayList.Columns[1].Visible = false;
                grdPlayList.Columns[2].Visible = false;
            }
        }

        private void btJanelaStream_Click(object sender, EventArgs e)
        {
            var f = Application.OpenForms.OfType<frmNomeMusica>().ToList();
            if(f.Any())
            {

                f.First().WindowState = FormWindowState.Normal;
                f.First().BringToFront();
                f.First().setNome(lblNomeDaMusica.Text);
            }
            else
            {
                frmNomeMusica frm = new frmNomeMusica();
                frm.Show();
                frm.setNome(lblNomeDaMusica.Text);
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

            Button b = (Button)sender;
            int current_track = grdPlayList.SelectedRows.Count > 0 ? grdPlayList.SelectedRows[0].Index : -1;
            bool ultima = current_track >= grdPlayList.RowCount-1;
            bool primeira = current_track == 0;
            switch (b.Name)
            {
                case "btPrev":
                    if(!primeira)
                    {
                        JumpToRowAndPlay(current_track - 1, cbShuffle.Checked);
                    }
                    break;
                case "btPlayPause":
                        if (Player.playState == WMPPlayState.wmppsPlaying)
                            Player.controls.pause();
                        else
                            Player.controls.play();
                    break;
                case "btNext":
                    if (!ultima)
                    {
                        JumpToRowAndPlay(current_track + 1, cbShuffle.Checked);
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
            _tbClicked = false;
        }

        private void brTempo_MouseDown(object sender, MouseEventArgs e)
        {
            _tbClicked = true;
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
