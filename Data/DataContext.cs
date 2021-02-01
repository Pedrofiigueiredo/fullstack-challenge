using Cotabox.Models;
using MongoDB.Driver;

namespace Cotabox.Data
{
  public class DataContext
  {
    public readonly IMongoCollection<Partner> Partner;
    public DataContext()
    {
      var client = new MongoClient("mongodb+srv://admin:admin@cluster0.wvisc.mongodb.net/Cotabox?retryWrites=true&w=majority");
      var database = client.GetDatabase("Cotabox");
      
      Partner = database.GetCollection<Partner>("Partners");
    }
  }
}