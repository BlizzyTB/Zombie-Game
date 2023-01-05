using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _jumpHeight = 2f;
    [SerializeField] float _gravityValue = -9.81f;
    [Range(0.1f, 6f)][SerializeField] float _fallSpeed = 3f;
    [SerializeField] bool _isGrounded;

    Vector3 _jumpVelocity;

    CharacterController _characterController;

    void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        _isGrounded = _characterController.isGrounded;

        MoveCharacter();
        ResetGravityIfGrounded();
        Jump();
        ApplyVelocityForces();
    }

    private void ApplyVelocityForces()
    {
        _jumpVelocity.y += _gravityValue * Time.deltaTime * _fallSpeed;
        _characterController.Move(_jumpVelocity * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _jumpVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }
    }

    void ResetGravityIfGrounded()
        {
            if (_isGrounded)
            {
                _jumpVelocity.y = -0.2f;
            }
        }

    private void MoveCharacter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(horizontal, 0, forward);


        _characterController.Move(moveDir * _moveSpeed * Time.deltaTime);
    }
}
