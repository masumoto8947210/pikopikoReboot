using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki4 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki5;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Houseki5, new Vector3(instantX, instantY, 37), Houseki5.transform.rotation);
            Destroy(this.gameObject);
        }

    }

}
