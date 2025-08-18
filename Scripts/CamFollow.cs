using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 CamStartPos;
    // Start is called before the first frame update
    void Start()
    {
        CamStartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, CamStartPos.y, CamStartPos.z);
    }
}
