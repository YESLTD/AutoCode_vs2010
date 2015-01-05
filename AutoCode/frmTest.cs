using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolFunction;
using System.Data.OracleClient;
using MongoDB.Bson;
using MongoDB.Driver;
using AutoCode.ServiceReference1;

namespace TestAutoCode
{
    public partial class frmTest : Form, IBase
    {
        public frmTest()
        {

            InitializeComponent();
            InitializeDataSources();
        }

        /// <summary>
        /// 初始化控件数据源，例如combobox
        /// </summary>
        public void InitializeDataSources()
        {
            uctlComboxcs2.source = CommonFunction.getComboxDatasource("number");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string sql1 = "update pat_visit set testcontent =:testcontent where patient_id = :patient_id and visit_id = :visit_id ";
            Dictionary<string, string> dic1 = new Dictionary<string, string>();
            dic1.Add("testcontent", "111");
            dic1.Add("patient_id", "A0856200");
            dic1.Add("visit_id", "1");

            string sql2 = "update pat_visit set testcontent =:testcontent where patient_id = :patient_id and visit_id = :visit_id ";
            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("testcontent", "222");
            dic2.Add("patient_id", "A0856200");
            dic2.Add("visit_id", "1");

            string sql3 = "update pat_visit set testcontent =:testcontent where patient_id = :patient_id and visit_id = :visit_id ";
            Dictionary<string, string> dic3 = new Dictionary<string, string>();
            dic3.Add("testcontent", "333");
            dic3.Add("patient_id", "A0856200");
            dic3.Add("visit_id", "1");
            CommonFunction.BeginTransaction();
            CommonFunction.ExecuteTransNonQuery(sql1, dic1);
            CommonFunction.ExecuteTransNonQuery(sql2, dic3);
            CommonFunction.ExecuteTransNonQuery(sql3, dic3);
            CommonFunction.EndTransaction();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            BsonDocument blog = new BsonDocument 
            {
              {"title"," Ernest Hemingway "  },
              {"content" , " For Whom the Bell Tolls "  },
              {"date" ,1},
              {"author","wuhailong"}
            };
            WriteConcernResult wcr = CommonFunction.InsertMongoCollection("blog", blog);
            //if (wcr.Ok )
            //{
            //    MessageBox.Show(wcr.ToString()+wcr.Ok+"保存成功");
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            QueryDocument query = new QueryDocument();
            BsonDocument b = new BsonDocument();
            //b.Add("$gt", "a");
            //query.Add("title", b);
            MongoCursor mc = CommonFunction.QueryMongoCollection("blog", query);
            string mess = "";

            foreach (BsonDocument item in mc)
            {
                //BsonElement bv = null;
                //item.ToJson();
                //foreach (string name in item.Names)
                //{
                //    mess += name+">>";
                //}
                //if (item.TryGetElement("title",bv))
                //{

                //}
                //GetElement("title").ToString() +"\n";
                try
                {
                    mess += item["date"].ToString() + "\n";
                }
                catch (Exception ex)
                {
                    CommonFunction.WriteErrorLog(ex.ToString());
                }

                //mess += item.Names.ToString() + item.ToString() + ">>>>>>>>" + item.Values.ToString();
            }
            richTextBox1.Text = mess;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserClient uc = new UserClient();
            richTextBox1.Text = uc.ShowName(textBox1.Text);
        }
    }
}
