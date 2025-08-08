using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    private Animator anim;
    private CharacterController ch;

    private Vector3 velocity = Vector3.zero;
    public float gravity = 20;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        ch = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        velocity = new Vector3(h, 0, v);
        anim.SetFloat("Speed", h * h + v * v);
        anim.SetFloat("Direction", h);

        if (!ch.isGrounded)
        { 
            velocity.y *= - gravity;
        }

        ch.Move(velocity * Time.deltaTime);
    }
}
