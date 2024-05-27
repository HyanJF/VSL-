using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image image;
    public void UpdateFill(float Amount)
    {
        image.fillAmount = Amount;
    }
}
