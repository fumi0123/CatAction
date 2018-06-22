using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour {
    GameObject main;


    void Start() {
//        main = GameObject.Find("GameDirector");
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("GameScene");
        }
	}
}
