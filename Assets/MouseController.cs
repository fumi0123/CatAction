using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {

    Rigidbody2D rigid2D;
    int direction = 1;
    float speed = 0.025f;
    GameObject director;

    public void SetDirection(int direction) {
        this.direction = direction;
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Mouse") {
            this.direction *= -1;
        }
    }


    // Use this for initialization
    void Start () {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.director = GameObject.Find("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
        if (this.rigid2D.velocity.y == 0)
            transform.Translate(this.speed * this.direction, 0, 0);

        if(8 < transform.position.x || transform.position.x < -8) {
            this.director.GetComponent<GameDirector>().SrueMouse();
            Destroy(this.gameObject);
        }
	}
}
