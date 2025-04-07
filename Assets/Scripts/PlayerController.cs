using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private float _moveInput;

    [SerializeField]
    private float _acceleration;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float _jumpPower;



   void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _moveInput = Input.GetAxisRaw("PlayerVertical");
        if (Input.GetKeyDown(KeyCode.W))
            Jump();

        if (Input.GetKeyDown(KeyCode.S))
            Squat();
        Vector3 force = new Vector3(1.5f, 0);
        _rigidbody.AddForce(force);
    }


    void FixedUpdate()
    {
        Vector3 fixedVelocity = _rigidbody.velocity;
        fixedVelocity.x = Mathf.Clamp(fixedVelocity.x, -_maxSpeed, _maxSpeed);
        _rigidbody.velocity = fixedVelocity;


    }

    void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);

    }

    void Squat()
    {
        
    }


}
