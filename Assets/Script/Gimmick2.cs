using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick2 : MonoBehaviour
{
    public AudioClip audioClip;
    AudioSource audioSource;
    public GameObject player;
    public Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        audioSource =
            gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {

        if (find.instance.Tp && Input.GetKeyDown(KeyCode.K))
        {
            player.transform.position = new Vector3(pos.x, pos.y, pos.z);
            audioSource.PlayOneShot(audioClip);
        }
    }

}
