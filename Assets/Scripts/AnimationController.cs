using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    [SerializeField] private float _blendDuration = 0.2f;
    private Animator _animator;

    private bool _isAttacking;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();    
    }

    public void Move(float speed)
    {
        _animator.SetFloat("Walking", speed / _maxSpeed);
    }

    public void Jump()
    {
        _animator.SetTrigger("Jump");
    }

    public void Falling(bool isOnGround)
    {
        _animator.SetBool("IsOnGround", isOnGround);
    }

    public void PlayAttack()
    {
        if (_isAttacking)
        {
            return;
        }
        StartCoroutine(HandleAttack());

    }

    private IEnumerator HandleAttack()
    {
        _isAttacking = true;

        yield return StartCoroutine(BlendLayerWeight(1, 1f, _blendDuration));

        _animator.SetTrigger("Attack");

        AnimatorStateInfo stateInfo;
        do
        {
            yield return null;
            stateInfo = _animator.GetCurrentAnimatorStateInfo(1);
        }
        while (stateInfo.normalizedTime < 0.9f);

        yield return StartCoroutine(BlendLayerWeight(1, 0f, _blendDuration));

        _isAttacking = false;
    }

    private IEnumerator BlendLayerWeight(int layerIndex, float targetWeight, float duration)
    {
        float startWeight = _animator.GetLayerWeight(layerIndex);
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float lerpPercent = time / duration;
            float newWeight = Mathf.Lerp(startWeight, targetWeight, lerpPercent);
            _animator.SetLayerWeight(layerIndex, newWeight);
            yield return null;
        }

        _animator.SetLayerWeight(layerIndex, targetWeight);
    }
}
