using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

    public float dashTime, dashSpeed, rotateDelay, rayDistance;
    private float time;
    private bool dashingRight, dashingLeft, rotating;
    private Transform target;
    private RaycastHit hit;
    private string saveTag;
    

    void Awake() {
        rotating = false;
        if(transform.tag == "Player1") {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
            saveTag = "Player2";
        }
        else {
            target = GameObject.FindGameObjectWithTag("Player1").transform;
            saveTag = "Player1";
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

        CheckForLookAt();

    }

    void CheckForLookAt() {
        if (Physics.Raycast(transform.position, Vector3.forward, out hit, rayDistance)) {
            print("rayhit");
        }
        else {
            if (!rotating) {
                print("rotating");
                rotating = true;
                StartCoroutine(Rotate());
                
            }
        }
    }

    IEnumerator Rotate() {
        print("rotating");
        yield return new WaitForSeconds(rotateDelay);
        Vector3 relativePos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos);
        transform.rotation = rotation;
        yield return new WaitForSeconds(1);
        rotating = false;
        StopCoroutine(Rotate());
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

