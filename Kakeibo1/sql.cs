using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Collections;
using System.Configuration;

namespace Kakeibo
{
	class KBDatabase : IDisposable
	{
		SQLiteConnection hConn;
		Category wkcate;
		int cnt;
		public const int KBDAT_TYPE_MONTH = 1;
		public const int KBDAT_TYPE_YEAR = 2;
		public const int KBDAT_TYPE_PAYMENT = 0;
		public const int KBDAT_TYPE_INCOME = 1;

		static string db_path = "";
		public KBDatabase()
		{
			hConn = null;
			cnt = 0;
			if (db_path == "")
			{
				db_path = ConfigurationManager.AppSettings["db_path"];
			}
		}

		public void Dispose()
		{
			// 念のためクローズしておく
			this.closedb();
			this.Dispose();
		}
		

		public int executeNonQuery(string szCmd, bool keepopen)
		{
			int ret = 0;
			SQLiteCommand command;

			if (null == hConn)
			{
				opendb();
			}

			command = new SQLiteCommand(szCmd, hConn);

			ret = command.ExecuteNonQuery();

			if (!keepopen)
			{
				closedb();
			}

			return ret;
		}

		private object executeScalar(string szCmd, bool keepopen)
		{
			object obj;
			SQLiteCommand command;

			if (null == hConn)
			{
				opendb();
			}


			command = new SQLiteCommand(szCmd, hConn);

			obj = command.ExecuteScalar();

			if (!keepopen)
			{
				closedb();
			}

			if (Convert.IsDBNull(obj))
			{
				return null;
			}

			return obj;
		}

		public string getMaxDate()
		{
			string str = "";
			object obj;
			string szCmd = "select max(buy_date) from T_KBDAT";

			obj = executeScalar(szCmd, false);
			if (null != obj)
			{
				str = obj.ToString();
			}
			return str;
		}

		public string getMinDate()
		{
			string str = "";
			object obj;
			string szCmd = "select min(buy_date) from T_KBDAT";

			obj = executeScalar(szCmd, false);
			if (null != obj)
			{
				str = obj.ToString();
			}
			return str;
		}

		public List<CateMainRec> getCateMainRec()
		{
			List<CateMainRec> lst;
			SQLiteCommand command;
			SQLiteDataReader reader;
			string szCmd = "select * from T_CATE_MAIN order by sortid";
			CateMainRec wkRec = new CateMainRec();
			char[] bytes = new Char[128];
			object[] obj;

			lst = new List<CateMainRec>();

			opendb();
			command = new SQLiteCommand(szCmd, hConn);
			reader = command.ExecuteReader();
			obj = new object[reader.FieldCount];


			while (reader.Read())
			{
				reader.GetValues(obj);
				// id		: uint16
				wkRec.id = reader.GetInt16(0);
				// sortid	: uint16
				wkRec.sortid = reader.GetInt16(1);
				// name		: string
				wkRec.name = reader.GetString(2);
				lst.Add(wkRec);
			}
			reader.Close();
			closedb();

			return lst;
		}

		public void setAccountRec(List<AccountRec> rec)
		{
			int i = 0;
			string szCmd;

			// めんどくさいから全部消す
			executeNonQuery("delete from T_BALANCE", true);

			for (i = 0; i < rec.Count; i++)
			{
				szCmd = String.Format("insert into T_BALANCE values({0}, {1}, {2}, {3}, '{4}')",
					rec[i].id,
					rec[i].eot,
					rec[i].type,
					rec[i].initval,
					rec[i].name);

				executeNonQuery(szCmd, true);
			}
			closedb();
		}

		public List<AccountRec> getAccountRec()
		{
			SQLiteCommand command;
			SQLiteDataReader reader;
			List<AccountRec> lst;
			string szCmd = "select * from T_BALANCE order by id";
			AccountRec wkRec = new AccountRec();


			lst = new List<AccountRec>();

			opendb();
			command = new SQLiteCommand(szCmd, hConn);
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				// id			: uint16
				wkRec.id = reader.GetInt16(0);
				// eot			: int8
				wkRec.eot = (sbyte)reader.GetByte(1);
				// type			: int8
				wkRec.type = (sbyte)reader.GetByte(2);
				// init			: int32
				wkRec.initval = reader.GetInt32(3);
				// name			: string
				wkRec.name = reader.GetString(4);
				lst.Add(wkRec);
			}

			reader.Close();
			closedb();
			return lst;
		}
		private List<short> getIDs()
		{
			SQLiteCommand command;
			SQLiteDataReader reader;
			string szCmd = "select id from T_BALANCE where type = 0";
			List<short> lst;

			lst = new List<short>();
			lst.Clear();

			opendb();
			command = new SQLiteCommand(szCmd, hConn);
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				lst.Add(reader.GetInt16(0));
			}

			return lst;
		}
		public List<CateSubRec> getCateSubRec()
		{
			SQLiteCommand command;
			SQLiteDataReader reader;
			List<CateSubRec> lst;
			string szCmd = "select * from T_CATE_SUB order by id_cate_main, id asc";
			CateSubRec wkRec = new CateSubRec();


			lst = new List<CateSubRec>();

			opendb();
			command = new SQLiteCommand(szCmd, hConn);
			reader = command.ExecuteReader();
			while (reader.Read())
			{
				// id			: uint16
				wkRec.id = reader.GetInt16(0);
				// sortid		: uint16
				wkRec.sortid = reader.GetInt16(1);
				// id_cate_main	: uint16
				wkRec.id_cate_main = reader.GetInt16(2);
				// name			: string
				wkRec.name = reader.GetString(3);
				lst.Add(wkRec);
			}

			reader.Close();
			closedb();
			return lst;
		}

		public int getTotalMoney(DateTime stDate, DateTime edDate, int ie_type = -1, int cate_main = -1, int cate_sub = -1)
		{
			int money = 0;
			object obj;
			string szCmd= "select sum(money) from T_KBDAT";
			string szSDate, szEDate;

			szSDate = String.Format("'{0}-{1:D2}-{2:D2}'", stDate.Year, stDate.Month, stDate.Day);
			szEDate = String.Format("'{0}-{1:D2}-{2:D2}'", edDate.Year, edDate.Month, edDate.Day);

			szCmd = String.Format("{0} where {1} <= buy_date and buy_date <= {2}", szCmd, szSDate, szEDate);
			if (ie_type != -1)
			{
				szCmd += " and ie_type = " + ie_type.ToString();
			}
			if (cate_main != -1)
			{
				szCmd += " and id_cate_main = " + cate_main.ToString();
			}
			if (cate_sub != -1)
			{
				szCmd += " and id_cate_sub = " + cate_sub.ToString();
			}

			obj = executeScalar(szCmd, false);

			if (null != obj)
			{
				money = int.Parse(obj.ToString());
			}
			return money;
		}
		public int getCateMainRecNum()
		{
			object ret = null;
			ret = executeScalar("select count(*) from T_CATE_MAIN", false);
			return Int32.Parse(ret.ToString());
		}

		public int getCateSubRecNum()
		{
			return (int)executeScalar("select count(*) from T_CATE_SUB", false);
		}

		public int setCateSubRec()
		{
			return executeNonQuery("insert into T_CATE_SUB values(1, 1, '食費')", false);
		}

		public int setCateMainRec()
		{
			string str;

			str = String.Format("insert into T_CATE_MAIN values({0}, 1, '食費')", cnt);
			cnt++;
			return executeNonQuery(str, false);
		}

		public void clearCategory()
		{
			executeNonQuery("delete from T_CATE_MAIN", false);
			executeNonQuery("delete from T_CATE_SUB", false);
		}

		// 指定した条件の金額を取得する
		private int getMoney(string szOpt, DateTime stDate, DateTime edDate)
		{
			object ret;
			string szSDate = "", szEDate = "";
			string szCmd = "";

			szSDate = String.Format("'{0}-{1:D2}-{2:D2}'", stDate.Year, stDate.Month, stDate.Day);
			szEDate = String.Format("'{0}-{1:D2}-{2:D2}'", edDate.Year, edDate.Month, edDate.Day);

			szCmd = String.Format("select sum(money) from T_KBDAT where ({0} <= buy_date) AND (buy_date <= {1}) AND ({2})",
				szSDate, szEDate, szOpt);
			ret = executeScalar(szCmd, false);
			return ret == null ? 0 : int.Parse(ret.ToString());
		}

		// 指定日付内の全収入の合計を取得する
		public int getTotalIncome(DateTime stDate, DateTime edDate)
		{
			int ret = 0;
			ret = getMoney("ie_type = 1", stDate, edDate);

			return ret;
		}

		// 指定日付内の全支出の合計を取得する
		// クレジットで使用した額 + 現金支出 + 引き落とし
		public int getTotalPayment(DateTime stDate, DateTime edDate, bool finance = false)
		{
			int ret = 0;
			string szOpt = "(ie_type = 0)";
			if (finance)
			{
				szOpt += "AND (id_cate_main != 90)";
			}
			ret = getMoney(szOpt, stDate, edDate);

			return ret;
		}

		// 指定日付内の全支出の合計を取得する
		// クレジットで使用した現金支出 + 引き落とし
		public int getTotalCashPayment(DateTime stDate, DateTime edDate)
		{
			int ret = 0;
			List<short> lst;
			string szOpt = "ie_type = 0";

			lst = this.getIDs();

			if (0 < lst.Count)
			{
				szOpt += " AND (";
				for (int i = 0; i < lst.Count; i++)
				{
					if (i != 0)
					{
						szOpt += " OR ";
					}
					szOpt += " id_account = " + lst[i].ToString();
				}
				szOpt += ")";
			}

			ret = getMoney(szOpt, stDate, edDate);

			return ret;
		}

		// 指定日付内のクレジット利用額を取得する
		public int getTotalCreditPayment(DateTime stDate, DateTime edDate)
		{
			int ret = 0;
			ret = getMoney("ie_type = 0 and id_account = (select id from T_BALANCE where type = 1)", stDate, edDate);

			return ret;
		}

		public int getMaxKBDatId()
		{
			int id = -1;
			object obj;
			string szCmd = "select count(id) from T_KBDAT";


			obj  = executeScalar(szCmd, false);
			if (null == obj)
			{
				id = 0;
			}
			else
			{
				id = int.Parse(obj.ToString());
			}
			return id;
		}

		public int getMaxRID(DateTime date)
		{
			int ret = 0;
			object obj;
			string szCmd = String.Format("select rid from T_KBDAT where (rid > {0}{1:D2}{2:D2}000) and ({0}{1:D2}{2:D2}999 < rid)",
				date.Year % 100, date.Month, date.Day);

			obj = executeNonQuery(szCmd, false);

			if (null == obj)
			{
				ret = -1;
			}
			else
			{
				ret = int.Parse(obj.ToString());
			}
			return ret;
		}

		public int getEOT(int id)
		{
			string szCmd = "select eot from T_BALANCE where id = " + id.ToString();
			object obj;

			obj = executeScalar(szCmd, false);

			return null == obj ? 0 : int.Parse(obj.ToString());
		}
		public int entryCategories(Category catedat)
		{
			int ret = 0;
			string szCmd = "delete from T_CATE_MAIN";
			int i = 0, j = 0;

			// カテゴリデータの更新はチェックがめんどくさいのでカテゴリデータを全部削除してからもう一度全部入れ直す。
			executeNonQuery("delete from T_CATE_MAIN", true);
			executeNonQuery("delete from T_CATE_SUB", true);

			// カテゴリメインを全部登録する
			for (i = 0; i < catedat.cate.rec.Count; i++)
			{
				szCmd = String.Format("insert into T_CATE_MAIN values({0}, {1}, {2})",
					catedat.cate.rec[i].id,
					catedat.cate.rec[i].sortid,
					catedat.cate.rec[i].name);

				executeNonQuery(szCmd, true);

				// カテゴリサブを全部登録する
				for (j = 0; j < catedat.cate.rec[i].rec_sub.Count; j++)
				{
					szCmd = String.Format("insert into T_CATE_SUB values({0}, {1}, {2}, {3})",
						catedat.cate.rec[i].rec_sub[j].id,
						catedat.cate.rec[i].rec_sub[j].sortid,
						catedat.cate.rec[i].rec_sub[j].id_cate_main,
						catedat.cate.rec[i].rec_sub[j].name);

					executeNonQuery(szCmd, true);
				}
			}


			closedb();

			return ret;
		}

		public int entryKBData(List<KBRec> rec)
		{
			int ret = 0;
			int i = 0;
			string szCmd = "";
			SQLiteCommand command;

			opendb();
			try
			{
				command = new SQLiteCommand("begin", hConn);
				command.ExecuteNonQuery();

				for (i = 0; i < rec.Count; i++)
				{
					szCmd = string.Format("insert into T_KBDAT values({0}, '{1}', '{2}', '{3}', '{4}', {5}, {6}, {7}, {8}, {9}, {10}, '{11}', {12})",
											rec[i].id,
											rec[i].buy_date,
											rec[i].pay_date,
											rec[i].where,
											rec[i].name,
											rec[i].rid,
											rec[i].money,
											rec[i].ie_type,
											rec[i].cate_main,
											rec[i].cate_sub,
											rec[i].id_usr,
											rec[i].memo,
											rec[i].id_accaount
										   );
					command = new SQLiteCommand(szCmd, hConn);
					command.ExecuteNonQuery();
				}

				command = new SQLiteCommand("commit", hConn);
				command.ExecuteNonQuery();
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
				Console.Write(e.ToString());
				command = new SQLiteCommand("rollback", hConn);
				command.ExecuteNonQuery();
			}
			closedb();

			return ret;
		}

		public List<KBRec> getKBDat(string szOpt)
		{
			List<KBRec> lst;
			SQLiteDataReader reader;
			SQLiteCommand command;
			string szCmd = "select * from T_KBDAT";
			KBRec rec;
			object[] obj;

			lst = new List<KBRec>();

			if (0 != szOpt.Trim().Length)
			{
				szCmd = szCmd + " where " + szOpt + "order by buy_date";
			}

			rec = new KBRec();
			obj = new object[13];
			opendb();
			command = new SQLiteCommand(szCmd, hConn);
			reader = command.ExecuteReader();

			while (reader.Read())
			{
#if true
				rec.id			= reader.GetInt32(0);
				rec.buy_date	= reader.GetString(1);
				rec.pay_date	= reader.GetString(2);
				rec.where		= reader.GetString(3);
				rec.name		= reader.GetString(4);
				rec.rid			= reader.GetInt32(5);
				rec.money		= reader.GetInt32(6);
				rec.ie_type		= reader.GetInt16(7);
				rec.cate_main	= reader.GetInt16(8);
				rec.cate_sub	= reader.GetInt16(9);
				rec.id_usr		= reader.GetInt16(10);
				rec.memo		= reader.GetString(11);
				rec.id_accaount = reader.GetInt16(12);
#else
				reader.GetValues(obj);
				if (!Convert.IsDBNull(obj[0]))
				{
					rec.id = int.Parse(obj[0].ToString());
				}
				else
				{
					rec.id = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.buy_date = obj[1].ToString().Split(' ')[0];
				}
				else
				{
					rec.buy_date = "";
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.pay_date = obj[2].ToString().Split(' ')[0];
				}
				else
				{
					rec.pay_date = "";
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.where = obj[3].ToString();
				}
				else
				{
					rec.where = "";
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.name = obj[4].ToString();
				}
				else
				{
					rec.name = "";
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.rid = int.Parse(obj[5].ToString());
				}
				else
				{
					rec.rid = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.money = int.Parse(obj[6].ToString());
				}
				else
				{
					rec.money = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.ie_type = Int16.Parse(obj[7].ToString());
				}
				else
				{
					rec.ie_type = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.cate_main = Int16.Parse(obj[8].ToString());
				}
				else
				{
					rec.cate_main = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.cate_sub = Int16.Parse(obj[9].ToString());
				}
				else
				{
					rec.cate_sub = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.id_usr = Int16.Parse(obj[10].ToString());
				}
				else
				{
					rec.id_usr = -1;
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.memo = obj[11].ToString();
				}
				else
				{
					rec.memo = "";
				}

				if (!Convert.IsDBNull(obj[0]))
				{
					rec.id_accaount = Int16.Parse(obj[12].ToString());
				}
				else
				{
					rec.id_accaount = -1;
				}
#endif
				lst.Add(rec);
			}

			reader.Close();
			closedb();
			return lst;
		}

		private void opendb()
		{
			if (null != hConn) return;
			hConn = new SQLiteConnection("Data Source=" + db_path);

			try
			{
				// データベース接続を開く
				hConn.Open();
			}
			catch (Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.Message);
			}
		}

		private void closedb()
		{
			hConn.Close();
			hConn.Dispose();
			hConn = null;
		}
	}

}
