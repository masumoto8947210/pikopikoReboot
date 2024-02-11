using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : MonoBehaviour
{
    public static int score1;
    // Start is called before the first frame update
    void Start()
    {
        score1 = Item.item1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            score1++;
            Destroy(this.gameObject);
        }
    }
}
