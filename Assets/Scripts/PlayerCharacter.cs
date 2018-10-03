using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {



    [SerializeField]
    private int lives = 3;
    [SerializeField]
    private string Name = "Mario";
    [SerializeField]
    private float jumpHeight = 5, accelerationForce = 5;
    [SerializeField]
    private Rigidbody2D rigidbody2DInstance;
    [SerializeField]
    private float maxSpeed = 5;

    private bool hasKey;
    private bool isOnGround;
    private float horizontalInput;

    
    // Use this for initialization
    void Start () {

        //rigidbody2DInstance = GetComponent<Rigidbody2D>();
        
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate( 0, -.01f,  0); not physics based do not use
        //GetInput();
        //Move();
        horizontalInput = Input.GetAxis("Horizontal");
	}

    //private void GetInput()
    //{

    //    float horizontalInput = Input.GetAxis("Horizontal");


    //}

    //private void Move()
    //{
    //    rigidbody2DInstance.velocity = new Vector2(horizontalInput, -1);
        

    //}
    private void FixedUpdate()
    {
        rigidbody2DInstance.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rigidbody2DInstance.velocity;
        clampedVelocity = Mathf.Clamp(rigidbody2DInstance.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2DInstance.velocity = clampedVelocity;


    }


}
