using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public float increaseDamagePerSecond;
    private float chargeDamage;
    public float damage, grabTime, grabDamage;
    private Transform target;

    public void NormalAttack(float damages) {//gives damage after a normal attack.
        target.GetComponent<PlayerHealth>().GetDamage((int)damages);
    }

    public void CharageAttack(float damage, float chargeTime) {//calculated charge damage
        damage += (chargeTime * increaseDamagePerSecond);
        target.GetComponent<PlayerHealth>().GetDamage((int)damage);
    }

    public void GrabAttack() {//grab attack, disables to players abilitie to attack, dash and defend.
        StartCoroutine(target.GetComponent<PlayerInput>().WaitBeforeInput(grabTime));
        StartCoroutine(target.GetComponent<PlayerDash>().WaitBeforeDash(grabTime));
        StartCoroutine(target.GetComponent<PlayerDefense>().WaitBeforeDefense(grabTime));
        //insert grab animation stuff here, maybe a corountine that does the animation first and then the damage.
        target.GetComponent<PlayerHealth>().GetDamage((int)grabDamage);
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
