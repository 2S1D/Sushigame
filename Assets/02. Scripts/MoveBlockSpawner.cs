using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBlockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] sushiPre;
    private int value;

    private void Start()
    {
        value = sushiPre.Length;

        for(int i = 0; i < value; i++)
        {
            sushiPre[i].SetActive(true);
        }
    }
}
