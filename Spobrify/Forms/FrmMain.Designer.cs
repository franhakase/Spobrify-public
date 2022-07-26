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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.LabelNomeDaFaixaAtual = new System.Windows.Forms.Label();
            this.BotaoFaixaAnterior = new System.Windows.Forms.Button();
            this.BotaoPlayPause = new System.Windows.Forms.Button();
            this.BotaoProximaFaixa = new System.Windows.Forms.Button();
            this.CheckBoxShuffle = new System.Windows.Forms.CheckBox();
            this.GradePlaylist = new System.Windows.Forms.DataGridView();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thumb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackBarVolume = new System.Windows.Forms.TrackBar();
            this.TrackBarTempoFaixaAtual = new System.Windows.Forms.TrackBar();
            this.timerSeekbar = new System.Windows.Forms.Timer(this.components);
            this.PanelBotoesCabecalho = new System.Windows.Forms.FlowLayoutPanel();
            this.BotaoPesquisarFaixa = new System.Windows.Forms.Button();
            this.BotaoCarregarPlaylist = new System.Windows.Forms.Button();
            this.BotaoSalvarPlaylist = new System.Windows.Forms.Button();
            this.BotaoSubirFaixaSelecionada = new System.Windows.Forms.Button();
            this.BotaoDescerFaixaSelecionada = new System.Windows.Forms.Button();
            this.BotaoRemoverFaixaSelecionada = new System.Windows.Forms.Button();
            this.BotaoAbrirJanelaOverlayStream = new System.Windows.Forms.Button();
            this.LabelPosicaoZeroFaixaAtual = new System.Windows.Forms.Label();
            this.LabelTempoTotalFaixaAtual = new System.Windows.Forms.Label();
            this.PanelControlesDeMidia = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlControles2 = new System.Windows.Forms.FlowLayoutPanel();
            this.LabelVolume = new System.Windows.Forms.Label();
            this.timerNextSong = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.GradePlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTempoFaixaAtual)).BeginInit();
            this.PanelBotoesCabecalho.SuspendLayout();
            this.PanelControlesDeMidia.SuspendLayout();
            this.pnlControles2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LabelNomeDaFaixaAtual
            // 
            this.LabelNomeDaFaixaAtual.AutoSize = true;
            this.LabelNomeDaFaixaAtual.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelNomeDaFaixaAtual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.LabelNomeDaFaixaAtual.Location = new System.Drawing.Point(483, 141);
            this.LabelNomeDaFaixaAtual.Name = "LabelNomeDaFaixaAtual";
            this.LabelNomeDaFaixaAtual.Size = new System.Drawing.Size(186, 21);
            this.LabelNomeDaFaixaAtual.TabIndex = 0;
            this.LabelNomeDaFaixaAtual.Text = "LabelNomeDaFaixaAtual";
            // 
            // BotaoFaixaAnterior
            // 
            this.BotaoFaixaAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BotaoFaixaAnterior.FlatAppearance.BorderSize = 2;
            this.BotaoFaixaAnterior.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoFaixaAnterior.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoFaixaAnterior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoFaixaAnterior.Location = new System.Drawing.Point(3, 3);
            this.BotaoFaixaAnterior.Name = "BotaoFaixaAnterior";
            this.BotaoFaixaAnterior.Size = new System.Drawing.Size(75, 44);
            this.BotaoFaixaAnterior.TabIndex = 1;
            this.BotaoFaixaAnterior.Text = "⏪";
            this.BotaoFaixaAnterior.UseVisualStyleBackColor = false;
            this.BotaoFaixaAnterior.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // BotaoPlayPause
            // 
            this.BotaoPlayPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BotaoPlayPause.FlatAppearance.BorderSize = 2;
            this.BotaoPlayPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoPlayPause.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoPlayPause.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoPlayPause.Location = new System.Drawing.Point(84, 3);
            this.BotaoPlayPause.Name = "BotaoPlayPause";
            this.BotaoPlayPause.Size = new System.Drawing.Size(75, 44);
            this.BotaoPlayPause.TabIndex = 2;
            this.BotaoPlayPause.Text = "▶️||";
            this.BotaoPlayPause.UseVisualStyleBackColor = false;
            this.BotaoPlayPause.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // BotaoProximaFaixa
            // 
            this.BotaoProximaFaixa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.BotaoProximaFaixa.FlatAppearance.BorderSize = 2;
            this.BotaoProximaFaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoProximaFaixa.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoProximaFaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoProximaFaixa.Location = new System.Drawing.Point(165, 3);
            this.BotaoProximaFaixa.Name = "BotaoProximaFaixa";
            this.BotaoProximaFaixa.Size = new System.Drawing.Size(75, 44);
            this.BotaoProximaFaixa.TabIndex = 3;
            this.BotaoProximaFaixa.Text = "⏩";
            this.BotaoProximaFaixa.UseVisualStyleBackColor = false;
            this.BotaoProximaFaixa.Click += new System.EventHandler(this.mediaControls_Click);
            // 
            // CheckBoxShuffle
            // 
            this.CheckBoxShuffle.AutoSize = true;
            this.CheckBoxShuffle.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckBoxShuffle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.CheckBoxShuffle.Location = new System.Drawing.Point(192, 3);
            this.CheckBoxShuffle.Name = "CheckBoxShuffle";
            this.CheckBoxShuffle.Size = new System.Drawing.Size(51, 25);
            this.CheckBoxShuffle.TabIndex = 4;
            this.CheckBoxShuffle.Text = "🔀";
            this.CheckBoxShuffle.UseVisualStyleBackColor = true;
            // 
            // GradePlaylist
            // 
            this.GradePlaylist.AllowUserToResizeColumns = false;
            this.GradePlaylist.AllowUserToResizeRows = false;
            this.GradePlaylist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GradePlaylist.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(12)))), ((int)(((byte)(12)))));
            this.GradePlaylist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GradePlaylist.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GradePlaylist.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GradePlaylist.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GradePlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GradePlaylist.ColumnHeadersVisible = false;
            this.GradePlaylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nome,
            this.ID,
            this.Thumb});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GradePlaylist.DefaultCellStyle = dataGridViewCellStyle2;
            this.GradePlaylist.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.GradePlaylist.Location = new System.Drawing.Point(0, 8);
            this.GradePlaylist.MultiSelect = false;
            this.GradePlaylist.Name = "GradePlaylist";
            this.GradePlaylist.ReadOnly = true;
            this.GradePlaylist.RowHeadersVisible = false;
            this.GradePlaylist.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GradePlaylist.Size = new System.Drawing.Size(161, 150);
            this.GradePlaylist.TabIndex = 6;
            this.GradePlaylist.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdPlayList_CellMouseDoubleClick);
            // 
            // Nome
            // 
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Thumb
            // 
            this.Thumb.HeaderText = "Thumb";
            this.Thumb.Name = "Thumb";
            this.Thumb.ReadOnly = true;
            this.Thumb.Visible = false;
            // 
            // TrackBarVolume
            // 
            this.TrackBarVolume.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarVolume.Location = new System.Drawing.Point(45, 3);
            this.TrackBarVolume.Maximum = 100;
            this.TrackBarVolume.Name = "TrackBarVolume";
            this.TrackBarVolume.Size = new System.Drawing.Size(141, 45);
            this.TrackBarVolume.TabIndex = 9;
            this.TrackBarVolume.TabStop = false;
            this.TrackBarVolume.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBarVolume.Value = 65;
            this.TrackBarVolume.ValueChanged += new System.EventHandler(this.brVolume_ValueChanged);
            // 
            // TrackBarTempoFaixaAtual
            // 
            this.TrackBarTempoFaixaAtual.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBarTempoFaixaAtual.Location = new System.Drawing.Point(219, 141);
            this.TrackBarTempoFaixaAtual.Maximum = 100;
            this.TrackBarTempoFaixaAtual.Name = "TrackBarTempoFaixaAtual";
            this.TrackBarTempoFaixaAtual.Size = new System.Drawing.Size(256, 45);
            this.TrackBarTempoFaixaAtual.TabIndex = 11;
            this.TrackBarTempoFaixaAtual.TabStop = false;
            this.TrackBarTempoFaixaAtual.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TrackBarTempoFaixaAtual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseClick);
            this.TrackBarTempoFaixaAtual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseDown);
            this.TrackBarTempoFaixaAtual.MouseUp += new System.Windows.Forms.MouseEventHandler(this.brTempo_MouseUp);
            // 
            // timerSeekbar
            // 
            this.timerSeekbar.Enabled = true;
            this.timerSeekbar.Interval = 1016;
            this.timerSeekbar.Tick += new System.EventHandler(this.timerSeekbar_Tick);
            // 
            // PanelBotoesCabecalho
            // 
            this.PanelBotoesCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoPesquisarFaixa);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoCarregarPlaylist);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoSalvarPlaylist);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoSubirFaixaSelecionada);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoDescerFaixaSelecionada);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoRemoverFaixaSelecionada);
            this.PanelBotoesCabecalho.Controls.Add(this.BotaoAbrirJanelaOverlayStream);
            this.PanelBotoesCabecalho.Location = new System.Drawing.Point(208, 80);
            this.PanelBotoesCabecalho.Name = "PanelBotoesCabecalho";
            this.PanelBotoesCabecalho.Size = new System.Drawing.Size(381, 55);
            this.PanelBotoesCabecalho.TabIndex = 12;
            // 
            // BotaoPesquisarFaixa
            // 
            this.BotaoPesquisarFaixa.BackColor = System.Drawing.Color.Transparent;
            this.BotaoPesquisarFaixa.FlatAppearance.BorderSize = 2;
            this.BotaoPesquisarFaixa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoPesquisarFaixa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoPesquisarFaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoPesquisarFaixa.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoPesquisarFaixa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoPesquisarFaixa.Location = new System.Drawing.Point(3, 3);
            this.BotaoPesquisarFaixa.Name = "BotaoPesquisarFaixa";
            this.BotaoPesquisarFaixa.Size = new System.Drawing.Size(48, 48);
            this.BotaoPesquisarFaixa.TabIndex = 5;
            this.BotaoPesquisarFaixa.Text = "🎵";
            this.BotaoPesquisarFaixa.UseVisualStyleBackColor = false;
            this.BotaoPesquisarFaixa.Click += new System.EventHandler(this.btPesquisar_Click);
            // 
            // BotaoCarregarPlaylist
            // 
            this.BotaoCarregarPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.BotaoCarregarPlaylist.FlatAppearance.BorderSize = 2;
            this.BotaoCarregarPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoCarregarPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoCarregarPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoCarregarPlaylist.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoCarregarPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoCarregarPlaylist.Location = new System.Drawing.Point(57, 3);
            this.BotaoCarregarPlaylist.Name = "BotaoCarregarPlaylist";
            this.BotaoCarregarPlaylist.Size = new System.Drawing.Size(48, 48);
            this.BotaoCarregarPlaylist.TabIndex = 9;
            this.BotaoCarregarPlaylist.Text = "📂";
            this.BotaoCarregarPlaylist.UseVisualStyleBackColor = false;
            this.BotaoCarregarPlaylist.Click += new System.EventHandler(this.btCarregarPlaylist_Click);
            // 
            // BotaoSalvarPlaylist
            // 
            this.BotaoSalvarPlaylist.BackColor = System.Drawing.Color.Transparent;
            this.BotaoSalvarPlaylist.FlatAppearance.BorderSize = 2;
            this.BotaoSalvarPlaylist.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoSalvarPlaylist.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoSalvarPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoSalvarPlaylist.Font = new System.Drawing.Font("Segoe UI Emoji", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoSalvarPlaylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoSalvarPlaylist.Location = new System.Drawing.Point(111, 3);
            this.BotaoSalvarPlaylist.Name = "BotaoSalvarPlaylist";
            this.BotaoSalvarPlaylist.Size = new System.Drawing.Size(48, 48);
            this.BotaoSalvarPlaylist.TabIndex = 8;
            this.BotaoSalvarPlaylist.Text = "💾";
            this.BotaoSalvarPlaylist.UseVisualStyleBackColor = false;
            this.BotaoSalvarPlaylist.Click += new System.EventHandler(this.btSalvarPlaylist_Click);
            // 
            // BotaoSubirFaixaSelecionada
            // 
            this.BotaoSubirFaixaSelecionada.BackColor = System.Drawing.Color.Transparent;
            this.BotaoSubirFaixaSelecionada.FlatAppearance.BorderSize = 2;
            this.BotaoSubirFaixaSelecionada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoSubirFaixaSelecionada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoSubirFaixaSelecionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoSubirFaixaSelecionada.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoSubirFaixaSelecionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoSubirFaixaSelecionada.Location = new System.Drawing.Point(165, 3);
            this.BotaoSubirFaixaSelecionada.Name = "BotaoSubirFaixaSelecionada";
            this.BotaoSubirFaixaSelecionada.Size = new System.Drawing.Size(48, 48);
            this.BotaoSubirFaixaSelecionada.TabIndex = 10;
            this.BotaoSubirFaixaSelecionada.Text = "↑";
            this.BotaoSubirFaixaSelecionada.UseVisualStyleBackColor = false;
            this.BotaoSubirFaixaSelecionada.Click += new System.EventHandler(this.btCimaPlaylist_Click);
            // 
            // BotaoDescerFaixaSelecionada
            // 
            this.BotaoDescerFaixaSelecionada.BackColor = System.Drawing.Color.Transparent;
            this.BotaoDescerFaixaSelecionada.FlatAppearance.BorderSize = 2;
            this.BotaoDescerFaixaSelecionada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoDescerFaixaSelecionada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoDescerFaixaSelecionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoDescerFaixaSelecionada.Font = new System.Drawing.Font("Segoe UI Symbol", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoDescerFaixaSelecionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoDescerFaixaSelecionada.Location = new System.Drawing.Point(219, 3);
            this.BotaoDescerFaixaSelecionada.Name = "BotaoDescerFaixaSelecionada";
            this.BotaoDescerFaixaSelecionada.Size = new System.Drawing.Size(48, 48);
            this.BotaoDescerFaixaSelecionada.TabIndex = 6;
            this.BotaoDescerFaixaSelecionada.Text = "↓";
            this.BotaoDescerFaixaSelecionada.UseVisualStyleBackColor = false;
            this.BotaoDescerFaixaSelecionada.Click += new System.EventHandler(this.btBaixoPlaylist_Click);
            // 
            // BotaoRemoverFaixaSelecionada
            // 
            this.BotaoRemoverFaixaSelecionada.BackColor = System.Drawing.Color.Transparent;
            this.BotaoRemoverFaixaSelecionada.FlatAppearance.BorderSize = 2;
            this.BotaoRemoverFaixaSelecionada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoRemoverFaixaSelecionada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoRemoverFaixaSelecionada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoRemoverFaixaSelecionada.Font = new System.Drawing.Font("Segoe UI Symbol", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoRemoverFaixaSelecionada.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoRemoverFaixaSelecionada.Location = new System.Drawing.Point(273, 3);
            this.BotaoRemoverFaixaSelecionada.Name = "BotaoRemoverFaixaSelecionada";
            this.BotaoRemoverFaixaSelecionada.Size = new System.Drawing.Size(48, 48);
            this.BotaoRemoverFaixaSelecionada.TabIndex = 7;
            this.BotaoRemoverFaixaSelecionada.Text = "X";
            this.BotaoRemoverFaixaSelecionada.UseVisualStyleBackColor = false;
            this.BotaoRemoverFaixaSelecionada.Click += new System.EventHandler(this.btRemoverDaLista_Click);
            // 
            // BotaoAbrirJanelaOverlayStream
            // 
            this.BotaoAbrirJanelaOverlayStream.BackColor = System.Drawing.Color.Transparent;
            this.BotaoAbrirJanelaOverlayStream.FlatAppearance.BorderSize = 2;
            this.BotaoAbrirJanelaOverlayStream.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.BotaoAbrirJanelaOverlayStream.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.BotaoAbrirJanelaOverlayStream.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BotaoAbrirJanelaOverlayStream.Font = new System.Drawing.Font("Segoe UI Emoji", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BotaoAbrirJanelaOverlayStream.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.BotaoAbrirJanelaOverlayStream.Location = new System.Drawing.Point(327, 3);
            this.BotaoAbrirJanelaOverlayStream.Name = "BotaoAbrirJanelaOverlayStream";
            this.BotaoAbrirJanelaOverlayStream.Size = new System.Drawing.Size(48, 48);
            this.BotaoAbrirJanelaOverlayStream.TabIndex = 11;
            this.BotaoAbrirJanelaOverlayStream.Text = "📶";
            this.BotaoAbrirJanelaOverlayStream.UseVisualStyleBackColor = false;
            this.BotaoAbrirJanelaOverlayStream.Click += new System.EventHandler(this.btJanelaStream_Click);
            // 
            // LabelPosicaoZeroFaixaAtual
            // 
            this.LabelPosicaoZeroFaixaAtual.AutoSize = true;
            this.LabelPosicaoZeroFaixaAtual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelPosicaoZeroFaixaAtual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.LabelPosicaoZeroFaixaAtual.Location = new System.Drawing.Point(632, 117);
            this.LabelPosicaoZeroFaixaAtual.Name = "LabelPosicaoZeroFaixaAtual";
            this.LabelPosicaoZeroFaixaAtual.Size = new System.Drawing.Size(31, 17);
            this.LabelPosicaoZeroFaixaAtual.TabIndex = 13;
            this.LabelPosicaoZeroFaixaAtual.Text = "--:--";
            // 
            // LabelTempoTotalFaixaAtual
            // 
            this.LabelTempoTotalFaixaAtual.AutoSize = true;
            this.LabelTempoTotalFaixaAtual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelTempoTotalFaixaAtual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.LabelTempoTotalFaixaAtual.Location = new System.Drawing.Point(632, 141);
            this.LabelTempoTotalFaixaAtual.Name = "LabelTempoTotalFaixaAtual";
            this.LabelTempoTotalFaixaAtual.Size = new System.Drawing.Size(31, 17);
            this.LabelTempoTotalFaixaAtual.TabIndex = 14;
            this.LabelTempoTotalFaixaAtual.Text = "--:--";
            // 
            // PanelControlesDeMidia
            // 
            this.PanelControlesDeMidia.Controls.Add(this.BotaoFaixaAnterior);
            this.PanelControlesDeMidia.Controls.Add(this.BotaoPlayPause);
            this.PanelControlesDeMidia.Controls.Add(this.BotaoProximaFaixa);
            this.PanelControlesDeMidia.Location = new System.Drawing.Point(236, 24);
            this.PanelControlesDeMidia.Name = "PanelControlesDeMidia";
            this.PanelControlesDeMidia.Size = new System.Drawing.Size(247, 50);
            this.PanelControlesDeMidia.TabIndex = 15;
            // 
            // pnlControles2
            // 
            this.pnlControles2.Controls.Add(this.LabelVolume);
            this.pnlControles2.Controls.Add(this.TrackBarVolume);
            this.pnlControles2.Controls.Add(this.CheckBoxShuffle);
            this.pnlControles2.Location = new System.Drawing.Point(211, 173);
            this.pnlControles2.Name = "pnlControles2";
            this.pnlControles2.Size = new System.Drawing.Size(246, 30);
            this.pnlControles2.TabIndex = 16;
            // 
            // LabelVolume
            // 
            this.LabelVolume.AutoSize = true;
            this.LabelVolume.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelVolume.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(131)))), ((int)(((byte)(255)))));
            this.LabelVolume.Location = new System.Drawing.Point(3, 0);
            this.LabelVolume.Name = "LabelVolume";
            this.LabelVolume.Padding = new System.Windows.Forms.Padding(2);
            this.LabelVolume.Size = new System.Drawing.Size(36, 25);
            this.LabelVolume.TabIndex = 0;
            this.LabelVolume.Text = "🔊";
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
            this.Controls.Add(this.PanelControlesDeMidia);
            this.Controls.Add(this.LabelTempoTotalFaixaAtual);
            this.Controls.Add(this.LabelPosicaoZeroFaixaAtual);
            this.Controls.Add(this.PanelBotoesCabecalho);
            this.Controls.Add(this.TrackBarTempoFaixaAtual);
            this.Controls.Add(this.GradePlaylist);
            this.Controls.Add(this.LabelNomeDaFaixaAtual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spobrify";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.GradePlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarTempoFaixaAtual)).EndInit();
            this.PanelBotoesCabecalho.ResumeLayout(false);
            this.PanelControlesDeMidia.ResumeLayout(false);
            this.pnlControles2.ResumeLayout(false);
            this.pnlControles2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LabelNomeDaFaixaAtual;
        private System.Windows.Forms.Button BotaoFaixaAnterior;
        private System.Windows.Forms.Button BotaoPlayPause;
        private System.Windows.Forms.Button BotaoProximaFaixa;
        private System.Windows.Forms.CheckBox CheckBoxShuffle;
        private System.Windows.Forms.DataGridView GradePlaylist;
        private System.Windows.Forms.TrackBar TrackBarVolume;
        private System.Windows.Forms.TrackBar TrackBarTempoFaixaAtual;
        private System.Windows.Forms.Timer timerSeekbar;
        private System.Windows.Forms.FlowLayoutPanel PanelBotoesCabecalho;
        private System.Windows.Forms.Button BotaoPesquisarFaixa;
        private System.Windows.Forms.Label LabelPosicaoZeroFaixaAtual;
        private System.Windows.Forms.Label LabelTempoTotalFaixaAtual;
        private System.Windows.Forms.Button BotaoDescerFaixaSelecionada;
        private System.Windows.Forms.Button BotaoRemoverFaixaSelecionada;
        private System.Windows.Forms.Button BotaoSalvarPlaylist;
        private System.Windows.Forms.Button BotaoCarregarPlaylist;
        private System.Windows.Forms.Button BotaoSubirFaixaSelecionada;
        private System.Windows.Forms.Button BotaoAbrirJanelaOverlayStream;
        private System.Windows.Forms.FlowLayoutPanel PanelControlesDeMidia;
        private System.Windows.Forms.FlowLayoutPanel pnlControles2;
        private System.Windows.Forms.Label LabelVolume;
        private System.Windows.Forms.Timer timerNextSong;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Thumb;
    }
}

