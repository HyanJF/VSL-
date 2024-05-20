using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UI;

public class Ability : ScriptableObject
{
    public string abilityName;
    public string abilityDescription;
    //public Image image;
    public Sprite sprite;

    public virtual void UpdateCall(KeyCode keyCode, GameObject player) { }
}
