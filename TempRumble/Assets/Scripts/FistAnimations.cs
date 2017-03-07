using UnityEngine;
using System.Collections;

public class FistAnimations : MonoBehaviour {

    public GameObject[] fists;
    private int fist;


    public void Attack() {
        if(fist == 0) {
            fist = 1;
        }
        else {
            fist = 0;
        }

        fists[fist].GetComponent<Fists>().Attacks();
    }

}
