using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    private PlayerControllerAfkarAly playerControllerAfkarAly;

    // TIME
    private float timeDuration = 100;
    private float timer;
    // Time GUI
    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    private void Start()
    {
        ResetTimer();
        // playerController.Load();
    }
    void Awake()
    {
        // ResetTimer();
        // playerController.ambilSoal();
    }

    // Update is called once per frame
    void Update()
    {
        // if (stateBook == 1)
        // {
        // print(timer);
        if (timer > 0)
        {
            // print("timerCounter");
            timer -= Time.deltaTime;

            UpdateTimerDisplay(timer);
        }
        else
        {
            // flash();
        }
        // }
    }
    private void ResetTimer()
    {
        // print("ResetTimer");
        timer = timeDuration;
    }
    private void UpdateTimerDisplay(float time)
    {
        // ~ UNTUK TIMER
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }
    public float getTimeValue()
    {
        return (timeDuration - timer);
    }
}
