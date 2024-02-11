using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    int P;
    int B;
    int H;
    public AudioClip collisionSound; // 衝突時に再生する音声ファイル
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        P = Item1.score1;
        B = Item2.score2;
        H = Item3.score3;
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
        if(P == 1 && H == 1 && B == 1)
            SceneManager.LoadScene("END_FULL");

        if(P == 1 && B == 1 && H != 1)
            SceneManager.LoadScene("END_B_P");

        if(B == 1 && H == 1 && P != 1)
            SceneManager.LoadScene("END_B_H");

        if(P != 1 && B == 1 && H != 1)
            SceneManager.LoadScene("END_B");

        if(P == 1 && B != 1 && H != 1)
            SceneManager.LoadScene("END_P");

        if(P != 1 && B != 1 && H == 1)
            SceneManager.LoadScene("END_H");

        if(P == 1 && B != 1 && H == 1)
            SceneManager.LoadScene("END_P_H");

        if (P != 1 && B != 1 && H != 1)
            SceneManager.LoadScene("END");
    }
}
