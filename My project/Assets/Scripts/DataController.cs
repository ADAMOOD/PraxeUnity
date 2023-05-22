using System;
using System.IO;
using UnityEngine;
using System.Net;
using Assets.Scripts;
using Newtonsoft.Json; // Add reference to Newtonsoft.Json package

public class DataController : MonoBehaviour
{
    public enum RoomState
    {
        Running,
        InLobby,
        Ended
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

    private Quiz[] GetQuizzes()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:5191/api/Quiz"));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log(jsonResponse);

        // Use Newtonsoft.Json for deserialization
        Quiz[] quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

        return quizzes;
    }
}