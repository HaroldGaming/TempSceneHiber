using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

    private Dash dashClass;
    public float dashTime;

	void Start () {
        dashClass = GetComponent<Dash>();
        StartCoroutine(Dashing(0));
	}

    IEnumerator Dashing(int leftRight) {
        dashClass.Dasher(leftRight);
        yield return new WaitForSeconds(dashTime);
        leftRight = Random.Range(0, 2);
        StartCoroutine(Dashing(leftRight));
    }
}
