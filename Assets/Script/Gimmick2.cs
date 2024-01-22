using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick2 : MonoBehaviour
{
    public GameObject player;
    public Transform tp_pea;
    public Transform tp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(find.instance.Tp && Input.GetKeyDown(KeyCode.Q))
        {
            player.transform.position = tp_pea.position;
        }
        if (find.instance.Tp_pea && Input.GetKeyDown(KeyCode.Q))
        {
            player.transform.position = tp.position;
        }
    }
}
