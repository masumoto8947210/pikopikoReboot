using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float xMin;
    private Rigidbody rb;
    private int upForce;
    private bool isGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        upForce = 400;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && this.transform.position.x < xMax)
        {
            transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime); 
        }
        if (Input.GetKey(KeyCode.F) && this.transform.position.x > xMin)
        {
            transform.Translate(new Vector3(-MoveSpeed, 0, 0) * Time.deltaTime);
        }
        if (Input.GetKeyDown("space") && isGround)
            rb.AddForce(new Vector3(0, upForce, 0));

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "G")
            isGround = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "G")
            isGround = false;
    }

}

