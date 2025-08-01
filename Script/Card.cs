using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Card : MonoBehaviour
{
    private float speed;
    public string alphabet;

    // Start is called before the first frame update
    void Start()
    {
        //2.下落速度随机
        speed = Random.Range(0.8f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //1.卡片往下掉
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        //3.检测键盘输入并比较
        if (Input.GetKeyDown(alphabet))
        {
            Destroy(this.gameObject);//销毁该游戏物体
        }
        //4.当卡片沉入海，销毁该物体
        if (transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }
    }
}
