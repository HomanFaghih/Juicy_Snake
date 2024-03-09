using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    GameManager gameManager;
    [SerializeField] Transform bodyPrefab;
    public List<Transform> bodyParts = new List<Transform>();

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Start() {
        bodyParts.Add(transform); //add head transform to list
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Apple"))
        {
            GrowUp();
            other.gameObject.SetActive(false);
            SpawnManager.Instance.SpawnParticle(gameObject.transform.position);
            SpawnManager.Instance.SpawnApple();

        }
        if(other.CompareTag("Wall") || other.CompareTag("Body"))
        {
            gameManager.GameOver();
        }
    }

    void GrowUp()
    {
        gameManager.score++;
        Transform newBodyPart = Instantiate(bodyPrefab,transform.position, Quaternion.identity);
        bodyParts.Add(newBodyPart);
    }
}
