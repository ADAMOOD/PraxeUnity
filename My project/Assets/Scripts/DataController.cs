using System;
using System.IO;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using Assets.Scripts;
using Newtonsoft.Json; // Add reference to Newtonsoft.Json package

public class DataController : MonoBehaviour
{
    public static bool loading;
    public static Quiz[] GetQuizzes(/*int num*/)
    {
        loading=true;
        try
        {
            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create(String.Format($"http://localhost:5191/api/Quiz/random/3"));
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            // Use Newtonsoft.Json for deserialization
            Quiz[] quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.Auto});
            loading = false;
            return quizzes;
        }
        catch (SocketException ex)
        {
            Debug.Log("Nepodaøilo se pøipojit k serveru: " + ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            Debug.Log("Neoèekávaná chyba: " + ex.Message);
            // Pøípadné další ošetøení chyby
            return null;
        }
    }
    public static Quiz[] GetQuizzes(int num)
    {
        loading = true;
        try
        {
            HttpWebRequest request =
                (HttpWebRequest)WebRequest.Create(String.Format($"http://localhost:5191/api/Quiz/random/{num}"));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            // Use Newtonsoft.Json for deserialization
            Quiz[] quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
            loading = false;
            return quizzes;
        }
        catch (SocketException ex)
        {
            Debug.Log("Nepodaøilo se pøipojit k serveru: " + ex.Message);
            return null;
        }
        catch (Exception ex)
        {
            Debug.Log("Neoèekávaná chyba: " + ex.Message);
            // Pøípadné další ošetøení chyby
            return null;
        }
    }
}