using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour {

    public float dashSpeed, dashRange, dashCooldown;
    private float time;
    private bool dashingRight, dashingLeft;
    private Transform target;
    private string saveTag;

    void Start() {
        if (transform.tag == "Player1") {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
            saveTag = "Player2";
        }
        else {
            target = GameObject.FindGameObjectWithTag("Player1").transform;
            saveTag = "Player1";
        }
    }

	void Update () {
        if (dashingRight) {
            transform.RotateAround(target.position, Vector3.up, +dashSpeed * Time.deltaTime);
        }
        else {

        }

        if (dashingLeft) {
            transform.RotateAround(target.position, Vector3.up, -dashSpeed * Time.deltaTime);
        }

        if (time >= 0) {
            time -= Time.deltaTime;

        }
        else {
            dashingRight = false;
            dashingLeft = false;
        }
    }

    public void Dasher(int leftRight) {
        time = dashCooldown;

        switch (leftRight) {
            case 0:
                dashingLeft = true;
                break;
            case 1:
                dashingRight = true;
                break;
        }
    }
}
