using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int scene = Data.Scene;
        switch (scene)
        {
            case 2:
             //   SceneManager.LoadScene("MainScene");
                break;
            case 3:
             //   SceneManager.LoadScene("MainScene");
                break;
        }



    }
}
