using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController _controller;
    private Vector3 _input, _moveDirection;
    public float jumpHeight = 10;
    public float gravity = 9.81f;
    public float airControl = 10f;

    [SerializeField] private float moveSpeed = 10;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _input = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        _input *= moveSpeed;

        //_controller.Move(_input * Time.deltaTime);

        if (_controller.isGrounded)
        {
            _moveDirection = _input;
            // We can jump
            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = Mathf.Sqrt(2 * jumpHeight * gravity);
            } else
            {
                _moveDirection.y = 0.0f;
            }
        }
        else
        {
            // We are midair
            _input.y = _moveDirection.y;
            _moveDirection = Vector3.Lerp(_moveDirection, _input, airControl * Time.deltaTime);
        }

        _moveDirection.y -= gravity * Time.deltaTime;

        Vector3 final = new Vector3(_input.x, _input.y + _moveDirection.y, _input.z);
        _controller.Move(final * Time.deltaTime);

    }
    
}
