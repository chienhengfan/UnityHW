using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public Player player;

    private void Awake()
    {
        Player player = gameObject.AddComponent<Player>();
        player.Init();
    }
    

    public void GetHurt(float damage)
    {
        player = gameObject.GetComponent<Player>();
        player.currentHP -= damage;
        if (player.currentHP < 0)
        {
            player.currentHP = 0;
            UIManager.Instance().ClickExit();
        }
        UIManager.Instance().UpdateHpBar(player);
    }
}
