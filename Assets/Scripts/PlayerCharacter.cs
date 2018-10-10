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
    [SerializeField]
    private Collider2D groundDetectTrigger;
    [SerializeField]
    private PhysicsMaterial2D playerMovingPhysicsMaterial, playerStoppingPhysicsMaterial;
    [SerializeField]
    private Collider2D playerGroundCollider;

    private bool isOnGround;

    private float horizontalInput;
    private Collider2D[] groundContactDetectionResults = new Collider2D[16];

	// Update is called once per frame
	void Update ()
    {
        //transform.Translate( 0, -.01f,  0); not physics based do not use

        UpdateHorizontalInput();
        UpdateIsOnGround();
        HandleJumpInput();
        UpdatePhysicsMaterial();

    }
    private void FixedUpdate()
    {
        Move();

    }
    private void UpdatePhysicsMaterial()
    {

        if (Mathf.Abs(horizontalInput) > 0)
        {

            playerGroundCollider.sharedMaterial = playerMovingPhysicsMaterial;
        }
        else
        {

            playerGroundCollider.sharedMaterial = playerStoppingPhysicsMaterial;


        }

    }
    private void UpdateIsOnGround()
    {

      isOnGround = groundDetectTrigger.OverlapCollider(groundContactFilter, groundContactDetectionResults) > 0;

    }

    private void UpdateHorizontalInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {


            rigidbody2DInstance.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }


    private void Move()
    {
        rigidbody2DInstance.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rigidbody2DInstance.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidbody2DInstance.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2DInstance.velocity = clampedVelocity;
    }
}
