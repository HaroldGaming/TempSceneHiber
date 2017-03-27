using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bars : MonoBehaviour {

    public Image imageBar;
    public float fillSpeed;
   // public float health, maxhealth;
    private float saveDamage;
    private bool alreadyMoving;
    private int counter;


    void Start() {
      //  health = maxhealth;
       // imageBar = GetComponent<Image>();// place the class on the image you want to be the bar and it will asign itself.
    }

    public void StartBar(float maxAmount, float CurrentAmount, bool reduce) {//when you want to activate the bar changer start it by giving a value of the max amount (max health, max mana ect.) and the currentAmount ( current health, current mana ect.)
        StopCoroutine(ChangeBar(0, 0, reduce));
        StartCoroutine(ChangeBar(maxAmount, CurrentAmount, reduce));
        alreadyMoving = true;
    }

    public IEnumerator ChangeBar(float maxAmount, float currentAmount, bool reduce) {
        float currentFill = imageBar.fillAmount;
        float newFill = 1 / maxAmount * currentAmount;

        newFill = Mathf.Round(newFill * 100F) / 100F;


        if (reduce) {
            currentFill -= 0.05F * fillSpeed * Time.deltaTime;
        }
        else {
            currentFill += 0.05F * fillSpeed * Time.deltaTime;
        }

        print(currentFill);
        print(newFill);
        imageBar.fillAmount = currentFill;

        yield return new WaitForSeconds(0);

        if (reduce) {
            if (newFill >= currentFill) {
                StopCoroutine(ChangeBar(0, 0, reduce));
                alreadyMoving = false;
                saveDamage = 0;
                counter = 0;
            }
            else {
                StartCoroutine(ChangeBar(maxAmount, currentAmount, reduce));
            }
        }
        else {
            if (newFill <= currentFill) {
                StopCoroutine(ChangeBar(0, 0, reduce));
                alreadyMoving = false;
                saveDamage = 0;
                counter = 0;
            }
            else {
                print(counter);
                StartCoroutine(ChangeBar(maxAmount, currentAmount, reduce));
            }
        }
    }

}
