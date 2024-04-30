// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;

// public class Register : MonoBehaviour
// {

//     public InputField usernameInput;
//     public InputField passwordInput;
//     public Button registerButton;
//     public Button goToLoginButton;

//     public ArrayList credentials;

//     // Start is called before the first frame update
//     void Start()
//     {
//         registerButton.onClick.AddListener(writeStuffToFile);
//         goToLoginButton.onClick.AddListener(goToLoginScene);

//         if (File.Exists(Application.dataPath + "/data/credentials.txt"))
//         {
//             credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/data/credentials.txt"));
//         }
//         else
//         {
//             File.WriteAllText(Application.dataPath + "/data/credentials.txt", "");
//         }

//     }

//     void goToLoginScene()
//     {
//         SceneManager.LoadScene("Login");
//     }


//     void writeStuffToFile()
//     {
//         bool isExists = false;

//         credentials = new ArrayList(File.ReadAllLines(Application.dataPath + "/data/credentials.txt"));
//         foreach (var i in credentials)
//         {
//             print(i);
//             if (i.ToString().Contains(usernameInput.text))
//             {

//                 isExists = true;
//                 break;
//             }
//         }

//         if (isExists)
//         {
//             Debug.Log($"Username '{usernameInput.text}' already exists");
//         }
//         else
//         {
//             credentials.Add(usernameInput.text + ":" + passwordInput.text);
//             File.WriteAllLines(Application.dataPath + "/data/credentials.txt", (String[])credentials.ToArray(typeof(string)));
//             Debug.Log("Account Registered");
//             goToLoginScene();
//         }
//     }


// }