using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _jumpVelocity = 3f;


    private float _moveHorizontal;
    private float _moveVertical;
    private bool _isJumping;
    private float _velocity;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Gravity();
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            Destroy(other.gameObject);
        }
    }

    private void GetInput()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");
        _isJumping = Input.GetKeyDown(KeyCode.Space);
    }

    private void Move()
    {
        Vector3 move = new Vector3(_moveHorizontal, 0, _moveVertical) * _walkSpeed;
        move.y = _velocity;

        _characterController.Move(move * Time.deltaTime);
    }

    private void Gravity()
    {
        if (_characterController.isGrounded)
        {
            if (_isJumping)
            {
                _velocity = _jumpVelocity;
                Debug.Log("Jump!");
            }
            else
            {
                _velocity = -0.1f;
            }
        }
        else
        {
            _velocity -= 9.82f * Time.deltaTime;
        }
    }
}
