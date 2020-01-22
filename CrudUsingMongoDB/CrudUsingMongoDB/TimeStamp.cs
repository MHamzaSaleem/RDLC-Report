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
    public partial class TimeStamp : Form
    {
        public TimeStamp()
        {
            InitializeComponent();
        }   
        public static DateTime Time1,Time2;
        //public static string stringTime1, stringTime2;
        List<TimeStamping> finalList = new List<TimeStamping>() { }; 
        
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Time1 = dateTimePicker1.Value;
            long lg = ConvertToUnixTime(Time1);
            //DateTime dt = UnixTimeToDateTime(lg);
            // = (lg.ToString()); 
        }
        
        
        public static long ConvertToUnixTime(DateTime datetime)
        {
            DateTime sTime = new DateTime(1970, 1, 1,0,0,0,DateTimeKind.Utc);;
          
            return (long)(datetime - sTime).TotalSeconds;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            Time2 = dateTimePicker2.Value;
            long lg = ConvertToUnixTime(Time2);
        }

        private void TimeStamp_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy hh:mm:ss tt";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MM/dd/yyyy hh:mm:ss tt"; 
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
        //void dropDown(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if(sender is ToolStripDropDownButton)
        //        {
        //            var ddList = sender as ToolStripDropDownButton;
        //            ddList.DropDownItems.Add(new ToolStripMenuItem("email", null, sendMail_Click));
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void sendMail_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("hye");
        //    throw new NotImplementedException();
        //}
        //void AddEmailOption()
        //{
        //    try
        //    {
        //        var toolstrip = this.reportViewer1.Controls.Find("toolStrip1", true)[0] as ToolStrip;
        //        if(toolstrip!=null)
        //        {
        //            foreach(var dropDownButton in toolstrip.Items.OfType<ToolStripDropDownButton>())
        //            {
        //                dropDownButton.DropDownOpened += new EventHandler(dropDown);
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        public static DateTime UnixTimeToDateTime(long unixtime)
        {
            DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return sTime.AddSeconds(unixtime);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Checked==true &&dateTimePicker2.Checked==true)
            {
                if (finalList != null)
                    finalList.Clear();

                reportViewer1.LocalReport.DataSources.Clear();
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("Hamza");
                var collection = database.GetCollection<TimeStamping>("TST");
                var filterQuery = Builders<TimeStamping>.Filter.Gte("DateTime", ConvertToUnixTime(Time1).ToString()) & Builders<TimeStamping>.Filter.Lte("DateTime", ConvertToUnixTime(Time2).ToString());
                List<TimeStamping> list = collection.AsQueryable().ToList();
                List<TimeStamping> filteredList = collection.Find(filterQuery).ToList();
                int c = filteredList.Count;
                int count = 0;
                try
                {
                    while (c > 0)
                    {
                        finalList.Add(new TimeStamping
                                 {
                                     _id = filteredList[count]._id,
                                     Name = filteredList[count].Name,
                                     Age = filteredList[count].Age,
                                     DateTime = UnixTimeToDateTime(long.Parse(filteredList[count].DateTime)).ToString()
                                 });
                        count++;
                        c--;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                ReportDataSource rds = new ReportDataSource("DataSet1", finalList);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                MessageBox.Show(finalList.Count.ToString());
                this.reportViewer1.RefreshReport();
            }
            else
            {
                label4.Text = "Please Choose Dates First & From Date must be less than To Date";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(t.Count.ToString());
           // Email email = new Email();
           // email.Show();
            //email.GetList(ref t);
            //var client = new MongoClient("mongodb://localhost:27017");
            //var database = client.GetDatabase("Hamza");
            //var collection = database.GetCollection<TimeStamping>("TST");
            //try
            //{
            //    TimeStamping ts = new TimeStamping("Hamza", double.Parse("21"), stringTime1.ToString());
            //    collection.InsertOne(ts);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
       }

        private void reportViewer1_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_ReportExport(object sender, ReportExportEventArgs e)
        {

        }
        public void sendMail()
        {
            int count = 0;
            try
            {
                if (textBox1.Text != "" || textBox4.Text != "")
                {
                    SmtpClient client = new SmtpClient();
                    client.Host = "nscommunity.mojkgb.com";
                    client.Port = int.Parse("587");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new NetworkCredential("hamza@nscommunity.mojkgb.com", "passwordmym123");
                    client.EnableSsl = true;
                    MailMessage message = new MailMessage();
                    message.To.Add(textBox1.Text);
                    message.From = new MailAddress("mhamzasaleem1998@gmail.com");
                    message.Subject = textBox4.Text;
                    //message.CC.Add(textBox2.Text);
                    //message.Bcc.Add(textBox3.Text);
                    message.IsBodyHtml = true;
                    string textBody = "";
                    int listCount = finalList.Count;
                    textBody = "<table border=" + 1 + " cellpadding=" + 0 + " cellspacing=" + 0 + " width = " + 400 + "><tr bgcolor='#4da6ff'><td><b>Name</b></td> <td> <b> Age</b> </td> <td> <b> JobType</b> </td></tr>";
                    while (listCount > 0)
                    {
                        textBody += "<tr><td>" + finalList[count].Name + "</td><td> " + finalList[count].Age + "</td><td>" + finalList[count].DateTime + "</td> </tr>";
                        count++;
                        listCount--;
                    }
                    textBody += "</table>";
                    message.Body = textBody;
                    client.Send(message);
                    label3.Text = "Sent!";
                }
                else
                {
                    label3.Text = "Please Enter Email Carefully!";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sendMail();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
    }
}
