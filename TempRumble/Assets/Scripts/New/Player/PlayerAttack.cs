using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public int damage;
    public float increaseDamagePerSecond;
    private float chargeDamage;
    private bool isCharging;
    private Transform target;

    public void NormalAttack(int damages) {
        target.GetComponent<PlayerHealth>().GetDamage(damages);
    }

    public void CharageAttack() {
        if (isCharging) {
            StopCoroutine(AttackIsCharging());
            NormalAttack((int)chargeDamage);
            chargeDamage = damage;
            isCharging = false;
        }
        else {
            StartCoroutine(AttackIsCharging());
            isCharging = true;
        }
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

    IEnumerator AttackIsCharging() {
        chargeDamage *= increaseDamagePerSecond;
        yield return new WaitForSeconds(1);
        StartCoroutine(AttackIsCharging());
    }
}
