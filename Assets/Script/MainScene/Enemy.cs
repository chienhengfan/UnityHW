using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp = 30f;
    public Object destroyEffect;
    public Object touchEffect;
    public AudioClip destroyAudio;
    public AudioClip touchAudio;



    private void OnTriggerEnter(Collider other)
    {
        GameObject gEffect = Instantiate(touchEffect) as GameObject;
        gEffect.transform.position = transform.position;
        AudioSource.PlayClipAtPoint(touchAudio, transform.position);
        Destroy(gameObject);
    }

    public IEnumerator Damage(float miunsBlood)
    {
        hp -= miunsBlood;

        Debug.Log(hp);
        if (hp <= 0)
        {
            hp = 0;
            GameObject gEffect = Instantiate(destroyEffect) as GameObject;
            gEffect.transform.position = transform.position;
            yield return new WaitForSeconds(0.3f);
            AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
            EnemySprawler.Instance().RemoveEnemy(gameObject);
        }
    }
}
