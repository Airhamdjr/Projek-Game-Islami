using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QQiraah_KeyController : MonoBehaviour
{
    public HasilRank hasilRank;
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
    public GameObject chestObject1;
    public GameObject chestObject2;
    public GameObject chestObject3;
    public GameObject chestObject4;

    // Output Layer
    public GameObject OutputLayer;

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

    // Inisiasi Ranking
    public string Rank1;
    public string Rank2;
    public string Rank3;
    public string Rank4;

    // Ranking Condition
    public bool isRanking1;
    public bool isRanking2;
    public bool isRanking3;
    public bool isRanking4;

    //Key Item
    keyItem key1;
    keyItem key2;
    keyItem key3;
    keyItem key4;

    //Materi
    string[] materiQQiraah;

    public class keyItem
    {
        public GameObject key;
        public string materi;

        public keyItem(GameObject key, string materi)
        {
            this.key = key;
            this.materi = materi;
        }
    }
    private void Start()
    {
        QQMateri1.SetActive(false);
        QQMateri2.SetActive(false);
        QQMateri3.SetActive(false);
        QQMateri4.SetActive(false);

    isRanking1 = false;
    isRanking2 = false;
    isRanking3 = false;
    isRanking4 = false;

    materiQQiraah = new string[] { "Materi Al-Ta'rif", "Materi Mad", "Materi Nun Sukun dan Tanwin", "Materi Waqaf" };


    }

    // Update is called once per frame
    void Update()
    {
        keyControl();
        chestControl();
    }

    public bool RankingCondition(keyItem key)
    {
        Rank1 = hasilRank.rank1;
        Rank2 = hasilRank.rank2;
        Rank3 = hasilRank.rank3;
        Rank4 = hasilRank.rank4;

        bool condition= false;

        if (!isRanking1)
        {
            if (key.materi.Equals(Rank1))
            {
                isRanking1 = true;
                return  true;
            }
            else
            {
                condition =  false;
                print("Cari kunci yang lain terlebih dahulu");
            }
        }
        if (isRanking1 && !isRanking2)
        {
            if (key.materi.Equals(Rank2))
            {
                isRanking2 = true;
                return true;
 
            }
            else
            {
                condition = false;
                print("Cari kunci yang lain terlebih dahulu");
            }
        }
        if (isRanking1 && isRanking2 && !isRanking3)
        {
            if (key.materi == Rank3)
            {
                isRanking3 = true;
                return  true;
            }
            else
            {
                condition = false;
                print("Cari kunci yang lain terlebih dahulu");
            }
        }
        if (isRanking1 && isRanking2 && isRanking3 && !isRanking4)
        {
            if (key.materi == Rank4)
            {
                isRanking4 = true;
                return true;
            }
            else
            {
                condition = false;
                print("Cari kunci yang lain terlebih dahulu");
            }
        }
        return condition;

    }

    

    void keyControl()
    {
        key1 = new keyItem(keyObject1, materiQQiraah[0]);
        key2 = new keyItem(keyObject2, materiQQiraah[1]);
        key3 = new keyItem(keyObject3, materiQQiraah[2]);
        key4 = new keyItem(keyObject4, materiQQiraah[3]);
        if (Vector2.Distance(player.transform.position, keyObject1.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject1 && RankingCondition(key1))
            {
                item.keyItem1 = 1;
                keyObject1.SetActive(false);

                Debug.Log("Mendapatkan Kunci 1");
            }
        }
        if (Vector2.Distance(player.transform.position, keyObject2.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject2 & RankingCondition(key2))
            {
                item.keyItem2 = 1;
                keyObject2.SetActive(false);
                Debug.Log("Mendapatkan Kunci 2");
            }
        }
        if (Vector2.Distance(player.transform.position, keyObject3.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject3 && RankingCondition(key3))
            {
                item.keyItem3 = 1;
                keyObject3.SetActive(false);

                Debug.Log("Mendapatkan Kunci 3");
            }
        }

        if (Vector2.Distance(player.transform.position, keyObject4.transform.position) < 1f)
        {
            if (Input.GetKey(collectItemKey) && keyObject4 && RankingCondition(key4))
            {
                item.keyItem4 = 1;
                keyObject4.SetActive(false);

                Debug.Log("Mendapatkan Kunci 4");
            }
        }
    }

    void chestControl()
    {
        // Key 1 == Materi 1
        if (Vector2.Distance(player.transform.position, chestObject1.transform.position) < 1f)
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
                if (item.keyItem1 == 0)
                {
                    Debug.Log("Cari Kunci 1 Terlebih Dahulu");
                }
                else
                {
                    OutputLayer.SetActive(true);
                    QQiraah.SetActive(true);

                    QQMateri1.SetActive(true);
                    QQMateri2.SetActive(false);
                    QQMateri3.SetActive(false);
                    QQMateri4.SetActive(false);

                }
            }
        }
        // Key 2 == Materi 2
        if (Vector2.Distance(player.transform.position, chestObject2.transform.position) < 1f)
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
                if (item.keyItem2 == 0)
                {
                    Debug.Log("Cari Kunci 2 Terlebih Dahulu");
                }
                else
                {
                    OutputLayer.SetActive(true);
                    QQiraah.SetActive(true);

                    QQMateri1.SetActive(false);
                    QQMateri2.SetActive(true);
                    QQMateri3.SetActive(false);
                    QQMateri4.SetActive(false);
                }
            }

        }
        // Key 3 == Materi 3
        if (Vector2.Distance(player.transform.position, chestObject3.transform.position) < 1f)
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
                if (item.keyItem3 == 0)
                {
                    Debug.Log("Cari Kunci 3 Terlebih Dahulu");
                }
                else
                {
                    OutputLayer.SetActive(true);
                    QQiraah.SetActive(true);

                    QQMateri1.SetActive(false);
                    QQMateri2.SetActive(false);
                    QQMateri3.SetActive(true);
                    QQMateri4.SetActive(false);
                }
            }
        }
        // Key 4 == Materi 4
        if (Vector2.Distance(player.transform.position, chestObject4.transform.position) < 1f)
        {
            if (Input.GetKeyDown(OpenChestKey))
            {
                if (item.keyItem4 == 0)
                {
                    Debug.Log("Cari Kunci 4 Terlebih Dahulu");
                }
                else
                {
                    OutputLayer.SetActive(true);
                    QQiraah.SetActive(true);

                    QQMateri1.SetActive(false);
                    QQMateri2.SetActive(false);
                    QQMateri3.SetActive(false);
                    QQMateri4.SetActive(true);
                }
            }
        }
    }

    public void btnBack()
    {
        OutputLayer.SetActive(false);
        QQiraah.SetActive(false);  
        QQMateri1.SetActive(false);
        QQMateri2.SetActive(false);
        QQMateri3.SetActive(false);
        QQMateri4.SetActive(false);
    }
}
