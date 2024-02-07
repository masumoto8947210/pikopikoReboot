using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki3 : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject Houseki4;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Houseki4, new Vector3(instantX, instantY, 37), Houseki4.transform.rotation);
            Destroy(this.gameObject);
        }

    }
}
