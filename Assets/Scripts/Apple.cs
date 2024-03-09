using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public bool appleIsOnBody;

    //Avoid spawning on the snake's body
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Body")) 
        {
            gameObject.SetActive(false);
            appleIsOnBody = true;
            SpawnManager.Instance.SpawnApple();
        }
    }
}
