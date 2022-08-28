using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotMoveTile : MonoBehaviour
{
    [SerializeField] private GameObject tilePre;
    [SerializeField] private int orderInLayer;
    [SerializeField] private Vector2Int tileCount = new Vector2Int(2, 2);
    [SerializeField] private Vector2 tileHalf = new Vector2(0.5f, 1.35f);

    private void Awake()
    {
        for(int i = 0; i < tileCount.y; ++i)
        {
            for(int j = 0; j < tileCount.x; ++j)
            {
                float px = -tileCount.x * 0.5f + tileHalf.x + j;
                float py = tileCount.y * 0.5f - tileHalf.y + i;
                Vector3 position = new Vector3(px, py, 0);
                GameObject clone = Instantiate(tilePre, position, Quaternion.identity, transform);
                clone.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;
            }
        }
    }
}