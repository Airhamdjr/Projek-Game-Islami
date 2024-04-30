using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManagementMukhlis : MonoBehaviour
{
    public SceneInfo sceneInfo;

    public SoalScriptMukhlis getSoalScript;
    public GameObject scriptLocation;

    public GameObject LearningLayer;
    public GameObject MenuLayer;
    public GameObject PretestLayer;
    public GameObject PopUp;
    public GameObject SceneManagement1;

    public float score;
    public float AnsTrue;
    public float Ansfalse;
    public float time;
    public float timeSpend;

    public bool HasTestTQAsasi;

    

    public Text showText;


    private void Awake()
    {
        getSoalScript = scriptLocation.GetComponent<SoalScriptMukhlis>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        GetData();
    }

    public void GetData()
    {
        if (score != null && time != null && timeSpend != null && AnsTrue != null && Ansfalse != null)
        {
            score = getSoalScript.nilaiTest;
            time = getSoalScript.sisaWaktu;
            timeSpend = getSoalScript.waktuTest;
            AnsTrue = getSoalScript.jwbBenar;
            Ansfalse = getSoalScript.jwbSalah;

            sceneInfo.GetScore = score;
            sceneInfo.GetTime = time;
            sceneInfo.GetTimeSpend = timeSpend;
            sceneInfo.GetAnsTrue = AnsTrue;
            sceneInfo.GetAnsFalse = Ansfalse;

            HasTestTQAsasi = true;
        }

    }

    public void ShowData()
    {
        score = getSoalScript.nilaiTest;
        time = getSoalScript.sisaWaktu;
        timeSpend = getSoalScript.waktuTest;
        AnsTrue = getSoalScript.jwbBenar;
        Ansfalse = getSoalScript.jwbSalah;

        showText.text = "Score : " + score +
                        "\nSisa Waktu : " + time +
                        "\nWaktu Terpakai : " + timeSpend +
                        "\nJawaban Benar : " + AnsTrue +
                        "\nJawaban Salah : " + Ansfalse;
    }
    
    public void LearningPath()
    {
        if (LearningLayer.activeInHierarchy)
        {
            LearningLayer.SetActive(false);
        }
        else
        {
            LearningLayer.SetActive(true);
        }
    }

    public void StartGame()
    {
        MenuLayer.SetActive(false);
        PretestLayer.SetActive(true);
    }

    public void BackToMenu()
    {
        MenuLayer.SetActive(true);
        PretestLayer.SetActive(false);

        sceneInfo.HasTestTQAsasi = HasTestTQAsasi;
    }

    public void ExitGame()
    {
        HasTestTQAsasi = true;
        sceneInfo.HasTestTQAsasi = HasTestTQAsasi;
        SceneManagement1.SetActive(false);
        PopUp.SetActive(true);
    }

}
