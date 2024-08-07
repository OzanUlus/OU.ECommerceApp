using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerce.Catalog.Entities
{
    public class SpecialDiscount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SpecialDiscountId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string ImageUrl { get; set; }
    }
}
