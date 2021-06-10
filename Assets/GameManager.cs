using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public bool gameStart = true;
	public static GameManager instance;
	public Text message;
	public Button menuButton;

	private void Awake()
	{
		if(instance != null && instance != this)
		{
			this.gameObject.SetActive(false);
		}
		else
		{
			instance = this;
		}
		message.text = "";
		menuButton.gameObject.SetActive(false);
	}

	public void GameOver(string _message)
	{
		gameStart = false;
		message.text = _message;
		menuButton.gameObject.SetActive(true);
	}

	public void OnClickMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
