using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPuzzle : MonoBehaviour
{
    public GameObject blockPosition;
    public GameObject block;

    public bool IsClear()
    {
        for (int i = 0; i < blockPosition.transform.childCount; i++)
        {
            if (blockPosition.transform.GetChild(i).childCount == 0)
            {
                return false;
            }
        }
        return true;
    }
}
