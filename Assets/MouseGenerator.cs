using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseGenerator : MonoBehaviour {

    public GameObject mousePrefab;
    float span = 2.0f;
    float delta = 0;

	// Update is called once per frame
	void Update () {
        this.delta += Time.deltaTime;
        if(this.delta > this.span) {
            this.delta = 0;
            GameObject mouse = Instantiate(mousePrefab) as GameObject;
            int dokan = Random.Range(1, 5);
 //           Debug.Log(dokan);
            float x = 0, y = 0;
            if(dokan == 1) {
                x = -7.0f;
                y = 3.25f;
                mouse.GetComponent<MouseController>().SetDirection(1);
            }else if(dokan == 2) {
                x = -7.0f;
                y = -0.75f;
                mouse.GetComponent<MouseController>().SetDirection(1);
            }
            else if(dokan == 3) {
                x = 7.0f;
                y = 2.35f;
                mouse.GetComponent<MouseController>().SetDirection(-1);
            }
            else if(dokan == 4) {
                x = 7.0f;
                y = -0.85f;
                mouse.GetComponent<MouseController>().SetDirection(-1);
            }
            mouse.transform.position = new Vector3(x, y, 0);
        }
		
	}
}
