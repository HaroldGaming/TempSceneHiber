using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private PlayerAttack playerAttackClass;
    private PlayerDefense playerDefenseClass;
    private PlayerDash playerDashClass;

	void Start () {
        playerAttackClass = GetComponent<PlayerAttack>();
        playerDefenseClass = GetComponent<PlayerDefense>();
        playerDashClass = GetComponent<PlayerDash>();

	}
	
	void Update () {
	
	}
}
