using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SAW : MonoBehaviour
{
    // bobot
    float bobotNilai = 0.5f;
    float bobotWaktu = 0.3f;
    float bobotPengalaman = 0.2f;
    string[] alternatifMateri;

    public PretestData pretest_aasasi;
    // array input nilai
    public float[] nilaiMateri1;
    public float[] nilaiMateri2;
    public float[] nilaiMateri3;
    public float[] nilaiMateri4;

    // array input waktu
    public float[] waktuMateri1;
    public float[] waktuMateri2;
    public float[] waktuMateri3;
    public float[] waktuMateri4;

    // array input pengalaman
    public float[] pengalamanMateri1;
    public float[] pengalamanMateri2;
    public float[] pengalamanMateri3;
    public float[] pengalamanMateri4;

    // matriks keputusan
    float mKeputusan11, mKeputusan12, mKeputusan13;
    float mKeputusan21, mKeputusan22, mKeputusan23;
    float mKeputusan31, mKeputusan32, mKeputusan33;
    float mKeputusan41, mKeputusan42, mKeputusan43;

    // normalisasi
    float normalisasi11, normalisasi12, normalisasi13;
    float normalisasi21, normalisasi22, normalisasi23;
    float normalisasi31, normalisasi32, normalisasi33;
    float normalisasi41, normalisasi42, normalisasi43;

    // perangkingan
    float perangkingan11, perangkingan12, perangkingan13;
    float perangkingan21, perangkingan22, perangkingan23;
    float perangkingan31, perangkingan32, perangkingan33;
    float perangkingan41, perangkingan42, perangkingan43;

    // rangking
    float rangking1;
    float rangking2;
    float rangking3;
    float rangking4;

    // alternatif
    public float alt1;
    public float alt2;
    public float alt3;
    public float alt4;

    //tampilkan hasil
    public GameObject hasilAkhir;
    public Text ranking1, ranking2, ranking3, ranking4;
    public Text[] detail;
    public bool[] answers;
    TheKey theKey;

    public class TheKey
    {
        public string key_index { get; set; }
        public float key_alt { get; set; }

        public TheKey(string key_index, float key_alt)
        {
            this.key_index = key_index;
            this.key_alt = key_alt;
        }
    }

    public void hitungDSS() 
    {
        alternatifMateri = new string[4] { "Materi Wudhu", "Materi Sholat Sunnah dan Fardhu", "Materi Puasa", "Materi Haji dan Umroh" };

        mKeputusan11 = pretest_aasasi.scores[0];
        mKeputusan21 = pretest_aasasi.scores[1];
        mKeputusan31 = pretest_aasasi.scores[2];
        mKeputusan41 = pretest_aasasi.scores[3];

        mKeputusan22 = pretest_aasasi.times[0];
        mKeputusan12 = pretest_aasasi.times[1];
        mKeputusan32 = pretest_aasasi.times[2];
        mKeputusan42 = pretest_aasasi.times[3];

        mKeputusan13 = pretest_aasasi.experience[0];
        mKeputusan23 = pretest_aasasi.experience[1];
        mKeputusan33 = pretest_aasasi.experience[2];
        mKeputusan43 = pretest_aasasi.experience[3];

        normalisasi11 = Mathf.Min(mKeputusan11, mKeputusan21, mKeputusan31, mKeputusan41) / mKeputusan11;
        normalisasi21 = Mathf.Min(mKeputusan11, mKeputusan21, mKeputusan31, mKeputusan41) / mKeputusan21;
        normalisasi31 = Mathf.Min(mKeputusan11, mKeputusan21, mKeputusan31, mKeputusan41) / mKeputusan31;
        normalisasi41 = Mathf.Min(mKeputusan11, mKeputusan21, mKeputusan31, mKeputusan41) / mKeputusan41;

        normalisasi12 = mKeputusan12 / Mathf.Max(mKeputusan12, mKeputusan22, mKeputusan32, mKeputusan42);
        normalisasi22 = mKeputusan22 / Mathf.Max(mKeputusan12, mKeputusan22, mKeputusan32, mKeputusan42);
        normalisasi32 = mKeputusan32 / Mathf.Max(mKeputusan12, mKeputusan22, mKeputusan32, mKeputusan42);
        normalisasi42 = mKeputusan42 / Mathf.Max(mKeputusan12, mKeputusan22, mKeputusan32, mKeputusan42);

        normalisasi13 = mKeputusan13 / Mathf.Max(mKeputusan13, mKeputusan23, mKeputusan33, mKeputusan43);
        normalisasi23 = mKeputusan23 / Mathf.Max(mKeputusan13, mKeputusan23, mKeputusan33, mKeputusan43);
        normalisasi33 = mKeputusan33 / Mathf.Max(mKeputusan13, mKeputusan23, mKeputusan33, mKeputusan43);
        normalisasi43 = mKeputusan43 / Mathf.Max(mKeputusan13, mKeputusan23, mKeputusan33, mKeputusan43);

        perangkingan11 = normalisasi11 * bobotNilai;
        perangkingan21 = normalisasi21 * bobotNilai;
        perangkingan31 = normalisasi31 * bobotNilai;
        perangkingan41 = normalisasi41 * bobotNilai;

        perangkingan12 = normalisasi12 * bobotWaktu;
        perangkingan22 = normalisasi22 * bobotWaktu;
        perangkingan32 = normalisasi32 * bobotWaktu;
        perangkingan42 = normalisasi42 * bobotWaktu;

        perangkingan13 = normalisasi13 * bobotPengalaman;
        perangkingan23 = normalisasi23 * bobotPengalaman;
        perangkingan33 = normalisasi33 * bobotPengalaman;
        perangkingan43 = normalisasi43 * bobotPengalaman;

        alt1 = perangkingan11 + perangkingan12 + perangkingan13;
        alt2 = perangkingan21 + perangkingan22 + perangkingan23;
        alt3 = perangkingan31 + perangkingan32 + perangkingan33;
        alt4 = perangkingan41 + perangkingan42 + perangkingan43;

		Debug.Log("Nilai Alt 1 : " + alt1);
		Debug.Log("Nilai Alt 2 : " + alt2);
		Debug.Log("Nilai Alt 3 : " + alt3);
		Debug.Log("Nilai Alt 4 : " + alt4);

		Debug.Log("======================");

        ranking();
    }

    public void ranking()
    {
        Dictionary<int, TheKey> SAWRank = new Dictionary<int, TheKey>();
        float[] alternatif = {alt1, alt2, alt3, alt4};
        for (int i = 0; i < alternatifMateri.Length; i++)
        {
            theKey = new TheKey(alternatifMateri[i], alternatif[i]);
            SAWRank.Add(i, theKey);
        }

        TheKey RankingSAW;
        float Ranking;
		for (int i = 0; i < alternatif.Length; i++)
		{
            for (int j = 0; j < 4; j++)
            {
                if (SAWRank[j].key_alt > SAWRank[i].key_alt)
                {
                    RankingSAW = new TheKey(SAWRank[i].key_index, SAWRank[i].key_alt);
                    SAWRank[i] = SAWRank[j];
                    SAWRank[j] = RankingSAW;
                    Ranking = alternatif[i];
                    alternatif[i] = alternatif[j];
                    alternatif[j] = Ranking;
                }
                else
                {
                    alternatif[i] = alternatif[i];
                    alternatif[j] = alternatif[j];
                }
                if (i == j)
                {
                    break;
                }
                if (alternatif[i] > alternatif[j])
                {
                    Ranking = alternatif[i];
                    alternatif[i] = alternatif[j];
                    alternatif[j] = Ranking;
                }
            }
        }

        rangking1 = alternatif[0];
        rangking2 = alternatif[1];
        rangking3 = alternatif[2];
        rangking4 = alternatif[3];
        Debug.Log("Ranking 1 : " + rangking1);
        Debug.Log("Ranking 2 : " + rangking2);
        Debug.Log("Ranking 3 : " + rangking3);
        Debug.Log("Ranking 4 : " + rangking4);
        showHasil(SAWRank[0].key_index, SAWRank[1].key_index, SAWRank[2].key_index, SAWRank[3].key_index);

    }
    private void showHasil(string rank1, string rank2, string rank3, string rank4)
    {
        int indexTime = 0;
        ranking1.text = rank1;
        ranking2.text = rank2;
        ranking3.text = rank3;
        ranking4.text = rank4;

        string[] rank = new string[4] { rank1, rank2, rank3, rank4 };
        for (int indexRank = 0; indexRank < pretest_aasasi.scores.Length; indexRank++)
        {
            switch (rank[indexRank])
            {
                case "Materi Wudhu":
                    answers = pretest_aasasi.answer1;
                    indexTime = 0;
                    break;
                case "Materi Sholat Sunnah dan Fardhu":
                    answers = pretest_aasasi.answer2;
                    indexTime = 1;

                    break;
                case "Materi Puasa":
                    answers = pretest_aasasi.answer3;
                    indexTime = 2;
                    break;
                case "Materi Haji dan Umroh":
                    answers = pretest_aasasi.answer4;
                    indexTime = 3;
                    break;
                default:
                    break;
            }
            detail[indexRank].text = "Benar: " + pretest_aasasi.getRightAns(answers).ToString() + " Waktu: " + pretest_aasasi.times[indexTime];

            hasilAkhir.SetActive(true);
        }

    }
}
