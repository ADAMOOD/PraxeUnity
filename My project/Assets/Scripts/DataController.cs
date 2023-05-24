using System;
using System.IO;
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
    public event Action QuizzesLoaded;

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
                    Quizzes = JsonConvert.DeserializeObject<Quiz[]>(jsonResponse, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });
                    QuizzesLoaded?.Invoke();
                }
                else
                {
                    Debug.Log("Ne�sp�n� po�adavek: " + response.StatusCode);
                }
            }
        }
        catch (HttpRequestException ex)
        {
            Debug.Log("Nepoda�ilo se p�ipojit k serveru: " + ex.Message);
            Loading = false;
        }
        catch (Exception ex)
        {
            Debug.Log("Neo�ek�van� chyba: " + ex.Message);
            Loading = false;
            // P��padn� dal�� o�et�en� chyby
        }
        Loading = false;
    }
}