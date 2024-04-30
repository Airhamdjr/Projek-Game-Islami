/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ListNilai", menuName = "ScriptableNilai", order = 1)]
public class ScriptableNilai : ScriptableObject
{
    public int[] dataNilai = new int[12];
    public int[] dataWaktu = new int[12];
    public int[] dataPengalaman = new int[12];

    public int[] arrayNilai = new int[6];
    public int[] arrayWaktu = new int[6];
    public int[] arrayPengalaman = new int[6];

    public float[] normalisasiNilai = new float[6];
    public float[] normalisasiWaktu = new float[6];
    public float[] normalisasiPengalaman = new float[6];

    public float[] ratioSystemNilai = new float[6];
    public float[] ratioSystemWaktu = new float[6];
    public float[] ratioSystemPengalaman = new float[6];

    public float[] hasilOptimasi = new float[6];
    public float[] ui = new float[6];

    public float[] rangking = new float[4];
    
    private void OnEnable()
    {
        for(int i = 0; i < 7; i++)
        {
            normalisasiNilai[i] = 0;
            normalisasiPengalaman[i] = 0;
            normalisasiWaktu[i] = 0;
            ratioSystemNilai[i] = 0;
            ratioSystemWaktu[i] = 0;
            ratioSystemPengalaman[i] = 0;
            hasilOptimasi[i] = 0;
            ui[i] = 0;
        }
    }
}
*/