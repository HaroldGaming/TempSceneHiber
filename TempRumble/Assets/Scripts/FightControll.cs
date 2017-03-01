using UnityEngine;
using System.Collections;

public class FightControll : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        if (Input.touchCount == 2) {
            print("Attack");
        }

        if (Input.GetMouseButtonDown(0)) {
            print("bleh");
        }
    }
}
