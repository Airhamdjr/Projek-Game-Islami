using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{
    public SceneInfo sceneInfo;
    public GameObject completionPanel;
    // Ahmad
    public Text ObjAhmad;
    public Text TestAhmad;
    public Text ExpAhmad;
    public GameObject TestTQQiraahDone;
    //public GameObject ExpTQQiraahDone;
    public bool ExpTQQiraah;
    public bool TestTQQiraah;
    
    // Mukhlis
    public Text ObjMukhlis;
    public Text TestMukhlis;
    public Text ExpMukhlis;
    public GameObject TestTQAsasiDone;
    //public GameObject ExpTQAsasiDone;
    public bool ExpTQAsasi;
    public bool TestTQAsasi;
    
    // Furqon
    public Text ObjFurqon;
    public Text TestFurqon;
    public Text ExpFurqon;
    public GameObject TestTAAlalyDone;
    //public GameObject ExpTAAlalyDone;
    public bool ExpTAAlaly;
    public bool TestTAAlaly;
    
    // Sumbul
    public Text ObjSumbul;
    public Text TestSumbul;
    public Text ExpSumbul;
    public GameObject TestTAAsasiDone;
    //public GameObject ExpTAAsasiDone;
    public bool ExpTAAsasi;
    public bool TestTAAsasi;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ObjectiveText();
        PretestText();
        ExpText();

        TestDone();
        ExpDone();

        CheckCompletion();

    }

    void ObjectiveText()
    {
        ObjAhmad.text = "Menemui dan Berbicara dengan Ahmad";
        ObjMukhlis.text = "Menemui dan Berbicara dengan Mukhlis";
        ObjFurqon.text = "Menemui dan Berbicara dengan Furqon";
        ObjSumbul.text = "Menemui dan Berbicara dengan Sumbul";
    }

    void PretestText()
    {
        TestAhmad.text = "Menyelesaikan Pretest Ta'lim Al-Qur'an Qira'ah";
        TestMukhlis.text = "Menyelesaikan Pretest Ta'lim Al-Qur'an Asasi";
        TestFurqon.text = "Menyelesaikan Pretest Ta'lim Afkar Al-Aly";
        TestSumbul.text = "Menyelesaikan Pretest Ta'lim Afkar Asasi";
    }

    void ExpText()
    {
        ExpAhmad.text = "Pertanyaan Pengalaman Ta'lim Al-Qur'an Qira'ah";
        ExpMukhlis.text = "Pertanyaan Pengalaman Ta'lim Al-Qur'an Asasi";
        ExpFurqon.text = "Pertanyaan Pengalaman Ta'lim Afkar Al-Aly";
        ExpSumbul.text = "Pertanyaan Pengalaman Ta'lim Afkar Asasi";
    }

    void ExpDone()
    {
        ExpTQQiraah = sceneInfo.HasExpTQQiraah;
        ExpTQAsasi = sceneInfo.HasExpTQAsasi;
        ExpTAAlaly = sceneInfo.HasExpTAAlaly;
        ExpTAAsasi = sceneInfo.HasExpTAAsasi;

        if(ExpTQQiraah == true)
        {
            //ExpTQQiraahDone.SetActive(true);
        }
        else
        {
            //ExpTQQiraahDone.SetActive(false);
        }
        
        if (ExpTQAsasi == true)
        {
            //ExpTQAsasiDone.SetActive(true);
        }
        else
        {
            //ExpTQAsasiDone.SetActive(false);
        }

        if (ExpTAAlaly == true)
        {
            //ExpTAAlalyDone.SetActive(true);
        }
        else
        {
            //ExpTAAlalyDone.SetActive(false);
        }

        if (ExpTAAsasi == true)
        {
            //ExpTAAsasiDone.SetActive(true);
        }
        else
        {
            //ExpTAAsasiDone.SetActive(false);
        }
    }

    void TestDone()
    {
        TestTQQiraah = sceneInfo.HasTestTQQiraah;
        TestTQAsasi = sceneInfo.HasTestTQAsasi;
        TestTAAlaly = sceneInfo.HasTestTAAlaly;
        TestTAAsasi = sceneInfo.HasTestTAAsasi;

        if (TestTQQiraah == true)
        {
            TestTQQiraahDone.SetActive(true);
        }
        else
        {
            TestTQQiraahDone.SetActive(false);
        }

        if (TestTQAsasi == true)
        {
            TestTQAsasiDone.SetActive(true);
        }
        else
        {
            TestTQAsasiDone.SetActive(false);
        }

        if (TestTAAlaly == true)
        {
            TestTAAlalyDone.SetActive(true);
        }
        else
        {
            TestTAAlalyDone.SetActive(false);
        }

        if (TestTAAsasi == true)
        {
            TestTAAsasiDone.SetActive(true);
        }
        else
        {
            TestTAAsasiDone.SetActive(false);
        }
    }

    void CheckCompletion()
    {
        // Menghitung jumlah game object "done" yang aktif.
        int doneCount = 0;

        if (TestTQQiraahDone.activeSelf) doneCount++;
        if (TestTQAsasiDone.activeSelf) doneCount++;
        if (TestTAAlalyDone.activeSelf) doneCount++;
        if (TestTAAsasiDone.activeSelf) doneCount++;

        // Jika semua objektif sudah selesai, munculkan panel.
        if (doneCount == 4)
        {
            completionPanel.SetActive(true);
        }
        else
        {
            completionPanel.SetActive(false);
        }
    }
}


