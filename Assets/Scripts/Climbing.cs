using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour {
    [SerializeField]
    private float ClimbingForce = 5;
    [SerializeField]
    private Rigidbody2D rigidbody2DInstance;
    [SerializeField]
    private float maxClimbSpeed = 5;
    [SerializeField]
     private Animator anim;
   
    private float verticalInput;
    private bool isOnLadder;
 
    // Update is called once per frame
    void Update ()
    {
        UpdateVerticalInput();       
	}
    void FixedUpdate()
    {
        Climb();
    }
     private void OnTriggerEnter2D(Collider2D collision)
     {
        if (collision.CompareTag("Player"))
        {
            isOnLadder = true;
        }
     }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isOnLadder = false;
            rigidbody2DInstance.gravityScale = 1f;
            anim.SetFloat("ClimbSpeed", 0f);
        }
    }
   
    private void UpdateVerticalInput()
    {
        verticalInput = Input.GetAxisRaw("Vertical");   
    }
    private void Climb()
    {
        if (isOnLadder == true)
        {
            rigidbody2DInstance.gravityScale = 0f;
            rigidbody2DInstance.velocity = Vector2.zero;
            rigidbody2DInstance.AddForce(Vector2.up * verticalInput * ClimbingForce);
            Vector2 clampedVelocity = rigidbody2DInstance.velocity;
            clampedVelocity.y = Mathf.Clamp(rigidbody2DInstance.velocity.y, -maxClimbSpeed, maxClimbSpeed);
            rigidbody2DInstance.velocity = clampedVelocity;
            anim.SetFloat("ClimbSpeed", Mathf.Abs(verticalInput));
        }
    }
}
