using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public float Level;
    public float HP;
    public float ATK;
    public float VIT;
    public float AGI;
    public float EXP;
    public float SP;

    //public float In_Level;
    [HideInInspector]public float In_HP;

    [HideInInspector] public float In_EXP;
}
