namespace Kakeibo
{
	partial class KBDatList
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

		#region コンポーネント デザイナーで生成されたコード

		/// <summary> 
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvKBList = new System.Windows.Forms.DataGridView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.DelRowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lstCateMain = new System.Windows.Forms.ListBox();
			this.lstCateSub = new System.Windows.Forms.ListBox();
			this.lstAccount = new System.Windows.Forms.ListBox();
			this.col_buy_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_income = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_account = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_where = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_ie_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvKBList)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvKBList
			// 
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvKBList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvKBList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvKBList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_buy_date,
            this.col_cate_main,
            this.col_cate_sub,
            this.col_income,
            this.col_payment,
            this.col_name,
            this.col_account,
            this.col_pay_date,
            this.col_where,
            this.col_memo,
            this.col_id,
            this.col_id_usr,
            this.col_ie_type,
            this.col_rid});
			this.dgvKBList.ContextMenuStrip = this.contextMenuStrip1;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvKBList.DefaultCellStyle = dataGridViewCellStyle4;
			this.dgvKBList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKBList.Location = new System.Drawing.Point(0, 0);
			this.dgvKBList.Name = "dgvKBList";
			this.dgvKBList.RowTemplate.Height = 21;
			this.dgvKBList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.dgvKBList.Size = new System.Drawing.Size(1088, 475);
			this.dgvKBList.TabIndex = 0;
			this.dgvKBList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvKBList_CellBeginEdit);
			this.dgvKBList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellClick);
			this.dgvKBList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellEndEdit);
			this.dgvKBList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellEnter);
			this.dgvKBList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellLeave);
			this.dgvKBList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvKBList_CellMouseClick);
			this.dgvKBList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellValueChanged);
			this.dgvKBList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKBList_KeyDown);
			this.dgvKBList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvKBList_KeyPress);
			this.dgvKBList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvKBList_KeyUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DelRowToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
			// 
			// DelRowToolStripMenuItem
			// 
			this.DelRowToolStripMenuItem.Name = "DelRowToolStripMenuItem";
			this.DelRowToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.DelRowToolStripMenuItem.Text = "行を削除";
			this.DelRowToolStripMenuItem.ToolTipText = "現在選択されているセルの行を削除します";
			this.DelRowToolStripMenuItem.Click += new System.EventHandler(this.DelRowToolStripMenuItem_Click);
			// 
			// lstCateMain
			// 
			this.lstCateMain.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstCateMain.FormattingEnabled = true;
			this.lstCateMain.ItemHeight = 12;
			this.lstCateMain.Location = new System.Drawing.Point(21, 159);
			this.lstCateMain.Name = "lstCateMain";
			this.lstCateMain.Size = new System.Drawing.Size(120, 88);
			this.lstCateMain.TabIndex = 1;
			this.lstCateMain.Visible = false;
			this.lstCateMain.VisibleChanged += new System.EventHandler(this.lstCateMain_VisibleChanged);
			this.lstCateMain.Enter += new System.EventHandler(this.lstCateMain_Enter);
			this.lstCateMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCateMain_KeyPress);
			this.lstCateMain.Leave += new System.EventHandler(this.lstCateMain_Leave);
			this.lstCateMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCateMain_MouseDoubleClick);
			// 
			// lstCateSub
			// 
			this.lstCateSub.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstCateSub.FormattingEnabled = true;
			this.lstCateSub.ItemHeight = 12;
			this.lstCateSub.Location = new System.Drawing.Point(208, 159);
			this.lstCateSub.Name = "lstCateSub";
			this.lstCateSub.Size = new System.Drawing.Size(120, 88);
			this.lstCateSub.TabIndex = 2;
			this.lstCateSub.Visible = false;
			this.lstCateSub.VisibleChanged += new System.EventHandler(this.lstCateSub_VisibleChanged);
			this.lstCateSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCateSub_KeyPress);
			this.lstCateSub.Leave += new System.EventHandler(this.lstCateSub_Leave);
			this.lstCateSub.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCateSub_MouseDoubleClick);
			// 
			// lstAccount
			// 
			this.lstAccount.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.lstAccount.FormattingEnabled = true;
			this.lstAccount.ItemHeight = 12;
			this.lstAccount.Location = new System.Drawing.Point(424, 159);
			this.lstAccount.Name = "lstAccount";
			this.lstAccount.Size = new System.Drawing.Size(130, 88);
			this.lstAccount.TabIndex = 3;
			this.lstAccount.Visible = false;
			this.lstAccount.VisibleChanged += new System.EventHandler(this.lstAccount_VisibleChanged);
			this.lstAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstAccount_KeyPress);
			this.lstAccount.Leave += new System.EventHandler(this.lstAccount_Leave);
			this.lstAccount.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstAccount_MouseDoubleClick);
			// 
			// col_buy_date
			// 
			this.col_buy_date.HeaderText = "日付";
			this.col_buy_date.Name = "col_buy_date";
			this.col_buy_date.Width = 80;
			// 
			// col_cate_main
			// 
			this.col_cate_main.HeaderText = "費目";
			this.col_cate_main.Name = "col_cate_main";
			// 
			// col_cate_sub
			// 
			this.col_cate_sub.HeaderText = "詳細";
			this.col_cate_sub.Name = "col_cate_sub";
			// 
			// col_income
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.col_income.DefaultCellStyle = dataGridViewCellStyle2;
			this.col_income.HeaderText = "収入";
			this.col_income.Name = "col_income";
			this.col_income.Width = 80;
			// 
			// col_payment
			// 
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			this.col_payment.DefaultCellStyle = dataGridViewCellStyle3;
			this.col_payment.HeaderText = "支出";
			this.col_payment.Name = "col_payment";
			this.col_payment.Width = 80;
			// 
			// col_name
			// 
			this.col_name.HeaderText = "品名";
			this.col_name.Name = "col_name";
			this.col_name.Width = 160;
			// 
			// col_account
			// 
			this.col_account.HeaderText = "口座";
			this.col_account.Name = "col_account";
			this.col_account.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col_account.Width = 130;
			// 
			// col_pay_date
			// 
			this.col_pay_date.HeaderText = "取扱日";
			this.col_pay_date.Name = "col_pay_date";
			this.col_pay_date.Width = 80;
			// 
			// col_where
			// 
			this.col_where.HeaderText = "場所";
			this.col_where.Name = "col_where";
			// 
			// col_memo
			// 
			this.col_memo.HeaderText = "メモ";
			this.col_memo.Name = "col_memo";
			// 
			// col_id
			// 
			this.col_id.HeaderText = "id";
			this.col_id.Name = "col_id";
			this.col_id.Visible = false;
			// 
			// col_id_usr
			// 
			this.col_id_usr.HeaderText = "id_usr";
			this.col_id_usr.Name = "col_id_usr";
			this.col_id_usr.Visible = false;
			// 
			// col_ie_type
			// 
			this.col_ie_type.HeaderText = "ie_type";
			this.col_ie_type.Name = "col_ie_type";
			this.col_ie_type.Visible = false;
			// 
			// col_rid
			// 
			this.col_rid.HeaderText = "rid";
			this.col_rid.Name = "col_rid";
			this.col_rid.Visible = false;
			// 
			// KBDatList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.lstAccount);
			this.Controls.Add(this.lstCateSub);
			this.Controls.Add(this.lstCateMain);
			this.Controls.Add(this.dgvKBList);
			this.Name = "KBDatList";
			this.Size = new System.Drawing.Size(1088, 475);
			((System.ComponentModel.ISupportInitialize)(this.dgvKBList)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvKBList;
		private System.Windows.Forms.ListBox lstCateMain;
		private System.Windows.Forms.ListBox lstCateSub;
		private System.Windows.Forms.ListBox lstAccount;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem DelRowToolStripMenuItem;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_income;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_payment;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_account;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_where;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_memo;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_usr;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_ie_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_rid;
	}
}
