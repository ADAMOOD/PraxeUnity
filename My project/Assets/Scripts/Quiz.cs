using System;
using Newtonsoft.Json;

namespace Assets.Scripts
{
    [Serializable]
    public class Quiz
    {
        public enum RoomState
        {
            Running,
            InLobby,
            Ended
        }

        public int maxPlayerCount { get; set; }
        public int currentPlayerCount { get; set; }
        public Quiz.RoomState roomState { get; set; }
        public DateTime createdAt { get; set; }

        // Default constructor for deserialization
        [JsonConstructor]
        public Quiz()
        {
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState, DateTime createdAt)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = createdAt;
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = DateTime.Now;
        }
        public override string ToString()
        {
            return $"Max {maxPlayerCount}, {currentPlayerCount} Players, {roomState}, createdAt={createdAt}";
        }
    }
}
