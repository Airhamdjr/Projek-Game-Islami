
using UnityEngine;

[CreateAssetMenu(fileName = "CompleteTest", menuName = "Math Adventure ver 5/Complete Test")]
public class CompleteTest : ScriptableObject
{
    public int[] GetBookDone = new int[12];
    public int indexBook = 0;
    public bool complete;
    public bool CheckComplete()
    {
        complete = true;
        foreach (int item in GetBookDone)
        {
            if (item == 0)
            {
                complete = false;
                break;
            }
        }
        return complete;
    }
    public void reset()
    {
        GetBookDone = new int[12];
        indexBook = 0;
    }
}
