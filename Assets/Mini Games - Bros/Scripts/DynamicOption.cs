using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicOption : MonoBehaviour
{
    [SerializeField] private GameObject opsiA;
    [SerializeField] private GameObject opsiB;
    [SerializeField] private GameObject opsiC;
    [SerializeField] private GameObject opsiD;

    [SerializeField] private char key_ans;

    public void dynamicOpt(char key_ans)
    {
        switch (key_ans)
        {
            case 'A':
                opsiA.layer = 9;
                opsiB.layer = 10;
                opsiC.layer = 10;
                opsiD.layer = 10;
                break;
            case 'B':
                opsiA.layer = 10;
                opsiB.layer = 9;
                opsiC.layer = 10;
                opsiD.layer = 10;
                break;
            case 'C':
                opsiA.layer = 10;
                opsiB.layer = 10;
                opsiC.layer = 9;
                opsiD.layer = 10;
                break;
            case 'D':
                opsiA.layer = 10;
                opsiB.layer = 10;
                opsiC.layer = 10;
                opsiD.layer = 9;
                break;
            default:
                opsiA.layer = 9;
                opsiB.layer = 10;
                opsiC.layer = 10;
                opsiD.layer = 10;
                break;


        }
    }
}
