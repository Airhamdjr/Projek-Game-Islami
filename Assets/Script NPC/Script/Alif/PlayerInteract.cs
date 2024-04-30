/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerInteract : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out MuklisInteractable muklisInteractable))
                {
                    muklisInteractable.TalkingInteract();
                }
                if (collider.TryGetComponent(out AhmadInteract ahmadInteract))
                {
                    ahmadInteract.WavingInteract();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out MuklisInteractable muklisInteractable))
                {
                    muklisInteractable.WavingInteract();
                }
                if (collider.TryGetComponent(out AhmadInteract ahmadInteract))
                {
                    ahmadInteract.BigJumpInteract();
                }
            }
        }
    }
}*/