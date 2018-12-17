﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hazard : MonoBehaviour {
    [SerializeField]
    private Animator Anim;
    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerCharacter player = collision.GetComponent<PlayerCharacter>();
            Anim.SetTrigger("isDead");
            player.Respawn();            
        }
    }
}
