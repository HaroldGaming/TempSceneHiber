using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

    void Start() {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy() {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
