using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item",menuName ="ScriptableItem",order = 1)]
public class ScriptableItem : ScriptableObject
{
    public int keyItem1;
    public int keyItem2;
    public int keyItem3;
    public int keyItem4;

    public int item1;
    public int item2;
    public int item3;
    public int item4;

    public int keyItem;
    public int item;

    private void OnEnable()
    {
        keyItem1 = 0;
        keyItem2 = 0;
        keyItem3 = 0;
        keyItem4 = 0;
    }
}
