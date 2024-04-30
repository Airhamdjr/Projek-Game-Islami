using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objecttive : MonoBehaviour
{
    public SceneInfo jenisTalim;
    public ScriptableItem item;

    // Objective Main
    public GameObject ObjectiveLayer;
    public GameObject ObjectiveKeyLayer;

    // Key & Chest Object
    public GameObject player;
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject Key4;
    public GameObject Chest;

    // Text Key
    public GameObject KeyText1;
    public GameObject KeyText2;
    public GameObject KeyText3;
    public GameObject KeyText4;

    // Key Done
    public GameObject Key1Done;
    public GameObject Key2Done;
    public GameObject Key3Done;
    public GameObject Key4Done;


    // Text Materi
    public GameObject MateriText1;
    public GameObject MateriText2;
    public GameObject MateriText3;
    public GameObject MateriText4;

    // Materi Done
    public GameObject Materi1Done;
    public GameObject Materi2Done;
    public GameObject Materi3Done;
    public GameObject Materi4Done;

    // Materi Tampil
    public GameObject Materi1;
    public GameObject Materi2;
    public GameObject Materi3;
    public GameObject Materi4;

    // Key And Chest Interact
    public GameObject KeyInteract;
    public GameObject ChestInteract;

    // UI Jenis Kelas Ta'lim
    public GameObject Talim;
    public GameObject QQiraah;
    public GameObject QAsasi;
    public GameObject AAlaly;
    public GameObject AAsasi;

    void Start()
    {
        ObjectiveLayer.SetActive(true);

        // Set False
        Key1Done.SetActive(false);
        Key2Done.SetActive(false);
        Key3Done.SetActive(false);
        Key4Done.SetActive(false);
        Materi1Done.SetActive(false);
        Materi2Done.SetActive(false);
        Materi3Done.SetActive(false);
        Materi4Done.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetKey();
        GetMateri();
        ItemInteract();
        JenisKelas();
    }

    void GetKey()
    {
        if (item.keyItem1 == 1)
        {
            Key1Done.SetActive(true);
        }
        if (item.keyItem2 == 1)
        {
            Key2Done.SetActive(true);
        }
        if (item.keyItem3 == 1)
        {
            Key3Done.SetActive(true);
        }
        if (item.keyItem4 == 1)
        {
            Key4Done.SetActive(true);
        }
    }

    void GetMateri()
    {
        if (Materi1.activeInHierarchy)
        {
            Materi1Done.SetActive(true);
        }
        if (Materi2.activeInHierarchy)
        {
            Materi2Done.SetActive(true);
        }
        if (Materi3.activeInHierarchy)
        {
            Materi3Done.SetActive(true);
        }
        if (Materi4.activeInHierarchy)
        {
            Materi4Done.SetActive(true);
        }
    }

    void ItemInteract()
    {
        if (Vector2.Distance(player.transform.position, Key1.transform.position) < 1f
            || (Vector2.Distance(player.transform.position, Key2.transform.position) < 1f)
                || (Vector2.Distance(player.transform.position, Key3.transform.position) < 1f)
                    || (Vector2.Distance(player.transform.position, Key4.transform.position) < 1f))
        {
            KeyInteract.SetActive(true);
        }
        else
        {
            KeyInteract.SetActive(false);
        }

        if (Vector2.Distance(player.transform.position, Chest.transform.position) < 1f)
        {
            ChestInteract.SetActive(true);
        }
        else
        {
            ChestInteract.SetActive(false);
        }

    }

    void JenisKelas()
    {
        if(jenisTalim.kelas_npc.Equals("Al-Qur'an Qiraah"))
        {
            QQiraah.SetActive(true);
            QAsasi.SetActive(false);
            AAlaly.SetActive(false);
            AAsasi.SetActive(false);
        }
        if (jenisTalim.kelas_npc.Equals("Al-Qur'an Asasi"))
        {
            QQiraah.SetActive(false);
            QAsasi.SetActive(true);
            AAlaly.SetActive(false);
            AAsasi.SetActive(false);
        }
        if (jenisTalim.kelas_npc.Equals("Afkar Al-Aly"))
        {
            QQiraah.SetActive(false);
            QAsasi.SetActive(false);
            AAlaly.SetActive(true);
            AAsasi.SetActive(false);
        }
        if (jenisTalim.kelas_npc.Equals("Afkar Asasi"))
        {
            QQiraah.SetActive(false);
            QAsasi.SetActive(false);
            AAlaly.SetActive(false);
            AAsasi.SetActive(true);
        }
    }

    public void btnMengerti()
    {
        ObjectiveLayer.SetActive(false);
        Talim.SetActive(false);
    }
}
