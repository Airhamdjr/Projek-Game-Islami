using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BrosMenu : MonoBehaviour
{
    public GameObject MainMenuLayer;
    public GameObject RankingLayer;
    public GameObject ScoreLayer;

    public GameObject Startbtn;
    public GameObject Continuebtn;

    public GameObject Rankingbtn;
    public GameObject Scorebtn;
    public GameObject Quitbtn;

    public static bool haveStart = false;

    void Start()
    {
        Continuebtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RankingCondition();
        ScoreCondition();

        MenuCondition();   
    }

    void MenuCondition()
    {
        if (haveStart)
        {
            MainMenuLayer.SetActive(false);
            Continuebtn.SetActive(true);
            Startbtn.SetActive(false);
        }
    }

    void RankingCondition()
    {
        /*if (pretestStat = true)
        {
            Rankingbtn.SetActive(true);
        }
        else
        {
            Rankingbtn.SetActive(false);
        } */
    }

    void ScoreCondition()
    {
        /*if (HasScore = true)
        {
            Scorebtn.SetActive(true);
        }
        else
        {
            Scorebtn.SetActive(false);
        }*/
    }

    public void StartGame()
    {
        MainMenuLayer.SetActive(false);
        haveStart = true;
    }

    public void Ranking()
    {
        RankingLayer.SetActive(true);
    }

    public void Score()
    {
        ScoreLayer.SetActive(true);
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void MainMenu()
    {
        MainMenuLayer.SetActive(true);
        haveStart = false;
    }
    
}
