using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OutputText : MonoBehaviour
{
    public GameObject POPUP;
    public PopUp popUp;

    public SceneInfo sceneInfo;
    public GameObject OutputLayer;
    public Text NPCName;
    public Text textLine1;
    public Text textLine2;
    public Text textLine3;
    public Text textLine4;

    public PlayerData playerData;
    public GameObject player;

    private bool hasExp = false;
    private bool hasTest = false;

    // Inisiasi Data dari player
    float nilai;
    float waktu;
    float pengalaman;

    // Penentuan Bobot tiap alternatif
    float bobotNilai = 0.5f;
    float bobotWaktu = 0.3f;
    float bobotPengalaman = 0.2f;

    // inisiasi alternatif 
    private float Alt1;
    private float Alt2;
    private float Alt3;
    private float AltBehaviour;

    float MKeputusan11 = 0, MKeputusan12 = 0, MKeputusan13 = 0;
    float MKeputusan21 = 0, MKeputusan22 = 0, MKeputusan23 = 0;
    float MKeputusan31 = 0, MKeputusan32 = 0, MKeputusan33 = 0;

    // Inisiasi Normalisasi Nilai
    float NormalisasiNilai11, NormalisasiNilai12, NormalisasiNilai13;
    float NormalisasiNilai21, NormalisasiNilai22, NormalisasiNilai23;
    float NormalisasiNilai31, NormalisasiNilai32, NormalisasiNilai33;

    // Inisiasi Perangkingan
    float perangkingan11, perangkingan12, perangkingan13;
    float perangkingan21, perangkingan22, perangkingan23;
    float perangkingan31, perangkingan32, perangkingan33;

    void Awake()
    {
        playerData = player.GetComponent<PlayerData>();
        popUp = POPUP.GetComponent<PopUp>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PerhitunganDSS();
        textOutput();
        npcNameOutput();
    }

    public void PerhitunganDSS()
    {
        // Pengambilan Data dari Player
        nilai = playerData.Nilai;
        waktu = playerData.Waktu;
        pengalaman = playerData.Pengalaman;

        // Matriks keputusan
        // Kriteria 1 (Nilai)

        if (nilai >= 0 && nilai <= 4)
        {
            MKeputusan11 = 3;
            MKeputusan21 = 1;
            MKeputusan31 = 1;
        }
        else if (nilai >= 5 && nilai <= 8)
        {
            MKeputusan11 = 1;
            MKeputusan21 = 3;
            MKeputusan31 = 1;
        }
        else if (nilai >= 9 && nilai <= 12)
        {
            MKeputusan11 = 1;
            MKeputusan21 = 1;
            MKeputusan31 = 3;
        }

        // Kriteria 2 (Waktu)
        if (waktu <= 20)
        {
            MKeputusan12 = 3;
            MKeputusan22 = 1;
            MKeputusan32 = 1;
        }
        else if (waktu > 20 && waktu <= 40)
        {
            MKeputusan12 = 1;
            MKeputusan22 = 3;
            MKeputusan32 = 1;
        }
        else if (waktu > 40 && waktu <= 60)
        {
            MKeputusan12 = 1;
            MKeputusan22 = 1;
            MKeputusan32 = 3;
        }

        // Kriteria 3 (Pengalaman)
        // pernah = 1, kurang = 2, tidak = 3
        if (pengalaman == 1)
        {
            MKeputusan13 = 3;
            MKeputusan23 = 1;
            MKeputusan33 = 1;
        }
        else if (pengalaman == 2)
        {
            MKeputusan13 = 1;
            MKeputusan23 = 3;
            MKeputusan33 = 1;
        }
        else if (pengalaman == 3)
        {
            MKeputusan13 = 1;
            MKeputusan23 = 1;
            MKeputusan33 = 3;
        }

        // Normalisasi
        NormalisasiNilai11 = MKeputusan11 / 3;
        NormalisasiNilai21 = MKeputusan21 / 3;
        NormalisasiNilai31 = MKeputusan31 / 3;

        NormalisasiNilai12 = MKeputusan12 / 3;
        NormalisasiNilai22 = MKeputusan22 / 3;
        NormalisasiNilai32 = MKeputusan32 / 3;

        NormalisasiNilai13 = MKeputusan13 / 3;
        NormalisasiNilai23 = MKeputusan23 / 3;
        NormalisasiNilai33 = MKeputusan33 / 3;

        // Perangkingan 
        perangkingan11 = NormalisasiNilai11 * bobotNilai;
        perangkingan21 = NormalisasiNilai21 * bobotNilai;
        perangkingan31 = NormalisasiNilai31 * bobotNilai;

        perangkingan12 = NormalisasiNilai12 * bobotWaktu;
        perangkingan22 = NormalisasiNilai22 * bobotWaktu;
        perangkingan32 = NormalisasiNilai32 * bobotWaktu;

        perangkingan13 = NormalisasiNilai13 * bobotPengalaman;
        perangkingan23 = NormalisasiNilai23 * bobotPengalaman;
        perangkingan33 = NormalisasiNilai33 * bobotPengalaman;

        Alt1 = perangkingan11 + perangkingan12 + perangkingan13;
        Alt2 = perangkingan21 + perangkingan22 + perangkingan23;
        Alt3 = perangkingan31 + perangkingan32 + perangkingan33;

        AltBehaviour = Mathf.Max(Alt1, Alt2, Alt3);

        

    }

    void textOutput()
    {
        playerData.hasTestData = hasTest;
        playerData.hasExpData = hasExp;

        if (OutputLayer.activeInHierarchy)
        {
            OutputLayer.SetActive(true);
            if (hasTest == false || hasExp == false)
            {
                textLine1.text = "Selamat datang " + player;
                textLine2.text = "Perkenalkan, Saya NPC";
                textLine3.text = "Kamu harus menjawab beberapa pertanyaan";
                textLine4.text = "selesaikan pertanyaan pretest " +
                                  "untuk lolos dari labirin";
            }
            else if (hasTest == true && hasExp == true)
            {
                if (AltBehaviour == Alt1)
                {
                    textLine1.text = "Nilai = " + nilai + " Soal Terjawab Benar";
                    textLine2.text = "Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal";
                    textLine3.text = "Pengalaman = " + pengalaman + " (Pernah Belajar dan Paham)";
                    textLine4.text = "Nilai Kamu Sangat Bagus, Pertahankan!";
                }
                if (AltBehaviour == Alt2)
                {
                    textLine1.text = "Nilai = " + nilai + " Soal Terjawab Benar";
                    textLine2.text = "Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal";
                    textLine3.text = "Pengalaman = " + pengalaman + " (Pernah, Namun Kurang Paham)";
                    textLine4.text = "Nilai Kamu sudah cukup, Namun tingkatkan lagi belajarmu!";
                }
                if (AltBehaviour == Alt3)
                {
                    textLine1.text = "Nilai = " + nilai + " Soal Terjawab Benar";
                    textLine2.text = "Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal";
                    textLine3.text = "Pengalaman = " + pengalaman + " (Tidak Pernah Belajar)";
                    textLine4.text = "Nilai Kamu Masih Kurang, Kamu Harus Belajar Lagi!";
                }
            }
        }
    }

    void npcNameOutput()
    {
        if (popUp.npcAhmadStat == true)
        {
            /*popUp.npcMukhlisStat = false;
            popUp.npcFurqonStat = false;
            popUp.npcSumbulStat = false;*/

            NPCName.text = "AHMAD";
        }
        if (popUp.npcMukhlisStat == true)
        {
            /*popUp.npcAhmadStat = false;
            popUp.npcFurqonStat = false;
            popUp.npcSumbulStat = false;*/

            NPCName.text = "MUKHLIS";
        }
        if (popUp.npcFurqonStat == true)
        {
            /*popUp.npcAhmadStat = false;
            popUp.npcMukhlisStat = false;
            popUp.npcSumbulStat = false;*/

            NPCName.text = "FURQON";
        }
        if (popUp.npcSumbulStat == true)
        {
            /*popUp.npcAhmadStat = false;
            popUp.npcMukhlisStat = false;
            popUp.npcFurqonStat = false;*/
            
            NPCName.text = "SUMBUL";
        }

    }
}
