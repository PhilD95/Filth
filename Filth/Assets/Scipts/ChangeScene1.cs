using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter (Collider other){
		SceneManager.LoadScene ("Scene_2", LoadSceneMode.Additive);

	}
}
