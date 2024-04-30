
using UnityEngine;

[CreateAssetMenu(fileName = "MateriID", menuName = "Math Adventure ver 5/MateriID")]
public class MateriID : ScriptableObject
{
    public int GetMateri_id = 0;

    public void reset()
    {
        GetMateri_id = 0;
    }
}
