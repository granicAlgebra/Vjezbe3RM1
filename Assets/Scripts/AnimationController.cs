using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5;
    private Animator _animator;

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
}
