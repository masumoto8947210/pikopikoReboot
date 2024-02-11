using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki2 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki3;
    [SerializeField] private GameObject Tobira2;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    [SerializeField] private AudioClip[] clips;
    private GameObject Tobira1;
    // Start is called before the first frame update
    private void Start()
    {
    

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tobira1 = GameObject.FindGameObjectWithTag("Tobira");
            Destroy(Tobira1);
            Instantiate(Houseki3, new Vector3(instantX, instantY, 37), Houseki3.transform.rotation);
            Instantiate(Tobira2, new Vector3(-17.5f, -11.5f, 40), Tobira2.transform.rotation);
            Destroy(this.gameObject);
          
        }
    }
}
