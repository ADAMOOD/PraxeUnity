using System;
using Newtonsoft.Json;

namespace Assets.Scripts
{
    [Serializable]
    public class Quiz
    {
        public int maxPlayerCount { get; set; }
        public int currentPlayerCount { get; set; }
        public DataController.RoomState roomState { get; set; }
        public DateTime createdAt { get; set; }

        // Default constructor for deserialization
        [JsonConstructor]
        public Quiz()
        {
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, DataController.RoomState roomState, DateTime createdAt)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = createdAt;
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, DataController.RoomState roomState)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = DateTime.Now;
        }
    }
}
