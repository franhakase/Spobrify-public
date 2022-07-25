namespace Spobrify
{
    partial class FrmBuscaVideo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlResults = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlBarraBusca = new System.Windows.Forms.FlowLayoutPanel();
            this.txtBusca = new System.Windows.Forms.TextBox();
            this.cmbTipoPesquisa = new System.Windows.Forms.ComboBox();
            this.btBuscar = new System.Windows.Forms.Button();
            this.pnlBarraBusca.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlResults
            // 
            this.pnlResults.AutoScroll = true;
            this.pnlResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlResults.Location = new System.Drawing.Point(0, 45);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(788, 393);
            this.pnlResults.TabIndex = 0;
            // 
            // pnlBarraBusca
            // 
            this.pnlBarraBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.pnlBarraBusca.Controls.Add(this.txtBusca);
            this.pnlBarraBusca.Controls.Add(this.cmbTipoPesquisa);
            this.pnlBarraBusca.Controls.Add(this.btBuscar);
            this.pnlBarraBusca.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraBusca.Location = new System.Drawing.Point(0, 0);
            this.pnlBarraBusca.Name = "pnlBarraBusca";
            this.pnlBarraBusca.Padding = new System.Windows.Forms.Padding(3);
            this.pnlBarraBusca.Size = new System.Drawing.Size(800, 39);
            this.pnlBarraBusca.TabIndex = 1;
            // 
            // txtBusca
            // 
            this.txtBusca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBusca.Location = new System.Drawing.Point(6, 6);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(520, 29);
            this.txtBusca.TabIndex = 1;
            // 
            // cmbTipoPesquisa
            // 
            this.cmbTipoPesquisa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPesquisa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTipoPesquisa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTipoPesquisa.FormattingEnabled = true;
            this.cmbTipoPesquisa.Location = new System.Drawing.Point(532, 6);
            this.cmbTipoPesquisa.Name = "cmbTipoPesquisa";
            this.cmbTipoPesquisa.Size = new System.Drawing.Size(145, 29);
            this.cmbTipoPesquisa.TabIndex = 2;
            // 
            // btBuscar
            // 
            this.btBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(215)))), ((int)(((byte)(96)))));
            this.btBuscar.Location = new System.Drawing.Point(683, 6);
            this.btBuscar.Name = "btBuscar";
            this.btBuscar.Size = new System.Drawing.Size(105, 29);
            this.btBuscar.TabIndex = 3;
            this.btBuscar.Text = "Go";
            this.btBuscar.UseVisualStyleBackColor = true;
            this.btBuscar.Click += new System.EventHandler(this.btBuscar_Click);
            // 
            // FrmBuscaVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBarraBusca);
            this.Controls.Add(this.pnlResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmBuscaVideo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmBuscaVideo_FormClosed);
            this.Resize += new System.EventHandler(this.FrmBuscaVideo_Resize);
            this.pnlBarraBusca.ResumeLayout(false);
            this.pnlBarraBusca.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlResults;
        private System.Windows.Forms.FlowLayoutPanel pnlBarraBusca;
        private System.Windows.Forms.TextBox txtBusca;
        private System.Windows.Forms.Button btBuscar;
        private System.Windows.Forms.ComboBox cmbTipoPesquisa;
    }
}