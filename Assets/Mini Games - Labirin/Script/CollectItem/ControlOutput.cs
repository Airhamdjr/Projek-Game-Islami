using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlOutput : MonoBehaviour
{
    // Inisiasi Item
    public ScriptableItem item;
    public KeyCode collectItemKey;
    public KeyCode OpenChestKey;

    // Inisiasi Object 
    public GameObject player;
    public GameObject keyObject1;
    public GameObject keyObject2;
    public GameObject keyObject3;
    public GameObject keyObject4;
    public GameObject chestObject;

    // Inisiasi Output Panel
    public GameObject OutputLayer;
    public GameObject MenuLayer;
    public GameObject MateriLayer;

    // Inisiasi Materi 
    public GameObject btnMateri1;
    public GameObject btnMateri2;
    public GameObject btnMateri3;
    public GameObject btnMateri4;

    // Inisiasi UI Text
    public Text Materi1Text;
    public Text Materi2Text;
    public Text Materi3Text;
    public Text Materi4Text;

    // Inisiasi Materi Complete
    public GameObject isMateri1Done;
    public GameObject isMateri2Done;
    public GameObject isMateri3Done;
    public GameObject isMateri4Done;

    // Inisiasi Talim
    public GameObject QQiraah;
    public GameObject QAsasi;
    public GameObject AAlaly;
    public GameObject AAsasi;

    // Materi Quran Qiraah
    public GameObject QQMateri1;
    public GameObject QQMateri2;
    public GameObject QQMateri3;
    public GameObject QQMateri4;

    public TestData testData;

    private void Start()
    {
        OutputLayer.SetActive(false);

        // Materi QQiraah
        QQMateri1.SetActive(false);
        QQMateri2.SetActive(false);
        QQMateri3.SetActive(false);
        QQMateri4.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        keyControl();
        chestControl();
/*
        OutputTextMateri();*/
    }

    void chestControl()
    {
        if (Vector2.Distance(player.transform.position, chestObject.transform.position) < 1f)
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
             /*   testData.calculateTopsis();*/
                OutputLayer.SetActive(true);
                MenuLayer.SetActive(true);

                // Key 1 == Materi 1
                if (item.keyItem1 == 0)
                {
                    Debug.Log("Cari Kunci 1 Terlebih Dahulu");
                }
                else
                {
                    btnMateri1.SetActive(true);
                }
                // Key 2 == Materi 2
                if (item.keyItem2 == 0)
                {
                    Debug.Log("Cari Kunci 2 Terlebih Dahulu");
                }
                else
                {
                    btnMateri2.SetActive(true);
                }
                // Key 3 == Materi 3
                if (item.keyItem3 == 0)
                {
                    Debug.Log("Cari Kunci 3 Terlebih Dahulu");
                }
                else
                {
                    btnMateri3.SetActive(true);
                }
                // Key 4 == Materi 4
                if (item.keyItem4 == 0)
                {
                    Debug.Log("Cari Kunci 4 Terlebih Dahulu");
                }
                else
                {
                    btnMateri4.SetActive(true);
                }

            }
        }
    }

    void keyControl()
    {
        if (Vector2.Distance(player.transform.position, keyObject1.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject1)
            {
                item.keyItem1 = 1;
                keyObject1.SetActive(false);
                Debug.Log("Mendapatkan Kunci 1");
            }
        }
        if (Vector2.Distance(player.transform.position, keyObject2.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject2)
            {
                item.keyItem2 = 1;
                keyObject2.SetActive(false);
                Debug.Log("Mendapatkan Kunci 2");
            }
        }
        if (Vector2.Distance(player.transform.position, keyObject3.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject3)
            {
                item.keyItem3 = 1;
                keyObject3.SetActive(false);
                Debug.Log("Mendapatkan Kunci 3");
            }
        }

        if (Vector2.Distance(player.transform.position, keyObject4.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject4)
            {
                item.keyItem4 = 1;
                keyObject4.SetActive(false);
                Debug.Log("Mendapatkan Kunci 4");
            }
        }
    }
/*    void OutputTextMateri()
    {
        Materi1Text.text = "Materi 1";
        Materi2Text.text = "Materi 2";
        Materi3Text.text = "Materi 3";
        Materi4Text.text = "Materi 4";
    }*/

    public void btnFuncMateri1()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri1.SetActive(true);
        isMateri1Done.SetActive(true);

        QQiraah.SetActive(true);
        QQMateri1.SetActive(true);
    }

    public void btnFuncMateri2()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri2.SetActive(true);
        isMateri2Done.SetActive(true);

        QQiraah.SetActive(true);
        QQMateri2.SetActive(true);
    }

    public void btnFuncMateri3()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri3.SetActive(true);
        isMateri3Done.SetActive(true);

        QQiraah.SetActive(true);
        QQMateri3.SetActive(true);
    }

    public void btnFuncMateri4()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri4.SetActive(true);
        isMateri4Done.SetActive(true);

        QQiraah.SetActive(true);

        QQMateri4.SetActive(true);
    }

    public void btnBack()
    {
        OutputLayer.SetActive(false);
    }
}
