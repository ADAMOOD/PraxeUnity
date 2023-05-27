using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    [Serializable]
    public class Quiz : MonoBehaviour
    {
        public enum RoomState
        {
            Running,
            InLobby,
            Ended
        }

        public int maxPlayerCount { get; set; }

        [JsonProperty] public int currentPlayerCount { get; set; }

        public Quiz.RoomState roomState { get; set; }
        public DateTime createdAt { get; set; }
        public List<Player> Players { get; set; }

        // Default constructor for deserialization
        [JsonConstructor]
        public Quiz()
        {
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState, DateTime createdAt, List<Player> players)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = createdAt;
            this.Players = players;
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState, List<Player> players)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = DateTime.Now;
            this.Players = players;
        }

        public override string ToString()
        {
            string playersString = Players != null ? string.Join(", ", Players.Select(p => p.ToString())) : "null";
            return
                $"maxP. {maxPlayerCount}, currentP. {currentPlayerCount}, R.Status {roomState}, {createdAt}, [{playersString}]";
        }

        public static string[] ExtractValuesFromFormattedString(string input)
        {
            string pattern = @"maxP\. (\d+), currentP\. (\d+), R\.Status (\w+), (.+), \[(.+)\]";
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                string maxPlayerCount = match.Groups[1].Value;
                string currentPlayerCount = match.Groups[2].Value;
                string roomState = match.Groups[3].Value;
                string createdAt = match.Groups[4].Value;
                string playersString = match.Groups[5].Value;
                string[] players = playersString.Split(',');
                string[] values = new string[5];
                values[0] = maxPlayerCount;
                values[1] = currentPlayerCount;
                values[2] = roomState;
                values[3] = createdAt;
                values[4] = playersString;
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