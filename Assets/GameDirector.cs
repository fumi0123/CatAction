using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

    GameObject timeText;
    GameObject scoreText;
    GameObject hpImage;

    float time = 45.0f;
    int score = 0;
    int hp = 5;

    public void HitMouse() {
        this.score += 100;
    }
    public void MissMouse() {
        this.hp -= 1;
        this.hpImage.GetComponent<Image>().fillAmount -= 0.2f;
    }
    public void SrueMouse() {
        this.score -= 50;
    }

	// Use this for initialization
	void Start () {
        this.timeText = GameObject.Find("Time");
        this.scoreText = GameObject.Find("Score");
        this.hpImage = GameObject.Find("Hp");
	}
	
	// Update is called once per frame
	void Update () {
            this.time -= Time.deltaTime;
        if (this.time > 0.0f && this.hp > 0) {
            this.timeText.GetComponent<Text>().text =
                this.time.ToString("F1");
            this.scoreText.GetComponent<Text>().text =
                this.score.ToString() + " point";
        }
        else {
            SceneManager.LoadScene("TitleScene");
        }
	}
}
