using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private float snapOffset = 30;
    [SerializeField] private GameObject blockPosition;
    [SerializeField] private GameObject success;
    [SerializeField] private Transform sushiPre;

    public bool isClear;

    public BlockPuzzle puzzle;

    private void Start()
    {
        //isClear = false;
    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos();
    }

    private void OnMouseDown()
    {

        if (Vector3.Distance(blockPosition.transform.position, transform.position) < snapOffset)
        {
            transform.SetParent(blockPosition.transform);
            transform.localPosition = Vector3.zero;
        }

        if (!CheckSnapBlock())
        {
            transform.SetParent(puzzle.block.transform);
        }

        if (puzzle.IsClear())
        {
            success.gameObject.SetActive(true);
            Debug.Log("Clear");
            Debug.Log(1);
            isClear = true;
            Debug.Log(isClear);
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
