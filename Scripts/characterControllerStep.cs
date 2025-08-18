using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterControllerStep : MonoBehaviour
{
    public float speed = 3;
    private CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                controller.Move(Vector3.right * speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                controller.Move(Vector3.left * speed * Time.deltaTime);
            }
        }
        else
        {
            controller.Move(Vector3.down * speed * Time.deltaTime);
        }
    }
}
