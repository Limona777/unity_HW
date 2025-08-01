using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] card; //��Ƭ
    private float timer = 0; //��ʱ��
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.��ʱ����1.5������ɿ�Ƭ
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            //2.���ɿ�Ƭ
            CreateCard(Random.Range(0, card.Length));
            //3.���ü�ʱ��
            timer = 0;
        }
        //���ɿ�Ƭ����
        void CreateCard(int index)
        {
            //�����������
            float x = Random.Range(-8.65f, 8.65f);
            float y = Random.Range(0, 8);
            //�����λ��������Ϸ����Card
            Instantiate(card[index], new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
