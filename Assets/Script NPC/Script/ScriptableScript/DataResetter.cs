using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataResetter : MonoBehaviour
{
    public SceneInfo sceneInfo;
    private void OnApplicationQuit()
    {
        sceneInfo.ResetData();
    }
}

