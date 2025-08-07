using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class trigger : MonoBehaviour
{
    public Text textFinished;
    // Start is called before the first frame update
    void Start()
    {
        textFinished.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        textFinished.gameObject.SetActive(true);
        textFinished.text = "Finished!";
        GameObject.Find("Bird").GetComponent<AddForce>().enabled = false;
        GameObject.Find("Bird").gameObject.SetActive(false);
    }
}
