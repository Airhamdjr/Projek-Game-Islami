/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptInput : MonoBehaviour
{
    public InputField nilai;
    public InputField waktu;
    public bool pengalaman;

    public ScriptableNilai scriptableNilai;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InputNilai()
    {
        int i = 0;
        while(i <= 5)
        {
            //ngatur data nilai
            if(scriptableNilai.arrayNilai[i] == 0)
            {
                scriptableNilai.arrayNilai[i] = int.Parse(nilai.text);
                nilai.text = " ";
                
            } else if(scriptableNilai.arrayNilai[i] != 0)
            {
                i++;
            }

            //ngatur data waktu
            if (scriptableNilai.arrayWaktu[i] == 0)
            {
                scriptableNilai.arrayWaktu[i] = int.Parse(waktu.text);
                waktu.text = " ";

            }
            else if (scriptableNilai.arrayWaktu[i] != 0)
            {
                i++;
            }

            //ngatur pengalaman
            if (scriptableNilai.arrayPengalaman[i] == 0)
            {
                if(pengalaman == true)
                {
                    scriptableNilai.arrayPengalaman[i] = 1;
                }
                else
                {
                    scriptableNilai.arrayPengalaman[i] = 2;
                }
            }
            else if (scriptableNilai.arrayPengalaman[i] != 0)
            {
                i++;
            }
        }
    }

    public void AllIn()
    {
        InputNilai();
    }

    public void NilaiBool(bool toggle)
    {
        pengalaman = toggle;
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
*/