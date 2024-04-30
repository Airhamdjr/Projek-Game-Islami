using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System;

public class SoalController : MonoBehaviour
{
    // get materi ID to load
    public MateriID materiID;

    // Dynamic option
    public DynamicOption dynamic_option;

    // Soal media properties
    public TextMeshPro soalText;
    public TextMeshPro opsi1Text;
    public TextMeshPro opsi2Text;
    public TextMeshPro opsi3Text;
    public TextMeshPro opsi4Text;
    public GameObject soalImage;
    public string soal_image;
    private SpriteRenderer soal_sprite;
    public Sprite[] soal_path;

    public TextAsset assetSoal1; // menampung file soal
    public TextAsset assetSoal2; // menampung file soal
    public TextAsset assetSoal3; // menampung file soal
    public TextAsset assetSoal4; // menampung file soal
    public string[] soal1;
    public string[] soal2;
    public string[] soal3;
    public string[] soal4;
    private string[,] DBpreTest1;
    private string[,] DBpreTest2;
    private string[,] DBpreTest3;
    private string[,] DBpreTest4;

    int indexData;
    public int materi_id;
    public int maxSoal1;
    public int maxSoal2;
    public int maxSoal3;
    public int maxSoal4;
    public char kunciJ;

    // Dynamic ambil soal
    public static List<int> i_store_1 = new List<int>();
    public static List<int> i_store_2 = new List<int>();
    public static List<int> i_store_3 = new List<int>();
    public static List<int> i_store_4 = new List<int>();

    // test
    public bool stat = false;
    public string l;


    void Awake()
    {
        materi_id = materiID.GetMateri_id;
        Load();
    }
    void Start()
    {
        soal_sprite = soalImage.GetComponent<SpriteRenderer>();
        dynamic_option = GetComponent<DynamicOption>();
        switch (materi_id)
        {
            case 1:
                ambilSoal1();
                break;
            case 2:
                ambilSoal2();
                break;
            case 3:
                ambilSoal3();
                break;
            case 4:
                ambilSoal4();
                break;
        }
    }
    void Update()
    {
        if (stat)
        {

            stat = false;
            switch (materi_id)
            {
                case 1:
                    ambilSoal1();
                    break;
                case 2:
                    ambilSoal2();
                    break;
                case 3:
                    ambilSoal3();
                    break;
                case 4:
                    ambilSoal4();
                    break;
            }
        }
    }

    void ambilSoal1()
    {
        // generate random index of soal
        int i = UnityEngine.Random.Range(0, maxSoal1);

        // reset i_store
        if (i_store_1.Count >= maxSoal1)
        {
            // Debug.Log("i_store is full");
            i_store_1.Clear();
        }

        // to avoid show the same question
        int i_fix = cekDuplicate1(i);
        // Debug.Log("i fix = " + i_fix);

        // for question with arabic text
         string l = DBpreTest1[i_fix, 6];

        // condition for the question with arabic text
         if ((l.Trim()).Equals("null", StringComparison.OrdinalIgnoreCase))
         {
             soalImage.SetActive(false);
             soalText.text = DBpreTest1[i_fix, 0];
             opsi1Text.text = DBpreTest1[i_fix, 1]; // Mengambil index ke 1 pada DB sebagai jawaban A
             opsi2Text.text = DBpreTest1[i_fix, 2]; // Mengambil index ke 2 pada DB sebagai jawaban B
             opsi3Text.text = DBpreTest1[i_fix, 3]; // Mengambil index ke 3 pada DB sebagai jawaban C
             opsi4Text.text = DBpreTest1[i_fix, 4]; // Mengambil index ke 4 pada DB sebagai jawaban D
                                                       // Debug.Log("Soal biasa");
         }
                                                else
                                                {
                                                    soalImage.SetActive(true);
                                                    soal_sprite.sprite = soal_path[int.Parse(l)];
                                                    soalText.text = "";
                                                    opsi1Text.text = "";
                                                    opsi2Text.text = "";
                                                    opsi3Text.text = "";
                                                    opsi4Text.text = "";
                                                    // Debug.Log("Soal mengandung bahasa arab");
                                               }
        kunciJ = DBpreTest1[i_fix, 5][0];
        dynamic_option.dynamicOpt(kunciJ);
    }
    void ambilSoal2()
    {
        int i = UnityEngine.Random.Range(0, maxSoal2);

        if (i_store_2.Count >= maxSoal2)
        {
            i_store_2.Clear();
        }

        int i_fix = cekDuplicate2(i);
        // Debug.Log(i_fix);

        l = DBpreTest2[i_fix, 6];

        if ((l.Trim()).Equals("null", StringComparison.OrdinalIgnoreCase))
        {
            soalImage.SetActive(false);

            soalText.text = DBpreTest2[i_fix, 0];
            opsi1Text.text = DBpreTest2[i_fix, 1]; // Mengambil index ke 1 pada DB sebagai jawaban A
            opsi2Text.text = DBpreTest2[i_fix, 2]; // Mengambil index ke 2 pada DB sebagai jawaban B
            opsi3Text.text = DBpreTest2[i_fix, 3]; // Mengambil index ke 3 pada DB sebagai jawaban C
            opsi4Text.text = DBpreTest2[i_fix, 4]; // Mengambil index ke 4 pada DB sebagai jawaban D
                                               // Debug.Log("Soal biasa");
        }
        else
        {
          soalImage.SetActive(true);
          soal_sprite.sprite = soal_path[int.Parse(l)];
          soalText.text = "";
          opsi1Text.text = "";
          opsi2Text.text = "";
          opsi3Text.text = "";
          opsi4Text.text = "";
          // Debug.Log("Soal mengandung bahasa arab");

         }
        kunciJ = DBpreTest2[i_fix, 5][0];
        dynamic_option.dynamicOpt(kunciJ);
    }
    void ambilSoal3()
    {
        int i = UnityEngine.Random.Range(0, maxSoal3);

        if (i_store_3.Count >= maxSoal3)
        {
            i_store_3.Clear();
        }

        int i_fix = cekDuplicate3(i);

        string l = DBpreTest3[i_fix, 6];

        if ((l.Trim()).Equals("null", StringComparison.OrdinalIgnoreCase))
        {
            soalImage.SetActive(false);
        soalText.text = DBpreTest3[i_fix, 0];
        opsi1Text.text = DBpreTest3[i_fix, 1]; // Mengambil index ke 1 pada DB sebagai jawaban A
        opsi2Text.text = DBpreTest3[i_fix, 2]; // Mengambil index ke 2 pada DB sebagai jawaban B
        opsi3Text.text = DBpreTest3[i_fix, 3]; // Mengambil index ke 3 pada DB sebagai jawaban C
        opsi4Text.text = DBpreTest3[i_fix, 4]; // Mengambil index ke 4 pada DB sebagai jawaban D
                                               // Debug.Log("Soal biasa");
        }
        else
        {
            soalImage.SetActive(true);
            soal_sprite.sprite = soal_path[int.Parse(l)];
            soalText.text = "";
            opsi1Text.text = "";
            opsi2Text.text = "";
            opsi3Text.text = "";
            opsi4Text.text = "";
            // Debug.Log("Soal mengandung bahasa arab");
        }
        kunciJ = DBpreTest3[i_fix, 5][0];
        dynamic_option.dynamicOpt(kunciJ);
    }
    void ambilSoal4()
    {
        int i = UnityEngine.Random.Range(0, maxSoal4);

        if (i_store_4.Count >= maxSoal4)
        {
            i_store_4.Clear();
        }

        int i_fix = cekDuplicate4(i);

         string l = DBpreTest4[i_fix, 6];

         if ((l.Trim()).Equals("null", StringComparison.OrdinalIgnoreCase))
         {
             soalText.text = DBpreTest4[i_fix, 0];
             opsi1Text.text = DBpreTest4[i_fix, 1]; // Mengambil index ke 1 pada DB sebagai jawaban A
             opsi2Text.text = DBpreTest4[i_fix, 2]; // Mengambil index ke 2 pada DB sebagai jawaban B
             opsi3Text.text = DBpreTest4[i_fix, 3]; // Mengambil index ke 3 pada DB sebagai jawaban C
             opsi4Text.text = DBpreTest4[i_fix, 4]; // Mengambil index ke 4 pada DB sebagai jawaban D
        }
        else
        {
            soalImage.SetActive(true);
            soal_sprite.sprite = soal_path[int.Parse(l)];
            soalText.text = "";
            opsi1Text.text = "";
            opsi2Text.text = "";
            opsi3Text.text = "";
            opsi4Text.text = "";
        }

        kunciJ = DBpreTest4[i_fix, 5][0];
        dynamic_option.dynamicOpt(kunciJ);
    }
    public void Load()
    {
        switch (materi_id)
        {
            case 1:
                soal1 = assetSoal1.ToString().Split('%');
                DBpreTest1 = new string[soal1.Length, 7];
                maxSoal1 = soal1.Length;
                break;
            case 2:
                soal2 = assetSoal2.ToString().Split('%');
                DBpreTest2 = new string[soal2.Length, 7];
                maxSoal2 = soal2.Length;
                break;
            case 3:
                soal3 = assetSoal3.ToString().Split('%');
                DBpreTest3 = new string[soal3.Length, 7];
                maxSoal3 = soal3.Length;
                Debug.Log(maxSoal3);
                break;
            case 4:
                soal4 = assetSoal4.ToString().Split('%');
                DBpreTest4 = new string[soal4.Length, 7];
                maxSoal4 = soal4.Length;
                break;
        }
        OlahSoal();
    }
    private void OlahSoal()
    {
        // penyimpanan soal ke DB dengan pembatas pada tiap index menggunakan simbol '+'
        switch (materi_id)
        {
            case 1:
                for (int i = 0; i < soal1.Length; i++)
                {
                    string[] tempSoal = soal1[i].Split('+');
                    for (int j = 0; j < tempSoal.Length; j++)
                    {
                        DBpreTest1[i, j] = tempSoal[j];
                        continue;
                    }
                    continue;
                }

                break;
            case 2:
                for (int i = 0; i < soal2.Length; i++)
                {
                    string[] tempSoal = soal2[i].Split('+');
                    for (int j = 0; j < tempSoal.Length; j++)
                    {
                        DBpreTest2[i, j] = tempSoal[j];
                        continue;
                    }
                    continue;
                }

                break;
            case 3:
                for (int i = 0; i < soal3.Length; i++)
                {
                    string[] tempSoal = soal3[i].Split('+');
                    for (int j = 0; j < tempSoal.Length; j++)
                    {
                        DBpreTest3[i, j] = tempSoal[j];
                        continue;
                    }
                    continue;
                }
                break;
            case 4:
                for (int i = 0; i < soal4.Length; i++)
                {
                    string[] tempSoal = soal4[i].Split('+');
                    for (int j = 0; j < tempSoal.Length; j++)
                    {
                        DBpreTest4[i, j] = tempSoal[j];
                        continue;
                    }
                    continue;
                }
                break;
        }
    }
    // Testing success
    public int cekDuplicate1(int i)
    {
        if (i_store_1.Count <= 1 || i_store_1.Count == maxSoal1)
        {
            i_store_1.Add(i);
            // Debug.Log("i count: " + i_store_1.Count + " i terakhir: " + i);
            return i;
        }
        else
        {
            if (!i_store_1.Contains(i))
            {
                i_store_1.Add(i);
                return i;
            }
            else
            {
                int new_i = UnityEngine.Random.Range(0, maxSoal1);
                return cekDuplicate1(new_i);
            }
        }
    }
    // End of Testing success
    public int cekDuplicate2(int i)
    {
        if (i_store_2.Count <= 1 || i_store_2.Count == maxSoal2)
        {
            i_store_2.Add(i);
            Debug.Log("i count: " + i_store_2.Count + " i terakhir: " + i);
            return i;
        }
        else
        {
            if (!i_store_2.Contains(i))
            {
                i_store_2.Add(i);
                return i;
            }
            else
            {
                int new_i = UnityEngine.Random.Range(0, maxSoal2);
                return cekDuplicate2(new_i);
            }
        }
    }
    public int cekDuplicate3(int i)
    {
        if (i_store_3.Count <= 1 || i_store_3.Count == maxSoal3)
        {
            i_store_3.Add(i);
            Debug.Log("i count: " + i_store_1.Count + " i terakhir: " + i);
            return i;
        }
        else
        {
            if (!i_store_3.Contains(i))
            {
                i_store_3.Add(i);
                return i;
            }
            else
            {
                int new_i = UnityEngine.Random.Range(0, maxSoal3);
                return cekDuplicate3(new_i);
            }
        }
    }
    public int cekDuplicate4(int i)
    {
        if (i_store_4.Count < 1 || i_store_4.Count == maxSoal4)
        {
            i_store_4.Add(i);
            Debug.Log("i count: " + i_store_1.Count + " i terakhir: " + i);
            return i;
        }
        else
        {
            if (!i_store_4.Contains(i))
            {
                i_store_4.Add(i);
                return i;
            }
            else
            {
                int new_i = UnityEngine.Random.Range(0, maxSoal4);
                return cekDuplicate4(new_i);
            }
        }
    }
    public char GetKunciJ()
    {
        return kunciJ;
    }
    /// <summary>
    /// Callback sent to all game objects before the application is quit.
    /// </summary>
    void OnApplicationQuit()
    {
        i_store_1 = null;
        i_store_2 = null;
        i_store_3 = null;
        i_store_4 = null;
    }
    // private void CheckJawaban(char huruf)
    // {

    //     if (huruf.Equals(kunciJ))
    //     {
    //         print("benar");
    //     }
    //     else
    //     {
    //         print("salah");
    //     }
    // }
}

