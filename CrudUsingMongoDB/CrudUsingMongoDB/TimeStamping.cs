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
using MongoDB.Bson.Serialization.Attributes;

namespace CrudUsingMongoDB
{
    class TimeStamping
    {

        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public double Age { get; set; }

        public string DateTime { get; set; }
    
        public TimeStamping(ObjectId id, string name, double age, string dateTime)
        {
            _id = id;
            Name = name;
            Age = age;
            DateTime = dateTime;
        }

        public TimeStamping()
        {   

        }

        public TimeStamping(string name , double age, string datetime)
        {
            // TODO: Complete member initialization
            Name = name;
            Age = age;
            DateTime = datetime;
        }
    }
    public class test
    {
        public ObjectId _id { get; set; }

        public string Name { get; set; }

        public double Age { get; set; }

        public DateTime DateTime { get; set; }
    }

}
