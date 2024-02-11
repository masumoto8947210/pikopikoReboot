using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGet : MonoBehaviour
{
    private GameObject item2;
    private Item2 itemCs2;
    // Start is called before the first frame update
    void Start()
    {
        item2 = GameObject.Find("Item2");
        itemCs2 = item2.GetComponent<Item2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            itemCs2.score2++;
            Destroy(this.gameObject);
        }
    }
}
