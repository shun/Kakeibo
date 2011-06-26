using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kakeibo
{
	public partial class KBDatList : UserControl
	{
//		List<CateMainRec> cate_main_lst;
		private List<CateSubRec> cate_sub_lst;
		private bool modify;
		private int selectedmoney;
		private bool keySelected;
		private bool lstCateMainOn;
		private bool lstCateSubOn;
		private bool lstAccountOn;

		public KBDatList()
		{
			InitializeComponent();
			modify = false;
			selectedmoney = 0;
			keySelected = false;
			lstCateMainOn = false;
			lstCateSubOn = false;
			lstAccountOn = false;
		}

		public int SelectedMoney
		{
			get { return this.selectedmoney; }
		}

		public bool Modify
		{
			get { return this.modify; }
			set { this.modify = value; }
		}
	
		public void rowClear()
		{
			this.dgvKBList.Rows.Clear();
		}

		public int getRowCnt()
		{
			return this.dgvKBList.Rows.Count;
		}

		public object getCellValue(int rowidx, string rowname)
		{
			return this.dgvKBList.Rows[rowidx].Cells[rowname].Value;
		}

		public DataGridView getControl()
		{
			return this.dgvKBList;
		}

		public string getAccount(int id)
		{
			int id_account = 0;
			int i = 0;
			string ret = "";

			for (i = 0; i < lstAccount.Items.Count; i++)
			{
				id_account = int.Parse(lstAccount.Items[i].ToString().Split(':')[0]);
				if (id == id_account)
				{
					ret = lstAccount.Items[i].ToString();
					break;
				}
			}
			return ret;
		}

		public string getCateMainStr(int id_cate_main)
		{
			int i = 0;
			int id;
			string ret = "";
			for (i = 0; i < lstCateMain.Items.Count; i++)
			{
				id = int.Parse(lstCateMain.Items[i].ToString().Split(':')[0]);
				if (id_cate_main == id)
				{
					ret = lstCateMain.Items[i].ToString();
					break;
				}
			}
			return ret;
		}

		public string getCateSubStr(int id_cate_main, int id_cate_sub)
		{
			string ret = "";
			foreach (CateSubRec rec in cate_sub_lst)
			{
				if ((rec.id_cate_main == id_cate_main) && (rec.id == id_cate_sub))
				{
					ret = String.Format("{0, 3}:{1}", rec.id, rec.name);
					break;
				}
			}
			return ret;
		}

		public void setCateMainList(List<CateMainRec> lst)
		{
			string str;

//			this.cate_main_lst = lst;
			lstCateMain.Items.Clear();
			foreach (CateMainRec rec in lst)
			{
				str = String.Format("{0,3}:{1}", rec.id, rec.name);
				lstCateMain.Items.Add(str);
			}
		}

		public void setCateSubList(List<CateSubRec> lst)
		{
			this.cate_sub_lst = lst;
		}

		public void setAccountList(List<AccountRec> lst)
		{
			foreach (AccountRec rec in lst)
			{
				this.lstAccount.Items.Add(String.Format("{0, 3}:{1}", rec.id, rec.name));
			}
		}

		private void dgvKBList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			int ofs = 0, i = 0, id_cate_main = -1, h = 15 * 5;
			int scrlrow = -1, ofs_y = 0;

			if (("品名" == dgvKBList.Columns[e.ColumnIndex].HeaderText) ||
				("場所" == dgvKBList.Columns[e.ColumnIndex].HeaderText) ||
				("メモ" == dgvKBList.Columns[e.ColumnIndex].HeaderText))
			{
				dgvKBList.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
			}

			ofs = dgvKBList.RowHeadersWidth;
			for (i = 0; i < e.ColumnIndex; i++)
			{
				ofs += dgvKBList.Columns[i].Width;
			}

			// 現在のスクロールの位置を取得
			scrlrow = dgvKBList.FirstDisplayedScrollingRowIndex;

			if (18 < e.RowIndex - scrlrow)
			{
				ofs_y = dgvKBList.Rows[0].Height * (scrlrow + 1) + lstCateMain.Height;
			}
			else
			{
				ofs_y = dgvKBList.Rows[0].Height * scrlrow;
			}

			if ("費目" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				if (lstCateMain.Items.Count < 5)
				{
					h = lstCateMain.Items.Count * 15;
				}

				lstCateMain.SetBounds(dgvKBList.Location.X + ofs, dgvKBList.Location.Y + dgvKBList.Rows[0].Height * (e.RowIndex + 2) - ofs_y, 100, h);
				e.Cancel = true;
				lstCateMain.Select();
				lstCateMain.Visible = true;
				lstCateMainOn = true;
			}
			else if ("詳細" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				bool entry = false;
				string str = "";
				lstCateSub.Items.Clear();

				if (null == dgvKBList.Rows[e.RowIndex].Cells["col_cate_main"].Value) return;

				id_cate_main = int.Parse(((string)dgvKBList.Rows[e.RowIndex].Cells["col_cate_main"].Value).Split(':')[0].Trim());

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

				lstCateSub.SetBounds(dgvKBList.Location.X + ofs, dgvKBList.Location.Y + dgvKBList.Rows[0].Height * (e.RowIndex + 2) - ofs_y, 100, h);
				e.Cancel = true;
				lstCateSub.Select();
				lstCateSub.Visible = true;
				lstCateSubOn = true;
			}
			else if ("口座" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				h = 8 * 15;

				lstAccount.SetBounds(dgvKBList.Location.X + ofs, dgvKBList.Location.Y + dgvKBList.Rows[0].Height * (e.RowIndex + 2) - ofs_y, 130, h);
				e.Cancel = true;
				lstAccount.Select();
				lstAccount.Visible = true;
				lstAccountOn = true;
			}

		}

		private void dgvKBList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			//Console.WriteLine("dgvKBList_CellEndEdit : {0}", lstCateMain.Visible);
			if (lstCateMainOn != true)
			{
				lstCateMain.Visible = false;
			}
			if (lstCateSubOn != true)
			{
				lstCateSub.Visible = false;
			}
			if (lstAccountOn != true)
			{
				lstAccount.Visible = false;
			}
		}

		private void dgvKBList_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			//Console.WriteLine("dgvKBList_CellLeave");
			dgvKBList.ImeMode = System.Windows.Forms.ImeMode.Off;
		}

		private void dgvKBList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int h = dgvKBList.Rows[0].Height;

			if ((-1 == e.RowIndex) || (-1 == e.ColumnIndex)) return;

			if ("口座" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				KBDatabase kdb = new KBDatabase();
				DateTime wkdate;
				string[] wk;
				int eot = -1;	// end of term

				eot = kdb.getEOT(int.Parse((((string)dgvKBList.Rows[e.RowIndex].Cells["col_account"].Value).Split(':')[0].Trim())));

				if ((eot != 0) && (null != dgvKBList.Rows[e.RowIndex].Cells["col_buy_date"].Value))
				{
					wk = ((string)dgvKBList.Rows[e.RowIndex].Cells["col_buy_date"].Value).Split('-');

					wkdate = new DateTime(int.Parse(wk[0]), int.Parse(wk[1]), eot);
					wkdate = wkdate.AddMonths(1);
					dgvKBList.Rows[e.RowIndex].Cells["col_pay_date"].Value = String.Format("{0}-{1}-{2}", wkdate.Year, wkdate.Month, wkdate.Day);
				}
				else
				{
					dgvKBList.Rows[e.RowIndex].Cells["col_pay_date"].Value = (string)dgvKBList.Rows[e.RowIndex].Cells["col_buy_date"].Value;
				}
			}
		}

		private void dgvKBList_KeyDown(object sender, KeyEventArgs e)
		{
			int row = 0, col = 0;

			row = dgvKBList.CurrentCell.RowIndex;
			col = dgvKBList.CurrentCell.ColumnIndex;

			if (Keys.F4 == e.KeyCode)
			{
				if (row == 0) return;
				if (dgvKBList.Rows[row - 1].Cells[col].Value == null) return;

				if (dgvKBList.Rows.Count == row + 1)
				{
					dgvKBList.Rows.Add(1);
				}
				dgvKBList.Rows[row].Cells[col].Value = dgvKBList.Rows[row - 1].Cells[col].Value;
			}
			else if (Keys.Delete == e.KeyCode)
			{
				dgvKBList.Rows[row].Cells[col].Value = null;
			}
			else if ((e.Control) || (e.Shift))
			{
				keySelected = true;
			}
		}

		private void cateListReg(ListBox lb)
		{
			int col, row;

			col = dgvKBList.SelectedCells[0].ColumnIndex;
			row = dgvKBList.SelectedCells[0].RowIndex;
			if (dgvKBList.Rows.Count == row + 1)
			{
				dgvKBList.Rows.Add(1);
			}

			dgvKBList.Rows[row].Cells[col].Value = lb.SelectedItem;
			lb.Visible = false;
			dgvKBList.Focus();
		}

		private void lstCateMain_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			cateListReg(lstCateMain);
		}

		private void lstCateMain_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Char)Keys.Enter == e.KeyChar)
			{
				cateListReg(lstCateMain);
			}
		}

		private void lstCateMain_Leave(object sender, EventArgs e)
		{
			//Console.WriteLine("lstCateMain_Leave : {0}, '{1}'", lstCateMain.Visible, this.ActiveControl.Name);
			if (this.ActiveControl.Name.Length != 0)
			{
				lstCateMain.Visible = false;
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

		private void lstCateSub_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Char)Keys.Enter == e.KeyChar)
			{
				cateListReg(lstCateSub);
			}
		}

		private void dgvKBList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
		}

		private void dgvKBList_KeyPress(object sender, KeyPressEventArgs e)
		{
		}

		private void dgvKBList_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			string str;
			int val = 0;

			if ((e.ColumnIndex < 0) || (e.RowIndex < 0))
			{
				return;
			}

			foreach(DataGridViewCell cell in  dgvKBList.SelectedCells)
			{
				try
				{
					str = cell.Value.ToString();
					val += int.Parse(str);
					Console.WriteLine(str);
#if true
					selectedmoney = val;
#else
					if (keySelected)
					{
						selectedmoney += val;
					}
					else
					{
						selectedmoney = val;
					}
#endif
				}
				catch
				{
					if (!keySelected)
					{
						selectedmoney = 0;
					}
				}
			}
		}

		private void dgvKBList_KeyUp(object sender, KeyEventArgs e)
		{
			if ((!e.Control) || (!e.Shift))
			{
				keySelected = false;
				selectedmoney = 0;
			}
		}

		private void lstCateMain_VisibleChanged(object sender, EventArgs e)
		{
			//Console.WriteLine("lstCateMain_VisibleChanged : {0}, '{1}'", lstCateMain.Visible, this.ActiveControl.Name);
			if (lstCateMain.Visible == true)
			{
				lstCateMain.Select();
				lstCateMain.SelectedIndex = 0;
			}
			lstCateMainOn = false;
		}

		private void lstCateSub_VisibleChanged(object sender, EventArgs e)
		{
			if (lstCateSub.Visible == true)
			{
				lstCateSub.Select();
				lstCateSub.SelectedIndex = 0;
			}
			lstCateSubOn = false;
		}

		private void lstCateMain_Enter(object sender, EventArgs e)
		{
			//Console.WriteLine("lstCateMain_Enter");

		}

		private void dgvKBList_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			//Console.WriteLine("dgvKBList_CellEnter");

		}

		private void lstAccount_Leave(object sender, EventArgs e)
		{
			lstAccount.Visible = false;
		}

		private void lstAccount_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			cateListReg(lstAccount);
		}

		private void lstAccount_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((Char)Keys.Enter == e.KeyChar)
			{
				cateListReg(lstAccount);
			}
		}

		private void lstAccount_VisibleChanged(object sender, EventArgs e)
		{
			if (lstAccount.Visible == true)
			{
				lstAccount.Select();
				lstAccount.SelectedIndex = 0;
			}
			lstAccountOn= false;
		}

		private void DelRowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if ((null == dgvKBList.CurrentRow) || (dgvKBList.Rows.Count - 1 == dgvKBList.CurrentRow.Index))
			{
				// 最終行は常に予備で何も入力されていないはずなのでありえないはず
				return;
			}

			if (dgvKBList.Rows.Count == 2)
			{
				// 1行だけ入力されていた場合は全消し
				this.rowClear();
			}
			else
			{
				// 当該行のみ削除する
				this.dgvKBList.Rows.RemoveAt(dgvKBList.CurrentRow.Index);
			}
		}
	}
}
