using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;






// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.SceneManagement;
// public class SaveData : MonoBehaviour
// {
//     string username = "Aaa";
//     public ArrayList player_info;

//     public List<PlayerDataInfo> data;
//     public bool save = false;
//     void Start()
//     {
//         // int[] angka = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//         if (File.Exists(Application.dataPath + "/data/player_info.txt"))
//         {
//             // player_info = new ArrayList(File.ReadAllLines(Application.dataPath + "/data/player_info.txt"));
//             players = new List<>(File.ReadAllLines(Application.dataPath + "/data/player_info.txt"));
//             data = JsonUtility.FromJson<PlayerDataInfo>(players);

//         }
//         else
//         {
//             File.WriteAllText(Application.dataPath + "/data/player_info.txt", "");
//         }
//     }
//     /// <summary>
//     /// Update is called every frame, if the MonoBehaviour is enabled.
//     /// </summary>
//     void Update()
//     {
//         if (save == true)
//         {
//             saveToJSON();
//             save = false;
//         }
//     }
//     // check if the username info exist
//     bool GetUsername()
//     {
//         bool usn_exist = false;
//         foreach (string player in data)
//         {
//             if (player.Contains(username))
//             {

//                 usn_exist = true;
//                 break;
//             }
//             else
//             {
//                 usn_exist = false;
//                 break;
//             }
//         }
//         return usn_exist;
//     }
//     void updateInfo()
//     {
//         if (GetUsername())
//         {
//             // update username info
//         }
//         else
//         {
//             // write username and username info
//         }
//     }
//     void saveToJSON()
//     {
//         PlayerDataInfo player_data = new PlayerDataInfo();
//         player_data.usn_info = "Aaa";
//         player_data.pw_info = "644";
//         player_data.qqiraah_exp = 0;
//         player_data.qasasi_exp = 0;
//         player_data.aasasi_exp = 0;
//         player_data.aaly_exp = 0;
//         player_data.qqiraah_scores = new float[3] { 70, 3, 10 };
//         // player_data.qqiraah_times = (100, 25, 15);

//         string json = JsonUtility.ToJson(player_data, true);
//         if (GetUsername())
//         {
//             File.WriteAllText(Application.dataPath + "/data/player_info.txt", json);
//         }
//         else
//         {
//             File.AppendAllLines(Application.dataPath + "/data/player_info.txt", (String[])player_info.ToArray(typeof(string)));
//         }

//     }
//     //     void loadFromJSON()
//     //     {
//     //         string json = File.ReadAllText(Application.dataPath + "/data/player_info.json");
//     // PlayerDataInfo 

//     //     }
//     // void save()
//     // {
//     //     bool isExists = false;

//     //     player_info = new ArrayList(File.ReadAllLines(Application.dataPath + "/data/player_info.txt"));
//     //     foreach (var i in player_info)
//     //     {
//     //         if (i.ToString().Contains(usernameInput.text))
//     //         {
//     //             isExists = true;
//     //             break;
//     //         }
//     //     }

//     //     if (isExists)
//     //     {
//     //         Debug.Log($"Username '{usernameInput.text}' already exists");
//     //     }
//     //     else
//     //     {
//     //         player_info.Add(usernameInput.text + ":" + passwordInput.text);
//     //         File.WriteAllLines(Application.dataPath + "/data/player_info.txt", (String[])credentials.ToArray(typeof(string)));
//     //     }
//     // }

// }