using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScriprtedMovement : MonoBehaviour
{
    [SerializeField] private float _timeToMove = 2f;
    [SerializeField] private Vector3 _endPosition;
    [SerializeField] private AnimationCurve _animationCurve;

    Vector3 _startPosition;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(MoveRoutine());
        //transform.DOMove(_endPosition, _timeToMove).SetEase(Ease.InQuint);
    }

    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += Vector3.up * _timeToMove * Time.deltaTime;
    }

    private IEnumerator MoveRoutine()
    {
        float time = 0;

        while (time < _timeToMove)
        {
            time += Time.deltaTime;
            //transform.position = Vector3.Lerp(_startPosition, _endPosition, time / _timeToMove);
            transform.position = Vector3.Lerp(_startPosition, _endPosition, _animationCurve.Evaluate(time / _timeToMove));
            yield return null;
        }
    }
}
