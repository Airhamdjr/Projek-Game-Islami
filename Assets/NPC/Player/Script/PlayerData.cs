using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public SceneInfo sceneInfo;

    public float Nilai;
    public float Waktu;
    public float Pengalaman;
    public bool hasTestData;
    public bool hasExpData;

    public bool hasExpTQAsasi;
    public float getExpTQAsasi = 0;
    public bool hasTestTQAsasi;
    public float getTestTQAsasi = 0;

    public bool hasExpTQQiraah;
    public float getExpTQQiraah = 0;
    public bool hasTestTQQiraah;
    public float getTestTQQiraah = 0;

    public bool hasExpTAAsasi;
    public float getExpTAAsasi = 0;
    public bool hasTestTAAsasi;
    public float getTestTAAsasi = 0;

    public bool hasExpTAAlaly;
    public float getExpTAAlaly = 0;
    public bool hasTestTAAlaly;
    public float getTestTAAlaly = 0;

    void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetData();
    }

    void GetData()
    {
        // Nilai menggunakan total jawaban Salah

        Nilai = sceneInfo.GetAnsFalse;
        Waktu = sceneInfo.GetTimeSpend;
        Pengalaman = sceneInfo.GetExp;
        hasTestData = sceneInfo.HasTestData;
        hasExpData = sceneInfo.HasExpData;

        // Ahmad
        hasExpTQQiraah = sceneInfo.HasExpTQQiraah;
        getExpTQQiraah = sceneInfo.GetExpTQQiraah;
        hasTestTQQiraah = sceneInfo.HasTestTQQiraah;
        getTestTQQiraah = sceneInfo.GetTestTQQiraah;

        // Mukhlis
        hasExpTQAsasi= sceneInfo.HasExpTQAsasi;
        getExpTQAsasi = sceneInfo.GetExpTQAsasi;
        hasTestTQAsasi = sceneInfo.HasTestTQAsasi;
        getTestTQAsasi = sceneInfo.GetTestTQAsasi;

        // Furqon
        hasExpTAAlaly = sceneInfo.HasExpTAAlaly;
        getExpTAAlaly = sceneInfo.GetExpTAAlaly;
        hasTestTAAlaly = sceneInfo.HasTestTAAlaly;
        getTestTAAlaly = sceneInfo.GetTestTAAlaly;

        // Sumbul
        hasExpTAAsasi = sceneInfo.HasExpTAAsasi;
        getExpTAAsasi = sceneInfo.GetExpTAAsasi;
        hasTestTAAsasi = sceneInfo.HasTestTAAsasi;
        getTestTAAsasi = sceneInfo.GetTestTAAsasi;

    }
}
