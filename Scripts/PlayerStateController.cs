using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    public GameState gameState;
        private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.Instance.GameStart())
        {
            if (Input.GetAxis("Horizontal") > 0)
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 180, 0);
                if (Input.GetButtonDown("Jump"))
                {
                    gameState = GameState.jumpRight;
                }
                else
                {
                    gameState = GameState.runRight;
                }
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
                if (Input.GetButtonDown("Jump"))
                {
                    gameState = GameState.jumpLeft;
                }
                else
                {
                    gameState = GameState.runLeft;
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump"))
                {
                    gameState = GameState.readyJump;
                }
                else
                {
                    gameState = GameState.ready;
                }
            }
        }

        switch (gameState)
        {
            case GameState.runRight:
            case GameState.runLeft:
                animator.SetBool("ReadyToRun", true);
                animator.SetBool("runToJump", false);
                break;
            case GameState.jumpLeft:
            case GameState.readyJump:
            case GameState.jumpRight:
                animator.SetBool("ReadyToJump", true);
                animator.SetBool("runToJump", true);
                break;

            default:
                animator.SetBool("ReadyToRun", false);
                animator.SetBool("ReadyToJump", false);
                break;
        }
    }
}
