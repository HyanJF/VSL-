using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class UI_Setpanel : MonoBehaviour
{
    public Ability a;
    public TextMeshProUGUI description; 
    public TextMeshProUGUI nameA;
    public Image m_Image;

    private void Awake()
    {
        SetAbility(a);
    }

    public void SetAbility(Ability ability)
    {
        description.text = ability.abilityDescription;
        nameA.text = ability.abilityName;
        m_Image.sprite = ability.sprite;

    }
}
