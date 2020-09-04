using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void gameSelectButtonClick()
    {
        SceneManager.LoadScene("Menu");
    }
    public void startButtonClick()
    {
        SceneManager.LoadScene("Start");
    }
    public void Stage1ButtonClick()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Stage2ButtonClick()
    {
        SceneManager.LoadScene("Stage2");
    }
    public void Stage3ButtonClick()
    {
        SceneManager.LoadScene("Stage3");
    }
    public void Stage4ButtonClick()
    {
        SceneManager.LoadScene("Stage4");
    }
}
