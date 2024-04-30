using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class loading : MonoBehaviour
{
    public Transform masukanLoadingbar; 
    [SerializeField] private float nilaiSekarang;
    [SerializeField] private float nilaiKecepatan;

    void Update()
    {
        if (nilaiSekarang < 100)
        {
            nilaiSekarang += nilaiKecepatan * Time.deltaTime;
            Debug.Log((int)nilaiSekarang);
        }
        else
        {
            Application.LoadLevel("maze");
        
            
        }
        masukanLoadingbar.GetComponent<Image>().fillAmount = nilaiSekarang / 100;
    }
}

