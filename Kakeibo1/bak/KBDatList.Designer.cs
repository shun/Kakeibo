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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgvKBList = new System.Windows.Forms.DataGridView();
			this.lstCateMain = new System.Windows.Forms.ListBox();
			this.lstCateSub = new System.Windows.Forms.ListBox();
			this.col_buy_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_main = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_cate_sub = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_income = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_account = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.col_pay_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_where = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_id_usr = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_ie_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.col_rid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvKBList)).BeginInit();
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
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvKBList.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvKBList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvKBList.Location = new System.Drawing.Point(0, 0);
			this.dgvKBList.Name = "dgvKBList";
			this.dgvKBList.RowTemplate.Height = 21;
			this.dgvKBList.Size = new System.Drawing.Size(1088, 475);
			this.dgvKBList.TabIndex = 0;
			this.dgvKBList.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvKBList_CellBeginEdit);
			this.dgvKBList.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellEndEdit);
			this.dgvKBList.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellLeave);
			this.dgvKBList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKBList_CellValueChanged);
			this.dgvKBList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvKBList_KeyDown);
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
			this.lstCateSub.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstCateSub_KeyPress);
			this.lstCateSub.Leave += new System.EventHandler(this.lstCateSub_Leave);
			this.lstCateSub.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstCateSub_MouseDoubleClick);
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
			this.col_income.HeaderText = "収入";
			this.col_income.Name = "col_income";
			this.col_income.Width = 80;
			// 
			// col_payment
			// 
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
			this.col_account.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
			this.col_account.HeaderText = "口座";
			this.col_account.Name = "col_account";
			this.col_account.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.col_account.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
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
			this.Controls.Add(this.lstCateSub);
			this.Controls.Add(this.lstCateMain);
			this.Controls.Add(this.dgvKBList);
			this.Name = "KBDatList";
			this.Size = new System.Drawing.Size(1088, 475);
			((System.ComponentModel.ISupportInitialize)(this.dgvKBList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvKBList;
		private System.Windows.Forms.ListBox lstCateMain;
		private System.Windows.Forms.ListBox lstCateSub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_buy_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_main;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_cate_sub;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_income;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_payment;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_name;
		private System.Windows.Forms.DataGridViewComboBoxColumn col_account;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_pay_date;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_where;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_memo;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_id_usr;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_ie_type;
		private System.Windows.Forms.DataGridViewTextBoxColumn col_rid;
	}
}
