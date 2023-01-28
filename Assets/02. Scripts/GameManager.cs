using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject success;
    [SerializeField] private Button nextButton;

    BlockMove blockMove;

    private void Clear()
    {
        /*if(blockMove.isClear == true)
        {
            nextButton.gameObject.SetActive(true);
        }*/
    }
}
