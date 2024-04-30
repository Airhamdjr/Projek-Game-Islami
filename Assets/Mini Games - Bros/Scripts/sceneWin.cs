using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class sceneWin : MonoBehaviour
{
    public static sceneWin SceneWin;
    [SerializeField] private TextMeshProUGUI coinText;
    public int coins;

    private void Awake()
    {
        print(scene1.Scene1.coins);
        coinText.text = scene1.Scene1.coins.ToString();

        // cek
        // PlayerController.playerControl.coins = scene1.Scene1.coins;
    }
}
