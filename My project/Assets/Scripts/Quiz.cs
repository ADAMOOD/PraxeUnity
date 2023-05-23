using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

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
            return $"Max {maxPlayerCount}, {currentPlayerCount} Players, Status {roomState}, created:{createdAt}";
        }
        public static string[] ExtractValuesFromFormattedString(string input)
        {
            string pattern = @"Max (\d+), (\d+) Players, Status (\w+), created:(.+)";

            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string maxPlayerCount = match.Groups[1].Value;
                string currentPlayerCount = match.Groups[2].Value;
                string roomState = match.Groups[3].Value;
                string createdAt = match.Groups[4].Value;

                string[] values = new string[4];
                values[0] = maxPlayerCount;
                values[1] = currentPlayerCount;
                values[2] = roomState;
                values[3] = createdAt;
                return values;
            }
            else
            {
                Debug.Log("chyba");
                return null;
            }
        }
    }
}
