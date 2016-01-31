using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onStartGame(){
		SceneManager.LoadScene ("3DEnvironment_ver_2");
	}
}
