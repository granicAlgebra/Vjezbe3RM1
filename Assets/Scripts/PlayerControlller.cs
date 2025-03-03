using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _walkSpeed = 5f;
    [SerializeField] private float _jumpSpeed = 5f;


    private float _moveHorizontal;
    private float _moveVertical;
    private bool _isJumping;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
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
        if (_isJumping)
            move.y = _jumpSpeed * Time.deltaTime;
        else
            move.y = 0;

        _characterController.Move(move * Time.deltaTime);
    }
}
