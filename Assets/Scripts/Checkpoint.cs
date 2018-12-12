using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    [SerializeField]
    private float inactiveRotationSpeed = 100, activeRotationSpeed = 400;

    [SerializeField]
    private float inactiveScale = 1, activeScale = 1.5f;
    [SerializeField]
    private Color inactiveColor, activeColor;

    private SpriteRenderer spriteRenderer;
    private bool isActivated;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateColor();
    }
    private void Update()
    {
        UpdateRotation();
        


    }
    private void UpdateColor()
    {

        Color color = inactiveColor;
        if (isActivated == true)
            color = activeColor;

        spriteRenderer.color = color;

    }
    private void UpdateScale()
    {
        float scale = inactiveScale;
        if (isActivated == true)
            scale = activeScale;

        transform.localScale = Vector3.one * scale;



    }
    private void UpdateRotation()
    {
        float rotationSpeed = inactiveRotationSpeed;
        if (isActivated == true)
            rotationSpeed = activeRotationSpeed;

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);


    }
    public void SetIsActivated(bool value)
    {


        isActivated = value;
        UpdateScale();
        UpdateColor();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
           

        }
       
    }


}
