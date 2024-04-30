using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Trigger : MonoBehaviour
{
    Soal soal;
    public GameObject player;
    public Animator anim;
    public GameObject konversasi;
    public string nama;
    public Text teksnama;
    public Text tekskalimat;
    public Animator animtext;
    // Start is called before the first frame update
    void Awake()
    {

        Debug.Log(Soal.jwbBenar + " " + Soal.scorewaktu + " " + Soal.pengalaman);

        teksnama.text = nama;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NilaiBagus()
    {
        animtext.SetBool("Open", true);
        tekskalimat.text = "Kamu benar sebanyak " + Soal.jwbBenar + " dari total lima soal, dan masih menyisakan " + Soal.scorewaktu + " detik. Selamat nak nilai kamu sudah bagus";
        anim.SetBool("Waving", true);

    }

    public void NilaiSedang()
    {
        animtext.SetBool("Open", true);
        tekskalimat.text = "Bagaimana bisa kamu benar sebanyak " + Soal.jwbBenar + " dari total lima soal, dan masih menyisakan " + Soal.scorewaktu + " detik. tingkatkan kembali nilaimu";
        anim.SetBool("Dissapoint", true);

    }

    public void NilaiBuruk()
    {
        animtext.SetBool("Open", true);
        tekskalimat.text = "Bagaimana bisa kamu benar sebanyak " + Soal.jwbBenar + " dari total lima soal, dan masih menyisakan " + Soal.scorewaktu + " detik. mari ikut saya untuk materi dikelas langsung";
        anim.SetBool("Walking", true);

    }

    private void OnTriggerEnter(Collider other)
    {
        float nilai = Soal.jwbBenar;
        float waktu = Soal.scorewaktu;
        float pengalaman = 0;
        if (Soal.pengalaman == true)
        {
            pengalaman = 1;
        }
        else if (Soal.pengalaman == false)
        {
            pengalaman = 0;
        }


        float bobotnilai = 3;
        float bobotwaktu = 3;
        float bobotpengalaman = 2;
        float ebobot = bobotnilai + bobotwaktu + bobotpengalaman;

        float wk1 = bobotnilai / ebobot;
        float wk2 = bobotwaktu / ebobot;
        float wk3 = bobotwaktu / ebobot;
        float wtotal = wk1 + wk2 + wk3;

        float alt1 = Mathf.Pow(nilai, wk1) + Mathf.Pow(waktu, wk2) + Mathf.Pow(pengalaman, wk3);
        /*float alt2 = Mathf.Pow(2, wk1) + Mathf.Pow(2, wk2) + Mathf.Pow(2, wk3) + Mathf.Pow(2, wk4);
        float alt3 = Mathf.Pow(3, wk1) + Mathf.Pow(3, wk2) + Mathf.Pow(3, wk3) + Mathf.Pow(3, wk4);
        float totalalt = alt1 + alt2 + alt3;*/

        float v1 = alt1;/* totalalt; //7
        float v2 = alt2 / totalalt; // 8
        float v3 = alt3 / totalalt; //9 */



        if (other.tag == "Player")
        {
            Debug.Log(nilai);
            Debug.Log(waktu);
            Debug.Log(pengalaman);
            Debug.Log(v1);
            konversasi.SetActive(true);
            if (nilai == 0 && waktu == 0)
            {
                animtext.SetBool("Open", true);
                tekskalimat.text = "Apakah kamu sudah tes?";

            }
            else if (v1 < 4.87)
            {
                NilaiBuruk();
            }
            else if (v1 >= 4.87 && v1 < 6.85)
            {
                NilaiSedang();
            }
            else if (v1 >= 6.85)
            {
                NilaiBagus();
            }
            else
            {
                Debug.Log("Ada yang salah");
            }
        }
        else if (other.tag == "Player" && other.tag == "Pohon")
        {
            anim.SetBool("Walking", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Keluar");
            anim.SetBool("Dissapoint", false);
            anim.SetBool("Waving", false);
            anim.SetBool("Walking", false);
            animtext.SetBool("Open", false);
            konversasi.SetActive(false);
        }
    }
}