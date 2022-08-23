using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlockSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] blockSpawnPoint;
    [SerializeField] private GameObject[] blockPre;

    private void Awake()
    {
        StartCoroutine("OnSpawnBlock");
    }

    private IEnumerator OnSpawnBlock()
    {
        for(int i = 0; i < blockSpawnPoint.Length; ++i)
        {
            yield return new WaitForSeconds(0.1f);
            int index = Random.Range(0, blockPre.Length);
            Instantiate(blockPre[index], blockSpawnPoint[i].position, Quaternion.identity, blockSpawnPoint[i]);
        }
    }
}
