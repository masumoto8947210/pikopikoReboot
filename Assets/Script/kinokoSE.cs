using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kinokoSE : MonoBehaviour
{
    public AudioClip collisionSound; // 衝突時に再生する音声ファイル
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = collisionSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // 衝突した相手がPlayerタグを持っている場合にSEを再生する
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
        }
    }

}
