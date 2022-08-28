using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class LoadManager : MonoBehaviour
{
    [SerializeField] float fadeInTime = 1f;
    [SerializeField] float fadeOutTime = 1f;

    [SerializeField] private Image image = null;

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Loading(sceneName));
    }

    IEnumerator Loading(string sceneName)
    {
        //이미지 a값 0이라고 가정 

        Time.timeScale = 0f;

        float timer = 0f;
        while(timer <= fadeInTime)
        {
            timer += Time.unscaledDeltaTime;

            image.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, timer / fadeInTime));

            yield return null;
        }

        //비동기식 : 다른 프로그램들이 동작하게 한다.
        AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(0); //Scene지우기
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive); //Scene불러오기

        while (!unloadOperation.isDone && !loadOperation.isDone)
        {
            Debug.Log(unloadOperation.progress);
            yield return null;
        }

        timer = 0f;
        while (timer <= fadeOutTime)
        {
            timer += Time.unscaledDeltaTime;

            image.color = new Color(0, 0, 0, Mathf.Lerp(1, 0, timer / fadeOutTime));

            yield return null;
        }

        yield return null;

        SceneManager.UnloadSceneAsync("LoadingScene");

        Time.timeScale = 1f;
    }
}
