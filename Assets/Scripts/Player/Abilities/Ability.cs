using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class Ability : ScriptableObject
{
    public virtual void UpdateCall(KeyCode keyCode, GameObject player) { }
}
