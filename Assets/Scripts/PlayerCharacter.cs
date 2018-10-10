using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {



   
    [SerializeField]
    private float accelerationForce = 5;
    [SerializeField]
    private Rigidbody2D rigidbody2DInstance;
    [SerializeField]
    private float maxSpeed = 5;
    [SerializeField]
    private float jumpForce = 5;
    [SerializeField]
    private ContactFilter2D groundContactFilter;

    private bool isOnGround;

    private float horizontalInput;

	// Update is called once per frame
	void Update ()
    {
        //transform.Translate( 0, -.01f,  0); not physics based do not use

        UpdateHorizontalInput();
        HandleJumpInput();

    }

    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump"))
        {


            rigidbody2DInstance.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void Move()
    {
        rigidbody2DInstance.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rigidbody2DInstance.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidbody2DInstance.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2DInstance.velocity = clampedVelocity;
    }
}
