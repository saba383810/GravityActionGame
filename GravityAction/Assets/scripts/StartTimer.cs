using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{

    public GameObject player;
    public GameObject gameStartPanel;
    public AudioClip startsound1;
    public AudioClip startsound2;
    AudioSource audioSource;
    float countTime = 4;
    float musiccount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (countTime >= 0)
        {
            if (musiccount >= 1)
            {
                musiccount = 0;
                audioSource.PlayOneShot(startsound1);
            }
            countTime -= Time.deltaTime; //スタートしてからの秒数を格納
            musiccount += Time.deltaTime;
            GetComponent<Text>().text = countTime.ToString("F2");
           
        }
        else
        {
            GetComponent<Text>().text = "G O !";
            player.SetActive(true);

            Invoke("uiFalse", 1);
            if (musiccount>0)
            {
                musiccount = -100;
                audioSource.PlayOneShot(startsound2);
            }
        }
    }

    void uiFalse()
    {
        gameStartPanel.SetActive(false);
    }
}
