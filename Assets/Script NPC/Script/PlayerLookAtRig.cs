using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerLookAtRig : MonoBehaviour
{
    // Start is called before the first frame update
    private Rig rig;
    private float targetWeight;
    public GameObject targetAhmad;
    public GameObject targetMukhlis;
    public GameObject targetFurqon;
    public GameObject targetSumbul;

    private void Awake()
    {
        rig = GetComponent<Rig>();
    }

    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);

        // Ahmad
        //if(Vector3.Distance(transform.position, targetAhmad.transform.position) < 10f)
        //{
            //LookAt();
        //}
       // else
        //{
           // StopLookAt();
        //}
        // Mukhlis
        if (Vector3.Distance(transform.position, targetMukhlis.transform.position) < 10f)
        {
            LookAt();
        }
        else
        {
            StopLookAt();
        }
        // Furqon
        //if (Vector3.Distance(transform.position, targetFurqon.transform.position) < 10f)
        //{
          //  LookAt();
        //}
        //else
        //{
         //   StopLookAt();
        //}
        // Sumbul
       //if (Vector3.Distance(transform.position, targetSumbul.transform.position) < 10f)
       // {
          //  LookAt();
        //}
        //else
        //{
            //StopLookAt();
        //}
    }

    public void LookAt()
    {
        targetWeight = 1f;
    }

    public void StopLookAt()
    {
        targetWeight = 0f;
    }
}
