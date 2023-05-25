using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

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

        [JsonProperty] public int currentPlayerCount { get; set; }

        public Quiz.RoomState roomState { get; set; }
        public DateTime createdAt { get; set; }
        public int[] Players { get; set; } = new int[0];

        // Default constructor for deserialization
        [JsonConstructor]
        public Quiz()
        {
        }

        public void InsertPlayers()
        {
            Players = new int[currentPlayerCount];
            Debug.Log(currentPlayerCount);
            int r;
            for (int i = 0; i < currentPlayerCount; i++)
            {
                do
                {
                    r = UnityEngine.Random.Range(0, 100);
                    Debug.Log(r);
                } while (Players.Contains(r));

                Players[i] = r;
            }
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState, DateTime createdAt)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = createdAt;
            InsertPlayers();
        }

        public Quiz(int maxPlayerCount, int currentPlayerCount, Quiz.RoomState roomState)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.roomState = roomState;
            this.createdAt = DateTime.Now;
            InsertPlayers();
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