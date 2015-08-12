using UnityEngine;
using System.Collections;

public class MenuUIScript : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void DidPressPlayButton()
	{

		StartCoroutine(ScenesManager.AsyncMapLoad(ScenesManager.Scenes.LevelEntrance));

	}

	public void DidPressExitButton()
	{

		Application.Quit();

	}

}
