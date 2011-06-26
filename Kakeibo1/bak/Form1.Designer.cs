namespace Kakeibo
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvKBDat = new System.Windows.Forms.DataGridView();
			this.buy_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cate_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cate_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.income = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.balance = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.where = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.toppane = new System.Windows.Forms.Panel();
			this.button5 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.lbl_cashpayment = new System.Windows.Forms.Label();
			this.lbl_creditpayment = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.lbl_totalpayment = new System.Windows.Forms.Label();
			this.lbl_totalincome = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp = new System.Windows.Forms.DateTimePicker();
			this.tbpSQL = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lstCateSub = new System.Windows.Forms.ListBox();
			this.lstCateMain = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txt_masspay = new System.Windows.Forms.TextBox();
			this.cmb_massaccount = new System.Windows.Forms.ComboBox();
			this.lbl_out = new System.Windows.Forms.Label();
			this.lbl_in = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtWhere = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.txtRID = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnEntry = new System.Windows.Forms.Button();
			this.tbpSearch = new System.Windows.Forms.TabPage();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tbpCategory = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.dgvCateSub = new System.Windows.Forms.DataGridView();
			this.col_id_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_cate_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_sortid_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvCateMain = new System.Windows.Forms.DataGridView();
			this.col_id_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_sortid_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tbpBalance = new System.Windows.Forms.TabPage();
			this.btnEntryBLC = new System.Windows.Forms.Button();
			this.dgvBalance = new System.Windows.Forms.DataGridView();
			this.blc_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.blc_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.blc_eot = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.blc_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.blc_initval = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.cmbBalanceMonth = new System.Windows.Forms.ComboBox();
			this.lvStatistics = new System.Windows.Forms.ListView();
			this.colhdr0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colhdr6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.button6 = new System.Windows.Forms.Button();
			this.txtSQL = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.smDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
			this.smInsertRow = new System.Windows.Forms.ToolStripMenuItem();
			this.kbDatList1 = new Kakeibo.KBDatList();
			((System.ComponentModel.ISupportInitialize)(this.dgvKBDat)).BeginInit();
			this.toppane.SuspendLayout();
			this.tbpSQL.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tbpSearch.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tbpCategory.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCateSub)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCateMain)).BeginInit();
			this.tbpBalance.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).BeginInit();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvKBDat
			// 
			this.dgvKBDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKBDat.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.buy_date,
            this.cate_main,
            this.cate_sub,
            this.income,
            this.payment,
            this.name,
            this.balance,
            this.pay_date,
            this.where,
            this.memo});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvKBDat.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvKBDat.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKBDat.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.dgvKBDat.Location = new System.Drawing.Point(3, 84);
			this.dgvKBDat.Name = "dgvKBDat";
			this.dgvKBDat.RowTemplate.Height = 21;
			this.dgvKBDat.Size = new System.Drawing.Size(1070, 488);
			this.dgvKBDat.TabIndex = 0;
			this.dgvKBDat.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvKBDat_CellBeginEdit);
			this.dgvKBDat.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBDat_CellEndEdit);
			this.dgvKBDat.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBDat_CellLeave);
			this.dgvKBDat.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBDat_CellValueChanged);
			this.dgvKBDat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKBDat_KeyDown);
			this.dgvKBDat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvKBDat_KeyPress);
			// 
			// buy_date
			// 
			this.buy_date.HeaderText = "日付";
			this.buy_date.Name = "buy_date";
			this.buy_date.Width = 80;
			// 
			// cate_main
			// 
			this.cate_main.HeaderText = "費目";
			this.cate_main.Name = "cate_main";
			this.cate_main.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.cate_main.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// cate_sub
			// 
			this.cate_sub.HeaderText = "詳細";
			this.cate_sub.Name = "cate_sub";
			this.cate_sub.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.cate_sub.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			// 
			// income
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.income.DefaultCellStyle = dataGridViewCellStyle1;
			this.income.HeaderText = "収入";
			this.income.Name = "income";
			this.income.Width = 80;
			// 
			// payment
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.payment.DefaultCellStyle = dataGridViewCellStyle2;
			this.payment.HeaderText = "支出";
			this.payment.Name = "payment";
			this.payment.Width = 80;
			// 
			// name
			// 
			this.name.HeaderText = "品名";
			this.name.Name = "name";
			this.name.Width = 160;
			// 
			// balance
			// 
			this.balance.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.balance.HeaderText = "口座";
			this.balance.Name = "balance";
			this.balance.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.balance.Width = 130;
			// 
			// pay_date
			// 
			this.pay_date.HeaderText = "取扱日";
			this.pay_date.Name = "pay_date";
			this.pay_date.Width = 80;
			// 
			// where
			// 
			this.where.HeaderText = "場所";
			this.where.Name = "where";
			// 
			// memo
			// 
			this.memo.HeaderText = "メモ";
			this.memo.Name = "memo";
			// 
			// toppane
			// 
			this.toppane.Controls.Add(this.button5);
			this.toppane.Controls.Add(this.button4);
			this.toppane.Controls.Add(this.lbl_cashpayment);
			this.toppane.Controls.Add(this.lbl_creditpayment);
			this.toppane.Controls.Add(this.label6);
			this.toppane.Controls.Add(this.label5);
			this.toppane.Controls.Add(this.lbl_totalpayment);
			this.toppane.Controls.Add(this.lbl_totalincome);
			this.toppane.Controls.Add(this.label3);
			this.toppane.Controls.Add(this.label2);
			this.toppane.Controls.Add(this.label1);
			this.toppane.Controls.Add(this.dtp);
			this.toppane.Dock = System.Windows.Forms.DockStyle.Top;
			this.toppane.Location = new System.Drawing.Point(0, 0);
			this.toppane.Name = "toppane";
			this.toppane.Size = new System.Drawing.Size(1084, 129);
			this.toppane.TabIndex = 1;
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(1044, 12);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(28, 23);
			this.button5.TabIndex = 12;
			this.button5.Text = ">>";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(846, 12);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(28, 23);
			this.button4.TabIndex = 11;
			this.button4.Text = "<<";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// lbl_cashpayment
			// 
			this.lbl_cashpayment.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_cashpayment.Location = new System.Drawing.Point(506, 31);
			this.lbl_cashpayment.Name = "lbl_cashpayment";
			this.lbl_cashpayment.Size = new System.Drawing.Size(140, 19);
			this.lbl_cashpayment.TabIndex = 10;
			this.lbl_cashpayment.Text = "9,999,999 円";
			this.lbl_cashpayment.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_creditpayment
			// 
			this.lbl_creditpayment.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_creditpayment.Location = new System.Drawing.Point(506, 50);
			this.lbl_creditpayment.Name = "lbl_creditpayment";
			this.lbl_creditpayment.Size = new System.Drawing.Size(140, 19);
			this.lbl_creditpayment.TabIndex = 9;
			this.lbl_creditpayment.Text = "9,999,999 円";
			this.lbl_creditpayment.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label6.Location = new System.Drawing.Point(342, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(159, 19);
			this.label6.TabIndex = 8;
			this.label6.Text = "ｸﾚｼﾞｯﾄ利用額：";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label5.Location = new System.Drawing.Point(342, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(158, 19);
			this.label5.TabIndex = 7;
			this.label5.Text = "現金支出    ：";
			// 
			// lbl_totalpayment
			// 
			this.lbl_totalpayment.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_totalpayment.Location = new System.Drawing.Point(132, 50);
			this.lbl_totalpayment.Name = "lbl_totalpayment";
			this.lbl_totalpayment.Size = new System.Drawing.Size(140, 19);
			this.lbl_totalpayment.TabIndex = 6;
			this.lbl_totalpayment.Text = "9,999,999 円";
			this.lbl_totalpayment.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lbl_totalincome
			// 
			this.lbl_totalincome.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_totalincome.Location = new System.Drawing.Point(132, 31);
			this.lbl_totalincome.Name = "lbl_totalincome";
			this.lbl_totalincome.Size = new System.Drawing.Size(140, 19);
			this.lbl_totalincome.TabIndex = 5;
			this.lbl_totalincome.Text = "9,999,999 円";
			this.lbl_totalincome.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label3.Location = new System.Drawing.Point(12, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(114, 19);
			this.label3.TabIndex = 3;
			this.label3.Text = "合計支出：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label2.Location = new System.Drawing.Point(12, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(114, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "合計収入：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(114, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "今月の情報";
			// 
			// dtp
			// 
			this.dtp.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.dtp.Location = new System.Drawing.Point(880, 12);
			this.dtp.Name = "dtp";
			this.dtp.Size = new System.Drawing.Size(158, 23);
			this.dtp.TabIndex = 0;
			// 
			// tbpSQL
			// 
			this.tbpSQL.Controls.Add(this.tabPage1);
			this.tbpSQL.Controls.Add(this.tbpSearch);
			this.tbpSQL.Controls.Add(this.tabPage3);
			this.tbpSQL.Controls.Add(this.tabPage4);
			this.tbpSQL.Controls.Add(this.tabPage5);
			this.tbpSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tbpSQL.Location = new System.Drawing.Point(0, 129);
			this.tbpSQL.Name = "tbpSQL";
			this.tbpSQL.SelectedIndex = 0;
			this.tbpSQL.Size = new System.Drawing.Size(1084, 601);
			this.tbpSQL.TabIndex = 2;
			this.tbpSQL.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.lstCateSub);
			this.tabPage1.Controls.Add(this.lstCateMain);
			this.tabPage1.Controls.Add(this.dgvKBDat);
			this.tabPage1.Controls.Add(this.panel1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1076, 575);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "登録";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// lstCateSub
			// 
			this.lstCateSub.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstCateSub.FormattingEnabled = true;
			this.lstCateSub.ItemHeight = 12;
			this.lstCateSub.Location = new System.Drawing.Point(176, 165);
			this.lstCateSub.Name = "lstCateSub";
			this.lstCateSub.Size = new System.Drawing.Size(120, 88);
			this.lstCateSub.TabIndex = 3;
			this.lstCateSub.Visible = false;
			this.lstCateSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCateSub_KeyPress);
			this.lstCateSub.Leave += new System.EventHandler(this.lstCateSub_Leave);
			this.lstCateSub.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCateSub_MouseDoubleClick);
			// 
			// lstCateMain
			// 
			this.lstCateMain.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstCateMain.FormattingEnabled = true;
			this.lstCateMain.ItemHeight = 12;
			this.lstCateMain.Location = new System.Drawing.Point(12, 165);
			this.lstCateMain.Name = "lstCateMain";
			this.lstCateMain.Size = new System.Drawing.Size(120, 88);
			this.lstCateMain.TabIndex = 2;
			this.lstCateMain.Visible = false;
			this.lstCateMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCateMain_KeyPress);
			this.lstCateMain.Leave += new System.EventHandler(this.lstCateMain_Leave);
			this.lstCateMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCateMain_MouseDoubleClick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txt_masspay);
			this.panel1.Controls.Add(this.cmb_massaccount);
			this.panel1.Controls.Add(this.lbl_out);
			this.panel1.Controls.Add(this.lbl_in);
			this.panel1.Controls.Add(this.label9);
			this.panel1.Controls.Add(this.label7);
			this.panel1.Controls.Add(this.txtWhere);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.button3);
			this.panel1.Controls.Add(this.button2);
			this.panel1.Controls.Add(this.txtRID);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.btnEntry);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(3, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1070, 81);
			this.panel1.TabIndex = 1;
			// 
			// txt_masspay
			// 
			this.txt_masspay.Location = new System.Drawing.Point(358, 42);
			this.txt_masspay.Name = "txt_masspay";
			this.txt_masspay.Size = new System.Drawing.Size(157, 19);
			this.txt_masspay.TabIndex = 12;
			// 
			// cmb_massaccount
			// 
			this.cmb_massaccount.FormattingEnabled = true;
			this.cmb_massaccount.Location = new System.Drawing.Point(358, 10);
			this.cmb_massaccount.Name = "cmb_massaccount";
			this.cmb_massaccount.Size = new System.Drawing.Size(157, 20);
			this.cmb_massaccount.TabIndex = 11;
			// 
			// lbl_out
			// 
			this.lbl_out.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_out.Location = new System.Drawing.Point(653, 32);
			this.lbl_out.Name = "lbl_out";
			this.lbl_out.Size = new System.Drawing.Size(80, 12);
			this.lbl_out.TabIndex = 10;
			this.lbl_out.Text = "999,999";
			this.lbl_out.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbl_in
			// 
			this.lbl_in.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lbl_in.Location = new System.Drawing.Point(653, 12);
			this.lbl_in.Name = "lbl_in";
			this.lbl_in.Size = new System.Drawing.Size(80, 12);
			this.lbl_in.TabIndex = 9;
			this.lbl_in.Text = "999,999";
			this.lbl_in.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label9.Location = new System.Drawing.Point(552, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(95, 12);
			this.label9.TabIndex = 8;
			this.label9.Text = "入力支出合計 : ";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.label7.Location = new System.Drawing.Point(552, 13);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 12);
			this.label7.TabIndex = 7;
			this.label7.Text = "入力収入合計 : ";
			// 
			// txtWhere
			// 
			this.txtWhere.Location = new System.Drawing.Point(69, 37);
			this.txtWhere.Name = "txtWhere";
			this.txtWhere.Size = new System.Drawing.Size(146, 19);
			this.txtWhere.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 42);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "場所";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(766, 13);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(93, 51);
			this.button3.TabIndex = 4;
			this.button3.Text = "クリア";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 7);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "レシートID発行";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtRID
			// 
			this.txtRID.Location = new System.Drawing.Point(69, 9);
			this.txtRID.Name = "txtRID";
			this.txtRID.Size = new System.Drawing.Size(146, 19);
			this.txtRID.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 13);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 12);
			this.label8.TabIndex = 1;
			this.label8.Text = "レシートID";
			// 
			// btnEntry
			// 
			this.btnEntry.Location = new System.Drawing.Point(865, 13);
			this.btnEntry.Name = "btnEntry";
			this.btnEntry.Size = new System.Drawing.Size(193, 51);
			this.btnEntry.TabIndex = 0;
			this.btnEntry.Text = "登録";
			this.btnEntry.UseVisualStyleBackColor = true;
			this.btnEntry.Click += new System.EventHandler(this.btnEntry_Click);
			// 
			// tbpSearch
			// 
			this.tbpSearch.Controls.Add(this.kbDatList1);
			this.tbpSearch.Controls.Add(this.panel2);
			this.tbpSearch.Location = new System.Drawing.Point(4, 22);
			this.tbpSearch.Name = "tbpSearch";
			this.tbpSearch.Size = new System.Drawing.Size(1076, 575);
			this.tbpSearch.TabIndex = 5;
			this.tbpSearch.Text = "検索";
			this.tbpSearch.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1076, 124);
			this.panel2.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.tabControl2);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(1076, 575);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "設定";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			this.tabControl2.Controls.Add(this.tbpCategory);
			this.tabControl2.Controls.Add(this.tbpBalance);
			this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl2.Location = new System.Drawing.Point(0, 0);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(1076, 575);
			this.tabControl2.TabIndex = 0;
			this.tabControl2.Enter += new System.EventHandler(this.tabControl2_Enter);
			// 
			// tbpCategory
			// 
			this.tbpCategory.Controls.Add(this.button1);
			this.tbpCategory.Controls.Add(this.dgvCateSub);
			this.tbpCategory.Controls.Add(this.dgvCateMain);
			this.tbpCategory.Location = new System.Drawing.Point(4, 22);
			this.tbpCategory.Name = "tbpCategory";
			this.tbpCategory.Padding = new System.Windows.Forms.Padding(3);
			this.tbpCategory.Size = new System.Drawing.Size(1068, 549);
			this.tbpCategory.TabIndex = 0;
			this.tbpCategory.Text = "Category";
			this.tbpCategory.UseVisualStyleBackColor = true;
			this.tbpCategory.Enter += new System.EventHandler(this.tbpCategory_Enter);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(894, 41);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(125, 45);
			this.button1.TabIndex = 2;
			this.button1.Text = "登録";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// dgvCateSub
			// 
			this.dgvCateSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCateSub.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id_sub,
            this.col_id_cate_main,
            this.col_sortid_sub,
            this.col_cate_sub});
			this.dgvCateSub.Location = new System.Drawing.Point(409, 15);
			this.dgvCateSub.Name = "dgvCateSub";
			this.dgvCateSub.RowTemplate.Height = 21;
			this.dgvCateSub.Size = new System.Drawing.Size(320, 515);
			this.dgvCateSub.TabIndex = 1;
			this.dgvCateSub.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCateSub_MouseClick);
			// 
			// col_id_sub
			// 
			this.col_id_sub.HeaderText = "id";
			this.col_id_sub.Name = "col_id_sub";
			this.col_id_sub.Width = 50;
			// 
			// col_id_cate_main
			// 
			this.col_id_cate_main.HeaderText = "id_cate_main";
			this.col_id_cate_main.Name = "col_id_cate_main";
			this.col_id_cate_main.Visible = false;
			// 
			// col_sortid_sub
			// 
			this.col_sortid_sub.HeaderText = "sortid_sub";
			this.col_sortid_sub.Name = "col_sortid_sub";
			this.col_sortid_sub.Visible = false;
			// 
			// col_cate_sub
			// 
			this.col_cate_sub.HeaderText = "詳細";
			this.col_cate_sub.Name = "col_cate_sub";
			this.col_cate_sub.Width = 200;
			// 
			// dgvCateMain
			// 
			this.dgvCateMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCateMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_id_main,
            this.col_sortid_main,
            this.col_cate_main});
			this.dgvCateMain.Location = new System.Drawing.Point(17, 15);
			this.dgvCateMain.Name = "dgvCateMain";
			this.dgvCateMain.RowTemplate.Height = 21;
			this.dgvCateMain.Size = new System.Drawing.Size(320, 515);
			this.dgvCateMain.TabIndex = 0;
			this.dgvCateMain.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCateMain_CellClick);
			this.dgvCateMain.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCateMain_CellEnter);
			// 
			// col_id_main
			// 
			this.col_id_main.HeaderText = "id";
			this.col_id_main.Name = "col_id_main";
			this.col_id_main.Width = 50;
			// 
			// col_sortid_main
			// 
			this.col_sortid_main.HeaderText = "sortid";
			this.col_sortid_main.Name = "col_sortid_main";
			this.col_sortid_main.Visible = false;
			// 
			// col_cate_main
			// 
			this.col_cate_main.HeaderText = "大項目";
			this.col_cate_main.Name = "col_cate_main";
			this.col_cate_main.Width = 200;
			// 
			// tbpBalance
			// 
			this.tbpBalance.Controls.Add(this.btnEntryBLC);
			this.tbpBalance.Controls.Add(this.dgvBalance);
			this.tbpBalance.Location = new System.Drawing.Point(4, 22);
			this.tbpBalance.Name = "tbpBalance";
			this.tbpBalance.Padding = new System.Windows.Forms.Padding(3);
			this.tbpBalance.Size = new System.Drawing.Size(1068, 549);
			this.tbpBalance.TabIndex = 1;
			this.tbpBalance.Text = "口座";
			this.tbpBalance.UseVisualStyleBackColor = true;
			this.tbpBalance.Enter += new System.EventHandler(this.tbpBalance_Enter);
			// 
			// btnEntryBLC
			// 
			this.btnEntryBLC.Location = new System.Drawing.Point(711, 6);
			this.btnEntryBLC.Name = "btnEntryBLC";
			this.btnEntryBLC.Size = new System.Drawing.Size(169, 75);
			this.btnEntryBLC.TabIndex = 1;
			this.btnEntryBLC.Text = "登録";
			this.btnEntryBLC.UseVisualStyleBackColor = true;
			this.btnEntryBLC.Click += new System.EventHandler(this.btnEntryBLC_Click);
			// 
			// dgvBalance
			// 
			this.dgvBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvBalance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.blc_id,
            this.blc_name,
            this.blc_eot,
            this.blc_type,
            this.blc_initval});
			this.dgvBalance.Location = new System.Drawing.Point(8, 6);
			this.dgvBalance.Name = "dgvBalance";
			this.dgvBalance.RowTemplate.Height = 21;
			this.dgvBalance.Size = new System.Drawing.Size(574, 402);
			this.dgvBalance.TabIndex = 0;
			// 
			// blc_id
			// 
			this.blc_id.HeaderText = "id";
			this.blc_id.Name = "blc_id";
			// 
			// blc_name
			// 
			this.blc_name.HeaderText = "口座名";
			this.blc_name.Name = "blc_name";
			// 
			// blc_eot
			// 
			this.blc_eot.HeaderText = "締め日";
			this.blc_eot.Name = "blc_eot";
			// 
			// blc_type
			// 
			this.blc_type.HeaderText = "種別";
			this.blc_type.Name = "blc_type";
			// 
			// blc_initval
			// 
			this.blc_initval.HeaderText = "初期金額";
			this.blc_initval.Name = "blc_initval";
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.cmbBalanceMonth);
			this.tabPage4.Controls.Add(this.lvStatistics);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(1076, 575);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "残高一覧";
			this.tabPage4.UseVisualStyleBackColor = true;
			this.tabPage4.Enter += new System.EventHandler(this.tabPage4_Enter);
			// 
			// cmbBalanceMonth
			// 
			this.cmbBalanceMonth.BackColor = System.Drawing.SystemColors.Window;
			this.cmbBalanceMonth.FormattingEnabled = true;
			this.cmbBalanceMonth.Location = new System.Drawing.Point(12, 15);
			this.cmbBalanceMonth.Name = "cmbBalanceMonth";
			this.cmbBalanceMonth.Size = new System.Drawing.Size(121, 20);
			this.cmbBalanceMonth.TabIndex = 2;
			this.cmbBalanceMonth.SelectedIndexChanged += new System.EventHandler(this.cmbBalanceMonth_SelectedIndexChanged);
			// 
			// lvStatistics
			// 
			this.lvStatistics.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lvStatistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colhdr0,
            this.colhdr1,
            this.colhdr2,
            this.colhdr3,
            this.colhdr4,
            this.colhdr5,
            this.colhdr6});
			this.lvStatistics.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lvStatistics.FullRowSelect = true;
			this.lvStatistics.GridLines = true;
			this.lvStatistics.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lvStatistics.LabelEdit = true;
			this.lvStatistics.Location = new System.Drawing.Point(8, 67);
			this.lvStatistics.Name = "lvStatistics";
			this.lvStatistics.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lvStatistics.Size = new System.Drawing.Size(646, 500);
			this.lvStatistics.TabIndex = 1;
			this.lvStatistics.UseCompatibleStateImageBehavior = false;
			this.lvStatistics.View = System.Windows.Forms.View.Details;
			// 
			// colhdr0
			// 
			this.colhdr0.Text = "詳細";
			this.colhdr0.Width = 120;
			// 
			// colhdr1
			// 
			this.colhdr1.Text = "";
			this.colhdr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr1.Width = 80;
			// 
			// colhdr2
			// 
			this.colhdr2.Text = "";
			this.colhdr2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr2.Width = 80;
			// 
			// colhdr3
			// 
			this.colhdr3.Text = "";
			this.colhdr3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr3.Width = 80;
			// 
			// colhdr4
			// 
			this.colhdr4.Text = "";
			this.colhdr4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr4.Width = 80;
			// 
			// colhdr5
			// 
			this.colhdr5.Text = "";
			this.colhdr5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr5.Width = 80;
			// 
			// colhdr6
			// 
			this.colhdr6.Text = "";
			this.colhdr6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.colhdr6.Width = 80;
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.button6);
			this.tabPage5.Controls.Add(this.txtSQL);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Size = new System.Drawing.Size(1076, 575);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "SQL";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(506, 44);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(75, 23);
			this.button6.TabIndex = 1;
			this.button6.Text = "SQL実行";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// txtSQL
			// 
			this.txtSQL.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.txtSQL.Location = new System.Drawing.Point(32, 34);
			this.txtSQL.Multiline = true;
			this.txtSQL.Name = "txtSQL";
			this.txtSQL.Size = new System.Drawing.Size(407, 311);
			this.txtSQL.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smDeleteRow,
            this.smInsertRow});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
			this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
			// 
			// smDeleteRow
			// 
			this.smDeleteRow.Name = "smDeleteRow";
			this.smDeleteRow.Size = new System.Drawing.Size(124, 22);
			this.smDeleteRow.Text = "行を削除";
			// 
			// smInsertRow
			// 
			this.smInsertRow.Name = "smInsertRow";
			this.smInsertRow.Size = new System.Drawing.Size(124, 22);
			this.smInsertRow.Text = "行を削除";
			// 
			// kbDatList1
			// 
			this.kbDatList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.kbDatList1.Location = new System.Drawing.Point(0, 124);
			this.kbDatList1.Name = "kbDatList1";
			this.kbDatList1.Size = new System.Drawing.Size(1076, 451);
			this.kbDatList1.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1084, 730);
			this.Controls.Add(this.tbpSQL);
			this.Controls.Add(this.toppane);
			this.Name = "Form1";
			this.Text = "家計簿";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvKBDat)).EndInit();
			this.toppane.ResumeLayout(false);
			this.toppane.PerformLayout();
			this.tbpSQL.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tbpSearch.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabControl2.ResumeLayout(false);
			this.tbpCategory.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCateSub)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCateMain)).EndInit();
			this.tbpBalance.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvBalance)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKBDat;
        private System.Windows.Forms.Panel toppane;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.TabControl tbpSQL;
        private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_totalpayment;
        private System.Windows.Forms.Label lbl_totalincome;
        private System.Windows.Forms.TextBox txtRID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEntry;
        private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtWhere;
		private System.Windows.Forms.TabControl tabControl2;
		private System.Windows.Forms.TabPage tbpCategory;
		private System.Windows.Forms.TabPage tbpBalance;
		private System.Windows.Forms.DataGridView dgvCateSub;
		private System.Windows.Forms.DataGridView dgvCateMain;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbl_cashpayment;
		private System.Windows.Forms.Label lbl_creditpayment;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_cate_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_sortid_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_sortid_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_main;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem smDeleteRow;
		private System.Windows.Forms.ToolStripMenuItem smInsertRow;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button btnEntryBLC;
		private System.Windows.Forms.DataGridView dgvBalance;
		private System.Windows.Forms.DataGridViewTextBoxColumn blc_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn blc_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn blc_eot;
		private System.Windows.Forms.DataGridViewTextBoxColumn blc_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn blc_initval;
		private System.Windows.Forms.TabPage tabPage5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.TextBox txtSQL;
		private System.Windows.Forms.ListBox lstCateMain;
		private System.Windows.Forms.DataGridViewTextBoxColumn buy_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn cate_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn cate_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn income;
		private System.Windows.Forms.DataGridViewTextBoxColumn payment;
		private System.Windows.Forms.DataGridViewTextBoxColumn name;
		private System.Windows.Forms.DataGridViewComboBoxColumn balance;
		private System.Windows.Forms.DataGridViewTextBoxColumn pay_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn where;
		private System.Windows.Forms.DataGridViewTextBoxColumn memo;
		private System.Windows.Forms.ListBox lstCateSub;
		private System.Windows.Forms.Label lbl_out;
		private System.Windows.Forms.Label lbl_in;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cmb_massaccount;
		private System.Windows.Forms.TextBox txt_masspay;
		private System.Windows.Forms.ListView lvStatistics;
		private System.Windows.Forms.ColumnHeader colhdr2;
		private System.Windows.Forms.ColumnHeader colhdr3;
		private System.Windows.Forms.ColumnHeader colhdr4;
		private System.Windows.Forms.ColumnHeader colhdr5;
		private System.Windows.Forms.ColumnHeader colhdr6;
		private System.Windows.Forms.ColumnHeader colhdr0;
		public System.Windows.Forms.ColumnHeader colhdr1;
		private System.Windows.Forms.ComboBox cmbBalanceMonth;
		private System.Windows.Forms.TabPage tbpSearch;
		private System.Windows.Forms.Panel panel2;
		private KBDatList kbDatList1;
    }
}

