
using UnityEngine;

[CreateAssetMenu(fileName = "TestResult", menuName = "Math Adventure ver 5/TestResult")]
public class HasilRank : ScriptableObject
{
    public string rank1 = "";
    public string rank2 = "";
    public string rank3 = "";
    public string rank4 = "";

    public void reset()
    {
        rank1 = "";
        rank2 = "";
        rank3 = "";
        rank4 = "";
    }
    // public string GetLoginInfo()
    // {
    //     return login_username;
    // }
    // public void reset()
    // {
    //     login_username = "";
    // }
}
