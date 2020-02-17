using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudUsingMongoDB
{
    public partial class Map : Form
    {
        public Map()
        {
            InitializeComponent();
        }

        private void MapPoint_Load(object sender, EventArgs e)
        {
            //https://www.codeproject.com/Articles/11844/Integrating-MapPoint-in-your-NET-applications
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MapPoint.ApplicationClass mapPoint = new MapPoint.ApplicationClass();
            MapPoint.Map map = mapPoint.ActiveMap;
            MapPoint.FindResults findResults = map.FindPlaceResults(this.textBox1.Text);
            var a = findResults[0];

        }
    }
}
