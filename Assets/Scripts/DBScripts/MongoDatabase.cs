using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using System;


public class MongoDatabase : MonoBehaviour
{

    // Luodaan uusi Mongoclient objekti ja otetaan parametriksi databasen URL-osoite.
    MongoClient mongoClient = new MongoClient("mongodb://peliryhma2:peliryhma2@pakohuonepeli-shard-00-00.y9oco.mongodb.net:27017,pakohuonepeli-shard-00-01.y9oco.mongodb.net:27017," +
        "pakohuonepeli-shard-00-02.y9oco.mongodb.net:27017/myFirstDatabase?ssl=true&replicaSet=atlas-1361pt-shard-0&authSource=admin&retryWrites=true&w=majority");

    // Luodaan muuttuja Mongodatabase ja Mongocollection interfaceista.
    IMongoDatabase db;
    IMongoCollection<BsonDocument> collection;


    private void Start()
    {
        // Haetaan database referenssi ja tallennetaan se "db" muuttujaan.
        db = mongoClient.GetDatabase("PakohuoneDB");
        // Haetaan collection referenssi ja tallennetaan se "collection" muuttujaan.
        collection = db.GetCollection<BsonDocument>("Players");
    }

    // Lisätään pelaaja käyttäen asynkronista metodia ja otetaan parametriksi pelaajan nimi string muodossa ja pisteet integereinä.
    public async void AddPlayer(string playerName, int score)
    {
        // Luodaan paikallinen muuttuja, johon tallennetaan LoadPlayer-metodin tieto.
        var playersData = LoadPlayer();
        // Luodaan paikallisesta playersData muuttujasta sanakirja/hakemisto.
        var dict = await playersData;

        // Katsotaan onko hakemistossa yhtään pelaajaa luotuna tietokantaan.
        if (dict.Count < 1)
        {
            // Tässä luodaan paikallinen BsonDocument muuttuja addPlayers ja tallennetaan siihen uusi olio, jossa on pelaajan nimi ja pisteet. 
            BsonDocument addPlayers = new BsonDocument().Add("name", playerName).Add("score", score);
            // Ladataan pelaaja await komennon avulla luotu pelaajakokoelmaan.
            await collection.InsertOneAsync(addPlayers);
        }
        // Jos hakemistossa on pelaajia.
        else
        {
            // Ajetaan silmukka läpi, jolla tarkistetaan löytyykö samanniminen pelaaja hakemistosta.
            foreach (var player in dict)
            {
                // Jos pelaaja löytyy jo hakemistosta palataan takaisin alkuun, eikä lisätä pelaajaa.
                if (playerName.Equals(player.Key))
                {
                    return;
                }
            }
            // Jos ei löytynyt yhtään samannimistä pelaajaa voidaan lisätä pelaaja hakemistoon.
            BsonDocument addPlayers = new BsonDocument().Add("name", playerName).Add("score", score);
            await collection.InsertOneAsync(addPlayers);
        }      
    }

    // Tässä metodissa korvataan vanha tulos uudella. Tätä käytetään vain jos uusi tulos on parempi kuin vanha.
    public void NewHighScore(string playerName, int score) // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! KOKEILE ILMAN NIMEÄ !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    {
        // Tässä luodaan paikallinen newScore muuttuja ja tallennetaan siihen uudet pisteet.
        BsonDocument newScore = new BsonDocument().Add("name", playerName).Add("score", score);
        // Tallennetaan muuttujaksi Builders-luokasta BsonDocument tyyppinen Filter.Equal metodi, ja asetetaan filtteriksi pelaajan nimi.
        var filter = Builders<BsonDocument>.Filter.Eq("name", playerName);
        // Korvataan löydetty vanha tulos paremmalla uudella tuloksella.
        collection.ReplaceOne(filter, newScore);
    }

    // Ladataan hakemistosta pelaajat ja pelaajien parhaimmat tulokset.
    public async Task<Dictionary<string, int>> LoadPlayer()
    {
        // Luodaan paikallinen muuttuja ja tallennetaan siihen collection.FindASync(new BsonDocument) metodi ja luodaan siitä uusi objekti.
        var playerID = collection.FindAsync(new BsonDocument());
        // Tallennetaan playerID:stä tuleva tieto toiseen paikalliseen muuttujaan nimeltä players.
        var players = await playerID;
        // Luodaan tyhjä hakemisto ja alustetaan se.
        Dictionary<string, int> dict = new Dictionary<string, int>();

        // Ajetaan silmukka läpi, jolla haetaan hakemistosta kaikki pelaajat ja pelaajien parhaat pisteet ja tallennetaan ne uuteen paikalliseen hakemistoon.
        foreach (var id in players.ToList())
        {
            // Luodaan paikallinen "key" muuttuja ja tallennetaan siihen pelaajan nimi.
            var key = id.GetValue("name").ToString();
            // Luodaan paikallinen "value" muuttuja ja tallennetaan siihen pelaajan pisteet. Käännetään se integer muotoon.
            var value = Convert.ToInt32(id.GetValue("score"));

            // Lisätään arvopari hakemistoon.
            dict.Add(key, value);
        }

        // Palautetaan hakemisto.
        return dict;
    }

}
