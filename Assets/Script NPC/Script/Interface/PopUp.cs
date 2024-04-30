using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using System.IO.Pipes;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    // public NPCDialogue npc;
    public GameObject interactionUI;
    public GameObject experienceUI;
    public GameObject dialogueUI;
    public GameObject OutputText;
    public GameObject SceneManagementMukhlis ;
    public GameObject SceneManagementAhmad ;
    public GameObject SceneManagementFurqon ;
    public GameObject SceneManagementSumbul ;
    public GameObject selesai;
    public GameObject hasilPretest;

    public Transform player;
    public Transform npcAhmad;
    public Transform npcMukhlis;
    public Transform npcFurqon;
    public Transform npcSumbul;

    public bool npcMukhlisStat;
    public bool npcAhmadStat;
    public bool npcFurqonStat;
    public bool npcSumbulStat;

    public GameObject Camera;
    public CameraControllerPlayer camScript;

    public SceneInfo sceneInfo;
   
    
    void Start()
    {
        camScript = Camera.GetComponent<CameraControllerPlayer>();
        SceneManagementMukhlis.SetActive(false);
        SceneManagementAhmad.SetActive(false);
        SceneManagementFurqon.SetActive(false);
        SceneManagementSumbul.SetActive(false);
        selesai.SetActive(false);
        //player = FindAnyObjectByType<PlayerLogic>().transform;
        //npcAhmad = FindAnyObjectByType<AhmadGaming>().transform;
        //npcMukhlis = FindAnyObjectByType<mukhlisgaming>().transform;
        //npcFurqon = FindAnyObjectByType<furqongaming>().transform;
        //npcSumbul = FindAnyObjectByType<sumbulgaming>().transform;
    }

    private void Update()
    {
        showInteract();
        showDialogue();
        showOutputText();
    }

    void showInteract()
    {
        // AHMAD
        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) < 5f && !SceneManagementAhmad.activeSelf && !selesai.activeSelf)
        {
            interactionUI.SetActive(true);
        }
        // MUKHLIS
        if (Vector3.Distance(npcMukhlis.transform.position, player.transform.position) < 5f && !SceneManagementMukhlis.activeSelf! && !selesai.activeSelf)
        {
            interactionUI.SetActive(true);
        }
        // FURQON
        if (Vector3.Distance(npcFurqon.transform.position, player.transform.position) < 5f && !SceneManagementFurqon.activeSelf && !selesai.activeSelf)
        {
            interactionUI.SetActive(true);
        }
        // SUMBUL
        if (Vector3.Distance(npcSumbul.transform.position, player.transform.position) < 5f && !SceneManagementSumbul.activeSelf && !selesai.activeSelf)
        {
            interactionUI.SetActive(true);
        }

        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) > 5f && !SceneManagementAhmad.activeSelf && !selesai.activeSelf &&
            Vector3.Distance(npcMukhlis.transform.position, player.transform.position) > 5f && !SceneManagementMukhlis.activeSelf && !selesai.activeSelf &&
            Vector3.Distance(npcFurqon.transform.position, player.transform.position) > 5f && !SceneManagementFurqon.activeSelf && !selesai.activeSelf &&
            Vector3.Distance(npcSumbul.transform.position, player.transform.position) > 5f && !SceneManagementFurqon.activeSelf)
        {
            interactionUI.SetActive(false);
        }
    }

    void showDialogue()
    {
        // Ahmad
        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) < 5f && Input.GetKeyDown(KeyCode.F) && !SceneManagementAhmad.activeSelf )
        {
            npcAhmadStat = true;
            npcMukhlisStat = false;
            npcFurqonStat = false;
            npcSumbulStat = false;

            if (dialogueUI.activeInHierarchy && !SceneManagementAhmad.activeSelf)
            {
                dialogueUI.SetActive(false);
                interactionUI.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                dialogueUI.SetActive(true);
                interactionUI.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }
        // Mukhlis
        if (Vector3.Distance(npcMukhlis.transform.position, player.transform.position) < 5f && Input.GetKeyDown(KeyCode.F) && !SceneManagementMukhlis.activeSelf)
        {
            npcAhmadStat = false;
            npcMukhlisStat = true;
            npcFurqonStat = false;
            npcSumbulStat = false;

            if (dialogueUI.activeInHierarchy && !SceneManagementMukhlis.activeSelf)
            {
                dialogueUI.SetActive(false);
                interactionUI.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                dialogueUI.SetActive(true);

                if (interactionUI.activeInHierarchy)
                {
                    interactionUI.SetActive(false);
                }

                Cursor.lockState = CursorLockMode.None;
                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }
        // Furqon
        if (Vector3.Distance(npcFurqon.transform.position, player.transform.position) < 5f && Input.GetKeyDown(KeyCode.F) && !SceneManagementFurqon.activeSelf )
        {
            npcAhmadStat = false;
            npcMukhlisStat = false;
            npcFurqonStat = true;
            npcSumbulStat = false;

            if (dialogueUI.activeInHierarchy && !SceneManagementFurqon.activeSelf )
            {
                dialogueUI.SetActive(false);
                interactionUI.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                dialogueUI.SetActive(true);
                interactionUI.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }
        // Sumbul
        if (Vector3.Distance(npcSumbul.transform.position, player.transform.position) < 5f && Input.GetKeyDown(KeyCode.F) && !SceneManagementSumbul.activeSelf )
        {
            npcAhmadStat = false;
            npcMukhlisStat = false;
            npcFurqonStat = false;
            npcSumbulStat = true;

            if (dialogueUI.activeInHierarchy && !SceneManagementSumbul.activeSelf)
            {
                dialogueUI.SetActive(false);
                interactionUI.SetActive(true);

                Cursor.lockState = CursorLockMode.Locked;
                if (camScript != null)
                {
                    camScript.enabled = true;
                }
            }
            else
            {
                dialogueUI.SetActive(true);
                interactionUI.SetActive(false);

                Cursor.lockState = CursorLockMode.None;
                if (camScript != null)
                {
                    camScript.enabled = false;
                }
            }
        }

        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) > 5f && !SceneManagementAhmad.activeSelf &&
            Vector3.Distance(npcMukhlis.transform.position, player.transform.position) > 5f && !SceneManagementMukhlis.activeSelf &&
            Vector3.Distance(npcFurqon.transform.position, player.transform.position) > 5f && !SceneManagementFurqon.activeSelf &&
            Vector3.Distance(npcSumbul.transform.position, player.transform.position) > 5f && !SceneManagementSumbul.activeSelf )
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
        // Ahmad
        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) < 5f)
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
        // Mukhlis
        if (Vector3.Distance(npcMukhlis.transform.position, player.transform.position) < 5f)
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
        // Furqon
        if (Vector3.Distance(npcFurqon.transform.position, player.transform.position) < 5f)
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
        // Sumbul
        if (Vector3.Distance(npcSumbul.transform.position, player.transform.position) < 5f)
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

        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) > 5f && 
            Vector3.Distance(npcMukhlis.transform.position, player.transform.position) > 5f && 
            Vector3.Distance(npcFurqon.transform.position, player.transform.position) > 5f && 
            Vector3.Distance(npcSumbul.transform.position, player.transform.position) > 5f)
        {
            experienceUI.SetActive(false);
        }
    }

    void showOutputText()
    {
        // Ahmad
        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) < 5f && !SceneManagementAhmad.activeSelf && !selesai.activeSelf)
        {
            OutputText.SetActive(true);
            npcAhmadStat = true;

            npcMukhlisStat = false;
            npcFurqonStat = false;
            npcSumbulStat = false;
            sceneInfo.kelas_npc = "Al-Qur'an Qiraah";

        }
        // Mukhlis
        if (Vector3.Distance(npcMukhlis.transform.position, player.transform.position) < 5f && !SceneManagementMukhlis.activeSelf && !selesai.activeSelf)
        {
            OutputText.SetActive(true);
            npcMukhlisStat = true;

            npcAhmadStat = false;
            npcFurqonStat = false;
            npcSumbulStat = false;
            sceneInfo.kelas_npc = "Al-Qur'an Asasi";
        }
        // Furqon
        if (Vector3.Distance(npcFurqon.transform.position, player.transform.position) < 5f && !SceneManagementFurqon.activeSelf && !selesai.activeSelf)
        {
            OutputText.SetActive(true);
            npcFurqonStat = true;

            npcAhmadStat = false;
            npcMukhlisStat = false;
            npcSumbulStat = false;
            sceneInfo.kelas_npc = "Afkar Al-Aly";
        }
        // Sumbul
        if (Vector3.Distance(npcSumbul.transform.position, player.transform.position) < 5f && !SceneManagementSumbul.activeSelf && !selesai.activeSelf)
        {
            OutputText.SetActive(true);
            npcSumbulStat = true;

            npcAhmadStat = false;
            npcMukhlisStat = false;
            npcFurqonStat = false;
            sceneInfo.kelas_npc = "Afkar Asasi";
        }

        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) > 5f && !SceneManagementAhmad.activeSelf &&
            Vector3.Distance(npcMukhlis.transform.position, player.transform.position) > 5f && !SceneManagementMukhlis.activeSelf &&
            Vector3.Distance(npcFurqon.transform.position, player.transform.position) > 5f && !SceneManagementFurqon.activeSelf &&
            Vector3.Distance(npcSumbul.transform.position, player.transform.position) > 5f && !SceneManagementSumbul.activeSelf)
        { 
            OutputText.SetActive(false);
        }

    }

    public void buttonExpPressed()
    {
        if (npcAhmadStat)
        {
            showExperience();
        }
        if (npcMukhlisStat)
        {
            showExperience();
        }
        if (npcFurqonStat)
        {
            showExperience();
        }
        if (npcSumbulStat)
        {
            showExperience();
        }
    }

    public void buttonQnAPressed()
    {
        // Menonaktifkan canvas yang sedang aktif
        interactionUI.SetActive(false);
        experienceUI.SetActive(false);
        dialogueUI.SetActive(false);
        OutputText.SetActive(false);
        hasilPretest.SetActive(false);

        // Memuat canvas atau elemen UI baru
        // Contoh: Mengaktifkan canvas baru
        if (Vector3.Distance(npcAhmad.transform.position, player.transform.position) < 5f)
        {
            SceneManagementAhmad.SetActive(true);
        }
        if (Vector3.Distance(npcMukhlis.transform.position, player.transform.position) < 5f)
        {
            SceneManagementMukhlis.SetActive(true);
            
        }
        if (Vector3.Distance(npcFurqon.transform.position, player.transform.position) < 5f)
        {
            SceneManagementFurqon.SetActive(true);

        }
        if (Vector3.Distance(npcSumbul.transform.position, player.transform.position) < 5f)
        {
            SceneManagementSumbul.SetActive(true);
        }
    }


 /*   public void buttonMiniBrosPressed()
    {
        if (npcAhmadStat)
        {
            if (!sceneInfo.HasTestTQQiraah)
            {
                SceneManager.LoadScene("Mini Bros Al-Qur'an Qiraah");
            }
            else
            {
                showTestResult();
            }
        }
        if (npcMukhlisStat)
        {
            if (!sceneInfo.HasTestTQQiraah)
            {
                SceneManager.LoadScene("Mini Bros Al-Qur'an Asasi");
            }
            else
            {
                showTestResult();
            }
        }
        if (npcFurqonStat)
        {
            if (!sceneInfo.HasTestTQQiraah)
            {
                SceneManager.LoadScene("Mini Bros Afkar Al-Aly");
            }
            else
            {
                showTestResult();
            }
        }
        if (npcSumbulStat)
        {
            if (!sceneInfo.HasTestTQQiraah)
            {
                SceneManager.LoadScene("Mini Bros Afkar Asasi");
            }
            else
            {
                showTestResult();
            }
        }
    }
    */
    public void buttonLabirinPressed()
    {
      /*  if (npcAhmadStat)
        {
            sceneInfo.kelas_npc = "QQiraah";
        }*/
        SceneManager.LoadScene("Labirin");

    }

    public void showTestResult()
    {
        hasilPretest.SetActive(true);
    }

}
