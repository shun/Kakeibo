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
		List<CateSubRec> cate_sub_lst;

		public KBDatList()
		{
			InitializeComponent();
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
				this.col_account.Items.Add(String.Format("{0, 3}:{1}", rec.id, rec.name));
			}
		}

		private void dgvKBList_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
		{
			int ofs = 0, i = 0, id_cate_main = -1, h = 15 * 5;

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
			if ("費目" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				if (lstCateMain.Items.Count < 5)
				{
					h = lstCateMain.Items.Count * 15;
				}

				lstCateMain.SetBounds(dgvKBList.Location.X + ofs, dgvKBList.Location.Y + dgvKBList.Rows[0].Height * (e.RowIndex + 2), 100, h);
				lstCateMain.Visible = true;
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

				lstCateSub.SetBounds(dgvKBList.Location.X + ofs, dgvKBList.Location.Y + dgvKBList.Rows[0].Height * (e.RowIndex + 2), 100, h);
				lstCateSub.Visible = true;
			}

		}

		private void dgvKBList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
			if (lstCateMain.Focused != true)
			{
				lstCateMain.Visible = false;
			}
			if (lstCateSub.Focused != true)
			{
				lstCateSub.Visible = false;
			}
		}

		private void dgvKBList_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			dgvKBList.ImeMode = System.Windows.Forms.ImeMode.Off;
		}

		private void dgvKBList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			int h = dgvKBList.Rows[0].Height;
			int i = 0;

			if ((-1 == e.RowIndex) || (-1 == e.ColumnIndex)) return;

			if ("口座" == dgvKBList.Columns[e.ColumnIndex].HeaderText)
			{
				KBDatabase kdb = new KBDatabase();
				DateTime wkdate;
				string[] wk;
				int eot = kdb.getEOT(int.Parse((((string)dgvKBList.Rows[e.RowIndex].Cells["col_account"].Value).Split(':')[0].Trim())));

				if (eot != 0)
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
			lstCateMain.Visible = false;
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

	}
}
