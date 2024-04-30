using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public GameObject panelmainmenu;
    public GameObject paneloption, panelloading,PanelStart, panelNarasi, panelTutorial,panelAbout;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void OpenMainMenu()
    {
        PanelStart.SetActive(false);
        panelmainmenu.SetActive(true);
    }
    public void Openloadingscreen()
    {
        panelTutorial.SetActive(false);
        panelloading.SetActive(true);
    }
    public void OpenOption()
    {
        panelmainmenu.SetActive(false);
        paneloption.SetActive(true);
    }
    public void CloseOption()
    {
        paneloption.SetActive(false);
        panelmainmenu.SetActive(true);
    }
    public void OpenTutorial()
    {
        panelNarasi.SetActive(false);
        panelTutorial.SetActive(true);
    }
    public void OpenNarasi()
    {
        panelmainmenu.SetActive(false);
        panelNarasi.SetActive(true);
    }
    public void OpenAbout()
    {
        panelmainmenu.SetActive(false);
        panelAbout.SetActive(true);
    }
    public void CLoseAbout()
    {
        
        panelAbout.SetActive(false);
        panelmainmenu.SetActive(true);
    }
    public void OpenGamePlay()
    {
        
        SceneManager.LoadScene("GamePlay");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
