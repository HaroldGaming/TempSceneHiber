using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bars : MonoBehaviour {

    public float startHealth , chargePerMin, barSpeedUp, barSpeedDown, timeBeforeRecharge;
    private float currentHealth, timer, increasePerSecond, maxHealth;
    public Image shieldFillBar; //shieldbar for the hud

    // Use this for initialization
    void Start () {
        currentHealth = startHealth;
        maxHealth = startHealth;
        increasePerSecond = (chargePerMin / 60);
    }

    void Update() {

        if (currentHealth <= maxHealth) { //if your health is below max the hud and health recharges will be activated
            ShieldRecharge();
            HudShield();
        }
    }

    void ShieldRecharge() {
        if (timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            if (currentHealth <= maxHealth) {//increased your shield per second.
                currentHealth += increasePerSecond * Time.deltaTime;
            }
            else {// makes sure it doesn't come above the max
                currentHealth = maxHealth;
            }
        }
    }

    void HudShield() {//this function is setting the slider on the image. it will gaing and deplate with a simple formula check
        float newBar = (1 / maxHealth * currentHealth);
        if (newBar <= 0) {
            newBar = 0;
        }
        float currentBar = shieldFillBar.fillAmount;
        if (currentBar >= newBar) {
            if (currentBar >= 0) {
                if (timer >= 0) {
                    currentBar -= barSpeedDown * Time.deltaTime;
                }
            }
            else {
                currentBar = 0;
            }
        }
        else {
            if (currentBar <= 1) {
                if (currentBar <= newBar) {
                    if (timer <= 0) {
                        currentBar += barSpeedUp * Time.deltaTime;
                    }
                }
            }
            else {
                currentBar = 1;
            }
        }
        shieldFillBar.fillAmount = currentBar;
    }

    public void GetDamage(float damage) {//player getting damaged, there is a damage reduction if you get hit again before x seconds have past.
        print("ohno");
        damage = damage / 100;
        timer = timeBeforeRecharge;
        currentHealth -= damage;
    }

}
