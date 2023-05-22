using System;
using System.IO;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using Assets.Scripts;
using Newtonsoft.Json; // Add reference to Newtonsoft.Json package

public class DataController : MonoBehaviour
{
    public static Quiz[] GetQuizzes()
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://localhost:5191/api/Quiz/random/20"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            Debug.Log(jsonResponse);
            // Use Newtonsoft.Json for deserialization
            Quiz[] quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            return quizzes;
        }
        catch (SocketException ex)
        {
            Debug.Log("Nepodaøilo se pøipojit k serveru: " + ex.Message);
            return null;
        }
    }
}