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
		const string _VERSION_NO_ = " Ver 0.0.7";

		List<CateMainRec> cate_main_lst;
		List<CateSubRec> cate_sub_lst;
		List<AccountRec> account_lst;
		Int16 id_usr;
		ListBox lstbox;
		int selectedmoney;

		public Form1()
        {
			try
			{
				InitializeComponent();

				id_usr = Int16.Parse(ConfigurationManager.AppSettings["id_usr"]);
				kbDatList_src.Modify = true;
				cate_main_lst = new List<CateMainRec>();
				cate_sub_lst = new List<CateSubRec>();
				updateCategory();
				this.dgvCateSub.ContextMenuStrip = this.contextMenuStrip1;
				lstbox = new ListBox();
				txt_masspay.Text = "";
				selectedmoney = 0;

				this.kbDatList_reg.getControl().CellEndEdit += new DataGridViewCellEventHandler(kbDatList2_CellEndEdit);
				this.kbDatList_src.getControl().CellClick += new DataGridViewCellEventHandler(kbDatList_src_CellClick);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}

		}

		void kbDatList_src_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int val = 0;

			if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
			{
				return;
			}

			val = kbDatList_src.SelectedMoney;
			slbltotalmoney.Text = val.ToString("合計 : #,##0 円");
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
				cmbAccount_src.Items.Add("");

				kbDatList_src.setAccountList(account_lst);
				kbDatList_reg.setAccountList(account_lst);

				string str = "";
				foreach (AccountRec rec in account_lst)
				{
					str = String.Format("{0, 3}:{1}", rec.id, rec.name);
					cmb_massaccount.Items.Add(str);
					cmbAccount_src.Items.Add(str);
				}

				this.Text += _VERSION_NO_;
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

				// ウィンドウサイズを取得して画面の中心にウィンドウを設定する
				int w = 0, h = 0;
				w = Screen.AllScreens[0].Bounds.Width;
				h = Screen.AllScreens[0].Bounds.Height;
				this.SetBounds((w - this.Width) / 2, (h - this.Height) / 2, this.Width, this.Height);

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
			lbl_totalpayment.Text = kdb.getTotalPayment(stDate, edDate, true).ToString("#,##0 円");
			// 現金支出
			lbl_cashpayment.Text = kdb.getTotalCashPayment(stDate, edDate).ToString("#,##0 円");
			// クレジット利用額
			lbl_creditpayment.Text = kdb.getTotalCreditPayment(stDate, edDate).ToString("#,##0 円");
		}

        private void button3_Click(object sender, EventArgs e)
        {
			kbDatList_reg.rowClear();
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
			sDate = sDate.AddMonths(-5);

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

//			colcnt = cmbBalanceMonth.Items.Count - cmbBalanceMonth.SelectedIndex;
			colcnt = 6;
			for (col = 1; col <= colcnt; col++)
			{
				lvStatistics.Columns[col].Text = String.Format("{0}-{1:D2}", sDate.Year, sDate.Month);
				for (row = 0; row < lvStatistics.Items.Count; row++)
				{
					if ((cate_sub_lst[row].id_cate_main == 50) || (cate_sub_lst[row].id_cate_main == 51))
					{
						money = kdb.getTotalMoney(sDate, sDate.AddMonths(1).AddDays(-1), KBDatabase.KBDAT_TYPE_INCOME, cate_sub_lst[row].id_cate_main, cate_sub_lst[row].id);
					}
					else
					{
						money = kdb.getTotalMoney(sDate, sDate.AddMonths(1).AddDays(-1), KBDatabase.KBDAT_TYPE_PAYMENT, cate_sub_lst[row].id_cate_main, cate_sub_lst[row].id);
					}
					lvStatistics.Items[row].SubItems.Add(money.ToString("#,#0"));
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
			int rowcnt = kbDatList_reg.getRowCnt();
			object wkobj = null;
			string err = "";

			rec = new List<KBRec>();
			wkrec = new KBRec();

			maxid = kdb.getMaxKBDatId();
			for (i = 0; i < rowcnt - 1; i++)
			{
				// DB内のインデックスを更新
				wkrec.id = ++maxid;
#if true
				wkobj = kbDatList_reg.getCellValue(i, "col_buy_date");
				if (null == wkobj)
				{
					err = String.Format("{0}行目の日付を入力してください", i + 1);
					MessageBox.Show(err, "入力項目不足");
					return;
				}
				wkdate = ((string)wkobj).Split('-');
				wkrec.buy_date = String.Format("{0}-{1:D2}-{2:D2}", Int32.Parse(wkdate[0]), Int32.Parse(wkdate[1]), Int32.Parse(wkdate[2])); ;

#else
				if (null == kbDatList_reg.getCellValue(i, "col_buy_date"))
				{
					wkrec.buy_date = String.Format("{0}-{1:D2}-{2:D2}", dtp.Value.Year, dtp.Value.Month, dtp.Value.Day);
				}
				else
				{
					wkdate = ((string)kbDatList_reg.getCellValue(i, "col_buy_date")).Split('-');
					wkrec.buy_date = String.Format("{0}-{1:D2}-{2:D2}", Int32.Parse(wkdate[0]), Int32.Parse(wkdate[1]), Int32.Parse(wkdate[2])); ;
				}
#endif
				// 場所
				if (txtWhere.Text.Trim().Length == 0)
				{
					if (null == kbDatList_reg.getCellValue(i, "col_where"))
					{
						wkrec.where = "";
					}
					else
					{
						wkrec.where = (string)kbDatList_reg.getCellValue(i, "col_where");
					}
				}
				else
				{
					wkrec.where = txtWhere.Text;
				}
				wkrec.rid = txtRID.Text.Trim().Length == 0 ? -1 :  Int32.Parse(txtRID.Text);

				if ((null == kbDatList_reg.getCellValue(i, "col_income")) || (0 == ((string)kbDatList_reg.getCellValue(i, "col_income")).Trim().Length))
				{
					// 支出
					wkrec.ie_type = 0;
					wkrec.money = int.Parse(((string)kbDatList_reg.getCellValue(i, "col_payment")).Trim());
				}
				else if ((null == kbDatList_reg.getCellValue(i, "col_payment")) || (0 == ((string)kbDatList_reg.getCellValue(i, "col_payment")).Trim().Length))
				{
					// 収入
					wkrec.ie_type = 1;
					wkrec.money = int.Parse(((string)kbDatList_reg.getCellValue(i, "col_income")).Trim());
				}
				else
				{
					err = String.Format("{0}行目の金額を入力してください", i + 1);
					MessageBox.Show(err, "入力項目不足");
					return;
				}

				// 品名
				wkobj = kbDatList_reg.getCellValue(i, "col_name");
				if (null == wkobj)
				{
					err = String.Format("{0}行目の品名を入力してください", i+1);
					MessageBox.Show(err, "入力項目不足");
					return;
				}
				wkrec.name = (string)wkobj;

				// 費目
				wkobj = kbDatList_reg.getCellValue(i, "col_cate_main");
				if (null == wkobj)
				{
					err = String.Format("{0}行目の費目を入力してください", i + 1);
					MessageBox.Show(err, "入力項目不足");
					return;
				}
				wkrec.cate_main = Int16.Parse(((string)wkobj).Split(':')[0].Trim());

				// 詳細
				wkobj = kbDatList_reg.getCellValue(i, "col_cate_sub");
				if (null == wkobj)
				{
					err = String.Format("{0}行目の詳細を入力してください", i + 1);
					MessageBox.Show(err, "入力項目不足");
					return;
				}
				wkrec.cate_sub = Int16.Parse(((string)wkobj).Split(':')[0].Trim());

				// ユーザＩＤ
				wkrec.id_usr = this.id_usr;

				// メモ
				wkobj = kbDatList_reg.getCellValue(i, "col_memo");
				if ((null == wkobj) || (((string)wkobj).Trim().Length == 0))
				{
					wkrec.memo = "";
				}
				else
				{
					wkrec.memo = (string)wkobj;
				}

				// 口座
				if (cmb_massaccount.SelectedIndex != 0)
				{
					string[] wk;
					DateTime dt;
					int eot = kdb.getEOT(int.Parse((cmb_massaccount.SelectedItem.ToString().Split(':')[0].Trim())));
					wkrec.id_accaount = Int16.Parse(cmb_massaccount.SelectedItem.ToString().Split(':')[0].Trim());
					if (eot != 0)
					{
						wk = wkrec.buy_date.Split('-');

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
					wkobj = kbDatList_reg.getCellValue(i, "col_account");
					if (null == wkobj)
					{
						err = String.Format("{0}行目の口座を入力してください", i + 1);
						MessageBox.Show(err, "入力項目不足");
						return;
					}
					wkrec.id_accaount = Int16.Parse(((string)wkobj).Split(':')[0].Trim());

					wkobj = kbDatList_reg.getCellValue(i, "col_pay_date");
					if (null == wkobj)
					{
						err = String.Format("{0}行目の取扱日を入力してください", i + 1);
						MessageBox.Show(err, "入力項目不足");
						return;
					}
					wkdate = ((string)wkobj).Split('-');
					wkrec.pay_date = String.Format("{0}-{1:D2}-{2:D2}", Int32.Parse(wkdate[0]), Int32.Parse(wkdate[1]), Int32.Parse(wkdate[2])); ;

				}
				rec.Add(wkrec);
			}
			// DBに登録
			kdb.entryKBData(rec);
			updateBalance();
			kbDatList_reg.rowClear();
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

			cate_main_lst.Clear();
			cate_sub_lst.Clear();

			kdb = new KBDatabase();

			cate_main_lst = kdb.getCateMainRec();
			cate_sub_lst = kdb.getCateSubRec();

			kbDatList_src.setCateMainList(cate_main_lst);
			kbDatList_src.setCateSubList(cate_sub_lst);
			kbDatList_reg.setCateMainList(cate_main_lst);
			kbDatList_reg.setCateSubList(cate_sub_lst);

			string str;
			cmbCateMain_src.Items.Add("");
			foreach (CateMainRec rec in cate_main_lst)
			{
				str = String.Format("{0,3}:{1}", rec.id, rec.name);
				cmbCateMain_src.Items.Add(str);
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

#if true
			foreach (string line in this.txtSQL.Lines)
			{
				kdb.executeNonQuery(line, false);
			}

			MessageBox.Show("SQL実行完了");
#else
			List<KBRec> lst;
			lst = kdb.getKBDat(szOpt);
#endif
		}




		private void updaterecietemoney()
		{
			int in_money = 0, out_money = 0;
			int i = 0;
			int rowcnt = kbDatList_reg.getRowCnt();

			for (i = 0; i < rowcnt - 1; i++)
			{
				if (kbDatList_reg.getCellValue(i, "col_income") != null)
				{
					in_money += int.Parse(kbDatList_reg.getCellValue(i, "col_income").ToString());
				}
				if (kbDatList_reg.getCellValue(i, "col_payment") != null)
				{
					out_money += int.Parse(kbDatList_reg.getCellValue(i, "col_payment").ToString());
				}
			}

			lbl_in.Text = in_money.ToString("#,##0 円");
			lbl_out.Text = out_money.ToString("#,##0 円");

		}

		private void kbDatList2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			updaterecietemoney();
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
			lvStatistics.Focus();
		}

		private void kbDatList2_MouseHover(object sender, EventArgs e)
		{

		}


		private void btnSearch_src_Click(object sender, EventArgs e)
		{
			KBDatabase kdb = new KBDatabase();
			string szOpt = "";
			DataGridView dgv = kbDatList_src.getControl();
			int i = 0;
			int len = 0;

			dgv.Rows.Clear();
			kbDatList_src.SuspendLayout();

			// SQLデータの作成
			// 日付
			if ((0 != txtDatest_src.Text.Trim().Length) || (0 != txtDateed_src.Text.Trim().Length))
			{
				if ((0 != txtDatest_src.Text.Trim().Length) && (0 != txtDateed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND ('{0}' <= buy_date AND buy_date <= '{1}')", txtDatest_src.Text.Trim(), txtDateed_src.Text.Trim());
				}
				else if ((0 != txtDatest_src.Text.Trim().Length) && (0 == txtDateed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND ('{0}' <= buy_date)", txtDatest_src.Text.Trim());
				}
				else if ((0 == txtDatest_src.Text.Trim().Length) && (0 != txtDateed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND (buy_date <= '{0}')", txtDateed_src.Text.Trim());
				}
			}

			// 取扱日
			if ((0 != txtPayst_src.Text.Trim().Length) || (0 != txtPayed_src.Text.Trim().Length))
			{
				if ((0 != txtPayst_src.Text.Trim().Length) && (0 != txtPayed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND ('{0}' <= buy_date AND buy_date <= '{1}')", txtPayst_src.Text.Trim(), txtPayed_src.Text.Trim());
				}
				else if ((0 != txtPayst_src.Text.Trim().Length) && (0 == txtPayed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND ('{0}' <= buy_date)", txtPayst_src.Text.Trim());
				}
				else if ((0 == txtPayst_src.Text.Trim().Length) && (0 != txtPayed_src.Text.Trim().Length))
				{
					szOpt += String.Format(" AND (buy_date <= '{0}')", txtPayed_src.Text.Trim());
				}
			}

			len = txtWhere_src.Text.Trim().Length;
			if (0 != len)
			{
				szOpt += String.Format(" AND (where = '{0}')", txtWhere_src.Text.Trim());
			}

			if (0 < cmbCateMain_src.SelectedIndex)
			{
				szOpt += String.Format(" AND (id_cate_main = {0})",
					cmbCateMain_src.SelectedItem.ToString().Trim().Split(':')[0]);
			}
			if (0 < cmbCateSub_src.SelectedIndex)
			{
				szOpt += String.Format(" AND (id_cate_sub = {0})",
					cmbCateSub_src.SelectedItem.ToString().Trim().Split(':')[0]);
			}
			if (0 < cmbAccount_src.SelectedIndex)
			{
				szOpt += String.Format(" AND (id_account = {0})",
					cmbAccount_src.SelectedItem.ToString().Trim().Split(':')[0]);
			}

			len = txtName_src.Text.Trim().Length;

			if (0 < len)
			{
				string str = "";
				foreach (string s in txtName_src.Lines)
				{
					if (s[0] == '-')
					{
						str += String.Format(" OR (name not like '{0}')", s.Substring(1));
					}
					else
					{
						str += String.Format(" OR (name like '{0}')", s);
					}
				}
				if (str.StartsWith(" OR"))
				{
					// 先頭が「 AND」から始まっていた場合は先頭の「 AND」を削除する
					str = str.Substring(" OR".Length);
				}

				szOpt += String.Format(" AND ({0})", str);
			}

			if (szOpt.StartsWith(" AND"))
			{
				// 先頭が「 AND」から始まっていた場合は先頭の「 AND」を削除する
				szOpt = szOpt.Substring(" AND".Length);
			}

			List<KBRec> lst = kdb.getKBDat(szOpt);

			int income = 0, payment = 0;
			for (i = 0; i < lst.Count; i++ )
			{
				dgv.Rows.Add(1);
				dgv.Rows[i].Cells["col_buy_date"].Value = lst[i].buy_date;
				if (0 != lst[i].ie_type)
				{
					income += int.Parse(lst[i].money.ToString());
					dgv.Rows[i].Cells["col_income"].Value = lst[i].money.ToString();
					dgv.Rows[i].Cells["col_payment"].Value = "";
				}
				else
				{
					payment += int.Parse(lst[i].money.ToString());
					dgv.Rows[i].Cells["col_income"].Value = "";
					dgv.Rows[i].Cells["col_payment"].Value =  lst[i].money.ToString();
				}
				dgv.Rows[i].Cells["col_name"].Value = lst[i].name;
				dgv.Rows[i].Cells["col_pay_date"].Value = lst[i].pay_date;
				dgv.Rows[i].Cells["col_where"].Value = lst[i].where;
				dgv.Rows[i].Cells["col_memo"].Value = lst[i].memo;
				dgv.Rows[i].Cells["col_id"].Value = lst[i].id;
				dgv.Rows[i].Cells["col_id_usr"].Value = lst[i].id_usr;
				dgv.Rows[i].Cells["col_ie_type"].Value = lst[i].ie_type;
				dgv.Rows[i].Cells["col_rid"].Value = lst[i].rid;

				dgv.Rows[i].Cells["col_cate_main"].Value = kbDatList_src.getCateMainStr(lst[i].cate_main);
				dgv.Rows[i].Cells["col_cate_sub"].Value = kbDatList_src.getCateSubStr(lst[i].cate_main, lst[i].cate_sub);
				dgv.Rows[i].Cells["col_account"].Value = kbDatList_src.getAccount(lst[i].id_accaount);
#if false
				dgv.Rows.Add(lst[i].buy_date,			// buy_date
								null,		// cate_main
								null,		// cate_sub
								(0 != lst[i].ie_type ? lst[i].money.ToString() : ""),					// income
								(0 == lst[i].ie_type ? lst[i].money.ToString() : ""),					// payment
								lst[i].name,			// name
								null,	// account
								lst[i].pay_date,		// pay_date
								lst[i].where,			// where
								lst[i].memo,			// memo
								lst[i].id,				// id
								lst[i].id_usr,			// id_usr
								lst[i].ie_type,		// ie_type
								lst[i].rid				// rid
								);
#endif
			}
			kbDatList_src.ResumeLayout();

			lbltotalincome_src.Text = income.ToString("#,##0 円");
			lbltotalpayment_src.Text = payment.ToString("#,##0 円");
			kbDatList_src.Focus();
		}

		private void cmbCateMain_src_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id_cate_main;
			string str;
			id_cate_main = int.Parse(cmbCateMain_src.SelectedItem.ToString().Split(':')[0].Trim());

			cmbCateSub_src.Items.Clear();
			this.cmbCateSub_src.Items.Add("");
			foreach (CateSubRec rec in cate_sub_lst)
			{
				if (rec.id_cate_main == id_cate_main)
				{
					str = String.Format("{0, 3}:{1}", rec.id, rec.name);
					this.cmbCateSub_src.Items.Add(str);
				}
			}

		}

		private void toppane_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
			{
				tbpSQL.Visible = true;
			}
		}

    }
}
