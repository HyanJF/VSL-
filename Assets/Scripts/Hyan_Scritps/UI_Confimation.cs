using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Confimation : MonoBehaviour
{
    public GameObject confirmationPanel;

    public GameObject skillsPanel;

    public GameObject masterPanel;

    private Ability ability; 


    private void Update()
    {
        if(Input.GetKeyDown(PlayerAbilities.Instance.ability1.keyCode))
        {
            PlayerAbilities.Instance.ability1.ability = ability;
            masterPanel.SetActive(false);
            gameObject.SetActive(false);
            confirmationPanel.SetActive(false);
            skillsPanel.SetActive(true);
        }
        if (Input.GetKeyDown(PlayerAbilities.Instance.ability2.keyCode))
        {
            PlayerAbilities.Instance.ability2.ability = ability;
            masterPanel.SetActive(false);
            gameObject.SetActive(false);
            confirmationPanel.SetActive(false);
            skillsPanel.SetActive(true);
        }
        if (Input.GetKeyDown(PlayerAbilities.Instance.ability3.keyCode))
        {
            PlayerAbilities.Instance.ability3.ability = ability;
            masterPanel.SetActive(false);
            gameObject.SetActive(false);
            confirmationPanel.SetActive(false);
            skillsPanel.SetActive(true);
        }
        if (Input.GetKeyDown(PlayerAbilities.Instance.ability4.keyCode))
        {
            PlayerAbilities.Instance.ability4.ability = ability;
            masterPanel.SetActive(false);
            gameObject.SetActive(false);
            confirmationPanel.SetActive(false);
            skillsPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            skillsPanel.SetActive(true);
            confirmationPanel.SetActive(false);
            
        }

    }

    public void SetAbility(Ability _ability)
    {
        ability = _ability;


    }

}
