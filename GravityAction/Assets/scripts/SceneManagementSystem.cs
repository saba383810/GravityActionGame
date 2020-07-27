using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagementSystem : MonoBehaviour
{
    public AudioClip StartButtonSound;
    void Start()
    {
        
    }

    void Update()
    {
        //start画面

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.PlayClipAtPoint(StartButtonSound, Camera.main.transform.position);
            Invoke("LoadScene", 3);
        }

    }
    private void LoadScene()
    {
        SceneManager.LoadScene("Stage1");
    }
}
