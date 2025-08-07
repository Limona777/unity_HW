using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitController : MonoBehaviour
{
    public float runSpeed = 7;
    public float jumpSpeed = 23;
    public float gravity = 2;

    private Vector3 v;
    private bool facingRight = true;

    private Animator RabbitAnim;
    private CharacterController RabbitCh;
    // Start is called before the first frame update
    void Start()
    {
        RabbitAnim = GameObject.Find("Rabbit").GetComponent<Animator>();
        RabbitCh = GameObject.Find("Rabbit").GetComponent <CharacterController>();
    }
    // 在角色的移动脚本（如RabbitController）中添加以下逻辑
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否踩在平台上
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // 将角色设为平台的子物体，角色会随平台移动
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            // 离开平台时取消父子关系
            transform.SetParent(null);
        }
    }
    private void TurnAround()
    {
        facingRight = !facingRight;
        Vector3 scale = RabbitCh.transform.localScale;
        scale.x *= -1;
        RabbitCh.transform.localScale = scale;
    }
    // Update is called once per frame
    void Update()
    {
        if (RabbitCh.isGrounded)
        {
            RabbitAnim.SetBool("isGrounded", true);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    v = new Vector3(runSpeed, jumpSpeed, 0);
                }
                else
                {
                    v = Vector3.right * runSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    v = new Vector3(-runSpeed, jumpSpeed, 0);
                }
                else
                {
                    v = Vector3.left * runSpeed;
                }
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                v = Vector3.up * jumpSpeed;
            }
            else
            {
                v = Vector3.zero;
            }
        }
        else
        {
            v.y -= gravity;
            RabbitAnim.SetBool("isGrounded", false);
        }

        RabbitAnim.SetFloat("vSpeed", v.y);
        RabbitAnim.SetFloat("hSpeed", Mathf.Abs(v.x));
        RabbitCh.Move(v * Time.deltaTime);

        if (!facingRight && v.x > 0)
        {
            TurnAround();
        }
        else if (facingRight && v.x < 0)
        {
            TurnAround();
        }
    }
}
