using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class scene1 : MonoBehaviour
{
    public static scene1 Scene1;
    public TextMeshProUGUI coinText;
    public int coins;
    private void Awake()
    {
        if (Scene1 == null)
        {
            Scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void setCoins()
    {
        print("setCoin");
        coins = int.Parse(coinText.text);
        print(coins);
        SceneManager.LoadScene("win");
    }
}
