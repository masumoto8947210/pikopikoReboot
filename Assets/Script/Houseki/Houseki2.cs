using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houseki2 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki3;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(Houseki3, new Vector3(instantX, instantY, 37), Houseki3.transform.rotation);
            Destroy(this.gameObject);
        }

    }
}
