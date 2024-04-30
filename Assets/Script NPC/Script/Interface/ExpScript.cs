using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExpScript : MonoBehaviour
{
    public GameObject player;
    public GameObject NPCAhmad;
    public GameObject NPCMukhlis;
    public GameObject NPCFurqon;
    public GameObject NPCSumbul;

    private bool isAhmad = false;
    private bool isMukhlis = false;
    private bool isFurqon= false;
    private bool isSumbul= false;

    bool hasExpTQAsasi = false;
    bool hasExpTQQiraah = false;
    bool hasExpTAAsasi = false;
    bool hasExpTAAlaly = false;

    public float ExpValueTQAsasi;
    public float ExpValueTQQiraah;
    public float ExpValueTAAsasi;
    public float ExpValueTAAlaly;

    public SceneInfo sceneInfo;
    public PlayerDataInfo playerDataInfo;
    bool hasExpData = false;

    // Initiate Q Assets
    public TextAsset soalTQAsasi;
    public TextAsset soalTQQiraah;
    public TextAsset soalTAAsasi;
    public TextAsset soalTAAlaly;

    // Initiate Layer
    public GameObject ExpLayer;
    public GameObject QuestionLayer;
    public GameObject hasilLayer;

    // Initiate Variables
    public TextAsset assetSoal; // menampung file soal
    public string[] soal;
    private string[,] DBExp;

    static int indexExp=0;
    int indexData;
    int maxSoal;
    bool ambilSoal;

    // inisiasi teks pada canvas
    public Text txtSoalExp;
    public Text txtOpsiP;
    public Text txtOpsiK;
    public Text txtOpsiT;

    public Text txtHasil;

    bool isQuestionOver;

    char KJPernah;
    char KJKurang;
    char KJTidak;

    int jwbPernah;
    int jwbKurang;
    int jwbTidak;

    int jwbPernahText;
    int jwbKurangText;
    int jwbTidakText;

    int hasilTQAsasiP;
    int hasilTQAsasiK;
    int hasilTQAsasiT;

    int hasilTQQiraahP;
    int hasilTQQiraahK;
    int hasilTQQiraahT;

    int hasilTAAsasiP;
    int hasilTAAsasiK;
    int hasilTAAsasiT;

    int hasilTAAlalyP;
    int hasilTAAlalyK;
    int hasilTAAlalyT;

    public float hasil;
    public float ExpValue;

    // experiences store pretest
    public PretestData pretest_qqiraah;
    public PretestData pretest_qasasi;
    public PretestData pretest_aaly;
    public PretestData pretest_aasasi;

    void Start()
    {
        //soal = assetSoal.ToString().Split('#'); // pembatas pada tiap antar soal dengan simbol '#'
        ExpPosition();/*
        DBExp = new string[soal.Length, 7];*/
      /*  maxSoal = soal.Length;*/
      /*  OlahSoal();*/

        ambilSoal = true;/*
        TampilkanSoal();*/

        pretest_qqiraah.experience = new int[4];
        pretest_qasasi.experience = new int[4];

    }

    // Update is called once per frame
    void Update()
    {
        ExpPosition();
    /* OlahSoal();

        if (isAhmad)
        {
            if (!hasExpTQQiraah){
                AskExperience();
            }
            else
            {
                TampilkanHasil();
            }
        }
        if (isMukhlis)
        {
            if (!hasExpTQAsasi)
            {
                AskExperience();
            }
            else
            {
                TampilkanHasil();
            }
        }
         if (isFurqon)
        {
            if (!hasExpTAAlaly)
            {
                AskExperience();
            }
            else
            {
                TampilkanHasil();
            }
        }
         if (isSumbul)
        {
            if (!hasExpTAAsasi)
            {
                AskExperience();
            }
            else
            {
                TampilkanHasil();
            }
        }
*/
    }

    // untuk menampilkan pertanyaan
    private void AskExperience()
    {  
            ExpLayer.SetActive(true);
            hasilLayer.SetActive(false);
            QuestionLayer.SetActive(true);
 
            if (!isQuestionOver)
            {
                TampilkanSoal();
            }
            else
            {
                if (isMukhlis)
                {
                    hasilTQAsasiP = jwbPernah;
                    hasilTQAsasiK = jwbKurang;
                    hasilTQAsasiT = jwbTidak;
                }
                if (isSumbul)
                {

                    hasilTAAsasiP = jwbPernah;
                    hasilTAAsasiK = jwbKurang;
                    hasilTAAsasiT = jwbTidak;
                }
                if (isFurqon)
                {

                    hasilTAAlalyP = jwbPernah;
                    hasilTAAlalyK = jwbKurang;
                    hasilTAAlalyT = jwbTidak;
                }
                if (isAhmad)
                {
                    hasilTQQiraahP = jwbPernah;
                    hasilTQQiraahK = jwbKurang;
                    hasilTQQiraahT = jwbTidak;
                }

                TampilkanHasil();
                isQuestionOver = false;
            }
    }
    private void TampilkanHasil()
    {
        /*sceneInfo.GetExp = ExpValue;*//*
                    hasExpData = true;*/
        if (isAhmad == true)
        {
            jwbPernahText = hasilTQQiraahP;
            jwbKurangText = hasilTQQiraahK;
            jwbTidakText = hasilTQQiraahT;
            txtHasil.text = "Semua Terjawab\n" +
                       "\nMateri yang dipahami :" + jwbPernahText +
                       "\nMateri yang kurang dipahami :" + jwbKurangText +
                       "\nMateri yang tidak dipahami : " + jwbTidakText +
                       "\nNilai Pengalaman Terbanyak : " + hasil +
                       "\n1 = Pernah | 2 = kurang | 3 = Tidak Pernah" +
                       "\nAlternatif Pengalaman : " + HitungNilai();
            hasExpTQQiraah = true;
            ExpValueTQQiraah = ExpValue;
            sceneInfo.GetExpTQQiraah = ExpValueTQQiraah;
            
        }
        if (isMukhlis == true)
        {
            jwbPernahText = hasilTQAsasiP;
            jwbKurangText = hasilTQAsasiK;
            jwbTidakText = hasilTQAsasiT;
            txtHasil.text = "Semua Terjawab\n" +
                      "\nMateri yang dipahami :" + jwbPernahText +
                      "\nMateri yang kurang dipahami :" + jwbKurangText +
                      "\nMateri yang tidak dipahami : " + jwbTidakText +
                      "\nNilai Pengalaman Terbanyak : " + hasil +
                      "\n1 = Pernah | 2 = kurang | 3 = Tidak Pernah" +
                      "\nAlternatif Pengalaman : " + HitungNilai();
            hasExpTQAsasi = true;
            ExpValueTQAsasi = ExpValue;
            sceneInfo.GetExpTQAsasi = ExpValueTQAsasi;
        }
        if (isFurqon == true)
        {
            jwbPernahText = hasilTAAlalyP;
            jwbKurangText = hasilTAAlalyK;
            jwbTidakText = hasilTAAlalyT;
            txtHasil.text = "Semua Terjawab\n" +
                       "\nMateri yang dipahami :" + jwbPernahText +
                       "\nMateri yang kurang dipahami :" + jwbKurangText +
                       "\nMateri yang tidak dipahami : " + jwbTidakText +
                       "\nNilai Pengalaman Terbanyak : " + hasil +
                       "\n1 = Pernah | 2 = kurang | 3 = Tidak Pernah" +
                       "\nAlternatif Pengalaman : " + HitungNilai();
            hasExpTAAlaly = true;
            ExpValueTAAlaly = ExpValue;
            sceneInfo.GetExpTAAlaly = ExpValueTAAlaly;
        }
        if (isSumbul == true)
        {
            jwbPernahText = hasilTAAsasiP;
            jwbKurangText = hasilTAAsasiK;
            jwbTidakText = hasilTAAsasiT;
            txtHasil.text = "Semua Terjawab\n" +
                       "\nMateri yang dipahami :" + jwbPernahText +
                       "\nMateri yang kurang dipahami :" + jwbKurangText +
                       "\nMateri yang tidak dipahami : " + jwbTidakText +
                       "\nNilai Pengalaman Terbanyak : " + hasil +
                       "\n1 = Pernah | 2 = kurang | 3 = Tidak Pernah" +
                       "\nAlternatif Pengalaman : " + HitungNilai();
            hasExpTAAsasi = true;
            ExpValueTAAsasi = ExpValue;
            sceneInfo.GetExpTAAsasi = ExpValueTAAsasi;
        }

        QuestionLayer.SetActive(false);
        hasilLayer.SetActive(true);

    }

    private void TampilkanSoal()
    {
        if (indexData < maxSoal)
        {
           /* if (ambilSoal)
            {*/
                txtSoalExp.text = DBExp[indexData, 0]; // Mengambil index ke 0 pada DB sebagai soal
                txtOpsiP.text = DBExp[indexData, 1]; // Mengambil index ke 1 pada DB sebagai jawaban P
                txtOpsiK.text = DBExp[indexData, 2]; // Mengambil index ke 2 pada DB sebagai jawaban K
                txtOpsiT.text = DBExp[indexData, 3]; // Mengambil index ke 3 pada DB sebagai jawaban T
                KJPernah = DBExp[indexData, 4][0];
                KJKurang = DBExp[indexData, 5][0];
                KJTidak = DBExp[indexData, 6][0];

                ambilSoal = false;
            }
        /*}*/

    }

    private void OlahSoal(TextAsset soalExp)
    {
        soal = soalExp.ToString().Split('#');

        maxSoal = soal.Length;
        DBExp = new string[soal.Length, 7];
        // penyimpanan soal ke DB dengan pembatas pada tiap index menggunakan simbol '+'
        for (int i = 0; i < soal.Length; i++)
        {
            string [] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                DBExp[i, j] = tempSoal[j];
/*                continue;*/
            }/*
            continue;*/
        }
    }

    private void CheckJawaban(char huruf)
    {
        if (huruf.Equals(KJPernah))
        {
            jwbPernah++;
            GetExpAnalysis(1);
        }
        else if (huruf.Equals(KJKurang))
        {
            jwbKurang++;
            GetExpAnalysis(2);
        }
        else if (huruf.Equals(KJTidak))
        {
            jwbTidak++;
            GetExpAnalysis(3);
        }
        
    }

    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);

        if (indexData == maxSoal - 1)
        {
            indexData = 0;
            isQuestionOver = true;
        }
        else
        {
            indexData++;
            ambilSoal = true;
        }
    }

    private float HitungNilai()
    {
        if (jwbPernah > jwbKurang && jwbPernah > jwbTidak)
        {
            hasil = jwbPernah;
            ExpValue = 1;
            print("Pernah");
        }
        else if (jwbKurang > jwbPernah && jwbKurang > jwbTidak)
        {
            hasil = jwbKurang;
            ExpValue = 2;
            print("Kurang");
        }
        else if (jwbTidak > jwbPernah && jwbTidak > jwbKurang)
        {
            hasil = jwbTidak;
            ExpValue = 3;
            print("Tidak");
        }
        else if (jwbPernah == jwbKurang)
        {
            hasil = jwbKurang;
            ExpValue = 2;
            print("Kurang");
        }
        else if (jwbPernah == jwbTidak)
        {
            hasil = jwbTidak;
            ExpValue = 3;
            print("Tidak");
        }
        else if (jwbKurang == jwbTidak)
        {
            hasil = jwbTidak;
            ExpValue = 3;
            print("Tidak");
        }
        else 
        {
            hasil = jwbTidak;
            ExpValue = 3;
            print("Tidak");
        }
        
        return ExpValue;

    }

    void ExpPosition()
    {
        if (Vector3.Distance(player.transform.position, NPCAhmad.transform.position) < 5f)
        {
            isAhmad = true;
            isMukhlis = false;
            isFurqon = false;
            isSumbul = false;
            Ahmad();
        }

        if (Vector3.Distance(player.transform.position, NPCMukhlis.transform.position) < 5f)
        {
            isMukhlis = true;
            isAhmad = false;
            isFurqon = false;
            isSumbul = false;
            Mukhlis();
            //OlahSoal();
        }

        if (Vector3.Distance(player.transform.position, NPCFurqon.transform.position) < 5f)
        {
            isFurqon = true;
            isAhmad = false;
            isMukhlis = false;
            isSumbul = false;
            Furqon();
            /*OlahSoal();*/
        }

        if (Vector3.Distance(player.transform.position, NPCSumbul.transform.position) < 5f)
        {
            isSumbul = true;
            isAhmad = false;
            isFurqon = false;
            isMukhlis = false;
            Sumbul();
            /*OlahSoal();*/
        }
    }

    public void Done()
    {
        ExpLayer.SetActive(false);
        sceneInfo.HasExpData = hasExpData;

        sceneInfo.HasExpTQAsasi = hasExpTQAsasi;
        sceneInfo.HasExpTQQiraah = hasExpTQQiraah;
        sceneInfo.HasExpTAAsasi = hasExpTAAsasi;
        sceneInfo.HasExpTAAlaly= hasExpTAAlaly;

        jwbKurang = 0;
        jwbPernah = 0;
        jwbTidak = 0;
    }
    public void GetExpAnalysis(int expValue)
    {
        if (isAhmad)
        {
            pretest_qqiraah.experience[indexExp] = expValue;
        }
        else if (isFurqon)
        {
            pretest_aaly.experience[indexExp] = expValue;
        }
        else if (isMukhlis)
        {
            pretest_qasasi.experience[indexExp] = expValue;
        }
        else if (isSumbul)
        {
            pretest_aasasi.experience[indexExp] = expValue;
        }
        
        indexExp++;

        if (indexExp >= 4)
        {
            indexExp = 0;
        }
    }
    public void Ahmad()
    {
        OlahSoal(soalTQQiraah);
        if (!hasExpTQQiraah)
        {
            AskExperience();
        }
        else
        {
            TampilkanHasil();
        }
    }    
    public void Mukhlis()
    {
        OlahSoal(soalTQAsasi);
        if (!hasExpTQAsasi)
        {
            AskExperience();
        }
        else
        {
            TampilkanHasil();
        }
    }    
    public void Furqon()
    {
        OlahSoal(soalTAAlaly);
        if (!hasExpTAAlaly)
        {
            AskExperience();
        }
        else
        {
            TampilkanHasil();
        }
    }
    public void Sumbul()
    {
        OlahSoal(soalTAAsasi);
        if (!hasExpTAAsasi)
        {
            AskExperience();
        }
        else
        {
            TampilkanHasil();
        }
    }
}
