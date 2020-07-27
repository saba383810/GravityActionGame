using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
	public GameObject effectPrefab;
	public AudioClip damageSound;
	public AudioClip destroySound;
	public int playerHP = 3;
	public GameObject[] playerIcons;
	public Rigidbody rb;

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "obstacle")
		{
			playerHP -= 1;

			//AudioSource.PlayClipAtPoint(damageSound, Camera.main.transform.position);
			rb.AddForce(25, 30, 0,ForceMode.Impulse);
			PlayerMove prem = GetComponent<PlayerMove>();
			prem.setTrue();

			if (playerHP == 0)
			{
				//GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
				//Destroy(effect, 1.0f);
				//AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position);

				this.gameObject.SetActive(false);
			}
		}
		UpdatePlayerIcons();

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