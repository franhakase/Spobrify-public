using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Spobrify.Controles
{
    class lblPlaylist : Label
    {
        public string id { get; set; } = "";
        public int type { get; set; } = 0; //0:video, 1:playlist
        public string caption { get; set; } = "";
        public lblPlaylist(string id, int type, string caption)
        {
            ContextMenu cm = new ContextMenu();
            switch(type)
            {
                case 0:
                    cm.MenuItems.Add("Add to queue and play", new EventHandler(bVideo_Play));
                    cm.MenuItems.Add("Add to queue", new EventHandler(bVideo_Add));

                    break;
                case 1:
                    cm.MenuItems.Add("Load playlist", new EventHandler(bList_Add));
                    cm.MenuItems.Add("Add playlist to queue", new EventHandler(bList_Annex));
                    break;
            }
            ContextMenu = cm;
            //Font = new Font("Segoe UI", 8f, FontStyle.Regular);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(2, 2, 2, 2);
            Padding = new Padding(2, 2, 2, 2);
            this.caption = caption;
            this.id = id;
            this.type = type;
            Text = this.caption;
            Click += _bclick;
            MouseUp += LblPlaylist_MouseUp;
            MouseDown += LblPlaylist_MouseDown;
        }

        private void LblPlaylist_MouseDown(object sender, MouseEventArgs e)
        {
            ForeColor = Color.FromArgb(0, 131, 255);
        }

        private void LblPlaylist_MouseUp(object sender, MouseEventArgs e)
        {
            ForeColor = Color.WhiteSmoke;
        }

        private void _bclick(object sender, EventArgs e)
        {
            ContextMenu.Show(this, PointToClient(Cursor.Position));
        }

        private void bVideo_Play(object sender, EventArgs e)
        {
            string _artist = this.caption;
            IEnumerable<FrmMain> f = Application.OpenForms.OfType<FrmMain>();
            if (f.Any())
                f.First().AddToPlaylist(_artist, id);
                f.First().ReproduzirMusica(id);

        }

        private void bVideo_Add(object sender, EventArgs e)
        {
            string _artist = this.caption;
            IEnumerable<FrmMain> f = Application.OpenForms.OfType<FrmMain>();
            if (f.Any())
                f.First().AddToPlaylist(_artist, id);
        }

        private void bList_Add(object sender, EventArgs e)
        {
            IEnumerable<FrmMain> f = Application.OpenForms.OfType<FrmMain>();
            if (f.Any())
                f.First().GetPlayList(this.id);
        }

        private void bList_Annex(object sender, EventArgs e)
        {
            IEnumerable<FrmMain> f = Application.OpenForms.OfType<FrmMain>();
            if (f.Any())
                f.First().GetPlayList(this.id, true);
        }
    }
}
