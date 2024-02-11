using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3 : MonoBehaviour
{
    public static int score3;
    // Start is called before the first frame update
    void Start()
    {
        score3 = Item.item3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score3++;
            Destroy(this.gameObject);
        }
    }
}
