namespace BatePapoNSM
{
    partial class TelaConversa
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
            this.components = new System.ComponentModel.Container();
            this.txbDigitacao = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.labelDigitando = new System.Windows.Forms.Label();
            this.richConversa = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnCancelarPerfil = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtEmailPerfil = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNomePerfil = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRedSenhaPerfil = new System.Windows.Forms.TextBox();
            this.btnSalvarPerfil = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSenhaPerfil = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtLoginPerfil = new System.Windows.Forms.TextBox();
            this.labelTituloPerfil = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listContatos = new System.Windows.Forms.ListView();
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtFulano = new System.Windows.Forms.TextBox();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.comboStatus = new System.Windows.Forms.ComboBox();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.timerNotificacao = new System.Windows.Forms.Timer(this.components);
            this.btnSons = new System.Windows.Forms.Button();
            this.btnEnviarArquivo = new System.Windows.Forms.Button();
            this.openFileEnviarArquivo = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbDigitacao
            // 
            this.txbDigitacao.BackColor = System.Drawing.SystemColors.Window;
            this.txbDigitacao.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbDigitacao.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txbDigitacao.Location = new System.Drawing.Point(370, 418);
            this.txbDigitacao.Multiline = true;
            this.txbDigitacao.Name = "txbDigitacao";
            this.txbDigitacao.ReadOnly = true;
            this.txbDigitacao.Size = new System.Drawing.Size(295, 59);
            this.txbDigitacao.TabIndex = 1;
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnEnviar.Enabled = false;
            this.btnEnviar.FlatAppearance.BorderSize = 2;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Font = new System.Drawing.Font("Comic Sans MS", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEnviar.Location = new System.Drawing.Point(664, 419);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(62, 57);
            this.btnEnviar.TabIndex = 3;
            this.btnEnviar.TabStop = false;
            this.btnEnviar.Text = "►";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // labelDigitando
            // 
            this.labelDigitando.AutoSize = true;
            this.labelDigitando.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDigitando.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelDigitando.Location = new System.Drawing.Point(368, 397);
            this.labelDigitando.Name = "labelDigitando";
            this.labelDigitando.Size = new System.Drawing.Size(134, 17);
            this.labelDigitando.TabIndex = 4;
            this.labelDigitando.Text = "Fulano está digitando...";
            this.labelDigitando.Visible = false;
            // 
            // richConversa
            // 
            this.richConversa.BackColor = System.Drawing.Color.DarkSlateGray;
            this.richConversa.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richConversa.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.richConversa.Location = new System.Drawing.Point(369, 34);
            this.richConversa.Name = "richConversa";
            this.richConversa.ReadOnly = true;
            this.richConversa.Size = new System.Drawing.Size(357, 358);
            this.richConversa.TabIndex = 2;
            this.richConversa.TabStop = false;
            this.richConversa.Text = "";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 444);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tabPage1.Controls.Add(this.btnCancelarPerfil);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.btnSalvarPerfil);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.labelTituloPerfil);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tabPage1.Location = new System.Drawing.Point(31, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(334, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Perfil";
            // 
            // btnCancelarPerfil
            // 
            this.btnCancelarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarPerfil.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancelarPerfil.Location = new System.Drawing.Point(168, 357);
            this.btnCancelarPerfil.Name = "btnCancelarPerfil";
            this.btnCancelarPerfil.Size = new System.Drawing.Size(110, 35);
            this.btnCancelarPerfil.TabIndex = 14;
            this.btnCancelarPerfil.Text = "Cancelar";
            this.btnCancelarPerfil.UseVisualStyleBackColor = true;
            this.btnCancelarPerfil.Click += new System.EventHandler(this.btnCancelarPerfil_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtEmailPerfil);
            this.groupBox5.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox5.Location = new System.Drawing.Point(56, 294);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(222, 52);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "E-mail";
            // 
            // txtEmailPerfil
            // 
            this.txtEmailPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailPerfil.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtEmailPerfil.Location = new System.Drawing.Point(7, 17);
            this.txtEmailPerfil.MaxLength = 50;
            this.txtEmailPerfil.Name = "txtEmailPerfil";
            this.txtEmailPerfil.Size = new System.Drawing.Size(209, 26);
            this.txtEmailPerfil.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtNomePerfil);
            this.groupBox4.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox4.Location = new System.Drawing.Point(56, 236);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(222, 52);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Nome";
            // 
            // txtNomePerfil
            // 
            this.txtNomePerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomePerfil.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtNomePerfil.Location = new System.Drawing.Point(7, 17);
            this.txtNomePerfil.MaxLength = 20;
            this.txtNomePerfil.Name = "txtNomePerfil";
            this.txtNomePerfil.Size = new System.Drawing.Size(209, 26);
            this.txtNomePerfil.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtRedSenhaPerfil);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox3.Location = new System.Drawing.Point(56, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(222, 52);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Repita a Senha";
            // 
            // txtRedSenhaPerfil
            // 
            this.txtRedSenhaPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRedSenhaPerfil.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtRedSenhaPerfil.Location = new System.Drawing.Point(7, 17);
            this.txtRedSenhaPerfil.MaxLength = 10;
            this.txtRedSenhaPerfil.Name = "txtRedSenhaPerfil";
            this.txtRedSenhaPerfil.PasswordChar = '•';
            this.txtRedSenhaPerfil.Size = new System.Drawing.Size(209, 26);
            this.txtRedSenhaPerfil.TabIndex = 3;
            // 
            // btnSalvarPerfil
            // 
            this.btnSalvarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvarPerfil.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSalvarPerfil.Location = new System.Drawing.Point(56, 357);
            this.btnSalvarPerfil.Name = "btnSalvarPerfil";
            this.btnSalvarPerfil.Size = new System.Drawing.Size(110, 35);
            this.btnSalvarPerfil.TabIndex = 13;
            this.btnSalvarPerfil.Text = "Salvar";
            this.btnSalvarPerfil.UseVisualStyleBackColor = true;
            this.btnSalvarPerfil.Click += new System.EventHandler(this.btnSalvarPerfil_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtSenhaPerfil);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox2.Location = new System.Drawing.Point(56, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 52);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Senha";
            // 
            // txtSenhaPerfil
            // 
            this.txtSenhaPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenhaPerfil.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtSenhaPerfil.Location = new System.Drawing.Point(7, 17);
            this.txtSenhaPerfil.MaxLength = 10;
            this.txtSenhaPerfil.Name = "txtSenhaPerfil";
            this.txtSenhaPerfil.PasswordChar = '•';
            this.txtSenhaPerfil.Size = new System.Drawing.Size(209, 26);
            this.txtSenhaPerfil.TabIndex = 2;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtLoginPerfil);
            this.groupBox6.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox6.Location = new System.Drawing.Point(56, 64);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(222, 53);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Login";
            // 
            // txtLoginPerfil
            // 
            this.txtLoginPerfil.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.txtLoginPerfil.Enabled = false;
            this.txtLoginPerfil.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPerfil.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtLoginPerfil.Location = new System.Drawing.Point(7, 17);
            this.txtLoginPerfil.MaxLength = 8;
            this.txtLoginPerfil.Name = "txtLoginPerfil";
            this.txtLoginPerfil.Size = new System.Drawing.Size(209, 26);
            this.txtLoginPerfil.TabIndex = 1;
            // 
            // labelTituloPerfil
            // 
            this.labelTituloPerfil.AutoSize = true;
            this.labelTituloPerfil.Font = new System.Drawing.Font("Comic Sans MS", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTituloPerfil.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.labelTituloPerfil.Location = new System.Drawing.Point(123, 23);
            this.labelTituloPerfil.Name = "labelTituloPerfil";
            this.labelTituloPerfil.Size = new System.Drawing.Size(88, 38);
            this.labelTituloPerfil.TabIndex = 8;
            this.labelTituloPerfil.Text = "Perfil";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(31, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(334, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contatos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listContatos);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 420);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contatos";
            // 
            // listContatos
            // 
            this.listContatos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nome,
            this.Status});
            this.listContatos.Font = new System.Drawing.Font("Comic Sans MS", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listContatos.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.listContatos.FullRowSelect = true;
            this.listContatos.GridLines = true;
            this.listContatos.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listContatos.HideSelection = false;
            this.listContatos.LabelWrap = false;
            this.listContatos.Location = new System.Drawing.Point(6, 19);
            this.listContatos.MultiSelect = false;
            this.listContatos.Name = "listContatos";
            this.listContatos.Size = new System.Drawing.Size(309, 395);
            this.listContatos.TabIndex = 4;
            this.listContatos.TabStop = false;
            this.listContatos.UseCompatibleStateImageBehavior = false;
            this.listContatos.View = System.Windows.Forms.View.Details;
            this.listContatos.SelectedIndexChanged += new System.EventHandler(this.listContatos_SelectedIndexChanged);
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 160;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Status.Width = 128;
            // 
            // txtFulano
            // 
            this.txtFulano.BackColor = System.Drawing.SystemColors.Window;
            this.txtFulano.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtFulano.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFulano.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtFulano.Location = new System.Drawing.Point(368, -1);
            this.txtFulano.Name = "txtFulano";
            this.txtFulano.ReadOnly = true;
            this.txtFulano.Size = new System.Drawing.Size(359, 35);
            this.txtFulano.TabIndex = 7;
            this.txtFulano.Text = "Fulano";
            // 
            // txtNome
            // 
            this.txtNome.BackColor = System.Drawing.SystemColors.Window;
            this.txtNome.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtNome.Font = new System.Drawing.Font("Comic Sans MS", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtNome.Location = new System.Drawing.Point(15, -1);
            this.txtNome.Name = "txtNome";
            this.txtNome.ReadOnly = true;
            this.txtNome.Size = new System.Drawing.Size(271, 35);
            this.txtNome.TabIndex = 8;
            this.txtNome.Text = "Nome";
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Comic Sans MS", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSair.Location = new System.Drawing.Point(326, 0);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(42, 33);
            this.btnSair.TabIndex = 9;
            this.btnSair.Text = "✘";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // comboStatus
            // 
            this.comboStatus.BackColor = System.Drawing.SystemColors.Window;
            this.comboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboStatus.DropDownWidth = 80;
            this.comboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboStatus.Font = new System.Drawing.Font("Comic Sans MS", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboStatus.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.comboStatus.FormattingEnabled = true;
            this.comboStatus.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Ausente"});
            this.comboStatus.Location = new System.Drawing.Point(0, -1);
            this.comboStatus.Name = "comboStatus";
            this.comboStatus.Size = new System.Drawing.Size(16, 34);
            this.comboStatus.TabIndex = 10;
            this.comboStatus.SelectedIndexChanged += new System.EventHandler(this.comboStatus_SelectedIndexChanged);
            // 
            // timerStatus
            // 
            this.timerStatus.Interval = 5000;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // timerNotificacao
            // 
            this.timerNotificacao.Interval = 5000;
            this.timerNotificacao.Tick += new System.EventHandler(this.timerNotificacao_Tick);
            // 
            // btnSons
            // 
            this.btnSons.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnSons.FlatAppearance.BorderSize = 0;
            this.btnSons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSons.Font = new System.Drawing.Font("Comic Sans MS", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btnSons.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnSons.Location = new System.Drawing.Point(284, 0);
            this.btnSons.Name = "btnSons";
            this.btnSons.Size = new System.Drawing.Size(42, 33);
            this.btnSons.TabIndex = 11;
            this.btnSons.Text = "🔊";
            this.btnSons.UseVisualStyleBackColor = false;
            this.btnSons.Click += new System.EventHandler(this.btnSons_Click);
            // 
            // btnEnviarArquivo
            // 
            this.btnEnviarArquivo.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnEnviarArquivo.Enabled = false;
            this.btnEnviarArquivo.FlatAppearance.BorderSize = 0;
            this.btnEnviarArquivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviarArquivo.Font = new System.Drawing.Font("Comic Sans MS", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World, ((byte)(0)));
            this.btnEnviarArquivo.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.btnEnviarArquivo.Location = new System.Drawing.Point(623, 390);
            this.btnEnviarArquivo.Name = "btnEnviarArquivo";
            this.btnEnviarArquivo.Size = new System.Drawing.Size(42, 30);
            this.btnEnviarArquivo.TabIndex = 12;
            this.btnEnviarArquivo.Text = "📤";
            this.btnEnviarArquivo.UseVisualStyleBackColor = false;
            this.btnEnviarArquivo.Click += new System.EventHandler(this.btnEnviarArquivo_Click);
            // 
            // openFileEnviarArquivo
            // 
            this.openFileEnviarArquivo.Multiselect = true;
            // 
            // TelaConversa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(726, 477);
            this.Controls.Add(this.btnEnviarArquivo);
            this.Controls.Add(this.btnSons);
            this.Controls.Add(this.comboStatus);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.txtFulano);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.richConversa);
            this.Controls.Add(this.labelDigitando);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txbDigitacao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TelaConversa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NSM";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TelaConversa_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TelaConversa_KeyUp);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbDigitacao;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label labelDigitando;
        private System.Windows.Forms.RichTextBox richConversa;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtFulano;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listContatos;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ComboBox comboStatus;
        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Timer timerNotificacao;
        private System.Windows.Forms.Button btnSons;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtEmailPerfil;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNomePerfil;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRedSenhaPerfil;
        private System.Windows.Forms.Button btnSalvarPerfil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtSenhaPerfil;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtLoginPerfil;
        private System.Windows.Forms.Label labelTituloPerfil;
        private System.Windows.Forms.Button btnCancelarPerfil;
        private System.Windows.Forms.Button btnEnviarArquivo;
        private System.Windows.Forms.OpenFileDialog openFileEnviarArquivo;
    }
}