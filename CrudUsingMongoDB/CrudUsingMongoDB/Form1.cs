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

namespace CrudUsingMongoDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshGrid();
        }
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        public static MongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase database = client.GetDatabase("Hamza");
        public static string SelectedID, SelectedName, SelectedJobType, SelectedAge;
 
        private void RefreshGrid()
        {
            var collection = database.GetCollection<Entity>("Hamza");
            List<Entity> list = collection.AsQueryable().ToList();
            if (list!=null)
                dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
                label5.Text = "ID field should be empty while Inserting";
            }
            else if(textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                label5.Text = "Fill Fields Carefully before submitting";
            }
            else
            { 
                var collection = database.GetCollection<Entity>("Hamza");
                Entity ent = new Entity(textBox2.Text, double.Parse(textBox3.Text), textBox4.Text);
                collection.InsertOne(ent);
                label5.Text = "Inserted Successfully!";
                RefreshGrid();
                doEmptyFields();
            }
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                var collection = database.GetCollection<Entity>("Hamza");
                var filter = Builders<Entity>.Filter.Eq(x => x._id, ObjectId.Parse(textBox1.Text));
                collection.DeleteOneAsync(filter);
                doEmptyFields();
                RefreshGrid();
                label5.Text = "Deleted Successfully";
            }
            else
            {
                label5.Text = "Please Select Record First which you wanna Delete!";
            }
        }
        private void doEmptyFields()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if(textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" )
            {
                var collection = database.GetCollection<Entity>("Hamza");
                var filter = Builders<Entity>.Filter.Eq(x => x._id, ObjectId.Parse(textBox1.Text));
                var updating = Builders<Entity>.Update.Set("Name", textBox2.Text).Set("Age", double.Parse(textBox3.Text)).Set("JobType", textBox4.Text);
                collection.UpdateOneAsync(filter, updating);
                doEmptyFields();
                RefreshGrid();
                label5.Text = "Updated Successfully!";
            }
            else
            {
                label5.Text = "Please Select Record First which you wanna update!";
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = SelectedID;
            SelectedName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = SelectedName;
            SelectedAge = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = SelectedAge;
            SelectedJobType = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = SelectedJobType;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.ForeColor = Color.Black;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 dialog = new Form3();
            dialog.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TimeStamp dialog = new TimeStamp();
            dialog.Show();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkBlue;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
    }
}
