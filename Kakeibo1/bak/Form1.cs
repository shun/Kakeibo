using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Configuration;

namespace Kakeibo
{
    public partial class Form1 : Form
    {
		List<CateMainRec> cate_main_lst;
		List<CateSubRec> cate_sub_lst;
		List<AccountRec> account_lst;
		Int16 id_usr;
		ListBox lstbox;

		public Form1()
        {
			try
			{
				InitializeComponent();

				id_usr = Int16.Parse(ConfigurationManager.AppSettings["id_usr"]);
				cate_main_lst = new List<CateMainRec>();
				cate_sub_lst = new List<CateSubRec>();
				updateCategory();
				this.dgvCateSub.ContextMenuStrip = this.contextMenuStrip1;
				lstbox = new ListBox();
				txt_masspay.Text = "";
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

		}

        private void Form1_Load(object sender, EventArgs e)
        {
			try
			{
				KBDatabase kdb = new KBDatabase();
				string[] stDate, edDate;
				DateTime sDate, eDate, wkDate;

				this.lbl_totalincome.Text = "0 円";
				this.lbl_totalpayment.Text = "0 円";
				this.lbl_cashpayment.Text = "0 円";
				this.lbl_creditpayment.Text = "0 円";
				lbl_in.Text = "0 円";
				lbl_out.Text = "0 円";
				updateBalance();

				account_lst = kdb.getAccountRec();
				cmb_massaccount.Items.Clear();
				cmb_massaccount.Items.Add("");

				kbDatList1.setAccountList(account_lst);

				string str = "";
				foreach (AccountRec rec in account_lst)
				{
					str = String.Format("{0, 3}:{1}", rec.id, rec.name);
					balance.Items.Add(str);
					cmb_massaccount.Items.Add(str);
				}
				this.Text += " Ver 0.0.4";
				cmb_massaccount.SelectedIndex = 0;
				this.Location = new Point(Location.X, 0);
				stDate = kdb.getMinDate().Split('-');
				edDate = kdb.getMaxDate().Split('-');
				sDate = new DateTime(int.Parse(stDate[0]), int.Parse(stDate[1]), 1);
				eDate = new DateTime(int.Parse(edDate[0]), int.Parse(edDate[1]) + 1, 1);
				wkDate = sDate;
				while (!wkDate.Equals(eDate))
				{
					cmbBalanceMonth.Items.Add(String.Format("{0}-{1:D2}", wkDate.Year, wkDate.Month));
					wkDate = wkDate.AddMonths(1);
				}

				cmbBalanceMonth.SelectedItem = String.Format("{0}-{1:D2}", DateTime.Today.Year, DateTime.Today.Month);

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void updateBalance()
		{
			DateTime stDate, edDate;
			KBDatabase kdb = new KBDatabase();

			stDate = new DateTime(dtp.Value.Year, dtp.Value.Month, 1);
			edDate = new DateTime(dtp.Value.Year, dtp.Value.Month, stDate.AddMonths(1).AddDays(-1).Day);
			// 収支
			lbl_totalincome.Text = kdb.getTotalIncome(stDate, edDate).ToString("#,##0 円");
			// 支出
			lbl_totalpayment.Text = kdb.getTotalPayment(stDate, edDate).ToString("#,##0 円");
			// 現金支出
			lbl_cashpayment.Text = kdb.getTotalCashPayment(stDate, edDate).ToString("#,##0 円");
			// クレジット利用額
			lbl_creditpayment.Text = kdb.getTotalCreditPayment(stDate, edDate).ToString("#,##0 円");
		}

        private void button3_Click(object sender, EventArgs e)
        {
            dgvKBDat.Rows.Clear();
        }

        const int ROW_GAP = 10;
        const int COL_GAP = 10;

		private void mkStatisticsList()
		{
			int i = 0;
			int cur_grp = -1;
			int id_cate_main = -1;
			int subidx = 0;
			DateTime sDate;
			string[] wk;
			KBDatabase kdb = new KBDatabase();
			int money = 0;
			int colcnt = 0;

			lvStatistics.SuspendLayout();
			foreach (ColumnHeader cl in lvStatistics.Columns)
			{
				cl.Text = "";
			}
			lvStatistics.Groups.Clear();
			lvStatistics.Items.Clear();

			wk = cmbBalanceMonth.SelectedItem.ToString().Split('-');
			sDate = new DateTime(int.Parse(wk[0]), int.Parse(wk[1]), 1);

			for (i = 0; i < cate_main_lst.Count; i++)
			{
				lvStatistics.Groups.Add(cate_main_lst[i].name, cate_main_lst[i].name);
			}

			for (i = 0; i < cate_sub_lst.Count; i++)
			{
				lvStatistics.Items.Add(cate_sub_lst[i].name, cate_sub_lst[i].name);
				if (cate_sub_lst[i].id_cate_main != id_cate_main)
				{
					cur_grp++;
					id_cate_main = cate_sub_lst[i].id_cate_main;
					subidx = 0;
				}
				else
				{
					subidx++;
				}
				lvStatistics.Items[i].Group = lvStatistics.Groups[cur_grp];

				if (0 == subidx % 2)
				{
					lvStatistics.Items[i].BackColor = Color.Thistle;

				}
			}

			int row = 0, col = 0;

			colcnt = cmbBalanceMonth.Items.Count - cmbBalanceMonth.SelectedIndex;
			for (col = 1; col <= colcnt; col++)
			{
				lvStatistics.Columns[col].Text = String.Format("{0}-{1:D2}", sDate.Year, sDate.Month);
				for (row = 0; row < lvStatistics.Items.Count; row++)
				{
					money = kdb.getTotalMoney(sDate, sDate.AddMonths(1).AddDays(-1), KBDatabase.KBDAT_TYPE_PAYMENT , cate_sub_lst[row].id_cate_main, cate_sub_lst[row].id);
					lvStatistics.Items[row].SubItems.Add(money.ToString("#,#0"));
					//lvStatistics.Items[row].SubItems[col].
				}
				sDate = sDate.AddMonths(1);
			}
			lvStatistics.GridLines = true;
			lvStatistics.ResumeLayout();
		}
		private void tabPage4_Enter(object sender, EventArgs e)
        {
		//	mkStatisticsList();
        }

        private void btnEntry_Click(object sender, EventArgs e)
        {
			int i = 0;
			int maxid = -1;
			List<KBRec> rec;
			KBRec wkrec;
			KBDatabase kdb = new KBDatabase();
			string[] wkdate;

			rec = new List<KBRec>();
			wkrec = new KBRec();

			maxid = kdb.getMaxKBDatId();
			for (i = 0; i < dgvKBDat.Rows.Count - 1; i++)
			{
				wkrec.id = ++maxid;
				if (null == dgvKBDat.Rows[i].Cells["buy_date"].Value)
				{
					wkrec.buy_date = String.Format("{0}-{1:D2}-{2:D2}", dtp.Value.Year, dtp.Value.Month, dtp.Value.Day);
				}
				else
				{
					wkdate = ((string)dgvKBDat.Rows[i].Cells["buy_date"].Value).Split('-');
					wkrec.buy_date = String.Format("{0}-{1:D2}-{2:D2}", Int32.Parse(wkdate[0]), Int32.Parse(wkdate[1]), Int32.Parse(wkdate[2])); ;
				}


				if (txtWhere.Text.Trim().Length == 0)
				{
					if (null == dgvKBDat.Rows[i].Cells["where"].Value)
					{
						wkrec.where = "";
					}
					else
					{
						wkrec.where = (string)dgvKBDat.Rows[i].Cells["where"].Value;
					}
				}
				else
				{
					wkrec.where = txtWhere.Text;
				}
				wkrec.rid = txtRID.Text.Trim().Length == 0 ? -1 :  Int32.Parse(txtRID.Text);

				if ((null == dgvKBDat.Rows[i].Cells["income"].Value) || (0 == ((string)dgvKBDat.Rows[i].Cells["income"].Value).Trim().Length))
				{
					// 支出
					wkrec.ie_type = 0;
					wkrec.money = int.Parse(((string)dgvKBDat.Rows[i].Cells["payment"].Value).Trim());
				}
				else if ((null == dgvKBDat.Rows[i].Cells["payment"].Value) || (0 == ((string)dgvKBDat.Rows[i].Cells["payment"].Value).Trim().Length))
				{
					// 収入
					wkrec.ie_type = 1;
					wkrec.money = int.Parse(((string)dgvKBDat.Rows[i].Cells["income"].Value).Trim());
				}
				else
				{
					MessageBox.Show(i.ToString() + " 行目の金額を入力してください。");
				}

				wkrec.name = (string)dgvKBDat.Rows[i].Cells["name"].Value;
				wkrec.cate_main = Int16.Parse(((string)dgvKBDat.Rows[i].Cells["cate_main"].Value).Split(':')[0].Trim());
				wkrec.cate_sub = Int16.Parse(((string)dgvKBDat.Rows[i].Cells["cate_sub"].Value).Split(':')[0].Trim());
				wkrec.id_usr = this.id_usr;
				if ((null == dgvKBDat.Rows[i].Cells["memo"].Value) || (((string)dgvKBDat.Rows[i].Cells["memo"].Value).Trim().Length == 0))
				{
					wkrec.memo = "";
				}
				else
				{
					wkrec.memo = (string)dgvKBDat.Rows[i].Cells["memo"].Value;
				}

				if (cmb_massaccount.SelectedIndex != 0)
				{
					string[] wk;
					DateTime dt;
					int eot = kdb.getEOT(int.Parse((cmb_massaccount.SelectedItem.ToString().Split(':')[0].Trim())));
					wkrec.id_accaount = Int16.Parse(cmb_massaccount.SelectedItem.ToString().Split(':')[0].Trim());
					if (eot != 0)
					{
						wk = ((string)dgvKBDat.Rows[i].Cells["buy_date"].Value).Split('-');

						dt = new DateTime(int.Parse(wk[0]), int.Parse(wk[1]), eot);
						dt = dt.AddMonths(1);
						wkrec.pay_date = String.Format("{0}-{1}-{2}", dt.Year, dt.Month, dt.Day);
					}
					else
					{
						wkrec.pay_date = wkrec.buy_date;
					}
				}
				else
				{
					wkrec.id_accaount = Int16.Parse(((string)dgvKBDat.Rows[i].Cells["balance"].Value).Split(':')[0].Trim());
					wkdate = ((string)dgvKBDat.Rows[i].Cells["pay_date"].Value).Split('-');
					wkrec.pay_date = String.Format("{0}-{1:D2}-{2:D2}", Int32.Parse(wkdate[0]), Int32.Parse(wkdate[1]), Int32.Parse(wkdate[2])); ;

				}
				rec.Add(wkrec);
			}
			kdb.entryKBData(rec);
			updateBalance();
			dgvKBDat.Rows.Clear();
			txtRID.Text = "";
			txtWhere.Text = "";
			lbl_in.Text = "0 円";
			lbl_out.Text = "0 円";
			cmb_massaccount.SelectedIndex = 0;
			txt_masspay.Text = "";

			// cate_sub.Items.Clear();
			
		}

		private void updateCategory()
		{
			// 保持しているメインカテゴリ・サブカテゴリを更新する
			KBDatabase kdb;
			string str = "";

			cate_main_lst.Clear();
			cate_sub_lst.Clear();

			kdb = new KBDatabase();

			cate_main_lst = kdb.getCateMainRec();
			cate_sub_lst = kdb.getCateSubRec();

			kbDatList1.setCateMainList(cate_main_lst);
			kbDatList1.setCateSubList(cate_sub_lst);

			lstCateMain.Items.Clear();
			foreach(CateMainRec rec in cate_main_lst)
			{
				str = String.Format("{0,3}:{1}", rec.id, rec.name);
				//cate_main.Items.Add(str);
				lstCateMain.Items.Add(str);
			}
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			int selectedIdx = -1;

			selectedIdx = ((TabControl)sender).SelectedIndex;

			switch (selectedIdx)
			{
				case 2:
					this.tabControl2.SelectedIndex = 0;
					this.tabControl2.TabPages[0].Focus();
					break;
				default :
					break;
			}
		}

		private void tbpCategory_Enter(object sender, EventArgs e)
		{
			int i = 0, num = 0;
			Console.WriteLine("tbpCategory_Enter");
			// メインカテゴリ・サブカテゴリを設定する
			this.dgvCateMain.Rows.Clear();
			this.dgvCateSub.Rows.Clear();

			num = cate_main_lst.Count;
			for (i = 0; i < num; i++)
			{
				dgvCateMain.Rows.Add(cate_main_lst[i].id.ToString(), cate_main_lst[i].sortid.ToString(), cate_main_lst[i].name);
			}

//			dgvCateMain.Rows[0].Cells["col_id_main"].Selected = true;
			dgvCateMain.Rows[0].Cells["col_cate_main"].Selected = true;
			
		}

		private void dgvCateMain_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			bool entry = false;
			dgvCateSub.Rows.Clear();

			if (e.RowIndex == dgvCateMain.Rows.Count-1) return;

			if (null == dgvCateMain.Rows[e.RowIndex].Cells["col_cate_main"].Value) return;
			foreach (CateSubRec rec in cate_sub_lst)
			{
				if (rec.id_cate_main == Int16.Parse(dgvCateMain.Rows[e.RowIndex].Cells["col_id_main"].Value.ToString()))
				{
					entry = true;
					dgvCateSub.Rows.Add(rec.id.ToString(), rec.sortid.ToString(), rec.id_cate_main, rec.name);
				}
				else if (entry)
				{
					break;
				}

			}

		}

		private void dgvCateMain_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			Console.WriteLine("dgvCateMain_CellEnter");
		}

		private void dgvCateSub_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
			}
		}

		private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{

		}

		private void button4_Click(object sender, EventArgs e)
		{
			dtp.Value = dtp.Value.AddMonths(-1);
			updateBalance();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			dtp.Value = dtp.Value.AddMonths(1);
			updateBalance();
		}

		private void updateBalanceList()
		{
			List<AccountRec> lst;
			KBDatabase kdb = new KBDatabase();
			int i = 0;

			lst = kdb.getAccountRec();

			for (i = 0; i < lst.Count; i++)
			{
				if (0 == lst[i].eot)
				{
					dgvBalance.Rows.Add(lst[i].id.ToString(), lst[i].name, null, lst[i].type.ToString(), lst[i].initval.ToString());
				}
				else
				{
					dgvBalance.Rows.Add(lst[i].id.ToString(), lst[i].name, lst[i].eot.ToString(), lst[i].type.ToString(), lst[i].initval.ToString());
				}
			}
		}

		private void btnEntryBLC_Click(object sender, EventArgs e)
		{
			int i = 0;
			List<AccountRec> lst = new List<AccountRec>();

			AccountRec wkRec = new AccountRec();

			// 列数は新規の行も含んでいるので－１する
			for (i = 0; i < dgvBalance.Rows.Count - 1; i++)
			{
				// id			: uint16
				wkRec.id = Int16.Parse((string)dgvBalance.Rows[i].Cells["blc_id"].Value);
				// eot			: byte
				if (null != dgvBalance.Rows[i].Cells["blc_eot"].Value)
				{
					wkRec.eot = sbyte.Parse((string)dgvBalance.Rows[i].Cells["blc_eot"].Value);
				}
				else
				{
					wkRec.eot = 0;
				}
				// type			: byte
				wkRec.type = sbyte.Parse((string)dgvBalance.Rows[i].Cells["blc_type"].Value);
				// init			: int32
				wkRec.initval = Int32.Parse((string)dgvBalance.Rows[i].Cells["blc_initval"].Value);
				// name			: string
				wkRec.name = (string)dgvBalance.Rows[i].Cells["blc_name"].Value;
				lst.Add(wkRec);
			}
			KBDatabase kdb = new KBDatabase();

			kdb.setAccountRec(lst);
			MessageBox.Show("口座を登録しました。");

		}

		private void tabControl2_Enter(object sender, EventArgs e)
		{

		}

		private void tbpBalance_Enter(object sender, EventArgs e)
		{
			updateBalanceList();
		}

		private void button6_Click(object sender, EventArgs e)
		{
			KBDatabase kdb = new KBDatabase();

			foreach (string line in this.txtSQL.Lines)
			{
				kdb.executeNonQuery(line, false);
			}
		}

		private void dgvKBDat_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			string str = "";
			int id_cate_main = -1;
			bool entry = false;
			int h = dgvKBDat.Rows[0].Height;
			int ofs = 0;
			int i = 0;

			if ((-1 == e.RowIndex) || (-1 == e.ColumnIndex)) return;

# if false
			if ("費目" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)
			{
				id_cate_main = int.Parse(((string)dgvKBDat.Rows[e.RowIndex].Cells["cate_main"].Value).Split(':')[0].Trim());
				//cate_sub.Items.Clear();
				foreach (CateSubRec rec in cate_sub_lst)
				{
					if (id_cate_main == rec.id_cate_main)
					{
						entry = true;
						str = String.Format("{0, 3}:{1}", rec.id, rec.name);
						//cate_sub.Items.Add(str);
						this.lstCateMain.Items.Add(str);
					}
					else if (entry)
					{
						break;
					}
				}
				ofs += dgvKBDat.RowHeadersWidth;
				for (i = 0; i < e.ColumnIndex + 1; i++)
				{
					ofs += dgvKBDat.Columns[i].Width;
				}
				lstCateMain.SetBounds(dgvKBDat.Location.X + ofs, dgvKBDat.Location.Y + h * (e.RowIndex + 2), 100, 80);
				lstCateMain.Visible = true;
			}
#endif
			if ("口座" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)
			{
				KBDatabase kdb = new KBDatabase();
				DateTime wkdate;
				string[] wk;
				int eot = kdb.getEOT(int.Parse((((string)dgvKBDat.Rows[e.RowIndex].Cells["balance"].Value).Split(':')[0].Trim())));

				if (eot != 0)
				{
					wk = ((string)dgvKBDat.Rows[e.RowIndex].Cells["buy_date"].Value).Split('-');

					wkdate = new DateTime(int.Parse(wk[0]), int.Parse(wk[1]), eot);
					wkdate = wkdate.AddMonths(1);
					dgvKBDat.Rows[e.RowIndex].Cells["pay_date"].Value = String.Format("{0}-{1}-{2}", wkdate.Year, wkdate.Month, wkdate.Day);
				}
				else
				{
					dgvKBDat.Rows[e.RowIndex].Cells["pay_date"].Value = (string)dgvKBDat.Rows[e.RowIndex].Cells["buy_date"].Value;
				}
			}
		}

		private void dgvKBDat_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			int ofs = 0, i = 0, id_cate_main = -1, h = 15 * 5;

			if (("品名" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)	||
				("場所" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)	||
				("メモ" == dgvKBDat.Columns[e.ColumnIndex].HeaderText))
			{
				dgvKBDat.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			}

			ofs = dgvKBDat.RowHeadersWidth;
			for (i = 0; i < e.ColumnIndex; i++)
			{
				ofs += dgvKBDat.Columns[i].Width;
			}
			if ("費目" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)
			{
				if (lstCateMain.Items.Count < 5)
				{
					h = lstCateMain.Items.Count * 15;
				}

				lstCateMain.SetBounds(dgvKBDat.Location.X + ofs, dgvKBDat.Location.Y + dgvKBDat.Rows[0].Height * (e.RowIndex + 2), 100, h);
				lstCateMain.Visible = true;
			}
			else if ("詳細" == dgvKBDat.Columns[e.ColumnIndex].HeaderText)
			{
				bool entry = false;
				string str = "";
				lstCateSub.Items.Clear();

				if (null == dgvKBDat.Rows[e.RowIndex].Cells["cate_main"].Value) return;

				id_cate_main = int.Parse(((string)dgvKBDat.Rows[e.RowIndex].Cells["cate_main"].Value).Split(':')[0].Trim());

				foreach (CateSubRec rec in cate_sub_lst)
				{
					if (rec.id_cate_main == id_cate_main)
					{
						str = String.Format("{0, 3}:{1}", rec.id, rec.name);
						lstCateSub.Items.Add(str);
					}
					else if (entry)
					{
						break;
					}
				}

				lstCateSub.SetBounds(dgvKBDat.Location.X + ofs, dgvKBDat.Location.Y + dgvKBDat.Rows[0].Height * (e.RowIndex + 2), 100, h);
				lstCateSub.Visible = true;
			}
		}

		private void dgvKBDat_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			dgvKBDat.ImeMode = System.Windows.Forms.ImeMode.Off;
		}

		private void lstCateMain_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			cateListReg(lstCateMain);
		}

		private void lstCateMain_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (13 == e.KeyChar)
			{
				cateListReg(lstCateMain);
			}
		}

		private void updaterecietemoney()
		{
			int in_money = 0, out_money = 0;
			int i = 0;
			for (i = 0; i < dgvKBDat.Rows.Count - 1; i++)
			{
				if (dgvKBDat.Rows[i].Cells["income"].Value != null)
				{
					in_money += int.Parse(dgvKBDat.Rows[i].Cells["income"].Value.ToString());
				}
				if (dgvKBDat.Rows[i].Cells["payment"].Value != null)
				{
					out_money += int.Parse(dgvKBDat.Rows[i].Cells["payment"].Value.ToString());
				}
			}

			lbl_in.Text = in_money.ToString("#,##0 円");
			lbl_out.Text = out_money.ToString("#,##0 円");

		}

		private void dgvKBDat_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (lstCateMain.Focused != true)
			{
				lstCateMain.Visible = false;
			}
			if (lstCateSub.Focused != true)
			{
				lstCateSub.Visible = false;
			}

			updaterecietemoney();

		}

		private void lstCateMain_Leave(object sender, EventArgs e)
		{
			lstCateMain.Visible = false;
		}

		private void cateListReg(ListBox lb)
		{
			int col, row;

			col = dgvKBDat.SelectedCells[0].ColumnIndex;
			row = dgvKBDat.SelectedCells[0].RowIndex;
			if (dgvKBDat.Rows.Count == row + 1)
			{
				dgvKBDat.Rows.Add(1);
			}

			dgvKBDat.Rows[row].Cells[col].Value = lb.SelectedItem;
			lb.Visible = false;
			dgvKBDat.Focus();

		}

		private void lstCateSub_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (13 == e.KeyChar)
			{
				cateListReg(lstCateSub);
			}
		}

		private void lstCateSub_Leave(object sender, EventArgs e)
		{
			lstCateSub.Visible = false;

		}

		private void lstCateSub_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			cateListReg(lstCateSub);
		}

		private void dgvKBDat_KeyPress(object sender, KeyPressEventArgs e)
		{
			Console.WriteLine("dgvKBDat_KeyPress : " + e.KeyChar.ToString());


		}

		private void dgvKBDat_KeyDown(object sender, KeyEventArgs e)
		{
			int row = 0, col = 0;
			Console.WriteLine("dgvKBDat_KeyDown  : " + e.KeyCode.ToString());

			row = dgvKBDat.CurrentCell.RowIndex;
			col = dgvKBDat.CurrentCell.ColumnIndex;

			if (Keys.F4 == e.KeyCode)
			{
				if (row == 0) return;
				if (dgvKBDat.Rows[row - 1].Cells[col].Value == null) return;

				if (dgvKBDat.Rows.Count == row + 1)
				{
					dgvKBDat.Rows.Add(1);
				}
				dgvKBDat.Rows[row].Cells[col].Value = dgvKBDat.Rows[row - 1].Cells[col].Value;
			}
			else if (Keys.Delete == e.KeyCode)
			{
				dgvKBDat.Rows[row].Cells[col].Value = null;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			int rid = -0;
			KBDatabase kdb = new KBDatabase();

			rid = kdb.getMaxRID(dtp.Value);

			if (rid <= 0)
			{
				txtRID.Text = String.Format("{0}{1:D2}{2:D2}001", dtp.Value.Year % 100, dtp.Value.Month, dtp.Value.Day);
			}
			else
			{
				txtRID.Text = rid.ToString();
			}
		}

		private void cmbBalanceMonth_SelectedIndexChanged(object sender, EventArgs e)
		{
			mkStatisticsList();
		}

    }
}
