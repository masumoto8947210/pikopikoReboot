using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find : MonoBehaviour
{
    public static find instance;
    public bool isTouched;
    // Start is called before the first frame update
    void Start()
    {
        isTouched = false;
    }

    // Update is called once per frame
    void Update()
    {
        isTouched = false;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnColliderStay(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            isTouched = true;
        }

    }
}
