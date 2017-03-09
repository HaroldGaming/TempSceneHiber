using UnityEngine;
using System.Collections;

public class FightControll : MonoBehaviour {

    //private bool charging;
    private FistAnimations fistClass;

    void Start() {
        fistClass = GetComponent<FistAnimations>();
    }

    void Update() {

        if(Input.touchCount > 0 && Input.GetTouch(0).phase != TouchPhase.Stationary) {
            fistClass.Attack(fistClass.damage);
        }

        if (Input.GetTouch(0).phase == TouchPhase.Stationary) {
            fistClass.ChargeAttack(true);
            fistClass.allowAttack = false;
            fistClass.ChargeAttack(true);
            fistClass.charging = true;
            print("charging");
        }
        else {
            if (fistClass.charging) {
                fistClass.ChargeAttack(false);
                fistClass.charging = false;
            }
        }
    }
}
