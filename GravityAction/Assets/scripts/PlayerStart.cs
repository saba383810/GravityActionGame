using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip stagemusic;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("Stage1Music", 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Stage1Music()
    {
        audioSource.PlayOneShot(stagemusic);
    }
}
