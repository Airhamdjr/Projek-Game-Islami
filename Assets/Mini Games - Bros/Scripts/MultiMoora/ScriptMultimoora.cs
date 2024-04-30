/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptMultimoora : MonoBehaviour
{
    public Text[] arrayNormalisasi = new Text[5];
    public Text[] arrayRatio = new Text[5];
    public Text[] arrayAlt = new Text[5];

    public InputField variabel;

    public ScriptableNilai scriptableNilai;

    private float normalisasiNilai;
    private float normalisasiWaktu;
    private float normalisasiPengalaman;

    private float RatioSystemNilai;
    private float RatioSystemPengalaman;
    private float RatioSystemWaktu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Normalisasi()
    {
        int i;
        i = int.Parse(variabel.text);
        //Normalisasi Nilai
        normalisasiNilai = scriptableNilai.arrayNilai[i] / Mathf.Sqrt(Mathf.Pow(scriptableNilai.arrayNilai[0], 2) + Mathf.Pow(scriptableNilai.arrayNilai[1], 2) + Mathf.Pow(scriptableNilai.arrayNilai[2], 2) + Mathf.Pow(scriptableNilai.arrayNilai[3], 2) + Mathf.Pow(scriptableNilai.arrayNilai[4], 2) + Mathf.Pow(scriptableNilai.arrayNilai[5], 2));
        Debug.Log(normalisasiNilai);
        arrayNormalisasi[i].text = normalisasiNilai.ToString();
        scriptableNilai.normalisasiNilai[i] = normalisasiNilai;

        //Normalisasi Waktu
        normalisasiWaktu = scriptableNilai.arrayWaktu[i] / Mathf.Sqrt(Mathf.Pow(scriptableNilai.arrayWaktu[0], 2) + Mathf.Pow(scriptableNilai.arrayWaktu[1], 2) + Mathf.Pow(scriptableNilai.arrayWaktu[2], 2) + Mathf.Pow(scriptableNilai.arrayWaktu[3], 2) + Mathf.Pow(scriptableNilai.arrayWaktu[4], 2) + Mathf.Pow(scriptableNilai.arrayWaktu[5], 2));
        Debug.Log(normalisasiWaktu);
        scriptableNilai.normalisasiWaktu[i] = normalisasiWaktu;

        //Normalisasi Pengalaman
        normalisasiPengalaman = scriptableNilai.arrayPengalaman[i] / Mathf.Sqrt(Mathf.Pow(scriptableNilai.arrayPengalaman[0], 2) + Mathf.Pow(scriptableNilai.arrayPengalaman[1], 2) + Mathf.Pow(scriptableNilai.arrayPengalaman[2], 2) + Mathf.Pow(scriptableNilai.arrayPengalaman[3], 2) + Mathf.Pow(scriptableNilai.arrayPengalaman[4], 2) + Mathf.Pow(scriptableNilai.arrayPengalaman[5], 2));
        scriptableNilai.normalisasiPengalaman[i] = normalisasiPengalaman;

        variabel.text = " ";
    }

    public void RatioSystem()
    {
        int i;
        i = int.Parse(variabel.text);
        RatioSystemNilai = (float)(scriptableNilai.normalisasiNilai[i] * 0.5);
        scriptableNilai.ratioSystemNilai[i] = RatioSystemNilai;
        RatioSystemWaktu = (float)(scriptableNilai.normalisasiWaktu[i] * 0.3);
        scriptableNilai.ratioSystemWaktu[i] = RatioSystemWaktu;
        RatioSystemPengalaman = (float)(scriptableNilai.normalisasiPengalaman[i] * 0.2);
        scriptableNilai.ratioSystemPengalaman[i] = RatioSystemPengalaman;

        arrayRatio[i].text = RatioSystemNilai.ToString();

        variabel.text = " ";
    }

    public void HasilOptimasi()
    {
        int i;
        i = int.Parse(variabel.text);

        scriptableNilai.hasilOptimasi[i] = scriptableNilai.ratioSystemNilai[i] + scriptableNilai.ratioSystemPengalaman[i] + scriptableNilai.ratioSystemWaktu[i];

        variabel.text = " ";
    }

    public void Ui()
    {
        int i;
        i = int.Parse(variabel.text);

        scriptableNilai.ui[i] = scriptableNilai.hasilOptimasi[i] / scriptableNilai.ratioSystemNilai[i];

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
*/