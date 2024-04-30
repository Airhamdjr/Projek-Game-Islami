using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class moorax : MonoBehaviour
{
    float bobotNilai = 0.5f;
    float bobotWaktu = 0.3f;
    float bobotPengalaman = 0.2f;

    public float[] nilaiMateri1;
    public float[] nilaiMateri2;
    public float[] nilaiMateri3;
    public float[] nilaiMateri4;

    public float[] WaktuMateri1;
    public float[] WaktuMateri2;
    public float[] WaktuMateri3;
    public float[] WaktuMateri4;

    public float[] ExpMateri1;
    public float[] ExpMateri2;
    public float[] ExpMateri3;
    public float[] ExpMateri4;

    public float Alt1;
    public float Alt2;
    public float Alt3;
    public float Alt4;

    float Rangking1;
    float Rangking2;
    float Rangking3;
    float Rangking4;

    public float MKeputusan11 = 0, MKeputusan12 = 0, MKeputusan13 = 0;
    public float MKeputusan21 = 0, MKeputusan22 = 0, MKeputusan23 = 0;
    public float MKeputusan31 = 0, MKeputusan32 = 0, MKeputusan33 = 0;
    public float MKeputusan41 = 0, MKeputusan42 = 0, MKeputusan43 = 0;

    float Normalisasi11, Normalisasi12, Normalisasi13;
    float Normalisasi21, Normalisasi22, Normalisasi23;
    float Normalisasi31, Normalisasi32, Normalisasi33;
    float Normalisasi41, Normalisasi42, Normalisasi43;

    float NilaiRatio11, NilaiRatio12, NilaiRatio13;
    float NilaiRatio21, NilaiRatio22, NilaiRatio23;
    float NilaiRatio31, NilaiRatio32, NilaiRatio33;
    float NilaiRatio41, NilaiRatio42, NilaiRatio43;

    float HasilOptimasi1, HasilOptimasi2, HasilOptimasi3, HasilOptimasi4;

    string[] alternatifMateri;

    void ScoreCalculate()
    {
        // Kondisi Nilai Materi 1
        for (int i = 0; i < nilaiMateri1.Length; i++)
        {
            if (nilaiMateri1[i] == 1)
            {
                nilaiMateri1[i] = 1;
            }
            else if (nilaiMateri1[i] == 4)
            {
                nilaiMateri1[i] = 4;
            }
        }

        // Kondisi Nilai Materi 2
        for (int i = 0; i < nilaiMateri2.Length; i++)
        {
            if (nilaiMateri2[i] == 1)
            {
                nilaiMateri2[i] = 1;
            }
            else if (nilaiMateri2[i] == 4)
            {
                nilaiMateri2[i] = 4;
            }
        }

        // Kondisi Nilai Materi 3
        for (int i = 0; i < nilaiMateri3.Length; i++)
        {
            if (nilaiMateri3[i] == 1)
            {
                nilaiMateri3[i] = 1;
            }
            else if (nilaiMateri3[i] == 4)
            {
                nilaiMateri3[i] = 4;
            }
        }

        // Kondisi Nilai Materi 4
        for (int i = 0; i < nilaiMateri4.Length; i++)
        {
            if (nilaiMateri4[i] == 1)
            {
                nilaiMateri4[i] = 1;
            }
            else if (nilaiMateri4[i] == 4)
            {
                nilaiMateri4[i] = 4;
            }
        }
    }
    void TimeCalculate()
    {
        // Kondisi Waktu Materi 1
        for (int i = 0; i < WaktuMateri1.Length; i++)
        {
            if (WaktuMateri1[i] > 1 && WaktuMateri1[i] < 20)
            {
                WaktuMateri1[i] = 1;
            }
            else if (WaktuMateri1[i] > 21 && WaktuMateri1[i] < 40)
            {
                WaktuMateri1[i] = 2;
            }
            else if (WaktuMateri1[i] > 41 && WaktuMateri1[i] < 60)
            {
                WaktuMateri1[i] = 3;
            }
            else if (WaktuMateri1[i] > 61 && WaktuMateri1[i] < 80)
            {
                WaktuMateri1[i] = 4;
            }
            else if (WaktuMateri1[i] > 81)
            {
                WaktuMateri1[i] = 5;
            }
        }
        // Kondisi Waktu Materi 2
        for (int i = 0; i < WaktuMateri2.Length; i++)
        {
            if (WaktuMateri2[i] > 1 && WaktuMateri2[i] < 20)
            {
                WaktuMateri2[i] = 1;
            }
            else if (WaktuMateri2[i] > 21 && WaktuMateri2[i] < 40)
            {
                WaktuMateri2[i] = 2;
            }
            else if (WaktuMateri2[i] > 41 && WaktuMateri2[i] < 60)
            {
                WaktuMateri2[i] = 3;
            }
            else if (WaktuMateri2[i] > 61 && WaktuMateri2[i] < 80)
            {
                WaktuMateri2[i] = 4;
            }
            else if (WaktuMateri2[i] > 81)
            {
                WaktuMateri2[i] = 5;
            }
        }

        // Kondisi Waktu Materi 3
        for (int i = 0; i < WaktuMateri3.Length; i++)
        {
            if (WaktuMateri3[i] > 1 && WaktuMateri3[i] < 20)
            {
                WaktuMateri3[i] = 1;
            }
            else if (WaktuMateri3[i] > 21 && WaktuMateri3[i] < 40)
            {
                WaktuMateri3[i] = 2;
            }
            else if (WaktuMateri3[i] > 41 && WaktuMateri3[i] < 60)
            {
                WaktuMateri3[i] = 3;
            }
            else if (WaktuMateri3[i] > 61 && WaktuMateri3[i] < 80)
            {
                WaktuMateri3[i] = 4;
            }
            else if (WaktuMateri3[i] > 81)
            {
                WaktuMateri3[i] = 5;
            }
        }

        // Kondisi Waktu Materi 4 
        for (int i = 0; i < WaktuMateri4.Length; i++)
        {
            if (WaktuMateri4[i] > 1 && WaktuMateri4[i] < 20)
            {
                WaktuMateri4[i] = 1;
            }
            else if (WaktuMateri4[i] > 21 && WaktuMateri4[i] < 40)
            {
                WaktuMateri4[i] = 2;
            }
            else if (WaktuMateri4[i] > 41 && WaktuMateri4[i] < 60)
            {
                WaktuMateri4[i] = 3;
            }
            else if (WaktuMateri4[i] > 61 && WaktuMateri4[i] < 80)
            {
                WaktuMateri4[i] = 4;
            }
            else if (WaktuMateri4[i] > 81)
            {
                WaktuMateri4[i] = 5;
            }
        }

        Debug.Log("Waktu Materi 1");
        Debug.Log("Soal 1 = " + WaktuMateri1[0]);
        Debug.Log("Soal 2 = " + WaktuMateri1[1]);
        Debug.Log("Soal 3 = " + WaktuMateri1[2]);
        Debug.Log("======================");
        Debug.Log("Waktu Materi 2");
        Debug.Log("Soal 1 = " + WaktuMateri2[0]);
        Debug.Log("Soal 2 = " + WaktuMateri2[1]);
        Debug.Log("Soal 3 = " + WaktuMateri2[2]);
        Debug.Log("======================");
        Debug.Log("Waktu Materi 3");
        Debug.Log("Soal 1 = " + WaktuMateri3[0]);
        Debug.Log("Soal 2 = " + WaktuMateri3[1]);
        Debug.Log("Soal 3 = " + WaktuMateri3[2]);
        Debug.Log("======================");
        Debug.Log("Waktu Materi 4");
        Debug.Log("Soal 1 = " + WaktuMateri4[0]);
        Debug.Log("Soal 2 = " + WaktuMateri4[1]);
        Debug.Log("Soal 3 = " + WaktuMateri4[2]);
        Debug.Log("======================");
    }
    void ExpCalculate()
    {
        // Kondisi Exp Materi 1
        for (int i = 0; i < ExpMateri1.Length; i++)
        {
            if (ExpMateri1[i] == 1)
            {
                ExpMateri1[i] = 1;
            }
            else if (ExpMateri1[i] == 2)
            {
                ExpMateri1[i] = 2;
            }
            else if (ExpMateri1[i] == 3)
            {
                ExpMateri1[i] = 3;
            }
        }

        // Kondisi Exp Materi 2
        for (int i = 0; i < ExpMateri2.Length; i++)
        {
            if (ExpMateri2[i] == 1)
            {
                ExpMateri2[i] = 1;
            }
            else if (ExpMateri2[i] == 2)
            {
                ExpMateri2[i] = 2;
            }
            else if (ExpMateri2[i] == 3)
            {
                ExpMateri2[i] = 3;
            }
        }

        // Kondisi Exp Materi 3
        for (int i = 0; i < ExpMateri3.Length; i++)
        {
            if (ExpMateri3[i] == 1)
            {
                ExpMateri3[i] = 1;
            }
            else if (ExpMateri3[i] == 2)
            {
                ExpMateri3[i] = 2;
            }
            else if (ExpMateri3[i] == 3)
            {
                ExpMateri3[i] = 3;
            }
        }

        // Kondisi Exp Materi 4
        for (int i = 0; i < ExpMateri4.Length; i++)
        {
            if (ExpMateri4[i] == 1)
            {
                ExpMateri4[i] = 1;
            }
            else if (ExpMateri4[i] == 2)
            {
                ExpMateri4[i] = 2;
            }
            else if (ExpMateri4[i] == 3)
            {
                ExpMateri4[i] = 3;
            }
        }
    }
    public void HitungMoora()
    {
        ScoreCalculate();
        TimeCalculate();
        ExpCalculate();

        // Nilai PerMateri
        MKeputusan11 = nilaiMateri1[0] + nilaiMateri1[1] + nilaiMateri1[2];
        MKeputusan21 = nilaiMateri2[0] + nilaiMateri2[1] + nilaiMateri2[2];
        MKeputusan31 = nilaiMateri3[0] + nilaiMateri3[1] + nilaiMateri3[2];
        MKeputusan41 = nilaiMateri4[0] + nilaiMateri4[1] + nilaiMateri4[2];

        // Waktu PerMateri
        MKeputusan12 = WaktuMateri1[0] + WaktuMateri1[1] + WaktuMateri1[2];
        MKeputusan22 = WaktuMateri2[0] + WaktuMateri2[1] + WaktuMateri2[2];
        MKeputusan32 = WaktuMateri3[0] + WaktuMateri3[1] + WaktuMateri3[2];
        MKeputusan42 = WaktuMateri4[0] + WaktuMateri4[1] + WaktuMateri4[2];

        // Pengalaman PerMateri
        MKeputusan13 = ExpMateri1[0] + ExpMateri1[1] + ExpMateri1[2];
        MKeputusan23 = ExpMateri2[0] + ExpMateri2[1] + ExpMateri2[2];
        MKeputusan33 = ExpMateri3[0] + ExpMateri3[1] + ExpMateri3[2];
        MKeputusan43 = ExpMateri4[0] + ExpMateri4[1] + ExpMateri4[2];

        // Normalisasi
        Normalisasi11 = MKeputusan11 / (Mathf.Sqrt(Mathf.Pow(MKeputusan11, 2) + Mathf.Pow(MKeputusan21, 2) + Mathf.Pow(MKeputusan31, 2) + Mathf.Pow(MKeputusan41, 2)));
        Normalisasi21 = MKeputusan21 / (Mathf.Sqrt(Mathf.Pow(MKeputusan11, 2) + Mathf.Pow(MKeputusan21, 2) + Mathf.Pow(MKeputusan31, 2) + Mathf.Pow(MKeputusan41, 2)));
        Normalisasi31 = MKeputusan31 / (Mathf.Sqrt(Mathf.Pow(MKeputusan11, 2) + Mathf.Pow(MKeputusan21, 2) + Mathf.Pow(MKeputusan31, 2) + Mathf.Pow(MKeputusan41, 2)));
        Normalisasi41 = MKeputusan41 / (Mathf.Sqrt(Mathf.Pow(MKeputusan11, 2) + Mathf.Pow(MKeputusan21, 2) + Mathf.Pow(MKeputusan31, 2) + Mathf.Pow(MKeputusan41, 2)));

        Normalisasi12 = MKeputusan12 / (Mathf.Sqrt(Mathf.Pow(MKeputusan12, 2) + Mathf.Pow(MKeputusan22, 2) + Mathf.Pow(MKeputusan32, 2) + Mathf.Pow(MKeputusan42, 2)));
        Normalisasi22 = MKeputusan22 / (Mathf.Sqrt(Mathf.Pow(MKeputusan12, 2) + Mathf.Pow(MKeputusan22, 2) + Mathf.Pow(MKeputusan32, 2) + Mathf.Pow(MKeputusan42, 2)));
        Normalisasi32 = MKeputusan32 / (Mathf.Sqrt(Mathf.Pow(MKeputusan12, 2) + Mathf.Pow(MKeputusan22, 2) + Mathf.Pow(MKeputusan32, 2) + Mathf.Pow(MKeputusan42, 2)));
        Normalisasi42 = MKeputusan42 / (Mathf.Sqrt(Mathf.Pow(MKeputusan12, 2) + Mathf.Pow(MKeputusan22, 2) + Mathf.Pow(MKeputusan32, 2) + Mathf.Pow(MKeputusan42, 2)));

        Normalisasi13 = MKeputusan13 / (Mathf.Sqrt(Mathf.Pow(MKeputusan13, 2) + Mathf.Pow(MKeputusan23, 2) + Mathf.Pow(MKeputusan33, 2) + Mathf.Pow(MKeputusan43, 2)));
        Normalisasi23 = MKeputusan23 / (Mathf.Sqrt(Mathf.Pow(MKeputusan13, 2) + Mathf.Pow(MKeputusan23, 2) + Mathf.Pow(MKeputusan33, 2) + Mathf.Pow(MKeputusan43, 2)));
        Normalisasi33 = MKeputusan33 / (Mathf.Sqrt(Mathf.Pow(MKeputusan13, 2) + Mathf.Pow(MKeputusan23, 2) + Mathf.Pow(MKeputusan33, 2) + Mathf.Pow(MKeputusan43, 2)));
        Normalisasi43 = MKeputusan43 / (Mathf.Sqrt(Mathf.Pow(MKeputusan13, 2) + Mathf.Pow(MKeputusan23, 2) + Mathf.Pow(MKeputusan33, 2) + Mathf.Pow(MKeputusan43, 2)));


        //Nilai Ratio
        NilaiRatio11 = Normalisasi11 * bobotNilai;
        NilaiRatio21 = Normalisasi21 * bobotNilai;
        NilaiRatio31 = Normalisasi31 * bobotNilai;
        NilaiRatio41 = Normalisasi41 * bobotNilai;

        NilaiRatio12 = Normalisasi12 * bobotWaktu;
        NilaiRatio22 = Normalisasi22 * bobotWaktu;
        NilaiRatio32 = Normalisasi32 * bobotWaktu;
        NilaiRatio42 = Normalisasi42 * bobotWaktu;

        NilaiRatio13 = Normalisasi13 * bobotPengalaman;
        NilaiRatio23 = Normalisasi23 * bobotPengalaman;
        NilaiRatio33 = Normalisasi33 * bobotPengalaman;
        NilaiRatio43 = Normalisasi43 * bobotPengalaman;

        // Hasil Optimasi
        HasilOptimasi1 = NilaiRatio11 + NilaiRatio12 + NilaiRatio13;
        HasilOptimasi2 = NilaiRatio21 + NilaiRatio22 + NilaiRatio23;
        HasilOptimasi3 = NilaiRatio31 + NilaiRatio32 + NilaiRatio33;
        HasilOptimasi4 = NilaiRatio41 + NilaiRatio42 + NilaiRatio43;

        print("==Nilai==");
        print(NilaiRatio11);
        print(NilaiRatio21);
        print(NilaiRatio31);
        print(NilaiRatio41);

        print("==Waktu==");
        print(NilaiRatio12);
        print(NilaiRatio22);
        print(NilaiRatio32);
        print(NilaiRatio42);

        print("==Pengalaman==");
        print(NilaiRatio13);
        print(NilaiRatio23);
        print(NilaiRatio33);
        print(NilaiRatio43);
        print("===========");

        // Perangkingan
        Alt1 = HasilOptimasi1 / NilaiRatio11;
        Alt2 = HasilOptimasi2 / NilaiRatio21;
        Alt3 = HasilOptimasi3 / NilaiRatio31;
        Alt4 = HasilOptimasi4 / NilaiRatio41;

        Debug.Log("Nilai Alternatif 1 = " + Alt1);
        Debug.Log("Nilai Alternatif 2 = " + Alt2);
        Debug.Log("Nilai Alternatif 3 = " + Alt3);
        Debug.Log("Nilai Alternatif 4 = " + Alt4);
        Debug.Log("======================");
        Perangkingan();


    }

    void Perangkingan()
    {
        float[] Alternatif = { Alt1, Alt2, Alt3, Alt4 };
        float Rangking;

        for (int i = 0; i < Alternatif.Length; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Rangking = Alternatif[i];
                Alternatif[i] = Alternatif[j];
                Alternatif[j] = Rangking;
            }
            
        }

        Rangking1 = Alternatif[0];
        Rangking2 = Alternatif[1];
        Rangking3 = Alternatif[2];
        Rangking4 = Alternatif[3];

        Debug.Log("Ranking 1 = " + Rangking1);
        Debug.Log("Ranking 2 = " + Rangking2);
        Debug.Log("Ranking 3 = " + Rangking3);
        Debug.Log("Ranking 4 = " + Rangking4);


    }
    }
