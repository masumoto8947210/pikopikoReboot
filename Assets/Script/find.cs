using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find : MonoBehaviour
{
    public static find instance;
    public bool Touch;
    // Start is called before the first frame update
    void Start()
    {
        Touch = false;
    }

    // Update is called once per frame
    void Update()
    {
        Touch = false;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnColliderStay(Collider other)
    {
        if (other.gameObject.tag == "tp")
        {
            Touch = true;
        }

    }
}
