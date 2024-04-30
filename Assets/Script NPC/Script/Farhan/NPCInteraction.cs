using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCInteraction : MonoBehaviour
{
    // public NPCDialogue npc;
    public GameObject interactionUI;
    public GameObject experienceUI;
    public GameObject dialogueUI;
    public GameObject OutputText;

    public GameObject player;
    public GameObject npc;

    public GameObject Camera;
    public CameraControllerPlayer camScript;

    public SceneInfo sceneInfo;

    void Start()
    {
        camScript = Camera.GetComponent<CameraControllerPlayer>();
    }

    private void Update()
    {
        showInteract();
        showDialogue();
        showOutputText();
    }

    void showInteract()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 5f)
        {
            interactionUI.SetActive(true);
        }
        else if (Vector3.Distance(npc.transform.position, player.transform.position) > 5f)
        {
            interactionUI.SetActive(false);
        }

    }

    void showDialogue()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 5f && Input.GetKeyDown(KeyCode.F))
        {
            if (dialogueUI.activeInHierarchy)
            {
                dialogueUI.SetActive(false);

                Cursor.lockState = CursorLockMode.Locked;
                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                dialogueUI.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }
        else if (Vector3.Distance(npc.transform.position, player.transform.position) > 5f)
        {
            dialogueUI.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;
            if (camScript != null)
            {
                camScript.enabled = true;
            }
        }
    }

    void showExperience()
    {
        if (Vector3.Distance(npc.transform.position, player.transform.position) < 5f)
        {
            if (experienceUI.activeInHierarchy)
            {
                experienceUI.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;

                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                experienceUI.SetActive(true);
                dialogueUI.SetActive(false);
                Cursor.lockState = CursorLockMode.None;

                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }
        else if (Vector3.Distance(npc.transform.position, player.transform.position) > 5f)
        {
            experienceUI.SetActive(false);
        }
    }

    void showOutputText()
    {
        if(Vector3.Distance(npc.transform.position, player.transform.position) < 5f)
        {
            OutputText.SetActive(true);
        }
        else
        {
            OutputText.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ahmad" )
        {
            interactionUI.SetActive(true);
        }
        else
        {
            interactionUI.SetActive(false);
        }
    }


    public void buttonAPressed()
    {
        showExperience();
    }
    public void buttonBPressed()
    {
        SceneManager.LoadScene("Pre-Test");
    }
    public void buttonCPressed()
    {
        /*showExperience();*/
        SceneManager.LoadScene("Mini Bros Al-Qur'an Asasi");
    }
    public void buttonDPressed()
    {
        showExperience();
    }

    


}
