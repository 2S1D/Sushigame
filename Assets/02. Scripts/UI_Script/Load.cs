using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
    [SerializeField] private string loadSceneName = "LoadingScene";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void LoadSceneN(string nextSceneAndCurSceneName)
    {
        string NextsceneName = nextSceneAndCurSceneName.Split('#')[0];
        string curSceneName = nextSceneAndCurSceneName.Split('#')[1];

        StartCoroutine(LoadSceneAsync(NextsceneName, curSceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName, string curSceneName)
    {
        AsyncOperation loadOper = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
        
        while (!loadOper.isDone)
        {
            Debug.Log(loadOper.progress);
            yield return null;
        }
        FindObjectOfType<LoadManager>().LoadScene(sceneName, curSceneName);
    }
}
