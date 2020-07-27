using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public GameObject effectPrefab;
	public AudioClip damageSound;
	public AudioClip destroySound;
	AudioSource audioSource;
	public int playerHP = 3;
	public GameObject[] playerIcons;
	public Rigidbody rb;
	Animator animPlayer;


	void Start()
	{
		animPlayer = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
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
				//GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
				//Destroy(effect, 1.0f);
				//AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);
				Invoke("charactorDestroy", 2);
				
			}
		}
		UpdatePlayerIcons();

	}
	void charactorDestroy()
	{
		this.gameObject.SetActive(false);
	}

	void UpdatePlayerIcons()
	{
		// for文（繰り返し文）・・・まずは基本形を覚えましょう！
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