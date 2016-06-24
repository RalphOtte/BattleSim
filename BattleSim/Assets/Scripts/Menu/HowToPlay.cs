using UnityEngine;
using System.Collections;

public class HowToPlay : MonoBehaviour
{
    public GameObject screens;
    public GameObject howToPlayMain;
    public GameObject generalMenu;
    public GameObject unitsMenu;
    public GameObject buildingsMenu;
    public GameObject battleSystemMenu;
    public GameObject howToWinMenu;

    private bool screensActive;
    private bool howToPlayMainActive;
    private bool generalMenuActive;
    private bool unitsMenuActive;
    private bool buildingsMenuActive;
    private bool battleSystemMenuActive;
    private bool howToWinMenuActive;

    void Start()
    {
        howToPlayMainActive = true;
        howToPlayMain.SetActive(true);
        generalMenuActive = false;
        unitsMenuActive = false;
        buildingsMenuActive = false;
        battleSystemMenuActive = false;
        howToPlayMainActive = false;
        SwitchHTPMain();
    }

    public void SwitchHTPMain()
    {
        if (howToPlayMainActive)
        {
            Debug.Log("HTP MAIN OFF");
            howToPlayMain.SetActive(false);
            howToPlayMainActive = false;
        }else { Debug.Log("HTP MAIN ON"); howToPlayMain.SetActive(true); howToPlayMainActive = true; }
    }

    public void SwitchGeneralMenu()
    {
        if (generalMenuActive)
        {
            Debug.Log("GENERAL OFF");
            generalMenu.SetActive(false);
            generalMenuActive = false;
        }else{ Debug.Log("GENERAL ON"); generalMenu.SetActive(true); generalMenuActive = true; }
    }

    public void SwitchUnitsMenu()
    {
        if (unitsMenuActive)
        {
            Debug.Log("UNITS OFF");
            unitsMenu.SetActive(false);
            unitsMenuActive = false;
        }else { Debug.Log("UNITS ON"); unitsMenu.SetActive(true); unitsMenuActive = true; }
    }

    public void SwitchBuildingsMenu()
    {
        if (buildingsMenuActive)
        {
            Debug.Log("BUILDINGS OFF");
            buildingsMenu.SetActive(false);
            buildingsMenuActive = false;
        }else { Debug.Log("BUILDINGS ON"); buildingsMenu.SetActive(true); buildingsMenuActive = true; }
    }

    public void SwitchBattleSystemMenu()
    {
        if (battleSystemMenuActive)
        {
            Debug.Log("BATTLESYSTEM OFF");
            battleSystemMenu.SetActive(false);
            battleSystemMenuActive = false;
        }else { Debug.Log("BATTLESYSTEM ON"); battleSystemMenu.SetActive(true); battleSystemMenuActive = true; }
    }

    public void SwitchHowToWinMenu()
    {
        if (howToWinMenuActive)
        {
            Debug.Log("HOWTOWIN OFF");
            howToWinMenu.SetActive(false);
            howToWinMenuActive = false;
        }else { Debug.Log("HOWTOWIN ON"); howToWinMenu.SetActive(true); howToWinMenuActive = true; }
    }
}
