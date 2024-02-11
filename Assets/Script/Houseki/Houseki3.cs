using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki3 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki4;
    [SerializeField] private GameObject Tobira3;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    [SerializeField] private AudioClip[] clips;
    private GameObject Tobira2;
    // Start is called before the first frame update
    private void Start()
    {
      

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tobira2 = GameObject.FindGameObjectWithTag("Tobira");
            Destroy(Tobira2);
            Instantiate(Houseki4, new Vector3(instantX, instantY, 37), Houseki4.transform.rotation);
            Instantiate(Tobira3, new Vector3(-17.5f, -11.5f, 40), Tobira3.transform.rotation);   
            Destroy(this.gameObject);

        }
    }
}
