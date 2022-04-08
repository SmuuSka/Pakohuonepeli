using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;


public class MongoDatabase : MonoBehaviour
{
    MongoClient mongoClient = new MongoClient("mongodb://peliryhma2:peliryhma2@pakohuonepeli-shard-00-00.y9oco.mongodb.net:27017,pakohuonepeli-shard-00-01.y9oco.mongodb.net:27017,pakohuonepeli-shard-00-02.y9oco.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-1361pt-shard-0&authSource=admin&retryWrites=true&w=majority");

    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;

    public Dictionary<string, string> newDict = new Dictionary<string, string>();

    private void Start()
    {
        db = mongoClient.GetDatabase("PakohuoneDB");
        collection = db.GetCollection<BsonDocument>("Players");
    }

    public async void AddPlayer(string playerName)
    {
        BsonDocument addPlayer = new BsonDocument().Add("name", playerName);
        await collection.InsertOneAsync(addPlayer);
    }

    public async Task<Dictionary<string,string>> LoadPlayer()
    {
        var playerID = collection.FindAsync(new BsonDocument());
        var players = await playerID;
        Dictionary<string, string> dict = new Dictionary<string, string>();

        foreach (var id in players.ToList())
        {
            var key = id.GetValue("_id").ToString();
            var value = id.GetValue("name").ToString();

            dict.Add(key, value);
        }

        return dict;
    }

}
