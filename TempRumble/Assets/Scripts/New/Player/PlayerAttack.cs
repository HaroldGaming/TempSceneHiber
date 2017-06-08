using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float increaseDamagePerSecond;
    private float chargeDamage;
    public float damage;
    private Transform target;

    public void NormalAttack(float damages) {
        target.GetComponent<PlayerHealth>().GetDamage((int)damages);
        print("Normal");
        print(damage);
    }

    public void CharageAttack(float damage, float chargeTime) {
        damage += (chargeTime * increaseDamagePerSecond);
        target.GetComponent<PlayerHealth>().GetDamage((int)damage);
        print("Chaaaarge");
        print(damage);
    }

    public void GrabAttack() {

    }

    public void SetTarget() {
        if (transform.tag == "Player1") {
            target = GameObject.FindGameObjectWithTag("Player2").transform;
        }
        else {
            target = GameObject.FindGameObjectWithTag("Player1").transform;
        }
    }
}
