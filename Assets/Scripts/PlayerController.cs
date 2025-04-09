using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
[RequireComponent(typeof(CollisionController))]

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

    private CollisionController collisionSystem;

    private bool isSquatin = false;
    


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
        if (Input.GetKeyUp(KeyCode.S))
            UnSquat();


        Vector3 force = new Vector3(1.5f, 0);
        _rigidbody.AddForce(force);
    }


    void FixedUpdate()
    {
        Vector3 fixedVelocity = _rigidbody.velocity;
        fixedVelocity.x = Mathf.Clamp(fixedVelocity.x, -_maxSpeed, _maxSpeed);
        _rigidbody.velocity = fixedVelocity;

        if(collisionSystem)
        {
            Console.WriteLine("Collided");
        }
    }

    void Jump()
    {
        if(!isSquatin)
        _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.Impulse);

    }

    void Squat()
    {
        transform.localScale = new Vector3(1, .5f, 1);
        isSquatin = true;
    }

    void UnSquat()
    {
        transform.localScale = new Vector3(1, 1, 1);
        isSquatin = false;
    }

}
