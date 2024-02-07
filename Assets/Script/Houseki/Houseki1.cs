using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditorInternal;

public class Houseki1 : MonoBehaviour
{
    [SerializeField] private GameObject Houseki2;
    [SerializeField] private float instantX;
    [SerializeField] private float instantY;
    // Start is called before the first frame update
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(Houseki2, new Vector3(instantX, instantY, 37), Houseki2.transform.rotation);
            Destroy(this.gameObject);
        }
        
    }
}
