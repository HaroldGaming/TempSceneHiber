using UnityEngine;
using System.Collections;

public class Fists : MonoBehaviour {

    public GameObject[] moveToObjects;
    public GameObject backObject;

	void Start () {
	
	}
	
	void Update () {
	
	}

    public void Attacks() {
        StartCoroutine(Attacking());
    }



    IEnumerator Attacking() {
        transform.position = moveToObjects[1].transform.position;
        yield return new WaitForSeconds(0.2F);
        transform.position = moveToObjects[0].transform.position;
    }
}
