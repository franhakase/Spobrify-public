using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spobrify.Controles;
namespace Spobrify
{
    public partial class FrmNomeMusica : DefaultForm
    {
        private OutlineLabel label1;
        private TextInfo ti;
        public FrmNomeMusica()
        {
            InitializeComponent();
            label1 = new OutlineLabel();
            label1.AutoSize = true;
            label1.Font = new Font("Segoe ui", 30f);
            label1.ForeColor = Color.White;
            label1.OutlineForeColor = Color.Black;
            label1.OutlineWidth = 3;
            this.Controls.Add(label1);
           // label1.Top = Height + label1.Height;
            ti = new CultureInfo("en-US", false).TextInfo;
        }

        public void setNome(string nome)
        {
            label1.Text = ti.ToTitleCase($"♬ {nome}".ToLower());
            Width = label1.Width + 25;
        }
    }
}
