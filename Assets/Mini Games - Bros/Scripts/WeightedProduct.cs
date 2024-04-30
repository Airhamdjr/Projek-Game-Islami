using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class WeightedProduct : MonoBehaviour
{
    public PretestData pretest_asasi;
    // deklarasi & inisialisasi kategori, bobot, dan alternatif
    // setiap float harus punya f di belakangnya
    float[] weights;
    string[] category;
    string[] alternatif;
    float[,] decisionMatrix;

    public GameObject hasilAkhir;
    public Text ranking1, ranking2, ranking3, ranking4;
    public Text[] detail;
    public bool[] answers;
    TheKey theKey;

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
    public void weightedProduct()
    {
        weights = new float[3] { 0.5f, 0.3f, 0.2f };
        category = new string[3] { "cost", "benefit", "benefit" };
        alternatif = new string[4] { "Tajwid", "Nun Sukun dan Tanwin", "Mim Sukun", "Qolqolah" };
        decisionMatrix = new float[alternatif.Length, category.Length];

        for (int i = 0; i < alternatif.Length; i++)
        {
            for (int j = 0; j < category.Length; j++)
            {
                if (j == 0)
                {
                    decisionMatrix[i, j] = pretest_asasi.scores[i];
                }
                else if (j == 1)
                {
                    decisionMatrix[i, j] = pretest_asasi.times[i];
                }
                else
                {
                    decisionMatrix[i, j] = pretest_asasi.experience[i];
                }
            }
        }
        // konversi bobot untuk di pangkat yang vektor s
        float[] convertedWeights = ConvertWeights(weights, category);
        // cuma buat ngeprint
        int a = 0;
        foreach (var c in convertedWeights)
        {
            print("c" + (a++) + c);
        }

        // menghitung vektor s
        float[] productOfWeightedScores = CalculateProductOfWeightedScores(decisionMatrix, convertedWeights);
        // cuma buat ngeprint
        foreach (var s in productOfWeightedScores)
        {
            // print("PWS: " + s);
        }

        // Jumlah dari vektor s
        float sumVectorS = SumVectorS(productOfWeightedScores);
        // cuma buat ngeprint
        // print("SUM" + sumVectorS);

        // preferensi v dalam Dictionary dengan key = string, dan value = float
        Dictionary<TheKey, float> hasil_wp = CalculateFinalScores(productOfWeightedScores, sumVectorS);
        // cuma buat print
        // print("Final Scores:");
        foreach (var st in hasil_wp)
        {
            print(st.Key + " = " + st.Value);
        }

        // perankingan
        perankingan(hasil_wp);
    }

    private float[] ConvertWeights(float[] weights, string[] category)
    {
        int count = weights.Length;
        float[] convertedWeights = new float[count];

        // untuk setiap bobot
        for (int i = 0; i < count; i++)
        {

            switch (category[i])
            {
                // jika kategori benefit, maka bobot tetap
                case "benefit":
                    convertedWeights[i] = weights[i];
                    // print("converted  = " + convertedWeights[i]);
                    break;
                // jika kategori cost, maka bobot kali (-1)
                case "cost":
                    convertedWeights[i] = weights[i] * (-1);
                    // print("converted  = " + convertedWeights[i]);
                    break;
            }

        }
        return convertedWeights;
    }

    private float[] CalculateProductOfWeightedScores(float[,] decisionMatrix, float[] convertedWeights)
    {
        // baris alternatif matrix keputusan
        int rows = decisionMatrix.GetLength(0);
        // kolom kriteria matrix keputusan
        int cols = decisionMatrix.GetLength(1);

        float[] productOfWeightedScores = new float[rows];

        for (int i = 0; i < rows; i++)
        {
            float product = 1;
            for (int j = 0; j < cols; j++)
            {
                // vektor s = perkalian (rating alternatif ^ bobot) di satu baris
                product *= Mathf.Pow(decisionMatrix[i, j], convertedWeights[j]);
            }
            print(product);
            // memasukkan hasil vektor s ke dalam array menjadi setiap nilai alternatif
            productOfWeightedScores[i] = product;
        }

        return productOfWeightedScores;
    }
    private float SumVectorS(float[] productOfWeightedScores)
    {
        float sumVectorS = 0;
        // penjumlahan semua nilai s
        for (int i = 0; i < productOfWeightedScores.Length; i++)
        {
            sumVectorS += productOfWeightedScores[i];
            print("sum" + sumVectorS);
        }
        return sumVectorS;

    }

    private Dictionary<TheKey, float> CalculateFinalScores(float[] productOfWeightedScores, float sumVectorS)
    {
        // dictionary untuk menyimpan nilai setiap materi (alternatif)
        Dictionary<TheKey, float> hasil = new Dictionary<TheKey, float>();
        float[] finalScores = new float[productOfWeightedScores.Length];

        for (int i = 0; i < productOfWeightedScores.Length; i++)
        {
            finalScores[i] = productOfWeightedScores[i] / sumVectorS;
            // manambahkan key dan value ke dalam dictionary hasil
            theKey = new TheKey(i, alternatif[i]);
            hasil.Add(theKey, finalScores[i]);
        }

        return hasil;
    }
    private void perankingan(Dictionary<TheKey, float> skorAkhir)
    {
        int r = 1;
        // perankingan by descending kemudian ke dalam list
        var sortedKeyValuePairs = skorAkhir.OrderByDescending(x => x.Value).ToList();
        foreach (var items in sortedKeyValuePairs)
        {
            print("Ranking " + (r++) + " = materi " + items.Key + " (" + items.Value + ")");
        }

        int indexTime = 0;
        for (int indexRank = 0; indexRank < sortedKeyValuePairs.Count; indexRank++)
        {
            print("Ranking " + (indexRank) + " = materi " + sortedKeyValuePairs[indexRank].Key.key_alt + " (" + sortedKeyValuePairs[indexRank].Value + ")");

            switch (sortedKeyValuePairs[indexRank].Key.key_index)
            {
                case 0:
                    answers = pretest_asasi.answer1;
                    indexTime = 0;
                    break;
                case 1:
                    answers = pretest_asasi.answer2;
                    indexTime = 1;

                    break;
                case 2:
                    answers = pretest_asasi.answer3;
                    indexTime = 2;
                    break;
                case 3:
                    answers = pretest_asasi.answer4;
                    indexTime = 3;
                    break;
                default:
                    break;
            }

            ranking1.text = sortedKeyValuePairs[0].Key.key_alt;
            ranking2.text = sortedKeyValuePairs[1].Key.key_alt;
            ranking3.text = sortedKeyValuePairs[2].Key.key_alt;
            ranking4.text = sortedKeyValuePairs[3].Key.key_alt;

            detail[indexRank].text = "Benar: " + pretest_asasi.getRightAns(answers).ToString() + " Waktu: " + pretest_asasi.times[indexTime];

            hasilAkhir.SetActive(true);
        }

    }
}
