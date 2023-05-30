using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rank { get; set; }
        public string Country { get; set; }

        public Player(int id, string name, string rank, string country)
        {
            Country = country;
            Id = id;
            Name = name;
            Rank = rank;
        }
        public override string ToString()
        {
            return $"Player ID: {Id}\nName: {Name}\nRank: {Rank}\nCountry: {Country}";
        }
        public static List<Player> SortPlayersByRankDescending(List<Player> players)
        {
            List<Player> sortedPlayers = new List<Player>(players);
            sortedPlayers.Sort((p1, p2) => int.Parse(p2.Rank).CompareTo(int.Parse(p1.Rank)));
            return sortedPlayers;
        }
    }
}

