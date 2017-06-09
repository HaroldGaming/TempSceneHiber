using UnityEngine;
using System.Collections;

public class PlayerDash : MonoBehaviour {

    public float dashSpeed, dashTime, dashCoolDown;
    private float timeWhileDash;
    private bool dashingRight, dashingLeft, allowDash;
    private Transform target;
    private string saveTag;

    void Start() {
        allowDash = true;
        if (transform.tag == "Player1") {//sets the right target.
            target = GameObject.FindGameObjectWithTag("Player2").transform;
            saveTag = "Player2";
        }
        else {
            target = GameObject.FindGameObjectWithTag("Player1").transform;
            saveTag = "Player1";
        }
    }

	void Update () {
        transform.LookAt(target);//make something better for this later
        if (dashingRight) {//function makes the payer dash around its target
            transform.RotateAround(target.position, Vector3.up, -dashSpeed * Time.deltaTime);
        }
        else {

        }

        if (dashingLeft) {
            transform.RotateAround(target.position, Vector3.up, +dashSpeed * Time.deltaTime);
        }

        if (timeWhileDash >= 0) {
            timeWhileDash -= Time.deltaTime;

        }
        else {
            dashingRight = false;
            dashingLeft = false;                       
        }
    }

    public IEnumerator WaitBeforeDash(float timeBeforeDash) {
        print("Cant dash");
        allowDash = false;
        yield return new WaitForSeconds(timeBeforeDash);
        allowDash = true;
        StopCoroutine(WaitBeforeDash(0));
    }

    public void Dasher(int leftRight) { // Checks the input to dash left or right
        if (allowDash) {
            timeWhileDash = dashTime;

            switch (leftRight) {
                case 0:
                    dashingLeft = true;
                    break;
                case 1:
                    dashingRight = true;
                    break;
            }          
            StartCoroutine(WaitBeforeDash(dashTime + dashCoolDown));           
        }
    }
}
