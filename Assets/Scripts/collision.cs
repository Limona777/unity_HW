using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    public Text textFailed;
    // Start is called before the first frame update
    void Start(){
        textFailed.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        textFailed.gameObject.SetActive(true);
        textFailed.text = "You Failed!";
        gameObject.GetComponent<AddForce>().enabled = false;
    }
}
