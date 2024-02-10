using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki5 : MonoBehaviour
{
    [SerializeField] private GameObject Tobira5;
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
            Instantiate(Tobira5, new Vector3(-22, -11.5f, 40), Tobira5.transform.rotation);
            Destroy(this.gameObject);
     
        }

    }
}
