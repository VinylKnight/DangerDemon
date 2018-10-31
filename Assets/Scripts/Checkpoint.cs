using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {
    [SerializeField]
    private float inactiveRotationSpeed = 100, activeRotationSpeed = 200;

    private bool isActivated;
    private void Update()
    {
        UpdateRotation();



    }
    private void UpdateRotation()
    {
        transform.Rotate(Vector3.up * inactiveRotationSpeed * Time.deltaTime);


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.SetCurrentCheckpoint(this);
            isActivated = true;

        }
       
    }


}
