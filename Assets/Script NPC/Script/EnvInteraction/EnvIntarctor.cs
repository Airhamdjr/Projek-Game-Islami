using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvIntarctor : MonoBehaviour
{
    private Animator anim;

    bool isSitting;
    void Start()
    {
        anim = GetComponent<Animator>();

        isSitting = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !isSitting)
        {
            anim.SetBool("SitDown", true);

        }

        if(Input.GetKeyDown(KeyCode.R) && isSitting)
        {
            anim.SetBool("SitUp", true);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Sit")
        {
            isSitting = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Sit")
        {
            isSitting = false;
        }
    }
}
