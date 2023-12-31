using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public Image playerHpBar;
    private static UIManager _instance = null;
    public static UIManager Instance() { return _instance; }
    public string sceneStart = "StartScene";
    public string sceneFPS = "FPS01";
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void FinishLoadScene(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Finish load :" + scene.name);
    }
    void Start()
    {
        ButtonStateControl buttonStateControl = ButtonStateControl.Instance();
        SceneLoader sceneLoader = SceneLoader.Instance();
        if (sceneLoader == null)
        {
            sceneLoader = new SceneLoader();
            sceneLoader.Init();
        }
        sceneLoader.SetupLoadingCallback(FinishLoadScene);

    }

    void Update()
    {

    }

    public void UpdateHpBar(Player player)
    {
        float ratio = player.currentHP / player.maxHP;
        playerHpBar.fillAmount *= ratio;

    }

    public void ClickStart()
    {
        SceneLoader.Instance().ChangeScene(sceneFPS);
    }
    public void ClickExit()
    {
        SceneLoader.Instance().ChangeScene(sceneStart);
    }

}
