using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConverter : MonoBehaviour
{
    public int jumlah_soal = 3;
    public int jumlah_materi = 4;
    float skor_mat1, skor_mat2, skor_mat3, skor_mat4;
    float time_mat1, time_mat2, time_mat3, time_mat4;
    public int skor_after;
    // public int pengalaman;


    public int ScoreConvert(bool answer, float time, int pengalaman)
    {
        // print("time = " + time);
        if (answer)
        {
            // print("answer = " + answer);
            if (time <= 100 && time >= 75)
            {

                switch (pengalaman)
                {

                    case 1:
                        skor_after = 36;
                        break;
                    case 2:
                        skor_after = 20;
                        break;
                    case 3:
                        skor_after = 4;
                        break;
                    default:
                        break;

                        // print("pengalaman = " + pengalaman);
                }
            }
            else if (time <= 74 && time >= 51)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 40;
                        break;
                    case 2:
                        skor_after = 24;
                        break;
                    case 3:
                        skor_after = 8;
                        break;
                    default:
                        break;
                }
            }
            else if (time <= 50 && time >= 26)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 44;
                        break;
                    case 2:
                        skor_after = 28;
                        break;
                    case 3:
                        skor_after = 12;
                        break;
                    default:
                        break;
                }
            }

            else if (time <= 25 && time >= 1)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 48;
                        break;
                    case 2:
                        skor_after = 32;
                        break;
                    case 3:
                        skor_after = 16;
                        break;
                    default:
                        break;

                }
            }
            print("skor after = " + skor_after);
        }
        if (!answer)
        {
            if (time <= 100 && time >= 75)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 9;
                        break;
                    case 2:
                        skor_after = 5;
                        break;
                    case 3:
                        skor_after = 1;
                        break;
                    default:
                        break;
                }
            }
            else if (time <= 74 && time >= 51)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 10;
                        break;
                    case 2:
                        skor_after = 6;
                        break;
                    case 3:
                        skor_after = 2;
                        break;
                    default:
                        break;
                }
            }
            else if (time <= 50 && time >= 26)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 11;
                        break;
                    case 2:
                        skor_after = 7;
                        break;
                    case 3:
                        skor_after = 3;
                        break;
                    default:
                        break;
                }
            }

            else if (time <= 25 && time >= 1)
            {
                switch (pengalaman)
                {
                    case 1:
                        skor_after = 12;
                        break;
                    case 2:
                        skor_after = 8;
                        break;
                    case 3:
                        skor_after = 4;
                        break;
                    default:
                        break;

                }
            }
            print("skor after2 = " + skor_after);
        }
        // float[] scores = new float[3] { skor_mat1, skor_mat2, skor_mat3 };
        // return scores;
        return skor_after;
    }

    // public float[] TimeConvert(float time1, float time2, float time3)
    // {
    //     time_mat1 = time1 / jumlah_soal;
    //     // print(skor_after + "/" + jumlah_soal + "=" + skor_mat1);
    //     time_mat2 = time2 / jumlah_soal;
    //     // print("2 = " + skor_mat2);
    //     time_mat3 = time3 / jumlah_soal;
    //     // print("3 = " + skor_mat3);

    //     float[] times = new float[3] { time_mat1, time_mat2, time_mat3 };
    //     return times;
    // }
}
