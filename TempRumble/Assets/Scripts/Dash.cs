using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

    public float dashTime, dashSpeed;
    private float time;
    private bool dashingRight, dashingLeft;
    private Transform target;

    void Awake() {
        if(transform.tag == "Player1") {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        else {
            target = GameObject.FindGameObjectWithTag("Player1").transform;
        }
    }

    void Update() {
        if (dashingRight) {
            transform.RotateAround(target.position, Vector3.up, +dashSpeed * Time.deltaTime);
        }
        else {

        }

        if (dashingLeft){
            transform.RotateAround(target.position, Vector3.up, -dashSpeed * Time.deltaTime);
        }

        if(time >= 0) {
            time -= Time.deltaTime;

        }
        else {
            dashingRight = false;
            dashingLeft = false;
        }

    }

    public void Dasher(int leftRight) {
        time = dashTime;
        switch (leftRight) {
            case 0:
                print("dash left");
                //transform.RotateAround(GameObject.FindGameObjectWithTag("Player2").transform.position, Vector3.up, +dashRange);
                dashingLeft = true;
                break;
            case 1:
                //transform.RotateAround(GameObject.FindGameObjectWithTag("Player2").transform.position, Vector3.up, -dashRange);
                dashingRight = true;
                break;
        }
    }

    IEnumerator Dashing() {
        yield return new WaitForSeconds(3);
    }

}

