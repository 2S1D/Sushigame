using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] sushiPre;

    private void Start()
    {
        Debug.Log(11);
        sushiPre[0].SetActive(true);
    }
}
