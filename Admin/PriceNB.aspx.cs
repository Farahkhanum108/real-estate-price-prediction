using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Collections;
using System.Threading;
using System.Configuration;

namespace pricePrediction.Admin.Files
{
    public partial class PriceNB : System.Web.UI.Page
    {
        public static OleDbConnection oledbConn;
        DataTable dt = new DataTable();
        DataTable dtDistinct = new DataTable();
        static ArrayList _arrayPatientsCnt = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TrainingDS();
                TestingDS();
            }
            catch
            {

            }
        }

        private void TestingDS()
        {
            string FileName = "TestingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TestingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTestingDS(FilePath, Extension, _Location);
        }
        //function which contains the algorithm steps
        private string __NaiveBAyes(string[] values)
        {
            ArrayList _Distance = new ArrayList();
            ArrayList _RecordId = new ArrayList();

            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 35; //k value

            //finding the distance between the objects
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double _val = 0.0;

                for (int j = 0; j < values.Length; j++)
                {
                    string _valluee = dt.Rows[i][j].ToString();

                    if (_valluee.Equals("?") || values[j].ToString().Equals("?") ||
                        _valluee.Equals("") || values[j].ToString().Equals(""))
                    {

                    }
                    else
                    {
                        _val += Math.Pow(double.Parse(dt.Rows[i][j].ToString()) - double.Parse(values[j].ToString()), 2);
                    }
                }

                _val = Math.Sqrt(_val);

                _Distance.Add(Math.Round(_val, 1));
                _RecordId.Add(i);
            }

            ArrayList temp = new ArrayList();
            ArrayList arrayRecords = new ArrayList();

            ArrayList arrayExists = new ArrayList();
            int d = 0;

            for (int x = 0; x < _Distance.Count; x++)
            {
                temp.Add(_Distance[x]);
            }

            temp.Sort();

            for (int y = 0; y < m; y++)
            {
                d = 0;

                for (int z = 0; z < _Distance.Count; z++)
                {
                    if (_Distance[z].Equals(temp[y]))
                    {
                        if (d == 0 && !arrayExists.Contains(_RecordId[z]))
                        {
                            arrayRecords.Add(_RecordId[z]);

                            arrayExists.Add(_RecordId[z]);

                            ++d;
                        }
                    }
                }
            }

            string _output = null;

            if (arrayRecords.Count > 0)
            {
                int cnt;

                ArrayList arrayCnt = new ArrayList();
                ArrayList arrayOutcome = new ArrayList();

                for (int i = 0; i < s.Count; i++)
                {
                    cnt = 0;

                    for (int j = 0; j < arrayRecords.Count; j++)
                    {
                        if (dt.Rows[int.Parse(arrayRecords[j].ToString())]["Result"].ToString().Equals(s[i]))
                        {
                            ++cnt;
                        }
                    }

                    arrayCnt.Add(cnt);
                    arrayOutcome.Add(s[i]);
                }

                ArrayList temp1 = new ArrayList();

                for (int x = 0; x < arrayCnt.Count; x++)
                {
                    temp1.Add(arrayCnt[x]);
                }

                temp1.Sort();
                temp1.Reverse();



                for (int y = 0; y < arrayCnt.Count; y++)
                {
                    if (arrayCnt[y].Equals(temp1[0]))
                    {
                        _output = s[y].ToString();

                        //if (_output.Equals("0"))
                        //{
                        //    _output = "No";
                        //}
                        //else
                        //{
                        //    _output = "Yes";
                        //}

                        return _output;

                    }
                }
            }

            return _output;
        }


        private void ImportTestingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {

                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();

            DataTable dt = new DataTable();

            cmdExcel.Connection = connExcel;

            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();



            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;

            oda.Fill(dt);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {

                //Bind Data to GridView

                GridView1.Caption = Path.GetFileName(FilePath);

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Testing Dataset Found!!!')</script>");
            }



            connExcel.Close();





        }

        private void TrainingDS()
        {
            string FileName = "TrainingDataset.xls";

            string Extension = ".xls";

            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

            string _Location = "TrainingDataset";

            string FilePath = Server.MapPath(FolderPath + FileName);

            ImportTrainingDS(FilePath, Extension, _Location);
        }

        private void ImportTrainingDS(string FilePath, string Extension, string _Location)
        {
            string conStr = "";

            switch (Extension)
            {
                case ".xls": //Excel 97-03

                    conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                             .ConnectionString;

                    break;

                case ".xlsx": //Excel 07

                    conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                              .ConnectionString;

                    break;

            }

            conStr = String.Format(conStr, FilePath, _Location);

            OleDbConnection connExcel = new OleDbConnection(conStr);

            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbCommand cmdDistinct = new OleDbCommand();
            OleDbCommand cmdPatientsCnt = new OleDbCommand();

            OleDbDataAdapter oda = new OleDbDataAdapter();
            OleDbDataAdapter odaDistinct = new OleDbDataAdapter();

            cmdExcel.Connection = connExcel;
            cmdDistinct.Connection = connExcel;
            cmdPatientsCnt.Connection = connExcel;
            //Get the name of First Sheet

            connExcel.Open();

            DataTable dtExcelSchema;

            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

            connExcel.Close();

            //Read Data from First Sheet

            connExcel.Open();

            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            cmdDistinct.CommandText = "SELECT DISTINCT(Result) From [" + SheetName + "]";

            oda.SelectCommand = cmdExcel;
            odaDistinct.SelectCommand = cmdDistinct;

            oda.Fill(dt);
            odaDistinct.Fill(dtDistinct);

            //BLL obj = new BLL();

            if (dt.Rows.Count > 0)
            {
                if (dtDistinct.Rows.Count > 0)
                {
                    //for (int i = 0; i < dtDistinct.Rows.Count; i++)
                    //{
                    //    cmdPatientsCnt.CommandText = "SELECT COUNT(*) From [" + SheetName + "] where result=" + dtDistinct.Rows[i]["result"].ToString() + "";
                    //    _arrayPatientsCnt.Add(cmdPatientsCnt.ExecuteScalar());
                    //}
                }

                connExcel.Close();

            }
            else
            {
                btnPrediction.Visible = false;
                ClientScript.RegisterStartupScript(this.GetType(), "Key", "<Script>alert('No Training Dataset!!!')</script>");
            }
        }

        protected void btnPrediction_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = "TestingDataset.xls";

                string Extension = ".xls";

                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];

                string _Location = "TestingDataset";

                string FilePath = Server.MapPath(FolderPath + FileName);

                string conStr = "";

                switch (Extension)
                {

                    case ".xls": //Excel 97-03

                        conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]

                                 .ConnectionString;

                        break;

                    case ".xlsx": //Excel 07

                        conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]

                                  .ConnectionString;

                        break;

                }

                conStr = String.Format(conStr, FilePath, _Location);

                OleDbConnection connExcel = new OleDbConnection(conStr);

                OleDbCommand cmdExcel = new OleDbCommand();

                OleDbDataAdapter oda = new OleDbDataAdapter();

                DataTable tabData = new DataTable();

                cmdExcel.Connection = connExcel;

                //Get the name of First Sheet

                connExcel.Open();

                DataTable dtExcelSchema;

                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                connExcel.Close();



                //Read Data from First Sheet

                connExcel.Open();

                cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";

                oda.SelectCommand = cmdExcel;

                oda.Fill(tabData);

                //BLL obj = new BLL();

                int slNo = 1;

                if (tabData.Rows.Count > 0)
                {
                    Session["Output"] = null;
                    string _Predictedoutput = null;
                    string _timeNB = null;

                    tablePrediction.Rows.Clear();

                    tablePrediction.BorderStyle = BorderStyle.Double;
                    tablePrediction.GridLines = GridLines.Both;
                    tablePrediction.BorderColor = System.Drawing.Color.Black;

                    TableRow mainrow = new TableRow();
                    mainrow.Height = 30;
                    mainrow.ForeColor = System.Drawing.Color.Black;
                    mainrow.BackColor = System.Drawing.Color.DarkOrange;

                    TableCell cell0 = new TableCell();
                    cell0.Width = 100;
                    cell0.Text = "<b>SlNo</b>";
                    mainrow.Controls.Add(cell0);


                    TableCell cell25 = new TableCell();
                    cell25.Text = "<b>Result</b>";
                    mainrow.Controls.Add(cell25);

                    tablePrediction.Controls.Add(mainrow);

                    var watch = System.Diagnostics.Stopwatch.StartNew();

                    for (int i = 0; i < tabData.Rows.Count; i++)
                    {
                        string _data = tabData.Rows[i]["area_type"].ToString() + "," +
                            tabData.Rows[i]["size"].ToString() + "," +
                            tabData.Rows[i]["total_sqft"].ToString() + "," +
                            tabData.Rows[i]["bath"].ToString() + "," +
                            tabData.Rows[i]["balcony"].ToString() + "," +
                            tabData.Rows[i]["road_access"].ToString() + "," +
                            tabData.Rows[i]["alley_access"].ToString() + "," +
                            tabData.Rows[i]["General_shape"].ToString() + "," +
                            tabData.Rows[i]["Flatness"].ToString() + "," +
                            tabData.Rows[i]["Slope"].ToString();


                        string[] values = _data.Split(',');

                        string _output = __NaiveBAyes(values);

                        TableRow row = new TableRow();

                        TableCell _cell0 = new TableCell();
                        _cell0.Text = slNo + i + ".";
                        row.Controls.Add(_cell0);


                        TableCell cellResult = new TableCell();
                        cellResult.Width = 250;
                        cellResult.Text = _output;
                        row.Controls.Add(cellResult);

                        tablePrediction.Controls.Add(row);

                        //if (_output.Equals("0"))
                        //{
                        //    ++_array0Res;
                        //}
                        //else if (_output.Equals("1"))
                        //{
                        //    ++_array1Res;
                        //}         

                        _Predictedoutput += _output + ",";
                    }

                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    _timeNB = elapsedMs.ToString();

                    Session["Output"] = _timeNB + "," + _Predictedoutput.Substring(0, _Predictedoutput.Length - 1);
                }
            }
            catch
            {

            }
        }

        ArrayList output = new ArrayList();
        ArrayList mul = new ArrayList();

        //function to load subject
        public ArrayList GetSubject()
        {
            ArrayList s = new ArrayList();

            if (dtDistinct.Rows.Count > 0)
            {
                s.Clear();

                for (int i = 0; i < dtDistinct.Rows.Count; i++)
                {
                    if (dtDistinct.Rows[i]["Result"].Equals(" ") || dtDistinct.Rows[i]["Result"].Equals("") || dtDistinct.Rows[i]["Result"] == null)
                    {

                    }
                    else
                    {
                        s.Add(dtDistinct.Rows[i]["Result"].ToString());
                    }
                }
            }

            return s;
        }

        protected void btnResults_Click(object sender, EventArgs e)
        {
            btnPrediction_Click(sender, e);
            Response.Redirect("ResultAnalysis.aspx");
        }

        double pi;
        int nc, n;
        double result;
       
        //function which contains binning coding
        private void binningMethod()
        {
            try
            {

                Class1 obj = new Class1();
                DataTable tabDataset = new DataTable();
                ArrayList _mising = new ArrayList();

                tabDataset.Rows.Clear();
                //fetch the training dataset 
                //tabDataset = dt;

                if (dt.Rows.Count > 0)
                {
                    //code of binning method
                    for (int i = 0; i < tabDataset.Rows.Count; i++)
                    {
                        string _data = tabDataset.Rows[i]["area_type"].ToString() + "," +
                            tabDataset.Rows[i]["size"].ToString() + "," +
                            tabDataset.Rows[i]["total_sqft"].ToString() + "," +
                            tabDataset.Rows[i]["bath"].ToString() + "," +
                            tabDataset.Rows[i]["balcony"].ToString() + "," +
                            tabDataset.Rows[i]["road_access"].ToString() + "," +
                            tabDataset.Rows[i]["alley_access"].ToString() + "," +
                            tabDataset.Rows[i]["General_shape"].ToString() + "," +
                            tabDataset.Rows[i]["Flatness"].ToString() + "," +
                            tabDataset.Rows[i]["Slope"].ToString();


                        string[] parameter = _data.Split(',');

                        for (int j = 0; j < parameter.Length; j++)
                        {
                            if (parameter[j].Equals("") || parameter.Equals("?"))
                            {
                                for (int k = 0; k < tabDataset.Rows.Count; k++)
                                {
                                    int id = 0;
                                    Random r = new Random();

                                    for (int x = 1; x <= 2; x++)
                                    {
                                        id = r.Next(9);
                                    }

                                    //setting value for ? and null value
                                    string _value = tabDataset.Rows[id][parameter[j]].ToString();
                                    _mising.Add(_value);
                                }
                            }

                        }
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "key", "<script>alert('Dataset Not Found!!!')</script>");
                }
            }
            catch
            {

            }
        }


        //function which contains the algorithm steps
        private string _NaiveBAyes(string[] values)
        {
            ArrayList s = new ArrayList();
            output.Clear();

            //try
            //{
            s = GetSubject();

            int m = 10;
            double numer = 1.0;
            double dino = double.Parse(s.Count.ToString());
            double p = numer / dino;


            for (int i = 0; i < s.Count; i++)
            {
                mul.Clear();

                for (int j = 0; j < 10; j++)
                {
                    n = 0;
                    nc = 0;

                    for (int d = 0; d < dt.Rows.Count; d++)
                    {
                        if (dt.Rows[d][j].ToString().Equals(values[j]))
                        {
                            ++n;

                            if (dt.Rows[d][m].ToString().Equals(s[i]))

                                ++nc;
                        }
                    }

                    double x = m * p;
                    double y = n + m;
                    double z = nc + x;

                    pi = z / y;
                    mul.Add(Math.Abs(pi));
                }

                double mulres = 1.0;

                for (int z = 0; z < mul.Count; z++)
                {
                    mulres *= double.Parse(mul[z].ToString());
                }

                result = mulres * p;
                output.Add(Math.Abs(result));
            }

            ArrayList list1 = new ArrayList();

            for (int x = 0; x < s.Count; x++)
            {
                list1.Add(output[x]);
            }

            list1.Sort();
            list1.Reverse();

            string _output = null;

            for (int y = 0; y < s.Count; y++)
            {
                if (output[y].Equals(list1[0]))
                {
                    _output = s[y].ToString();

                    //if (_output.Equals("0"))
                    //{
                    //    _output = "No";
                    //}
                    //else
                    //{
                    //    _output = "Yes";
                    //}

                    return _output;
                }
            }
            //}
            //catch
            //{

            //}

            return _output;
        }



    }
}