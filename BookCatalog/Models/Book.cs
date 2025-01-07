using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Models{
    public class Book{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Genre { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}