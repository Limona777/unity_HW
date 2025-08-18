using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompetitorController : MonoBehaviour
{
    public float speed = 0.5f;
    private CharacterController characterController;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0 && GameController.Instance.GameStart())
        {
            anim.SetBool("ReadyToRun", true);
            float v = speed * Time.deltaTime;
            characterController.Move(v * Vector3.right);
        }
        else
        {
            anim.SetBool("ReadyToRun", false);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "endPoint":
                GameController.Instance.Lose();
                Debug.Log("youLose!!!!!!");
                break;
        }
    }
}
