using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarPoolService.Models
{
    public class Employee
    {
        public ObjectId Id { get; set; }

        [BsonElement("EmployeeId")]
        public int EmployeeID { get; set; }

        [BsonElement("EmployeeName")]
        public string EmployeeName { get; set; }

        [BsonElement("EmployeeAddress")]
        public string EmployeeAddress { get; set; }        
        
    }
}