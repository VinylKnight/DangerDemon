using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour {
    [SerializeField]
    private string sceneToLoad;

    private bool isPlayerInTrigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Vertical") && isPlayerInTrigger)
        {

            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
