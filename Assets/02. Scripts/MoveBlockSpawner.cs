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
        sushiPre[1].SetActive(true);
        sushiPre[2].SetActive(true);
        sushiPre[3].SetActive(true);
        sushiPre[4].SetActive(true);
        sushiPre[5].SetActive(true);
        sushiPre[6].SetActive(true);
        sushiPre[7].SetActive(true);
        sushiPre[8].SetActive(true);
        sushiPre[9].SetActive(true);
    }
}
