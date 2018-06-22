using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D rigid2D;
    float jumpFource = 680.0f;
    float walkFource = 30.0f;
    float maxWalkSpeed = 3.0f;
    GameObject director;

    Animator animator;

    // Use this for initialization
    void Start() {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        this.director = GameObject.Find("GameDirector");
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Mouse") {
            if (Mathf.Abs(other.gameObject.transform.position.x - this.transform.position.x) < 0.5 && this.rigid2D.velocity.y < 0) {
                this.director.GetComponent<GameDirector>().HitMouse();
                Debug.Log("Hit!");
                Destroy(other.gameObject);
            }
            else {
                this.director.GetComponent<GameDirector>().MissMouse();
                Debug.Log("Miss!");
                Destroy(other.gameObject);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) {
            this.animator.SetTrigger("JumpTrigger");
            this.rigid2D.AddForce(transform.up * this.jumpFource);

        }

        int key = 0;
        if (Input.GetKey(KeyCode.LeftArrow)) {
            key = -1;
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            key = 1;
        }
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        if(speedx < this.maxWalkSpeed) {
            this.rigid2D.AddForce(transform.right * this.walkFource * key);
        }
        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        if (this.rigid2D.velocity.y == 0) {
            this.animator.speed = speedx / 2.0f;
        }
        else {
            this.animator.speed = 1.0f;
        }
	}
}
