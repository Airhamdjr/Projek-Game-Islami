
using UnityEngine;

[CreateAssetMenu(fileName = "LoginUser", menuName = "Math Adventure ver 5/Login User")]
public class LoginUser : ScriptableObject
{
    public string login_username;

    // public string GetLoginInfo()
    // {
    //     return login_username;
    // }
    public void reset()
    {
        login_username = "";
    }
}
