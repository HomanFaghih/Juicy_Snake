using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    GameManager gameManager;
    public bool appleIsOnBody;
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Body"))
        {
            gameObject.SetActive(false);
            appleIsOnBody = true;
            SpawnManager.Instance.SpawnApple();
        }
    }
}
