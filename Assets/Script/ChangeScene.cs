using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.tag == "Player")
        {
            Debug.Log("ChangeScene");
        }
    }

}
