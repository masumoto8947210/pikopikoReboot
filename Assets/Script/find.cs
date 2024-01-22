using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find : MonoBehaviour
{
    public static find instance;
    public bool Touch;
    // Start is called before the first frame update

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            Touch = true;
        }
  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            Touch = false;
        }

    }
}
