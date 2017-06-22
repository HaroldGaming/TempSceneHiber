using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    private PlayerDash dashClass;
    private PlayerAttack attackClass;
    public float dashTime, attackTime;
    public int damage;

	void Start () {
        dashClass = GetComponent<PlayerDash>();
        attackClass = GetComponent<LightAttack>();
        StartCoroutine(Dashing(1));
    }

    IEnumerator Attacking(int damage) {        
        yield return new WaitForSeconds(attackTime);
        GetComponent<FistAnimationV2>().Attack();
        attackClass.NormalAttack(damage);
        StartCoroutine(Dashing(Random.Range(0, 2)));
    }

    IEnumerator Dashing(int leftRight) {
        yield return new WaitForSeconds(dashTime);
        dashClass.Dasher(leftRight);
        print("dashed");
        StartCoroutine(Attacking(damage));       
    }
}
