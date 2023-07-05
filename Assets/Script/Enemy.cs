using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _hp;
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
    void Start()
    {
        _hp = 30.0f;
        

    }

    public IEnumerator Damage(float miunsBlood)
    {
        _hp -= miunsBlood;

        Debug.Log(_hp);
        if (_hp <= 0)
        {
            _hp = 0;
            GameObject gEffect = Instantiate(destroyEffect) as GameObject;
            gEffect.transform.position = transform.position;
            yield return new WaitForSeconds(0.3f);
            AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
            Destroy(gameObject);
        }
    }
}
