using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_UI1 : MonoBehaviour
{
    public Animator animator;
    public GameObject OptionsMenu;
    public void StartGame()
    {
       animator.SetBool("Close", true); 
    }

}
