using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoalScriptMukhlis : MonoBehaviour
{
    // Save data to SceneInfo
    public SceneInfo sceneInfo;

    // Initiate Layer
    public GameObject PretestLayer;

    // Initiate Variables
    public TextAsset assetSoalMukhlis; // menampung file soal
 

    private string[] soal;
    private string[,] DBpreTest;

    int indexData;
    int maxSoal;
    bool ambilSoal;
    char kunciJ;

    // inisiasi teks pada canvas
    public Text txtTalim;
    public Text txtMateri;

    public Text txtSoal;
    public Text txtOpsiA;
    public Text txtOpsiB;
    public Text txtOpsiC;
    public Text txtOpsiD;

    public GameObject panelHasilPenilaian;
    public GameObject imgPenilaian;
    public GameObject outputBenar;
    public GameObject outputSalah;
    public GameObject imgHasil;

    public GameObject LearningLayer;
    public GameObject MateriA;
    public GameObject MateriB;
    public GameObject MateriC;
    public GameObject MateriD;
    public GameObject MateriE;
    public GameObject MateriF;

    public GameObject CompleteA;
    public GameObject CompleteB;
    public GameObject CompleteC;
    public GameObject CompleteD;
    public GameObject CompleteE;
    public GameObject CompleteF;

    public GameObject player;

    public GameObject Mukhlis;
    public GameObject Ahmad;
    public GameObject Furqon;
    public GameObject Sumbul;

    public bool isSumbul;
    public bool isMukhlis;
    public bool isFurqon;
    public bool isAhmad;


    public Text txtHasil;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    public int jwbBenar;
    public int jwbSalah;

    // Variable Set Timer
    public float totalTime = 60.0f; // Total waktu dalam detik
    private float currentTime;
    public Text timerText;

    private bool isGameOver = false;

    // Data yang harus di Pass ke Player
    private float nilai;
    private float waktu;
    private float waktuTerpakai;

    public int nilaiTest;
    public int waktuTest;
    public int sisaWaktu;
    
    void Start()
    {
        soal = assetSoalMukhlis.ToString().Split('#'); // pembatas pada tiap antar soal dengan simbol '#'
        DBpreTest = new string[soal.Length, 8];
        maxSoal = soal.Length;
        OlahSoal();

        ambilSoal = true;
        TampilkanSoal();

        durasi = durasiPenilaian;

        currentTime = totalTime;
        UpdateTimerText();
        // Memulai timer countdown menggunakan coroutine
        StartCoroutine(StartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        GameRunning();

        MateriA.SetActive(true);
        MateriB.SetActive(true);
        MateriC.SetActive(true);
        MateriD.SetActive(true);
        MateriF.SetActive(true);
        MateriE.SetActive(true);

        
    }

    private void TampilkanSoal()
    {
        if (indexData < maxSoal)
        {
            if (ambilSoal)
            {
                txtSoal.text = DBpreTest[indexData, 0]; // Mengambil index ke 0 pada DB sebagai soal
                txtOpsiA.text = DBpreTest[indexData, 1]; // Mengambil index ke 1 pada DB sebagai jawaban A
                txtOpsiB.text = DBpreTest[indexData, 2]; // Mengambil index ke 2 pada DB sebagai jawaban B
                txtOpsiC.text = DBpreTest[indexData, 3]; // Mengambil index ke 3 pada DB sebagai jawaban C
                txtOpsiD.text = DBpreTest[indexData, 4]; // Mengambil index ke 4 pada DB sebagai jawaban D
                kunciJ = DBpreTest[indexData, 5][0];

                txtTalim.text = DBpreTest[indexData, 6];
                txtMateri.text = DBpreTest[indexData, 7];

                ambilSoal = false;
            }

        }

    }

    private void OlahSoal()
    {
        // penyimpanan soal ke DB dengan pembatas pada tiap index menggunakan simbol '+'
        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                DBpreTest[i, j] = tempSoal[j];
                continue;
            }
            continue;
        }
    }

    private void CheckJawaban(char huruf)
    {
        if (huruf.Equals(kunciJ))
        {
            outputBenar.SetActive(true);
            outputSalah.SetActive(false);
            jwbBenar++;
        }
        else
        {
            outputSalah.SetActive(true);
            outputBenar.SetActive(false);
            jwbSalah++;
        }
    }

    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);

        if(indexData == maxSoal - 1)
        {
            isHasil = true;
        }
        else
        {
            indexData++;
            ambilSoal = true;
        }

        panelHasilPenilaian.SetActive(true);
    }

    private float HitungNilai()
    {
        return nilai = (float)jwbBenar / maxSoal * 100;
    }

    private float HitungSisaWaktu()
    {
        return waktu = Mathf.FloorToInt(currentTime);
    }

    private float HitungWaktuTerpakai()
    {
        return waktuTerpakai = Mathf.FloorToInt(totalTime - currentTime);
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return null; // Menunggu satu frame
        }
        GameOver();
    }

    void GameOver()
    {
        isGameOver = true;
    }

    public void GameRunning()
    {
        nilaiTest = Mathf.FloorToInt(nilai);
        sisaWaktu = Mathf.FloorToInt(currentTime);
        waktuTest = Mathf.FloorToInt(totalTime - currentTime);

        if (PretestLayer.activeSelf)
        {
            if (!isGameOver)
            {
                currentTime -= Time.deltaTime;

                imgHasil.SetActive(false);
                imgPenilaian.SetActive(false);

                TampilkanSoal();

                if (currentTime <= 0)
                {
                    imgHasil.SetActive(true);
                    txtHasil.text = "Waktu Habis\n" +
                        "\nJumlah Soal :" + maxSoal +
                        "\nJumlah Benar :" + jwbBenar +
                        "\nJumlah Salah : " + jwbSalah +
                        "\nNilai : " + HitungNilai() +
                        "\nWaktu Pengerjaan : " + waktuTest +
                        "\nSisa Waktu : " + sisaWaktu;

                    currentTime = 0;
                    GameOver();
                }
                UpdateTimerText();
            }

            if (panelHasilPenilaian.activeSelf)
            {
                durasiPenilaian -= Time.deltaTime; // countdown panelHasilPenilaian

                if (!isHasil)
                {
                    imgPenilaian.SetActive(true);
                    imgHasil.SetActive(false);

                    if (durasiPenilaian <= 0)
                    {
                        panelHasilPenilaian.SetActive(false);
                        durasiPenilaian = durasi;

                        TampilkanSoal();
                    }
                }
                else
                {
                    imgPenilaian.SetActive(true);
                    imgHasil.SetActive(false);

                    if (durasiPenilaian <= 0)
                    {
                        txtHasil.text = "Semua Terjawab\n" +
                            "\nJumlah Soal :" + maxSoal +
                            "\nJumlah Benar :" + jwbBenar +
                            "\nJumlah Salah : " + jwbSalah +
                            "\nNilai : " + HitungNilai() +
                            "\nWaktu Pengerjaan : " + waktuTest +
                            "\nSisa Waktu : " + sisaWaktu;

                        panelHasilPenilaian.SetActive(false);
                        imgPenilaian.SetActive(false);
                        imgHasil.SetActive(true);

                        durasiPenilaian = 0;
                        GameOver();
                    }
                }
            }
        }
    }


    public void BMateriA()
    {
        CompleteA.SetActive(true);
    }
    public void BMateriB()
    {
        CompleteB.SetActive(true);
    }
    public void BMateriC()
    {
        CompleteC.SetActive(true);
    }
    public void BMateriD()
    {
        CompleteD.SetActive(true);
    }
    public void BMateriE()
    {
        CompleteE.SetActive(true);
    }
    public void BMateriF()
    {
        CompleteF.SetActive(true);
    }

}
