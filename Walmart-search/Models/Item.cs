using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Walmart_search.Models
{
    [BsonIgnoreExtraElements()]
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int id { get; set; }
        public string brand { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public int price { get; set; }
        
        // public Item(string _id, int id, string brand, string description, string image, int price) 
        // { 
        //     this._id = _id; 
        //     this.id = id; 
        //     this.brand = brand; 
        //     this.description = description; 
        //     this.image = image;
        //     this.price = price;
        // } 
    }
}