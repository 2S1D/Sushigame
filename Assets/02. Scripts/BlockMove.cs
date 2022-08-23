using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMove : MonoBehaviour
{
    [SerializeField] private AnimationCurve curveMoment;
    [SerializeField] private AnimationCurve curveScale;

    private float appearTime = 0.5f;
    private float returnTime = 0.1f;

    [field:SerializeField]
    public Vector2Int blockCount { private set; get; }

    public void Setup(Vector3 parentPosition)
    {
        StartCoroutine(OnMoveto(parentPosition, appearTime));
    }

    private void OnMouseDown()
    {
        StopCoroutine("OnScalTo");
        StartCoroutine("OnScalTo", Vector3.one);
    }

    private void OnMouseDrag()
    {
        Vector3 gap = new Vector3(0, blockCount.y * 0.5f + 1, 10);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + gap;
    }

    private void OnMouseUp()
    {
        StopCoroutine("OnScalTo");
        StartCoroutine("OnScalTo", Vector3.one * 0.5f);
        StartCoroutine(OnMoveTo(transform.parent.position, returnTime));
    }

    // private IEnumerator OnMoveTo(Vector3 end, float time)

    private IEnumerator OnScalTo(Vector3 end)
    {
        Vector3 start = transform.localScale;
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / returnTime;

            transform.localScale = Vector3.Lerp(start, end, curveScale.Evaluate(percent));

            yield return null;
        }
    }
}
