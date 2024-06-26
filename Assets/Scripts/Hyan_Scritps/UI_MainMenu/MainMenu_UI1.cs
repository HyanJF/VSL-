using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_UI1 : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    public GameObject creditsMenu;

    public GameObject extraMenu;

    public GameObject blackPanel;

    

    public void Options()
    {
        StartCoroutine(Black(mainMenu, optionsMenu));
    }

    public void ReturnMenuOptions()
    {
        StartCoroutine(Black(optionsMenu, mainMenu));
    }

    public void Credits()
    {
        StartCoroutine(Black(mainMenu, creditsMenu));
    }

    public void ReturnMenuCredits()
    {
        StartCoroutine(Black(creditsMenu, mainMenu));
    }

    public void Extra()
    {
        StartCoroutine(Black(mainMenu, extraMenu));
    }

    public void ReturnMenuExtra()
    {
        StartCoroutine(Black(extraMenu, mainMenu));
    }

    IEnumerator Black(GameObject Ob1, GameObject Ob2)
    {
        blackPanel.SetActive(true);
        yield return new WaitForSeconds(1);
        blackPanel.SetActive(false);
        Ob1.SetActive(false);
        Ob2.SetActive(true);
    }

    public void ExitGame() 
    {
        Debug.Log("Game is exiting");
        Application.Quit();
    }

    public void LoadScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
