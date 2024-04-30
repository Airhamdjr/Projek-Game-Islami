using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MateriController : MonoBehaviour
{
    public ScriptableItem item;
    public class rankData{
        public int ranking;
        public string materi;
        public GameObject key;

        public rankData(int ranking, string materi, GameObject key)
        {
            this.ranking = ranking;
            this.materi = materi;
            this.key = key;
        }
    }
    public TestData testData;

    public QQiraah_KeyController keyCon;

    public GameObject OutputLayer;
    public GameObject MenuLayer;
    public GameObject MateriLayer;

    public GameObject btnMateri1;
    public GameObject btnMateri2;
    public GameObject btnMateri3;
    public GameObject btnMateri4;

    public Text Materi1Text;
    public Text Materi2Text;
    public Text Materi3Text;
    public Text Materi4Text;

    public GameObject isMateri1Done;
    public GameObject isMateri2Done;
    public GameObject isMateri3Done;
    public GameObject isMateri4Done;

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

    private void Start()
    {
        OutputLayer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (OutputLayer.activeInHierarchy)
        {
            MenuLayer.SetActive(true);
        }

        OutputTextMateri();

    }

    public void btnFuncMateri1()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri1.SetActive(true);
        isMateri1Done.SetActive(true);
    }

    public void btnFuncMateri2()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri2.SetActive(true);
        isMateri2Done.SetActive(true);
    }

    public void btnFuncMateri3()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri3.SetActive(true);
        isMateri3Done.SetActive(true);
    }

    public void btnFuncMateri4()
    {
        MenuLayer.SetActive(false);
        MateriLayer.SetActive(true);
        btnMateri4.SetActive(true);
        isMateri4Done.SetActive(true);
    }
    
    public void btnBack()
    {
        MenuLayer.SetActive(true);
        MateriLayer.SetActive(false);
    }

    void OutputTextMateri()
    {
        Materi1Text.text = "Materi 1";
        Materi2Text.text = "Materi 2";
        Materi3Text.text = "Materi 3";
        Materi4Text.text = "Materi 4";
    }

    public void BackToMahad()
    {
        SceneManager.LoadScene("MainScene");
    }


   /* void rankTopsis()
    {
        var topsis_data = topsis.topsis_calculate();
        rank1 = topsis_data[0].key_alt;
        rank2 = topsis_data[1].key_alt;
        rank3 = topsis_data[2].key_alt;
        rank4 = topsis_data[3].key_alt;

        ranking1.text = rank1;
        ranking2.text = rank2;
        ranking3.text = rank3;
        ranking4.text = rank4;

*//*        for(int i = 0;i<topsis_data.Count; i++)
        {
            switch (topsis_data[i].key_alt)
            {
                case "Materi Al-Ta'rif":

            }
        }*/
/*        rankData key1Data = new rankData(materi1,);
        rankData key2Data = new rankData(2, rank2);
        rankData key3Data = new rankData(3, rank3);
        rankData key4Data = new rankData(4, rank4);*//*


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
    }
*/
}
