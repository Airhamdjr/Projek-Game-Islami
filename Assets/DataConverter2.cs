using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConverter2 : MonoBehaviour
{
    private int score_after;
    private int time_after;
    public int ScoreCalculate(bool answer)
    {
        if (answer = true)
        {
            score_after = 4;
        }
        else
        {
            score_after = 1;
        }
        return score_after;
    }
    public int TimeCalculate(int time_before)
    {
        if (time_before > 1 && time_before < 20)
        {
            time_after = 1;
        }
        else if (time_before > 21 && time_before < 40)
        {
            time_after = 2;
        }
        else if (time_before > 41 && time_before< 60)
        {
            time_after = 3;
        }
        else if (time_before > 61 && time_before < 80)
        {
            time_after = 4;
        }
        else if (time_before > 81)
        {
            time_after = 5;
        }
        return time_after;
    }
}
