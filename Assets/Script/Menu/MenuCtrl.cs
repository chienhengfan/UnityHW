using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour
{
    private static MenuCtrl _instance = null;
    private static MenuCtrl Instance() { return _instance; }
    public string sceneStart = "StartScene";
    public string sceneFPS = "FPS01";

    void Awake()
    {
        if(_instance == null)
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
        Debug.Log("Finish load :" + scene.name);
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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(SceneManager.GetActiveScene().name == sceneStart)
            {
                SceneLoader.Instance().ChangeScene(sceneFPS);
            }
            else
            {
                SceneLoader.Instance().ChangeScene(sceneStart);
            }
        }
    }

}
