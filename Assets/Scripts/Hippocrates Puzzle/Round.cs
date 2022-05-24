using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Round", menuName = "ScriptableObjects/Round", order = 0)]
[Serializable]
public class Round : ScriptableObject
{

    [SerializeField]
    public string[] correctFormula;

    [SerializeField]
    public string[] formulas;

    [SerializeField]
    public string[] instructions;
}
