using MongoDB.Driver;
using RoomBookingAPI.Models;
using RoomBookingAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomBookingAPI.Services
{

    public class RoomServices
    {
        private readonly IMongoCollection<Room> _room;
        ILoggerManager _logger;
        IRoomBookingDatabaseSettings _settings;
        public RoomServices(ILoggerManager logger, IRoomBookingDatabaseSettings settings)
        {
            _logger = logger;
            _settings = settings;

            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _room = database.GetCollection<Room>(_settings.RoomBookingCollectionName);
        }

        public List<Room> Get()
        {
            List<Room> room;
            room = _room.Find(rm => true).ToList();
            return room;
        }

        public Room Get(string id)
        {
            Room room = new Room();
            if (_room != null)
                return _room.Find<Room>(rm => rm.RoomId == id).FirstOrDefault();
            else
                return room;
        }

        public Room Create(Room room)
        {
            _room.InsertOne(room);
            return room;
        }

        public void Update(string id, Room roomIn) =>
            _room.ReplaceOne(rm => rm.RoomId == id, roomIn);

        public void Remove(Room roomIn) =>
            _room.DeleteOne(rm => rm.RoomId == roomIn.RoomId);

        public void Remove(string id) =>
            _room.DeleteOne(rm => rm.RoomId == id);
    }
}
