using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCLookAtRig : MonoBehaviour
{
    // Start is called before the first frame update
    private Rig rig;
    private float targetWeight;
    public GameObject target;

    private void Awake()
    {
        rig = GetComponent<Rig>();
    }

    private void Update()
    {
        rig.weight = Mathf.Lerp(rig.weight, targetWeight, Time.deltaTime * 10f);

        if (Vector3.Distance(transform.position, target.transform.position) < 3f)
        {
            LookAt();
        }
        else if (Vector3.Distance(transform.position, target.transform.position) > 3f)
        {
            StopLookAt();
        }
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
