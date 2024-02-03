using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick2 : MonoBehaviour
{
    public GameObject player;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {

        if (find.instance.Tp && Input.GetKeyDown(KeyCode.Q))
        {
            player.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }

}
