using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki5 : MonoBehaviour
{
    [SerializeField] private GameObject Tobira5;
    [SerializeField] private GameObject Yajirusi;
    private GameObject Tobira4;

    private void Start()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tobira4 = GameObject.FindGameObjectWithTag("Tobira");
            Destroy(Tobira4);
            Instantiate(Tobira5, new Vector3(-17.5f, -11.5f, 40), Tobira5.transform.rotation);
            Instantiate(Yajirusi, new Vector3(-17.8f,-9.24f,38.5f), Yajirusi.transform.rotation);
            Destroy(this.gameObject);
     
        }

    }
}
