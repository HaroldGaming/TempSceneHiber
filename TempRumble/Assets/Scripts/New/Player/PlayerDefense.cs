using UnityEngine;
using System.Collections;

public class PlayerDefense : MonoBehaviour {

    public float defenseTime, defenseCoolDown;
    private bool allowDefend;
    private PlayerHealth healthClass;

    void Start() {
        allowDefend = true;
        healthClass = GetComponent<PlayerHealth>();
    }

    public void Defend() {
        if (allowDefend) {
            healthClass.invulnerable = true;
            StartCoroutine(IsDefending(defenseTime));
        }
    }

    IEnumerator IsDefending(float defenseTime) {
        allowDefend = false;
        yield return new WaitForSeconds(defenseTime);
        healthClass.invulnerable = false;
        StartCoroutine(WaitBeforeDefense(defenseCoolDown));
        StopCoroutine(IsDefending(0));
    }

    public IEnumerator WaitBeforeDefense(float defenseCoolDown) {
        allowDefend = false;
        print("Cant deff");
        yield return new WaitForSeconds(defenseCoolDown);
        allowDefend = true;
        StopCoroutine(WaitBeforeDefense(0));
    }
}
