using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSS : MonoBehaviour
{
    public PlayerData playerData;
    public GameObject player;
    public GameObject NPC;

    // Inisiasi Data dari player
    float nilai;
    float waktu;
    float pengalaman;

    // Penentuan Bobot tiap alternatif
    float bobotNilai = 0.5f;
    float bobotWaktu = 0.3f;
    float bobotPengalaman = 0.2f;

    // inisiasi alternatif 
    public float Alt1;
    public float Alt2;
    public float Alt3;
    public float AltBehaviour;

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

    bool nullData = true;

    void Awake()
    {
        playerData = player.GetComponent<PlayerData>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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

        if (AltBehaviour == Alt1)
        {
            Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
            Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
            Debug.Log("Pengalaman = " + pengalaman + " (Pernah Belajar dan Paham)");
            Debug.Log("Nilai Kamu Sangat Bagus, Pertahankan!");

        }
        if (AltBehaviour == Alt2)
        {
            Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
            Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
            Debug.Log("Pengalaman = " + pengalaman + " (Pernah, Namun Kurang Paham)");
            Debug.Log("Nilai Kamu sudah cukup, Namun tingkatkan lagi belajarmu!");

        }
        else if (AltBehaviour == Alt3)
        {
            Debug.Log("Nilai = " + nilai + " Soal Terjawab Benar");
            Debug.Log("Waktu = " + waktu + " Detik Rata-Rata Pengerjaan Soal");
            Debug.Log("Pengalaman = " + pengalaman + " (Tidak Pernah Belajar)");
            Debug.Log("Nilai Kamu Masih Kurang, Kamu Harus Belajar Lagi!");

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Player Masuk Dalam Jangkauan " + NPC);
            PerhitunganDSS();
        }
        

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Keluar Dari Jangkauan " + NPC);
        }
    }


}
