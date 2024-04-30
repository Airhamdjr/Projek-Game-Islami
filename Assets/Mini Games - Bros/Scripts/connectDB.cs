// using UnityEngine;
// using System.Data;
// using MySql.Data.MySqlClient;

// public class connectDB : MonoBehaviour
// {
//     private MySqlConnection connection;
//     private string server = "localhost";
//     private string database = "game_themahad";
//     private string username = "root";
//     private string password = "miftahs";

//     private void Start()
//     {
//         string connectionString = "Server=" + server + ";Database=" + database + ";Uid=" + username + ";Pwd=" + password + ";";
//         connection = new MySqlConnection(connectionString);

//         try
//         {
//             connection.Open();
//             Debug.Log("Berhasil terhubung ke database!");
//         }
//         catch (MySqlException ex)
//         {
//             Debug.Log("Gagal terhubung ke database: " + ex.Message);
//         }
//     }

//     private void OnApplicationQuit()
//     {
//         if (connection != null && connection.State != ConnectionState.Closed)
//         {
//             connection.Close();
//         }
//     }
// }

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
// using UnityEngine.Networking;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class connectDB : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        StartCoroutine(GetRequest("http://localhost/game_themahad/getSoalData.php"));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }
    void Update()
    {

    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:

                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;

                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}