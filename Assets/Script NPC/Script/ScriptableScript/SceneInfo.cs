using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "GetData")]

public class SceneInfo : ScriptableObject
{
    public float GetScore = 0;
    public float GetTime = 0;
    public float GetExp = 0;

    public float GetAnsTrue = 0;
    public float GetAnsFalse = 0;
    public float GetTimeSpend = 0;

    public bool HasExpData = false;
    public bool HasTestData = false;

    public bool HasExpTQAsasi = false;
    public float GetExpTQAsasi = 0;
    public bool HasTestTQAsasi = false;
    public float GetTestTQAsasi = 0;

    public bool HasExpTQQiraah = false;
    public float GetExpTQQiraah = 0;
    public bool HasTestTQQiraah = false;
    public float GetTestTQQiraah= 0;

    public bool HasExpTAAsasi = false;
    public float GetExpTAAsasi = 0;
    public bool HasTestTAAsasi = false;
    public float GetTestTAAsasi = 0;

    public bool HasExpTAAlaly = false;
    public float GetExpTAAlaly = 0;
    public bool HasTestTAAlaly = false;
    public float GetTestTAAlaly= 0;

    public string kelas_npc;

    public float Rank1TQQiraah = 0;

    public float ranking1QQiraah;
    public float ranking2QQiraah;
    public float ranking3QQiraah;
    public float ranking4QQiraah;

    public float Materi1QQiraah;
    public float Materi2QQiraah;
    public float Materi3QQiraah;
    public float Materi4QQiraah;

    public float ranking1QAsasi;
    public float ranking2QAsasi;
    public float ranking3QAsasi;
    public float ranking4QAsasi;


    public void ResetData()
    {
        GetScore = 0;
        GetTime = 0;
        GetExp = 0;

        GetAnsTrue = 0;
        GetAnsFalse = 0;
        GetTimeSpend = 0;

        HasExpData = false;
        HasTestData = false;

        HasExpTQAsasi = false;
        GetExpTQAsasi = 0;
        HasTestTQAsasi = false;
        GetTestTQAsasi = 0;

        HasExpTQQiraah = false;
        GetExpTQQiraah = 0;
        HasTestTQQiraah = false;
        GetTestTQQiraah = 0;

        HasExpTAAsasi = false;
        GetExpTAAsasi = 0;
        HasTestTAAsasi = false;
        GetTestTAAsasi = 0;

        HasExpTAAlaly = false;
        GetExpTAAlaly = 0;
        HasTestTAAlaly = false;
        GetTestTAAlaly = 0; 

    }
}
