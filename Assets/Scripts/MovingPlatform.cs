// MovingPlatform.cs
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    private Vector3 startPos;
    private bool movingRight = true;

    void Start()
    {
        startPos = transform.position;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        // 水平移动逻辑
        float targetX = movingRight ? startPos.x + moveDistance : startPos.x - moveDistance;
        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, targetX, moveSpeed * Time.deltaTime),
            transform.position.y,
            transform.position.z
        );

        // 到达终点时反向
        if (Mathf.Abs(transform.position.x - targetX) < 0.01f)
        {
            movingRight = !movingRight;
        }
    }
}