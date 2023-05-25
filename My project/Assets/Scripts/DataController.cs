using System;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Assets.Scripts;
using Newtonsoft.Json;

public class DataController : MonoBehaviour
{
    public bool Loading { get; set; }
    public Quiz[] Quizzes { get; set; }

    public DataController()
    {
        Quizzes = new Quiz[0];
        Loading = false;
    }

    public async Task GetQuizzesAsync(int num)
    {
        Loading = true;
        try
        {
            string url = $"http://localhost:5191/api/Quiz/random/{num}";
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse);
                    Array.ForEach(Quizzes, quiz => quiz.InsertPlayers());
                }
                else
                {
                    Debug.Log("Neúspìšný požadavek: " + response.StatusCode);
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Debug.Log("Nepodaøilo se pøipojit k serveru: " + ex.Message);
            Loading = false;
        }
        catch (Exception ex)
        {
            Debug.Log("Neoèekávaná chyba: " + ex.Message);
            Loading = false;
        }
        Loading = false;
    }
}