using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    private static SceneLoader _instance = null;
    public static SceneLoader Instance() { return _instance; }

    public void Init()
    {
        _instance = this;
    }

    public void SetupLoadingCallback( UnityAction<Scene, LoadSceneMode> finishLoaded)
    {
        SceneManager.sceneLoaded += finishLoaded;

    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }
}
