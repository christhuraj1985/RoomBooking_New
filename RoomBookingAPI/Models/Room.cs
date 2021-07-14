using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingAPI.Models
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string RoomId { get; set; }
        [BsonElement("Name")]
        public string RoomName { get; set; }
        public string Status { get; set; }
        public string RoomType { get; set; }
    }
}
