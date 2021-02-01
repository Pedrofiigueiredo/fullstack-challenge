using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cotabox.Models
{
  public class Partner
  {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("Name")]
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Participation { get; set; }
  }
}