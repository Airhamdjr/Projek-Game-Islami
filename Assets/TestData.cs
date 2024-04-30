using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestData : MonoBehaviour
{
    public GameObject hasil;
    public Topsis topsis;
    public Text ranking1;
    public Text ranking2;
    public Text ranking3;
    public Text ranking4;
    public Text[] detail;

    public string rank1;
    public string rank2;
    public string rank3;
    public string rank4;

    public PretestData pretest_qiraah;
    public int indexRank;
    public int indexTime;
    public bool[] answers;

    void Start()
    {
    }
    /*public void calculateTopsis()
    {
        var topsis_data = topsis.topsis_calculate();
        ranking1.text = topsis_data[0].key_alt;
        ranking2.text = topsis_data[1].key_alt;
        ranking3.text = topsis_data[2].key_alt;
        ranking4.text = topsis_data[3].key_alt;

        rank1 = topsis_data[0].key_alt;
        rank2 = topsis_data[1].key_alt;
        rank3 = topsis_data[2].key_alt;
        rank4 = topsis_data[3].key_alt;

        for (indexRank = 0; indexRank < topsis_data.Count; indexRank++)
        {
            switch (topsis_data[indexRank].key_index)
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
            detail[indexRank].text = "Benar: " + pretest_qiraah.getRightAns(answers).ToString() + " Waktu: " + pretest_qiraah.times[indexTime];
        }

        hasil.SetActive(true);
    }*/
}

