
using UnityEngine;

[CreateAssetMenu(fileName = "Pretest Data", menuName = "Math Adventure ver 5/Pretest Data")]
public class PretestData : ScriptableObject
{
    public float[] scores = new float[4];
    public float[] times = new float[4];
    public int[] experience= new int[4];
    public int indexAnswer1 = 0;
    public int indexAnswer2 = 0;
    public int indexAnswer3 = 0;
    public int indexAnswer4 = 0;

    
    public bool[] answer1 = new bool[3];
    public bool[] answer2 = new bool[3];
    public bool[] answer3 = new bool[3];
    public bool[] answer4 = new bool[3];
    public int[] rightAnswer = new int[4];
    public int[] wrongAnswer = new int[4];
    public int getRightAns(bool[] answers)
    {
        int total = 0;
        for (int i = 0; i < answers.Length; i++)
        {
            if (answers[i] == true)
            {
                total += 1;
            }
        }
        return total;
    }
    public int getTotalRightAns()
    {
        int totalRight = 0;

        totalRight = getRightAns(answer1);
        totalRight += getRightAns(answer2);
        totalRight += getRightAns(answer3);
        totalRight += getRightAns(answer4);

        return totalRight;
    }
    public void reset()
    {
        scores = new float[4];
        times = new float[4];
        rightAnswer = new int[4];
        wrongAnswer = new int[4];

        for (int i = 0; i < answer1.Length; i++)
        {
            answer1[i] = false;
            answer2[i] = false;
            answer3[i] = false;
            answer4[i] = false;
        }

        indexAnswer1 = 0;
        indexAnswer2 = 0;
        indexAnswer3 = 0;
        indexAnswer4 = 0;
    }
    public void resetExp()
    {
        experience = new int[4];
    }
}
