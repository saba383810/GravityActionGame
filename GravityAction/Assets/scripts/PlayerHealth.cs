using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public GameObject effectPrefab;
	public AudioClip damageSound;
	public AudioClip destroySound;
	public AudioClip clearsound;
	public AudioClip gameoversound;
	public int playerHP = 3;
	
	public Rigidbody rb;
	public GameObject gameOverPanel;
	public GameObject clearPanel;
	public GameObject[] playerIcons;
	Animator animPlayer;
	AudioSource audioSource;


	void Start()
	{
		animPlayer = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
		gameOverPanel.SetActive(false);
		clearPanel.SetActive(false);
	}


	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "obstacle")
		{
			playerHP -= 1;

			//---浮いているなら落下させる。----
			Gravity grav = GetComponent<Gravity>();
			grav.setFalse();
			animPlayer.SetBool("isFloating", false);
			animPlayer.SetBool("isCollision", true);
			//-----------------------------

			PlayerMove prem = GetComponent<PlayerMove>();
			prem.setTrue();
			rb.AddForce(25, 30, 0,ForceMode.Impulse);
			
			audioSource.PlayOneShot(damageSound);
			if (playerHP == 0)
			{
				Invoke("charactorDestroy", 1);
				audioSource.PlayOneShot(gameoversound);
				gameOverPanel.SetActive(true);
			}
		}
		if (col.gameObject.tag == "Goal")
		{
			Invoke("charactorDestroy", 1);
			audioSource.PlayOneShot(clearsound);
			clearPanel.SetActive(true);
		}


		UpdatePlayerIcons();

	}
	void charactorDestroy()
	{
		this.gameObject.SetActive(false);
	}

	void UpdatePlayerIcons()
	{
		for (int i = 0; i < playerIcons.Length; i++)
		{
			if (playerHP <= i)
			{
				playerIcons[i].SetActive(false);
			}
			else
			{
				playerIcons[i].SetActive(true);
			}
		}
	}
}