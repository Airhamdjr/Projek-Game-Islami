using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Topsis : MonoBehaviour
{
    // mengambil data pretest
    public PretestData pretest_qiraah;

    //set ranking
    public HasilRank hasilRank;

    // TOPSIS Var
    [SerializeField] private string[] alternatif;
    [SerializeField] private string[] category;
    private static float[] score, time;
    private float[] times;
    private int[] experience;

    private float[,] decision_matrix;
    [SerializeField]
    private string c1_category, c2_category, c3_category;

    public float sum_c1;
    public float sum_c2;
    public float sum_c3;
    public float norm_div_c1;
    public float norm_div_c2;
    public float norm_div_c3;
    public float[] norm_c1;
    public float[] norm_c2;
    public float[] norm_c3;
    public float[] norm_weight_c1;
    public float[] norm_weight_c2;
    public float[] norm_weight_c3;
    public float topsis_ips_c1;
    public float topsis_ips_c2;
    public float topsis_ips_c3;
    public float topsis_ins_c1;
    public float topsis_ins_c2;
    public float topsis_ins_c3;
    public float[] topsis_dp;
    public float[] topsis_dn;
    public float[] topsis_sum_dp;
    public float[] topsis_sum_dn;
    public float val;

    public bool[] answers;
    int answer;
    float timeTotal;
    TheKey theKey;
    public GameObject hasilAkhir;
    public Text ranking1, ranking2, ranking3, ranking4;
    public Text[] detail;
    /*result[] resultValue;*/
    Dictionary<int, TheKey> resultValue = new Dictionary<int, TheKey>();

    public class TheKey
    {
        public int key_index { get; set; }
        public string key_alt { get; set; }

        public TheKey(int key_index, string key_alt)
        {
            this.key_index = key_index;
            this.key_alt = key_alt;
        }
    }
    public class result
    {
        public TheKey theKey;
        public float value;

        public result(TheKey theKey, float value)
        {
            this.theKey = theKey;
            this.value = value;
        }
    }


    public void topsis_calculate()
    {
        alternatif = new string[4] { "Materi Al-Ta'rif", "Materi Mad", "Materi Nun Sukun dan Tanwin", "Materi Waqaf" };
        category = new string[3] { "nilai", "waktu", "pengalaman" };
        c1_category = "cost";
        c2_category = "benefit";
        c3_category = "benefit";

        // mengambil data pre-test
        score = pretest_qiraah.scores;
        time = pretest_qiraah.times;
        experience = pretest_qiraah.experience;

        norm_c3 = new float[experience.Length];
        norm_c2 = new float[time.Length];
        norm_c1 = new float[score.Length];

        topsis_dp = new float[alternatif.Length];
        topsis_dn = new float[alternatif.Length];
        topsis_sum_dp = new float[alternatif.Length];
        topsis_sum_dn = new float[alternatif.Length];


        // ~ INI VARIABEL DICTIONARY UNTUK PERANKINGAN
        Dictionary<TheKey, float> topsis_v = new Dictionary<TheKey, float>();


        // NORMALISASI C1
        for (int i = 0; i < score.Length; i++)
        {
            // print("score" + i + " = " + score[i]);
            sum_c1 += (score[i] * score[i]);
            // print("Sum c1 = " + sum_c1);
        }

        norm_div_c1 = Mathf.Sqrt(sum_c1);
        // print("norm div1 = " + norm_div_c1);

        for (int i = 0; i < score.Length; i++)
        {
            norm_c1[i] = (score[i] / norm_div_c1);
        }
        // // UNTUK LIAT HASIL NORMALISASI C1
        // foreach (var item1 in norm_c1)
        // {
        //     print("normalisasi c1 = " + item1);
        // }

        // // ~ NORMALISASI C2
        for (int i = 0; i < time.Length; i++)
        {
            // print("time" + i + " = " + time[i]);
            sum_c2 += (time[i] * time[i]);
            // print("Sum c2= " + sum_c2);
        }

        norm_div_c2 = Mathf.Sqrt(sum_c2);
        // print("norm div3" + norm_div_c2);

        for (int i = 0; i < time.Length; i++)
        {
            norm_c2[i] = (time[i] / norm_div_c2);
        }
        // UNTUK LIAT HASIL NORMALISASI C2
        // foreach (var item2 in norm_c2)
        // {
        //     print("normalisasi c2" + item2);
        // }

        // // ~ NORMALISASI C3
        for (int i = 0; i < experience.Length; i++)
        {
            // print("experience" + i + " = " + experience[i]);
            sum_c3 += (experience[i] * experience[i]);
            // print("Sum c3" + sum_c3);
        }

        norm_div_c3 = Mathf.Sqrt(sum_c3);
        // print("norm div3" + norm_div_c3);

        for (int i = 0; i < experience.Length; i++)
        {
            norm_c3[i] = (experience[i] / norm_div_c3);
        }
        // UNTUK LIAT HASIL NORMALISASI C3
        // foreach (var item3 in norm_c3)
        // {
        //     print("normalisasi c3" + item3);
        // }

        // ~ NORMALISASI TERBOBOT PER KATEGORI
        norm_weight_c1 = new float[score.Length];
        norm_weight_c2 = new float[time.Length];
        norm_weight_c3 = new float[experience.Length];
        for (int j = 0; j < score.Length; j++)
        {
            norm_weight_c1[j] = (norm_c1[j] * 0.5f);
            // print("norm weight1 " + norm_weight_c1[j]);
        }
        for (int j = 0; j < time.Length; j++)
        {
            norm_weight_c2[j] = (norm_c2[j] * 0.3f);
            // print("norm weight2 " + norm_weight_c2[j]);
        }
        for (int j = 0; j < experience.Length; j++)
        {
            norm_weight_c3[j] = (norm_c3[j] * 0.2f);
            // print("norm weight3 " + norm_weight_c3[j]);
        }

        // ~ SOLUSI IDEAL POSITIF PERKATEGORI
        if (c1_category == "benefit")
        {
            topsis_ips_c1 = Mathf.Max(norm_weight_c1);
        }
        else if (c1_category == "cost")
        {
            topsis_ips_c1 = Mathf.Min(norm_weight_c1);
        }
        // print("ideal positif1 = " + topsis_ips_c1);

        if (c2_category == "benefit")
        {
            topsis_ips_c2 = Mathf.Max(norm_weight_c2);
        }
        else if (c2_category == "cost")
        {
            topsis_ips_c2 = Mathf.Min(norm_weight_c2);
        }
        // print("ideal positif2 = " + topsis_ips_c2);

        if (c3_category == "benefit")
        {
            topsis_ips_c3 = Mathf.Max(norm_weight_c3);
        }
        else if (c3_category == "cost")
        {
            topsis_ips_c3 = Mathf.Min(norm_weight_c3);
        }
        // print("ideal positif3 = " + topsis_ips_c3);

        // ~ SOLUSI IDEAL NEGATIF
        if (c1_category == "benefit")
        {
            topsis_ins_c1 = Mathf.Min(norm_weight_c1);
        }
        else if (c1_category == "cost")
        {
            topsis_ins_c1 = Mathf.Max(norm_weight_c1);
        }
        // print("ideal negatif1 = " + topsis_ins_c1);

        if (c2_category == "benefit")
        {
            topsis_ins_c2 = Mathf.Min(norm_weight_c2);
        }
        else if (c2_category == "cost")
        {
            topsis_ins_c2 = Mathf.Max(norm_weight_c2);
        }
        // print("ideal negatif2 = " + topsis_ins_c2);

        if (c3_category == "benefit")
        {
            topsis_ins_c3 = Mathf.Min(norm_weight_c3);
        }
        else if (c3_category == "cost")
        {
            topsis_ins_c3 = Mathf.Max(norm_weight_c3);
        }
        // print("ideal negatif3 = " + topsis_ins_c3);

        // ~ JARAK EUCLIDEAN ALTERNATIF KE SOLUSI IDEAL POSITIF
        for (int i = 0; i < alternatif.Length; i++)
        {
            topsis_sum_dp[i] = ((topsis_ips_c1 - norm_weight_c1[i]) * (topsis_ips_c1 - norm_weight_c1[i])) + ((topsis_ips_c2 - norm_weight_c2[i]) * (topsis_ips_c2 - norm_weight_c2[i])) + ((topsis_ips_c3 - norm_weight_c3[i]) * (topsis_ips_c3 - norm_weight_c3[i]));
            // print(topsis_sum_dp[i]);

        }
        for (int i = 0; i < alternatif.Length; i++)
        {
            topsis_dp[i] = Mathf.Sqrt(topsis_sum_dp[i]);
            // print("pos [ " + topsis_dp[i] + "]");
        }

        // // ~ JARAK EUCLIDEAN ALTERNATIF KE SOLUSI IDEAL NEGATIF
        for (int j = 0; j < alternatif.Length; j++)
        {
            topsis_sum_dn[j] += ((topsis_ins_c1 - norm_weight_c1[j]) * (topsis_ins_c1 - norm_weight_c1[j])) + ((topsis_ins_c2 - norm_weight_c2[j]) * (topsis_ins_c2 - norm_weight_c2[j])) + ((topsis_ins_c3 - norm_weight_c3[j]) * (topsis_ins_c3 - norm_weight_c3[j]));
        }
        for (int j = 0; j < alternatif.Length; j++)
        {
            topsis_dn[j] = Mathf.Sqrt(topsis_sum_dn[j]);
            // print("neg [ " + topsis_dn[j] + "]");
        }

        // // ~ NILAI PREFERENSI
        for (int i = 0; i < alternatif.Length; i++)
        {
            val = (topsis_dn[i] / (topsis_dp[i] + topsis_dn[i]));
            print("Nilai preferensi materi  " + i + " = " + val);
            theKey = new TheKey(i, alternatif[i]);
            // Memasukkan ke dictionary dengan key = nomor materi, value = nilai preferensi
            topsis_v.Add(theKey, val);
        }

        // // ~ PENGURUTAN DARI YANG TERBESAR
        /*int r = 1;
        var sortedKeyValuePairs = topsis_v.OrderByDescending(x => x.Value).ToList();
        int indexTime = 0;
        *//*resultValue = new result[sortedKeyValuePairs.Count];*//*
        for (int indexRank = 0; indexRank < sortedKeyValuePairs.Count; indexRank++)
        {
            print("Ranking " + (indexRank) + " = materi " + sortedKeyValuePairs[indexRank].Key.key_alt + " (" + sortedKeyValuePairs[indexRank].Value + ")");

            resultValue.Add(indexRank, sortedKeyValuePairs[indexRank].Key);

        }
*//*        ranking1.text = "SCORE : " + answer;

        detail.text = "TIME : " + timeTotal;*/

        /*        hasilAkhir.SetActive(true);*//*


                //         foreach (var items in sortedKeyValuePairs)
                //         {
                //             print("Ranking " + (r++) + " = materi " + items.Key + " (" + items.Value + ")");

                // ranking1.text = 
                //             hasilAkhir.SetActive(true);
                //         }
                return resultValue;*/
        int r = 1;
        var sortedKeyValuePairs = topsis_v.OrderByDescending(x => x.Value).ToList();
        int indexTime = 0;
        for (int indexRank = 0; indexRank < sortedKeyValuePairs.Count; indexRank++)
        {
            print("Ranking " + (indexRank) + " = materi " + sortedKeyValuePairs[indexRank].Key.key_alt + " (" + sortedKeyValuePairs[indexRank].Value + ")");

            switch (sortedKeyValuePairs[indexRank].Key.key_index)
            {
                case 0:
                    answers = pretest_qiraah.answer1;
                    indexTime = 0;
                    break;
                case 1:
                    answers = pretest_qiraah.answer2;
                    indexTime = 1;

                    break;
                case 2:
                    answers = pretest_qiraah.answer3;
                    indexTime = 2;
                    break;
                case 3:
                    answers = pretest_qiraah.answer4;
                    indexTime = 3;
                    break;
                default:
                    break;
            }

            ranking1.text = sortedKeyValuePairs[0].Key.key_alt;
            ranking2.text = sortedKeyValuePairs[1].Key.key_alt;
            ranking3.text = sortedKeyValuePairs[2].Key.key_alt;
            ranking4.text = sortedKeyValuePairs[3].Key.key_alt;

            detail[indexRank].text = "Benar: " + pretest_qiraah.getRightAns(answers).ToString() + " Waktu: " + pretest_qiraah.times[indexTime];

            hasilAkhir.SetActive(true);
        }

        hasilRank.rank1 = sortedKeyValuePairs[0].Key.key_alt;
        hasilRank.rank2 = sortedKeyValuePairs[1].Key.key_alt;
        hasilRank.rank3 = sortedKeyValuePairs[2].Key.key_alt;
        hasilRank.rank4 = sortedKeyValuePairs[3].Key.key_alt;
    }
}

