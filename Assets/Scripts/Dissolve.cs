using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private float _dissolvingTime;
    [SerializeField] private float _startAmount;

    private Material _dissolveMaterial;

    private void Start()
    {
        _dissolveMaterial = _meshRenderer.material;
        _dissolveMaterial.SetFloat("_Amount", _startAmount);
    }

    public void DissolveIn()
    {
        StartCoroutine(DissolveCoroutine(true));
    }

    public void DissolveOut()
    {
        StartCoroutine(DissolveCoroutine(false));
    }

    private IEnumerator DissolveCoroutine(bool dissolveIn)
    {
        float time = 0;
        while (time < _dissolvingTime) 
        {
            if (dissolveIn) 
                _dissolveMaterial.SetFloat("_Amount", time / _dissolvingTime);
            else 
                _dissolveMaterial.SetFloat("_Amount", 1 - time / _dissolvingTime);
            time += Time.deltaTime; 
            yield return null;
        }
    }
}
