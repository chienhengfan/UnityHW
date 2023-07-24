using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player:MonoBehaviour
{
    public float maxHP = 100f;
    public float currentHP = 100f;
    

    public void Init()
    {
        currentHP = maxHP;
    }

}
