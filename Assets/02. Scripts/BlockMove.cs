using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private int snapOffset = 30;
    [SerializeField] private GameObject blockPosition;

    //public Vector2Int blockCount { private set; get; }
    public BlockPuzzle puzzle;

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
    }

    Vector3 GetMousePos()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    bool CheckSnapBlock()
    {
        /*if(transform.SetParent(blockPosition.transform))
        {

        }*/
        return false;
    }
}
