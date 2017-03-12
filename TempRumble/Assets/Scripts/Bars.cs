using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bars : MonoBehaviour {

    public Image imageBar;
    public float fillSpeed;
    public float health, maxhealth;
    private float saveDamage;
    private bool alreadyMoving;


    void Start() {
        health = maxhealth;
        imageBar = GetComponent<Image>();// place the class on the image you want to be the bar and it will asign itself.
    }

    void Update() {// remove later, no update needed

        if (Input.GetButtonDown("Fire2")) {
            StartCoroutine(ChangeBar(maxhealth, maxhealth));
            health = maxhealth;
        }
    }

    public void GetDamage(float damage) {
        if (!alreadyMoving) {
            health -= damage;
            StartBar(maxhealth, health);
        }
        else {
            saveDamage += damage;
        }
    }

    public void StartBar(float maxAmount, float CurrentAmount) {//when you want to activate the bar changer start it by giving a value of the max amount (max health, max mana ect.) and the currentAmount ( current health, current mana ect.)
        StopCoroutine(ChangeBar(0, 0));
        StartCoroutine(ChangeBar(maxAmount, CurrentAmount));
        alreadyMoving = true;
    }

    public IEnumerator ChangeBar(float maxAmount, float currentAmount) {
        float currentFill = imageBar.fillAmount;
        float newFill = 1 / maxAmount * currentAmount;

        newFill = Mathf.Round(newFill * 100F) / 100F;

        if (newFill <= currentFill) {
            currentFill -= 0.05F * fillSpeed * Time.deltaTime;
        }
        else {
            currentFill += 0.05F * fillSpeed * Time.deltaTime;
        }

        currentFill = Mathf.Round(currentFill * 100F) / 100F;
        imageBar.fillAmount = currentFill;

        yield return new WaitForSeconds(0);

        if (currentFill == newFill) {
            StopCoroutine(ChangeBar(0, 0));
            alreadyMoving = false;
            GetDamage(saveDamage);
            saveDamage = 0;
        }
        else {
            StartCoroutine(ChangeBar(maxAmount, currentAmount));
        }
    }

}
