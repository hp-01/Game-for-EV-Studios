using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			GameManager.instance.GameOver("WIN!!!");
		}
	}
}
