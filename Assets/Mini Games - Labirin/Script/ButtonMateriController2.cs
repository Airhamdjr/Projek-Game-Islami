using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonMateriController2 : MonoBehaviour
{
    public GameObject OutputLayer;
    public GameObject MenuLayer;
    public GameObject MateriLayer;
    public GameObject btnMateri1;
    public GameObject btnMateri2;
    public GameObject btnMateri3;
    public GameObject btnMateri4;

    public GameObject materiWudhu;
    public GameObject materiShalat;
    public GameObject materiHaji;
    public GameObject materiPuasa;

    public Text Materi1Text;
    public Text Materi2Text;
    public Text Materi3Text;
    public Text Materi4Text;

    public GameObject isMateri1Done;
    public GameObject isMateri2Done;
    public GameObject isMateri3Done;
    public GameObject isMateri4Done;

    public GameObject Player;

    private void Start()
    {
        OutputLayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        /*OutputTextMateri();*/

        /*if (MenuLayer.activeInHierarchy)
        {
            MateriLayer.SetActive(false);

            if (playerdata.input == 1)
            {
                btnMateri1.SetActive(true);
                btnMateri2.SetActive(false);
                btnMateri3.SetActive(false);
                btnMateri4.SetActive(false);

                Materi1Text.text = "Materi 1";
            }

            else if (playerdata.input == 2)
            {
                btnMateri1.SetActive(false);
                btnMateri2.SetActive(true);
                btnMateri3.SetActive(false);
                btnMateri4.SetActive(false);

                Materi2Text.text = "Materi 2";
            }

            else if (playerdata.input == 3)
            {
                btnMateri1.SetActive(false);
                btnMateri2.SetActive(false);
                btnMateri3.SetActive(true);
                btnMateri4.SetActive(false);

                Materi3Text.text = "Materi 3";
            }

            else if (playerdata.input == 4)
            {
                btnMateri1.SetActive(false);
                btnMateri2.SetActive(false);
                btnMateri3.SetActive(false);
                btnMateri4.SetActive(true);

                Materi4Text.text = "Materi 4";
            }
        }*/

        if (OutputLayer.activeInHierarchy)
        {
            MenuLayer.SetActive(true);
        }

    }

    public void btnFuncMateri1()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        materiWudhu.SetActive(true);
        isMateri1Done.SetActive(true);
    }

    public void btnFuncMateri2()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        materiShalat.SetActive(true);
        isMateri2Done.SetActive(true);
    }

    public void btnFuncMateri3()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        materiHaji.SetActive(true);
        isMateri3Done.SetActive(true);
    }

    public void btnFuncMateri4()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        materiPuasa.SetActive(true);
        isMateri4Done.SetActive(true);
    }
    
    public void btnBack()
    {
        MenuLayer.SetActive(true);
        MateriLayer.SetActive(false);
    }

/*    void OutputTextMateri()
    {
        Materi1Text.text = "Materi 1";
        Materi2Text.text = "Materi 2";
        Materi3Text.text = "Materi 3";
        Materi4Text.text = "Materi 4";
    }*/

    public void BackToMahad()
    {
        SceneManager.LoadScene("MainScene");
    }

}
