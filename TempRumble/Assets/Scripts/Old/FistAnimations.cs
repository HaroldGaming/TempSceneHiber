using UnityEngine;
using System.Collections;

public class FistAnimations : MonoBehaviour {

    public GameObject[] fists;
    public bool charging, allowAttack;
    public int spinSpeed;
    public float setAttackCoolDown, setGrabCooldDOwn, setDefendCoolDown, damage;
    private int fist;
    private float attackCoolDown, chargeDamage;

    void Start() {
        chargeDamage = damage;
        allowAttack = true;
    }
    void Update() {
        if (Input.GetButton("Fire1")) {
            allowAttack = false;
            ChargeAttack(true);
            charging = true;
            print("charging");
            //print(chargeDamage);
        }
        else {
            if (charging) {
                charging = false;
                ChargeAttack(false);            
            }

            if (Input.GetButtonDown("Fire1")) {
                Attack(damage);
                print("Attack");
            }
        }



        if(attackCoolDown >= 0) {
            attackCoolDown -= Time.deltaTime;
        }
    }

    public void ChargeAttack(bool charge) {
        if (attackCoolDown <= 0) {
            if (charge) {
                fists[fist].transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
                fists[fist].transform.position = fists[fist].GetComponent<Fists>().backObject.transform.position;
                chargeDamage *= 1.1F;
            }
            else {
                allowAttack = true;
                Attack(chargeDamage);
                chargeDamage = damage;
            }
        }
    }

    public void Defend() {
        if (attackCoolDown <= 0) {
            if (allowAttack) {
                fists[0].GetComponent<Fists>().Defends();
                fists[1].GetComponent<Fists>().Defends();
            }
        }
    }

    public void Grab() {
        if(attackCoolDown <= 0) {
            if (allowAttack) {
                fists[0].GetComponent<Fists>().Grabs(GetComponent<Dash>().target);
                fists[1].GetComponent<Fists>().Grabs(GetComponent<Dash>().target);
                attackCoolDown = setGrabCooldDOwn;
            }

        }
    }

    public void Attack(float totalDamage) {
        if (attackCoolDown <= 0) {
            if (allowAttack) {
                fists[fist].GetComponent<Fists>().Attacks();
                if (fist == 0) {
                    fist = 1;
                }
                else {
                    fist = 0;
                }
               // GameObject.FindGameObjectWithTag("HealthBar").GetComponent<Bars>().GetDamage(totalDamage);
                attackCoolDown = setAttackCoolDown;
            }
        }     
    }
}
