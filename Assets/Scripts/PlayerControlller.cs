using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerControlller : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private Transform _character;
    [SerializeField] private float _walkSpeed = 1.5f;
    [SerializeField] private float _runSpeed = 4f;
    [SerializeField] private float _sprintSpeed = 6f;
    [SerializeField] private float _mouseSensitivity = 10;
    [SerializeField] private float _jumpVelocity = 3f;
    [SerializeField] private float _characterRotationSmooth = 10f;
    [SerializeField] private LayerMask _layerMaskJump;

    private float _moveHorizontal;
    private float _moveVertical;
    private bool _isJumping;
    private bool _isWalking;
    private bool _isSprinting;
    private float _velocity;
    private float _mouseHorizontal;
    private bool _groundCheck;

    private RaycastHit[] _hitResults = new RaycastHit[5];

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animationController = GetComponent<AnimationController>();
        _groundCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Gravity();
        RotateCharachter();
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
        _mouseHorizontal = Input.GetAxis("Mouse X");
        _isJumping = Input.GetKeyDown(KeyCode.Space);
        _isWalking = Input.GetKey(KeyCode.LeftAlt);
        _isSprinting = Input.GetKey(KeyCode.LeftShift);
    }

    private void Move()
    {
        float speed = _runSpeed;

        if (_isWalking)
        {
            speed = _walkSpeed;
        }
        else if (_isSprinting)
        {
            speed = _sprintSpeed;
        }
               
        Vector3 move = (transform.forward * _moveVertical + transform.right * _moveHorizontal) * speed;

        _animationController.Move(move.magnitude);

        move.y = _velocity;
        _characterController.Move(move * Time.deltaTime);
    }

    private void RotateCharachter()
    {
        transform.Rotate(0, _mouseHorizontal * Time.deltaTime * _mouseSensitivity, 0);
        Vector3 dir = _characterController.velocity.normalized;
        dir.y = 0;
        if (_characterController.velocity.sqrMagnitude > 0.01f)
        {
            _character.rotation = Quaternion.Slerp(_character.rotation, Quaternion.LookRotation(dir, Vector3.up), Time.deltaTime * _characterRotationSmooth);
        }
    }

    private void Gravity()
    {
        if (!_groundCheck)
        {
            return;
        }

        bool isOnGround = Physics.SphereCastNonAlloc(transform.position, 0.2f, -Vector3.up, _hitResults, 0.85f, _layerMaskJump) > 0;

        if (isOnGround)
        {
            if (_isJumping)
            {
                _velocity = _jumpVelocity;
                _animationController.Jump();
                Debug.Log("Jump!");
                StartCoroutine(IgnoreGroundCheck());
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

        _animationController.Falling(isOnGround);
    }

    private IEnumerator IgnoreGroundCheck()
    {
        _groundCheck = false;
        yield return new WaitForSeconds(0.3f);
        _groundCheck = true;

    }
}
