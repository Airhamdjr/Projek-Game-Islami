using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groudcheck : MonoBehaviour
{
    PlayerLogic logicmovement;
    // Start is called before the first frame update
    private void Start()
    {
        logicmovement = this.GetComponentInParent<PlayerLogic>();
    }
    private void OnTriggerEnter(Collider other)
    {
        logicmovement.groundedchanger();
        Debug.Log("Touch The Ground");
    }
   
}
