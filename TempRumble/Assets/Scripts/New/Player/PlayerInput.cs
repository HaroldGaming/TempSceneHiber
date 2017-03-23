using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private LightAttack lightAttackClass;
    private MediumAttack mediumAttackClass;
    private HeavyAttack heavyAttackClass;
    private PlayerDefense playerDefenseClass;
    private PlayerDash playerDashClass;
    public string attackClassString;

	void Start () {
        lightAttackClass = GetComponent<LightAttack>();
        mediumAttackClass = GetComponent<MediumAttack>();
        heavyAttackClass = GetComponent<HeavyAttack>();
        playerDefenseClass = GetComponent<PlayerDefense>();
        playerDashClass = GetComponent<PlayerDash>();

	}

    void Update() {
        switch (attackClassString) {
            case "Light":
                if (Input.GetButtonDown("Fire1")) {
                    lightAttackClass.NormalAttack(lightAttackClass.damage);
                }
                break;
            case "Medium":
                if (Input.GetButtonDown("Fire1")) {
                    mediumAttackClass.NormalAttack(mediumAttackClass.damage);
                }
                break;
            case "Heavy":
                if (Input.GetButtonDown("Fire1")) {
                    heavyAttackClass.NormalAttack(heavyAttackClass.damage);
                }
                break;
        }
    }
}
