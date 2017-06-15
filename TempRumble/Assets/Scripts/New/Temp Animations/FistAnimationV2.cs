using UnityEngine;
using System.Collections;

public class FistAnimationV2 : MonoBehaviour {

    public GameObject[] fists;
    public int spinSpeed;
    private int fist;


    public void ChargeAttack(bool charge) {
        if (charge) {
            fists[fist].transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
            fists[fist].transform.position = fists[fist].GetComponent<Fists>().backObject.transform.position;
        }
        else {
            Attack();
        }      
    }

    public void Defend() {
        fists[0].GetComponent<Fists>().Defends();
        fists[1].GetComponent<Fists>().Defends();
    }

    //public void Grab() {
    //  if (attackCoolDown <= 0) {
    //   if (allowAttack) {
    //  fists[0].GetComponent<Fists>().Grabs(GetComponent<Dash>().target);
    //  fists[1].GetComponent<Fists>().Grabs(GetComponent<Dash>().target);
    //  attackCoolDown = setGrabCooldDOwn;
    //   }

    //  }
    // }

    public void Attack() {
        fists[fist].GetComponent<Fists>().Attacks();
        if (fist == 0) {
            fist = 1;
        }
        else {
            fist = 0;
        }
    }
}

