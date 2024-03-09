using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private Vector2 direction;
    float xInput;
    float yInput;
    Player player;
    GameManager gameManager;
    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CharacterControl(gameManager.isGameOver);
    }

    void CharacterControl(bool isGameOver)
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        //Check that the snake is not moving right or left when your input is horizontal. If the snake is moving to the right and you attempt to move it left, the snake will eat itself)
        if(xInput != 0 && direction != Vector2.right && direction != Vector2.left) 
        {
            direction = Vector2.right * xInput;
        }
        else if(yInput != 0 && direction != Vector2.up && direction != Vector2.down)
        {
            direction = Vector2.up * yInput;
        }
    }

    private void FixedUpdate() {

        CharacterMove();
    }

    void CharacterMove()
    {
        if (!gameManager.isGameOver)
        {

        //for body parts to follow the player
        for(int i = player.bodyParts.Count - 1; i > 0; i--)
        {
            player.bodyParts[i].transform.position = player.bodyParts[i - 1].transform.position;
        }

        //round direction to have a int value for position like pixels
        transform.position = new Vector3(
            transform.position.x + Mathf.Round(direction.x), 
            transform.position.y + Mathf.Round(direction.y),
            0.0f) ;
        }
    }
}
