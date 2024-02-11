using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2 : MonoBehaviour
{
    public static int score2;
    // Start is called before the first frame update
    void Start()
    {
        score2 = Item.item2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score2++;
            Destroy(this.gameObject);
        }
    }

}
