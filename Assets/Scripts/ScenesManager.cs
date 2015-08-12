using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenesManager : MonoBehaviour
{

	public enum Scenes
	{
		None,
		Menu,
		LevelEntrance
	}

	/// <summary>
	/// Currently loaded scene.
	/// </summary>
	public static Scenes CurrentScene = Scenes.None;

	/// <summary>
	/// Map of scene enums to scene names.
	/// </summary>
	public static Dictionary<Scenes, string> ScenesDictionary = null;

	void Awake()
	{

		Init();

	}

	/// <summary>
	/// Initializes ScenesDictionary.
	/// </summary>
	void Init()
	{

		ScenesDictionary = new Dictionary<Scenes, string>();
		ScenesDictionary[Scenes.Menu] = "Menu";
		ScenesDictionary[Scenes.LevelEntrance] = "LevelEntrance";

	}

	/// <summary>
	/// Loads scene by given scene enum value. Prints an error message in the console if no scene info found.
	/// </summary>
	/// <param name="scene"></param>
	public static IEnumerator AsyncMapLoad(Scenes sceneName)
	{

		string sceneNameString = "";
		if (ScenesDictionary.TryGetValue(sceneName, out sceneNameString) == true)
		{
			CurrentScene = sceneName;

			AsyncOperation LoadingOperation = Application.LoadLevelAsync(sceneNameString);
			if (LoadingOperation.isDone == false)
			{
				// still loading, maybe show loading indication
				// LoadingOperation.progress for [0; 1] loading status value
				yield return null;
			}
			// loading complete after this point

		}
		else
		{
			Debug.LogError("Failed to find a scene of type " + sceneName);
		}
		
	}

}
