using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class web : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        // StartCoroutine(GetRequest("http://localhost/game_themahad/getSoalData.php"));

        // A non-existing page.
        // StartCoroutine(GetRequest("https://error.html"));
    }
    void Update()
    {

    }

    // IEnumerator GetRequest(string uri)
    // {
    //     using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
    //     {
    //         // Request and wait for the desired page.
    //         yield return webRequest.SendWebRequest();

    //         string[] pages = uri.Split('/');
    //         int page = pages.Length - 1;

    //         switch (webRequest.result)
    //         {
    //             case UnityWebRequest.Result.ConnectionError:

    //             case UnityWebRequest.Result.DataProcessingError:
    //                 Debug.LogError(pages[page] + ": Error: " + webRequest.error);
    //                 break;

    //             case UnityWebRequest.Result.ProtocolError:
    //                 Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
    //                 break;

    //             case UnityWebRequest.Result.Success:
    //                 Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
    //                 break;
    //         }
    //     }
    // }
    // IEnumerator test()
    // {
    //     using (UnityWebRequest www = UnityWebRequest.Get("https://localhost/database/test.php")) ;
    //     {
    //         // Request and wait for the desired page.
    //         yield return www.Send();

    //         if (www.isNetworkError || www.isHttpError)
    //         {
    //             Debug.Log(www.error);
    //         }
    //         else
    //         {
    //             Debug.Log(www.downloadHandler.text);

    //             byte[] results = www.downloadHandler.data;
    //         }
    //     }
    // }
    //     IEnumerator getUser()
    //     {
    //         using (UnityWebRequest www = UnityWebRequest.Get("https://localhost/database/login.php")) ;
    //         {
    //             // Request and wait for the desired page.
    //             yield return www.Send();

    //             if (www.isNetworkError || www.isHttpError)
    //             {
    //                 Debug.Log(www.error);
    //             }
    //             else
    //             {
    //                 Debug.Log(www.downloadHandler.text);

    //                 byte[] results = www.downloadHandler.data;
    //             }
    //         }
    //     }
    //     public IEnumerator registerUser(string usn, string pw)
    //     {
    //         WWWForm form = new WWWForm();
    //         form.AddField("loginUser", usn);
    //         form.AddField("loginPass", pw);

    //         using (UnityWebRequest www = UnityWebRequest.Post("https://localhost/database/registerUser.php", form)) ;
    //         {
    //             // Request and wait for the desired page.
    //             yield return www.SendWebRequest();

    //             if (www.isNetworkError || www.isHttpError)
    //             {
    //                 Debug.Log(www.error);
    //             }
    //             else
    //             {
    //                 Debug.Log(www.downloadHandler.text);

    //                 byte[] results = www.downloadHandler.data;
    //             }
    //         }
    //     }
    //     IEnumerator getUserUsername(string userUsn)
    //     {

    //         WWWForm form = new WWWForm();
    //         form.AddField("userUsn", userUsn);

    //         using (UnityWebRequest www = UnityWebRequest.Post("https://localhost/database/login.php", form)) ;
    //         {
    //             // Request and wait for the desired page.
    //             yield return www.Send();

    //             if (www.isNetworkError || www.isHttpError)
    //             {
    //                 Debug.Log(www.error);
    //             }
    //             else
    //             {
    //                 Debug.Log(www.downloadHandler.text);

    //                 string jsonArray = www.downloadHandler.text;
    //             }
    //         }
    //     }

}