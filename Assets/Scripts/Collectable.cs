using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour
{
    private AudioSource collectableSound;

    private bool isCollected;

    void Start()
    {
        collectableSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCollected = true;
        
        if (collision.gameObject.CompareTag("Player") && isCollected == true)
        {
            //collectableSound.Play();
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            player.carrotsCollected ++;
            player.collectedNewCarrot = true;
            Destroy(gameObject);
            
        }

    }
    
    
}
