// using System.Collections;
// using System.Collections.Generic;
// using System.IO;
// using UnityEngine;
// using Newtonsoft.Json;
// using System;

// public class JSONDataService : IDataService
// {
//     public bool SaveData<T>(string RelativePath, T Data, bool Encrypted)
//     {
//         string path = Application.persistentDataPath + RelativePath;

//         // if (File.Exists(path))
//         // {
//         try
//         {
//             Debug.Log("Data exist. Deleting old file and writing a new one!");
//             File.Delete(path);
//             using FileStream stream = File.Create(path);
//             stream.Close();
//             File.WriteAllText(path, JsonConvert.SerializeObject(Data));
//             return true;
//         }
//         catch (Exception e)
//         {
//             Debug.Log($"Unable to save data due to: (e.Message) (e.StackTrace)");
//             return false;
//         }
//         // }
//         // else
//         // {
//         //     try
//         //     {
//         //         Debug.Log("Creating file for the first time!");
//         //         using FileStream stream = File.Create(path);
//         //         stream.Close();
//         //         File.WriteAllText(path, JsonConvert.SerializeObject(Data));
//         //         return true;
//         //     }
//         //     catch (Exception e)
//         //     {
//         //         Debug.LogError($"Unable to save data due to: (e.Message) (e.StackTrace)");
//         //         return false;
//         //     }
//         // }
//     }
//     public T LoadData<T>(string RelativePath, bool Encrypted)
//     {
//         throw new System.NotImplementedException();
//     }
// }