using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private bool isReverse;
    public GameObject player;
    Animator animPlayer;
    private bool reachFlag = false;
    public bool isdamege = false;
    private bool invokeCheck = false;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        if (isdamege == false)
        {
            transform.position += new Vector3(-0.15f, 0, 0);
            invokeCheck = false;
        }
        else
        {
            if (invokeCheck == false)
            {
                Invoke("setFalse", 4.2f);
                invokeCheck = true;
            }
        }

        //天井か地面についていないと重力反転できないようにする。
        Gravity grav = GetComponent<Gravity>();
        if (Input.GetKeyDown(KeyCode.Space) && reachFlag == true) {
            if (isReverse == true)
            {
                animPlayer.SetBool("isFloating", false);
                grav.setFalse();
                isReverse = false;  
            }
            else
            {
                animPlayer.SetBool("isFloating", true);
                grav.setTrue();
                isReverse = true;
            }
        }
    }
	private void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.tag == "Ground")
        {
            reachFlag = true;
        }
	}
	private void OnCollisionExit(Collision col)
	{
        if (col.gameObject.tag == "Ground")
        {
            reachFlag = false;
        }
	}

    public void setTrue()
    {
        isdamege = true;
    }
    public void setFalse()
    {
        animPlayer.SetBool("isCollision", false);
        isdamege = false;
    }
}
