using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public GameObject loadingScreen;

	void Awake()
	{
		loadingScreen.SetActive (false);
	}

    public void LoadScene(string name)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(name);
    }

	public void LoadScene(int level)
	{
        loadingScreen.SetActive(true);
		SceneManager.LoadScene(level);
	}

	public void LoadNextLevel()
	{
        loadingScreen.SetActive(true);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
		
	public IEnumerator GameOver(string victimtag)
	{

		Debug.Log(victimtag);
		yield return new WaitForSeconds(5);
		Debug.Log(victimtag.Length);
		if ( victimtag == "Player")
		{

			LoadScene("Lose Screen");
		}
		else if (victimtag == "Enemy")
		{
			LoadNextLevel();
		}
	}
}
