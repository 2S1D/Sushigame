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

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation loadOper = SceneManager.LoadSceneAsync(loadSceneName, LoadSceneMode.Additive);
        
        while (!loadOper.isDone)
        {
            Debug.Log(loadOper.progress);
            yield return null;
        }
        FindObjectOfType<LoadManager>().LoadScene(sceneName);
    }
}
