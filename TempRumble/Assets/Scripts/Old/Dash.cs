using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

    public float rotateDelay, rayDistance, rotateSpeed, rotateCoolDown;
    private bool rotating;
    public Transform target;
   // private RaycastHit hit;
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
        CheckForLookAt();
        if (rotating){
            Vector3 pos = target.position - transform.position;
            var newRot = Quaternion.LookRotation(pos);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRot, rotateSpeed * Time.deltaTime);
        }


    }

    void CheckForLookAt() {
        if (Physics.Raycast(transform.position, Vector3.forward, rayDistance)) {
            //StopCoroutine(Rotate());
        }
        else {
            if (!rotating) {
                StartCoroutine(Rotate());
            }

        }
    }

    IEnumerator Rotate() {
        yield return new WaitForSeconds(rotateDelay);
        rotating = true;


        yield return new WaitForSeconds(rotateCoolDown);
        rotating = false;

        //StartCoroutine(Rotate());
    }

    IEnumerator Dashing() {
        yield return new WaitForSeconds(3);
    }

}

