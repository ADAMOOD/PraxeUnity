using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System;
using System.IO;


public class DataController : MonoBehaviour
{
    public enum RoomState
    {
        Running,
        InLobby,
        Ended
    }
    public class Quiz
    {
        public int maxPlayerCount { get; set; }
        public int currentPlayerCount { get; set; }
        public RoomState roomState { get; set; }
        public DateTime createdAt { get; set; }



        public Quiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.createdAt = DateTime.Now;
            this.roomState = roomState;
        }
        public Quiz(int maxPlayerCount, int currentPlayerCount, RoomState roomState,DateTime createdAt)
        {
            this.maxPlayerCount = maxPlayerCount;
            this.currentPlayerCount = currentPlayerCount;
            this.createdAt = createdAt;
            this.roomState = roomState;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("prdeeel");
        foreach (var quiz in GetQuizzes())
        {
            Debug.Log(quiz);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private Quiz[] GetQuizzes()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:5191/api/Quiz"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log(jsonResponse);
        Quiz[] quizzes = JsonUtility.FromJson<Quiz[]>(jsonResponse);
        return quizzes;
    }
}
