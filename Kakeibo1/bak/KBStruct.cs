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
	struct KBRec
	{
		public int id;
		public string buy_date;
		public string pay_date;
		public string where;
		public string name;
		public int rid;
		public int money;
		public Int16 ie_type;
		public Int16 cate_main;
		public Int16 cate_sub;
		public Int16 id_usr;
		public string memo;
		public Int16 id_accaount;
	}
	struct KBDat
	{
		public int num;
		public List<KBRec> rec;
	}

	public struct CateSubRec
	{
		public Int16 id;
		public Int16 sortid;
		public Int16 id_cate_main;
		public string name;
	}

	public struct CateMainRec
	{
		public Int16 id;
		public Int16 sortid;
		public string name;
		public List<CateSubRec> rec_sub;
	}
	struct CateMaindat
	{
		public List<CateMainRec> rec;
	}

	struct Category
	{
		public CateMaindat cate;
	}

	public struct AccountRec
	{
		public Int16 id;
		public sbyte eot;
		public sbyte type;
		public int initval;
		public string name;
	}
}
