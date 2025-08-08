using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform followTarget;

    public float distanceH = 5;
    public float distanceV = 2;
    public float smooth = 3;
    private Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        targetPosition = followTarget.position + Vector3.up * distanceV - Vector3.forward * distanceH;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        transform.LookAt(followTarget);
    }
}
