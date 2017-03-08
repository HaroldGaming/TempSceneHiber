using UnityEngine;
using System.Collections;

public class FistAnimations : MonoBehaviour {

    public GameObject[] fists;
    private bool charging, allowAttack;
    public int spinSpeed;
    public float setAttackCoolDown;
    private int fist;
    private float attackCoolDown;

    void Start() {
        allowAttack = true;
    }
    void Update() {
        if (Input.GetButton("Jump")) {
            allowAttack = false;
            ChargeAttack(true);
            charging = true;
            print("charging");
        }
        else {
            if (charging) {
                ChargeAttack(false);
                charging = false;
            }
        }

        if(attackCoolDown >= 0) {
            attackCoolDown -= Time.deltaTime;
        }
    }

    void ChargeAttack(bool charge) {
        if (attackCoolDown <= 0) {
            if (charge) {
                fists[fist].transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
                fists[fist].transform.position = fists[fist].GetComponent<Fists>().backObject.transform.position;
            }
            else {
                allowAttack = true;
                Attack();
            }
        }
    }

    public void Attack() {
        if (attackCoolDown <= 0) {
            if (allowAttack) {
                fists[fist].GetComponent<Fists>().Attacks();
                if (fist == 0) {
                    fist = 1;
                }
                else {
                    fist = 0;
                }
                attackCoolDown = setAttackCoolDown;
            }
        }     
    }

}
