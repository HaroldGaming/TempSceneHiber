using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

    private LightAttack lightAttackClass;
    private MediumAttack mediumAttackClass;
    private HeavyAttack heavyAttackClass;
    private PlayerDefense playerDefenseClass;
    private PlayerDash playerDashClass;
    public string attackClassString;
    private float checkForCharge;

	void Start () {
        lightAttackClass = GetComponent<LightAttack>();
        mediumAttackClass = GetComponent<MediumAttack>();
        heavyAttackClass = GetComponent<HeavyAttack>();
        playerDefenseClass = GetComponent<PlayerDefense>();
        playerDashClass = GetComponent<PlayerDash>();

	}

    void Update() {

        if (Input.GetButton("Fire1")){
            checkForCharge += 1 * Time.deltaTime;
            print(checkForCharge);
        }


        if (Input.GetButtonUp("Fire1")) {
            if(checkForCharge <= 1F) {
                switch (attackClassString) {
                    case "Light":
                        LightAttack();
                        break;
                    case "Medium":
                        MediumAttack();
                        break;
                    case "Heavy":
                        HeavyAttack();
                        break;
                }
            }
            else {
                if (Input.GetButtonUp("Fire1")) {
                    switch (attackClassString) {
                        case "Light":
                            LightChargeAttack();
                            break;
                        case "Medium":
                            MediumChargeAttack();
                            break;
                        case "Heavy":
                            HeavyChargeAttack();
                            break;
                    }
                } 
            }
            checkForCharge = 0;
        }
    }

    public void LightAttack() {
        lightAttackClass.NormalAttack(lightAttackClass.damage);
    }

    public void MediumAttack() {
        mediumAttackClass.NormalAttack(mediumAttackClass.damage);
    }

    public void HeavyAttack() {
        heavyAttackClass.NormalAttack(heavyAttackClass.damage);
    }

    public void LightChargeAttack() {
        lightAttackClass.CharageAttack(lightAttackClass.damage, checkForCharge);
    }

    public void MediumChargeAttack() {
        mediumAttackClass.CharageAttack(mediumAttackClass.damage, checkForCharge);
    }

    public void HeavyChargeAttack() {
        heavyAttackClass.CharageAttack(heavyAttackClass.damage, checkForCharge);
    }
}
