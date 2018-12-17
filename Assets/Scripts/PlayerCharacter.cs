using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private bool isFacingRight;
    private bool isOnGround;
    private float horizontalInput;
    private Checkpoint currentCheckpoint;
    private Collider2D[] groundContactDetectionResults = new Collider2D[16];

    Animator anim;

     void Start()
     {
        anim = GetComponent<Animator>();
     }
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
        anim.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    private void HandleJumpInput()
    {
        if (Input.GetButtonDown("Jump") && isOnGround)
        {
            rigidbody2DInstance.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("isJumping");            
        }
    }


    private void Move()
    {
        rigidbody2DInstance.AddForce(Vector2.right * horizontalInput * accelerationForce);
        Vector2 clampedVelocity = rigidbody2DInstance.velocity;
        clampedVelocity.x = Mathf.Clamp(rigidbody2DInstance.velocity.x, -maxSpeed, maxSpeed);
        rigidbody2DInstance.velocity = clampedVelocity;
        if (horizontalInput < 0 && !isFacingRight)
            Flip();
        else if (horizontalInput > 0 && isFacingRight)
            Flip();
    }
    public void Respawn()
    {
        if (currentCheckpoint == null)
        {     
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);           
        }
        else
        {
         rigidbody2DInstance.velocity = Vector2.zero;
         transform.position = currentCheckpoint.transform.position;
        }
    }
    public void SetCurrentCheckpoint(Checkpoint newCurrentCheckpoint)
    {
        if(currentCheckpoint != null)
           currentCheckpoint.SetIsActivated(false);

        currentCheckpoint = newCurrentCheckpoint;
        currentCheckpoint.SetIsActivated(true);
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
