using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System;
using System.Linq;

public static class FileHandler
{
    public static void SaveToJSON<T>(List<T> to_save, string file_name)
    {
        Debug.Log(GetPath(file_name));
        string content = JsonHelper.ToJson<T>(to_save.ToArray());
        writeFile(GetPath(file_name), content);
    }
    public static List<T> ReadFromJSON<T>(string file_name)
    {
        string content = ReadFile(GetPath(file_name));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;
    }

    private static string GetPath(string file_name)
    {
        /* return Application.streamingAssetsPath + "/" + file_name;*/
        return Application.streamingAssetsPath + "/" + file_name;
    }
    private static void writeFile(string path, string content)
    {
        FileStream filestream = new FileStream(path, FileMode.Create);


        using (StreamWriter writer = new StreamWriter(filestream))
        {
            writer.Write(content);
        }
    }
    private static string ReadFile(string path)
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }
        return "";
    }
}
public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
