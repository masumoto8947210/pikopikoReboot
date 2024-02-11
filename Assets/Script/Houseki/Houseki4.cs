using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki4 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki5;
    [SerializeField] private GameObject Tobira4;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    [SerializeField] private AudioClip[] clips;
    private GameObject Tobira3;
    // Start is called before the first frame update
    private void Start()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Tobira3 = GameObject.FindGameObjectWithTag("Tobira");
            Destroy(Tobira3);
            Instantiate(Houseki5, new Vector3(instantX, instantY, 37), Houseki5.transform.rotation);
            Instantiate(Tobira4, new Vector3(-17.5f, -11.5f, 40), Tobira4.transform.rotation);
            Destroy(this.gameObject);

        }
    }
}
