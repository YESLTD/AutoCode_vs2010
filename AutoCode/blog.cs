using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using ToolFunction;
namespace AutoCode
{
    public class blog: IBasePO
    {
        public ObjectId _id;//BsonType.ObjectId 这个对应了 MongoDB.Bson.ObjectId 
        public string titile { get; set; }
        public string content { set; get; }
        public DateTime date { set; get; }
    }
}
