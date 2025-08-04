using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                GameObject gameObj = hitInfo.collider.gameObject;
                if (gameObj.tag == "map")
                {
                    transform.position = new Vector3(14,1,-10);
                }
            }
        }
    }
}
