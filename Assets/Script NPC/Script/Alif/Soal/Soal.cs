using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Soal : MonoBehaviour
{

    public TextAsset assetSoal;

    private string[] soal;

    private string[,] soalBag;


    int indexSoal;
    int maxSoal;
    bool ambilSoal;
    char kunciJ;

    public Text txtSoal, txtOpsiA, txtOpsiB, txtOpsiC, txtOpsiD;

    bool isHasil;
    private float durasi;
    public float durasiPenilaian;

    public static int jwbBenar, jwbSalah;
    float nilai;

    public GameObject panel;
    public GameObject imgPenilaian, imgHasil;
    public Text txtHasil;

    public float currenttime;
    public bool timeractive;
    public int settime;
    public Text timetext;
    public static int scorewaktu;
    [SerializeField] GameObject pausemenu;
    public GameObject pengalamanpanel;
    public static bool pengalaman;

    // Start is called before the first frame update
    void Start()
    {
        PagePengalaman();

        currenttime = settime * 60;

        durasi = durasiPenilaian;

        soal = assetSoal.ToString().Split('#');

        soalBag = new string[soal.Length, 6];
        maxSoal = soal.Length;
        OlahSoal();

        ambilSoal = true;
        TampilkanSoal();

        print(soalBag[1, 3]);

        jwbBenar = 0;
        jwbSalah = 0;

        Debug.Log("Tes");

    }

    public void pause()
    {
        timeractive = false;

        pausemenu.SetActive(true);

    }

    public void PagePengalaman()
    {
        timeractive = false;

        pengalamanpanel.SetActive(true);
    }

    public void PilihanPengalaman(bool nilaipengalaman)
    {
        pengalaman = nilaipengalaman;

        timeractive = true;

        pengalamanpanel.SetActive(false);
    }

    public void lanjut()
    {
        timeractive = true;

        pausemenu.SetActive(false);
        pengalamanpanel.SetActive(false);
    }

    public void ulangscene()
    {
        SceneManager.LoadScene(11);
    }

    private void OlahSoal()
    {
        for (int i = 0; i < soal.Length; i++)
        {
            string[] tempSoal = soal[i].Split('+');
            for (int j = 0; j < tempSoal.Length; j++)
            {
                soalBag[i, j] = tempSoal[j];
                continue;
            }
            continue;
        }
    }

    private void TampilkanSoal()
    {
        if (indexSoal < maxSoal)
        {
            if (ambilSoal)
            {
                txtSoal.text = soalBag[indexSoal, 0];
                txtOpsiA.text = soalBag[indexSoal, 1];
                txtOpsiB.text = soalBag[indexSoal, 2];
                txtOpsiC.text = soalBag[indexSoal, 3];
                txtOpsiD.text = soalBag[indexSoal, 4];
                kunciJ = soalBag[indexSoal, 5][0];

                ambilSoal = false;
            }
        }
    }


    public void Opsi(string opsiHuruf)
    {
        CheckJawaban(opsiHuruf[0]);

        if (indexSoal == maxSoal - 1)
        {
            isHasil = true;
        }
        else
        {
            indexSoal++;
            ambilSoal = true;
        }

        panel.SetActive(true);
    }

    private float HitungNilai()
    {
        return nilai = (float)jwbBenar / maxSoal * 100;
    }

    public GameObject BenarObj;
    public GameObject SalahObj;
    private void CheckJawaban(char huruf)
    {
        if (huruf.Equals(kunciJ))
        {
            BenarObj.SetActive(true);
            SalahObj.SetActive(false);
            jwbBenar++;
        }
        else
        {
            SalahObj.SetActive(true);
            BenarObj.SetActive(false);
            jwbSalah++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeractive == true)
        {
            currenttime = currenttime - Time.deltaTime;
            if (currenttime <= 0)
            {
                timeractive = false;
            }
        }
        else if (timeractive == false)
        {
            scorewaktu = Mathf.RoundToInt(currenttime);

        }

        TimeSpan time = TimeSpan.FromSeconds(currenttime);
        timetext.text = time.Minutes.ToString() + ": " + time.Seconds.ToString();

        if (panel.activeSelf)
        {
            durasiPenilaian -= Time.deltaTime;

            if (isHasil)
            {
                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    timeractive = false;

                    time = TimeSpan.FromSeconds(currenttime);
                    timetext.text = time.Minutes.ToString() + ": " + time.Seconds.ToString();
                    //txtHasil.text = "Jumlah benar : " + jwbBenar + "\nJumlah Salah : " + jwbSalah + "\n\nNilai : " + HitungNilai();
                    txtHasil.text = "Test Sudah Selesai, Apakah Anda Ingin Melanjutkan Atau Mengulang Tes?";

                    imgPenilaian.SetActive(false);
                    imgHasil.SetActive(true);

                    durasiPenilaian = 0;

                }
            }
            else
            {

                imgPenilaian.SetActive(true);
                imgHasil.SetActive(false);

                if (durasiPenilaian <= 0)
                {
                    panel.SetActive(false);
                    durasiPenilaian = durasi;

                    TampilkanSoal();
                }
            }
        }


    }
}