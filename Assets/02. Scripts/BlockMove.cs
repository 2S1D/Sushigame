using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private int snapOffset = 30;

    //public Vector2Int blockCount { private set; get; }
    public BlockPuzzle puzzle;

    void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private void OnMouseUp()
    {
        /*float x = Mathf.RoundToInt(transform.position.x -blockCount.x % 2 * 0.5f) + blockCount.x % 2 * 0.5f;
        float y = Mathf.RoundToInt(transform.position.x -blockCount.x % 2 * 0.5f) + blockCount.x % 2 * 0.5f;

        transform.position = new Vector3(x, y, 0);*/
    }

    private void OnMouseDown()
    {
        if (!CheckSnapBlock())
        {
            transform.SetParent(puzzle.blockPosition.transform);
        }
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    bool CheckSnapBlock()
    {
        for (int i = 0; i < puzzle.blockPosition.transform.childCount; i++)
        {
            if (puzzle.blockPosition.transform.GetChild(i).childCount != 0)
            {
                continue;
            }
            else if (Vector2.Distance(puzzle.blockPosition.transform.GetChild(i).position, transform.position) < snapOffset)
            {
                transform.SetParent(puzzle.blockPosition.transform.GetChild(i).transform);
                transform.localPosition = Vector3.zero;
                return true;
            }
        }
        return false;
    }
}
