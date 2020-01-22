using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver.Builders;
using Microsoft.Reporting.WinForms;
using System.Net.Mail;
using System.Net;

namespace CrudUsingMongoDB
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public static IMongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase database = client.GetDatabase("Hamza");

        private void Form3_Load(object sender, EventArgs e)
        {
            var collection = database.GetCollection<Entity>("Hamza");
        
            List<Entity> list = collection.AsQueryable().ToList();

            ReportDataSource rds = new ReportDataSource("DataSet1", list);
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            ToolStrip toolstrip = new ToolStrip();
            toolstrip.Text = "Email";
        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {
            ToolStrip ts = new ToolStrip();
            ts.Items.Add("Email");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


    }
}