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
        //2.�����ٶ����
        speed = Random.Range(0.8f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //1.��Ƭ���µ�
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        //3.���������벢�Ƚ�
        if (Input.GetKeyDown(alphabet))
        {
            Destroy(this.gameObject);//���ٸ���Ϸ����
        }
        //4.����Ƭ���뺣�����ٸ�����
        if (transform.position.y < -4)
        {
            Destroy(this.gameObject);
        }
    }
}
