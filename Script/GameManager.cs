using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] card; //卡片
    private float timer = 0; //计时器
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //1.计时器：1.5秒后生成卡片
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            //2.生成卡片
            CreateCard(Random.Range(0, card.Length));
            //3.重置计时器
            timer = 0;
        }
        //生成卡片函数
        void CreateCard(int index)
        {
            //生成随机坐标
            float x = Random.Range(-8.65f, 8.65f);
            float y = Random.Range(0, 8);
            //在随机位置生成游戏物体Card
            Instantiate(card[index], new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}
