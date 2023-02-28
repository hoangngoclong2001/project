using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	[SerializeField]
	private AudioSource soundMenu;

	private void Awake()
	{
        SoundManager.Instance.Play(soundMenu);
        SoundManager.Instance.AddToAudio(soundMenu);
    }

	public void ChangeSceneByName(string name) {
		SceneManager.LoadScene(name);
	}

	public void Mute()
	{
		SoundManager.Instance.MuteAll();
	}
}
