using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour
{
    ParticleSystem[] pss;
    void Start()
    {
        pss = GetComponentsInChildren<ParticleSystem>();
    }

    void Update()
    {
        for(int i = 0; i < pss.Length; i++)
        {
            if (pss[i].isPlaying)
            {
                return;
            }
        }
        Destroy(gameObject);
    }
}
