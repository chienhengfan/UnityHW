using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    public bool IsDead = false;
    public int scoreOfEnemy = 5;
    public float currentHP = 30f;
    public float MaxHP = 60f;
    public Object destroyEffect;
    public Object touchEffect;
    public AudioClip destroyAudio;
    public AudioClip touchAudio;
    public GameObject objectUI;

    public void InitEnemy()
    {
        currentHP = MaxHP;
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject gEffect = Instantiate(touchEffect) as GameObject;
        gEffect.transform.position = transform.position;
        AudioSource.PlayClipAtPoint(touchAudio, transform.position);
        GameObject player = other.gameObject;
        //Debug.Log(player);
        player.SendMessage("GetHurt", 20f);
        EnemySprawler.Instance().RemoveEnemy(gameObject);
    }

    public IEnumerator Damage(float miunsBlood)
    {
        GameObject obj = Instantiate(objectUI, transform.position, Quaternion.identity);
        objectUI.GetComponent<Canvas>().worldCamera = Camera.main;
        obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = miunsBlood.ToString();
        Destroy(obj, 1f);

        currentHP -= miunsBlood;

        if (currentHP <= 0)
        {
            currentHP = 0;
            IsDead = true;
            GameObject gEffect = Instantiate(destroyEffect) as GameObject;
            gEffect.transform.position = transform.position;
            yield return new WaitForSeconds(0.3f);
            AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
            EnemySprawler.Instance().RemoveEnemy(gameObject);
        }
    }

    public int GetScore()
    {
        int score = IsDead ? scoreOfEnemy : 0;
        return score;
    }
}
