using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;

namespace CrudUsingMongoDB
{
    class Entity
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Age")]
        public double Age { get; set; }

        [BsonElement("JobType")]
        public string JobType { get; set; }

        public Entity(string name, double age, string jobtype)
        {
            Name = name;
            Age = age;
            JobType = jobtype;
        }
    }
}
