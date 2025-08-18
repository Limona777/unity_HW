using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float startRunSpeed = 2.0f;
    private float runSpeed;
    private float jumpSpeed = 10.0f;
    private float gravity = 20.0f;
    private Vector3 velocity = Vector3.zero;

    private GameState gameState;
    private PlayerStateController playerStateController;
    private CharacterController rabbitCharController;
    private float minusTimer = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rabbitCharController = GetComponent<CharacterController>();
        playerStateController = GetComponent<PlayerStateController>();

        runSpeed = startRunSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        gameState = playerStateController.gameState;
        if (rabbitCharController.isGrounded)
        {
            switch (gameState)
            {
                case GameState.ready:
                    velocity = Vector3.zero;
                    break;
                case GameState.readyJump:
                    velocity = new Vector3(0, jumpSpeed, 0);
                    break;
                case GameState.runLeft:
                    velocity = runSpeed * Vector3.left;
                    break;
                case GameState.runRight:
                    velocity = runSpeed * Vector3.right;
                    break;
                case GameState.jumpRight:
                    velocity = new Vector3(runSpeed, jumpSpeed, 0);
                    break;
                case GameState.jumpLeft:
                    velocity = new Vector3(-runSpeed, jumpSpeed, 0);
                    break;
                default:
                    velocity = Vector3.zero;
                    break;
            }
        }
        else
        { 
            velocity.y -= gravity * Time.deltaTime;    
        }

        rabbitCharController.Move(velocity * Time.deltaTime);

        if (runSpeed > startRunSpeed)
        {
            runSpeed -= 0.1f;
        }

        if (runSpeed < startRunSpeed)
        {
            if (runSpeed < 0)
            {
                runSpeed = 0;
            }
            minusTimer -= Time.deltaTime;
            if (minusTimer < 0)
            {
                runSpeed += 0.5f;
                minusTimer = 3.0f;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "endPoint":
                runSpeed = 0;
                GameController.Instance.Win();
                Debug.Log("youWin!!!!!!");
                break;
            case "pit":
                runSpeed = 0;
                GameController.Instance.Lose();
                Debug.Log("Lose!!!!!!");
                break;
 
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "stone")
        {
            runSpeed -= 0.1f;
            Debug.Log("stone!!!!!!" + runSpeed);
        }
    }
}
