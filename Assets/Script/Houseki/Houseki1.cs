using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Houseki1 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki2;
    [SerializeField] private GameObject Tobira1;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    [SerializeField] private AudioClip[] clips;
    private GameObject Tobira0;
    // Start is called before the first frame update
    private void Start()
    {
       

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameObject Tobira0 = GameObject.Find("Tobira0");
            Instantiate(Houseki2, new Vector3(instantX, instantY, 37), Houseki2.transform.rotation);
            Instantiate(Tobira1, new Vector3(-17.5f, -11.5f, 40), Tobira1.transform.rotation);
            Destroy(Tobira0);
            Destroy(this.gameObject);
      
        }
    }
}
