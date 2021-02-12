namespace Spobrify
{
    partial class FrmMain
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNomeDaMusica = new System.Windows.Forms.Label();
            this.btPrev = new System.Windows.Forms.Button();
            this.btPlayPause = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.cbShuffle = new System.Windows.Forms.CheckBox();
            this.grdPlayList = new System.Windows.Forms.DataGridView();
            this.brVolume = new System.Windows.Forms.TrackBar();
            this.brTempo = new System.Windows.Forms.TrackBar();
            this.timerSeekbar = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader = new System.Windows.Forms.FlowLayoutPanel();
            this.btPesquisar = new System.Windows.Forms.Button();
            this.btCarregarPlaylist = new System.Windows.Forms.Button();
            this.btSalvarPlaylist = new System.Windows.Forms.Button();
            this.btCimaLista = new System.Windows.Forms.Button();
            this.btBaixoLista = new System.Windows.Forms.Button();
            this.btRemoverDaLista = new System.Windows.Forms.Button();
            this.btJanelaStream = new System.Windows.Forms.Button();
            this.lblZero = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.pnlControles = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlControles2 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblVolume = new System.Windows.Forms.Label();
            this.timerNextSong = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brTempo)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlControles.SuspendLayout();
            this.pnlControles2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNomeDaMusica
            // 
            this.lblNomeDaMusica.AutoSize = true;
            this.lblNomeDaMusica.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeDaMusica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.lblNomeDaMusica.Location = new System.Drawing.Point(483, 141);
            this.lblNomeDaMusica.Name = "lblNomeDaMusica";
            this.lblNomeDaMusica.Size = new System.Drawing.Size(143, 21);
            this.lblNomeDaMusica.TabIndex = 0;
            this.lblNomeDaMusica.Text = "lblNomeDaMusica";
            // 
            // btPrev
            // 
            this.btPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btPrev.FlatAppearance.BorderSize = 2;
            this.btPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPrev.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btPrev.Location = new System.Drawing.Point(3, 3);
            this.btPrev.Name = "btPrev";
            this.btPrev.Size = new System.Drawing.Size(75, 44);
            this.btPrev.TabIndex = 1;
            this.btPrev.Text = "⏪";
            this.btPrev.UseVisualStyleBackColor = false;
            this.btPrev.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // btPlayPause
            // 
            this.btPlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btPlayPause.FlatAppearance.BorderSize = 2;
            this.btPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPlayPause.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlayPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btPlayPause.Location = new System.Drawing.Point(84, 3);
            this.btPlayPause.Name = "btPlayPause";
            this.btPlayPause.Size = new System.Drawing.Size(75, 44);
            this.btPlayPause.TabIndex = 2;
            this.btPlayPause.Text = "▶️||";
            this.btPlayPause.UseVisualStyleBackColor = false;
            this.btPlayPause.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.btNext.FlatAppearance.BorderSize = 2;
            this.btNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btNext.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNext.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btNext.Location = new System.Drawing.Point(165, 3);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 44);
            this.btNext.TabIndex = 3;
            this.btNext.Text = "⏩";
            this.btNext.UseVisualStyleBackColor = false;
            this.btNext.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // cbShuffle
            // 
            this.cbShuffle.AutoSize = true;
            this.cbShuffle.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbShuffle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.cbShuffle.Location = new System.Drawing.Point(192, 3);
            this.cbShuffle.Name = "cbShuffle";
            this.cbShuffle.Size = new System.Drawing.Size(51, 25);
            this.cbShuffle.TabIndex = 4;
            this.cbShuffle.Text = "🔀";
            this.cbShuffle.UseVisualStyleBackColor = true;
            // 
            // grdPlayList
            // 
            this.grdPlayList.AllowUserToResizeColumns = false;
            this.grdPlayList.AllowUserToResizeRows = false;
            this.grdPlayList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdPlayList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.grdPlayList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdPlayList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.grdPlayList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPlayList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdPlayList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPlayList.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPlayList.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdPlayList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdPlayList.Location = new System.Drawing.Point(0, 8);
            this.grdPlayList.MultiSelect = false;
            this.grdPlayList.Name = "grdPlayList";
            this.grdPlayList.ReadOnly = true;
            this.grdPlayList.RowHeadersVisible = false;
            this.grdPlayList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPlayList.Size = new System.Drawing.Size(161, 150);
            this.grdPlayList.TabIndex = 6;
            this.grdPlayList.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayList_CellMouseDoubleClick);
            // 
            // brVolume
            // 
            this.brVolume.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brVolume.Location = new System.Drawing.Point(45, 3);
            this.brVolume.Maximum = 100;
            this.brVolume.Name = "brVolume";
            this.brVolume.Size = new System.Drawing.Size(141, 45);
            this.brVolume.TabIndex = 9;
            this.brVolume.TabStop = false;
            this.brVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brVolume.Value = 65;
            this.brVolume.ValueChanged += new System.EventHandler(this.brVolume_ValueChanged);
            // 
            // brTempo
            // 
            this.brTempo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.brTempo.Location = new System.Drawing.Point(219, 141);
            this.brTempo.Maximum = 100;
            this.brTempo.Name = "brTempo";
            this.brTempo.Size = new System.Drawing.Size(256, 45);
            this.brTempo.TabIndex = 11;
            this.brTempo.TabStop = false;
            this.brTempo.TickStyle = System.Windows.Forms.TickStyle.None;
            this.brTempo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseClick);
            this.brTempo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseDown);
            this.brTempo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseUp);
            // 
            // timerSeekbar
            // 
            this.timerSeekbar.Enabled = true;
            this.timerSeekbar.Interval = 1016;
            this.timerSeekbar.Tick += new System.EventHandler(this.timerSeekbar_Tick);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.pnlHeader.Controls.Add(this.btPesquisar);
            this.pnlHeader.Controls.Add(this.btCarregarPlaylist);
            this.pnlHeader.Controls.Add(this.btSalvarPlaylist);
            this.pnlHeader.Controls.Add(this.btCimaLista);
            this.pnlHeader.Controls.Add(this.btBaixoLista);
            this.pnlHeader.Controls.Add(this.btRemoverDaLista);
            this.pnlHeader.Controls.Add(this.btJanelaStream);
            this.pnlHeader.Location = new System.Drawing.Point(208, 80);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(381, 55);
            this.pnlHeader.TabIndex = 12;
            // 
            // btPesquisar
            // 
            this.btPesquisar.BackColor = System.Drawing.Color.Transparent;
            this.btPesquisar.FlatAppearance.BorderSize = 2;
            this.btPesquisar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btPesquisar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btPesquisar.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPesquisar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btPesquisar.Location = new System.Drawing.Point(3, 3);
            this.btPesquisar.Name = "btPesquisar";
            this.btPesquisar.Size = new System.Drawing.Size(48, 48);
            this.btPesquisar.TabIndex = 5;
            this.btPesquisar.Text = "🎵";
            this.btPesquisar.UseVisualStyleBackColor = false;
            this.btPesquisar.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // btCarregarPlaylist
            // 
            this.btCarregarPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.btCarregarPlaylist.FlatAppearance.BorderSize = 2;
            this.btCarregarPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btCarregarPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btCarregarPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCarregarPlaylist.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCarregarPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btCarregarPlaylist.Location = new System.Drawing.Point(57, 3);
            this.btCarregarPlaylist.Name = "btCarregarPlaylist";
            this.btCarregarPlaylist.Size = new System.Drawing.Size(48, 48);
            this.btCarregarPlaylist.TabIndex = 9;
            this.btCarregarPlaylist.Text = "📂";
            this.btCarregarPlaylist.UseVisualStyleBackColor = false;
            this.btCarregarPlaylist.Click += new System.EventHandler(this.btCarregarPlaylist_Click);
            // 
            // btSalvarPlaylist
            // 
            this.btSalvarPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.btSalvarPlaylist.FlatAppearance.BorderSize = 2;
            this.btSalvarPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btSalvarPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btSalvarPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btSalvarPlaylist.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvarPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btSalvarPlaylist.Location = new System.Drawing.Point(111, 3);
            this.btSalvarPlaylist.Name = "btSalvarPlaylist";
            this.btSalvarPlaylist.Size = new System.Drawing.Size(48, 48);
            this.btSalvarPlaylist.TabIndex = 8;
            this.btSalvarPlaylist.Text = "💾";
            this.btSalvarPlaylist.UseVisualStyleBackColor = false;
            this.btSalvarPlaylist.Click += new System.EventHandler(this.btSalvarPlaylist_Click);
            // 
            // btCimaLista
            // 
            this.btCimaLista.BackColor = System.Drawing.Color.Transparent;
            this.btCimaLista.FlatAppearance.BorderSize = 2;
            this.btCimaLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btCimaLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btCimaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btCimaLista.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btCimaLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btCimaLista.Location = new System.Drawing.Point(165, 3);
            this.btCimaLista.Name = "btCimaLista";
            this.btCimaLista.Size = new System.Drawing.Size(48, 48);
            this.btCimaLista.TabIndex = 10;
            this.btCimaLista.Text = "↑";
            this.btCimaLista.UseVisualStyleBackColor = false;
            this.btCimaLista.Click += new System.EventHandler(this.btCimaPlaylist_Click);
            // 
            // btBaixoLista
            // 
            this.btBaixoLista.BackColor = System.Drawing.Color.Transparent;
            this.btBaixoLista.FlatAppearance.BorderSize = 2;
            this.btBaixoLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btBaixoLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btBaixoLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btBaixoLista.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btBaixoLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btBaixoLista.Location = new System.Drawing.Point(219, 3);
            this.btBaixoLista.Name = "btBaixoLista";
            this.btBaixoLista.Size = new System.Drawing.Size(48, 48);
            this.btBaixoLista.TabIndex = 6;
            this.btBaixoLista.Text = "↓";
            this.btBaixoLista.UseVisualStyleBackColor = false;
            this.btBaixoLista.Click += new System.EventHandler(this.btBaixoPlaylist_Click);
            // 
            // btRemoverDaLista
            // 
            this.btRemoverDaLista.BackColor = System.Drawing.Color.Transparent;
            this.btRemoverDaLista.FlatAppearance.BorderSize = 2;
            this.btRemoverDaLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btRemoverDaLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btRemoverDaLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btRemoverDaLista.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoverDaLista.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btRemoverDaLista.Location = new System.Drawing.Point(273, 3);
            this.btRemoverDaLista.Name = "btRemoverDaLista";
            this.btRemoverDaLista.Size = new System.Drawing.Size(48, 48);
            this.btRemoverDaLista.TabIndex = 7;
            this.btRemoverDaLista.Text = "X";
            this.btRemoverDaLista.UseVisualStyleBackColor = false;
            this.btRemoverDaLista.Click += new System.EventHandler(this.btRemoverDaLista_Click);
            // 
            // btJanelaStream
            // 
            this.btJanelaStream.BackColor = System.Drawing.Color.Transparent;
            this.btJanelaStream.FlatAppearance.BorderSize = 2;
            this.btJanelaStream.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.btJanelaStream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btJanelaStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btJanelaStream.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJanelaStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.btJanelaStream.Location = new System.Drawing.Point(327, 3);
            this.btJanelaStream.Name = "btJanelaStream";
            this.btJanelaStream.Size = new System.Drawing.Size(48, 48);
            this.btJanelaStream.TabIndex = 11;
            this.btJanelaStream.Text = "📶";
            this.btJanelaStream.UseVisualStyleBackColor = false;
            this.btJanelaStream.Click += new System.EventHandler(this.btJanelaStream_Click);
            // 
            // lblZero
            // 
            this.lblZero.AutoSize = true;
            this.lblZero.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZero.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.lblZero.Location = new System.Drawing.Point(632, 117);
            this.lblZero.Name = "lblZero";
            this.lblZero.Size = new System.Drawing.Size(31, 17);
            this.lblZero.TabIndex = 13;
            this.lblZero.Text = "--:--";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.lblTotal.Location = new System.Drawing.Point(632, 141);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(31, 17);
            this.lblTotal.TabIndex = 14;
            this.lblTotal.Text = "--:--";
            // 
            // pnlControles
            // 
            this.pnlControles.Controls.Add(this.btPrev);
            this.pnlControles.Controls.Add(this.btPlayPause);
            this.pnlControles.Controls.Add(this.btNext);
            this.pnlControles.Location = new System.Drawing.Point(236, 24);
            this.pnlControles.Name = "pnlControles";
            this.pnlControles.Size = new System.Drawing.Size(247, 50);
            this.pnlControles.TabIndex = 15;
            // 
            // pnlControles2
            // 
            this.pnlControles2.Controls.Add(this.lblVolume);
            this.pnlControles2.Controls.Add(this.brVolume);
            this.pnlControles2.Controls.Add(this.cbShuffle);
            this.pnlControles2.Location = new System.Drawing.Point(211, 173);
            this.pnlControles2.Name = "pnlControles2";
            this.pnlControles2.Size = new System.Drawing.Size(246, 30);
            this.pnlControles2.TabIndex = 16;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.lblVolume.Location = new System.Drawing.Point(3, 0);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Padding = new System.Windows.Forms.Padding(2);
            this.lblVolume.Size = new System.Drawing.Size(36, 25);
            this.lblVolume.TabIndex = 0;
            this.lblVolume.Text = "🔊";
            // 
            // timerNextSong
            // 
            this.timerNextSong.Enabled = true;
            this.timerNextSong.Interval = 64;
            this.timerNextSong.Tick += new System.EventHandler(this.timerNextSong_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.ClientSize = new System.Drawing.Size(704, 441);
            this.Controls.Add(this.pnlControles2);
            this.Controls.Add(this.pnlControles);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblZero);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.brTempo);
            this.Controls.Add(this.grdPlayList);
            this.Controls.Add(this.lblNomeDaMusica);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Spobrify";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.grdPlayList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brTempo)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlControles.ResumeLayout(false);
            this.pnlControles2.ResumeLayout(false);
            this.pnlControles2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNomeDaMusica;
        private System.Windows.Forms.Button btPrev;
        private System.Windows.Forms.Button btPlayPause;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.CheckBox cbShuffle;
        private System.Windows.Forms.DataGridView grdPlayList;
        private System.Windows.Forms.TrackBar brVolume;
        private System.Windows.Forms.TrackBar brTempo;
        private System.Windows.Forms.Timer timerSeekbar;
        private System.Windows.Forms.FlowLayoutPanel pnlHeader;
        private System.Windows.Forms.Button btPesquisar;
        private System.Windows.Forms.Label lblZero;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btBaixoLista;
        private System.Windows.Forms.Button btRemoverDaLista;
        private System.Windows.Forms.Button btSalvarPlaylist;
        private System.Windows.Forms.Button btCarregarPlaylist;
        private System.Windows.Forms.Button btCimaLista;
        private System.Windows.Forms.Button btJanelaStream;
        private System.Windows.Forms.FlowLayoutPanel pnlControles;
        private System.Windows.Forms.FlowLayoutPanel pnlControles2;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Timer timerNextSong;
    }
}

