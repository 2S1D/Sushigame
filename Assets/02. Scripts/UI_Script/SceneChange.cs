using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public void SceneCH(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
    }
}