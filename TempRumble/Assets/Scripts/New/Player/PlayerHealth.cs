using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    private int health;
    public bool invulnerable;
    private Bars healthBar;
    public GameObject damagePartical;


    void Start () {
        health = maxHealth;
        healthBar = GetComponent<Bars>();
	}

    public void GetDamage(int damage) {
        if (!invulnerable) {
            health -= damage;
            if (health <= 0) {
                health = 0;
            }
            else {
                healthBar.StartBar(maxHealth, health, true);
                Instantiate(damagePartical, transform.position, (damagePartical.transform.localRotation));//remove later
            }
        }

    }

    public void FullHealth() {
        health = maxHealth;
        healthBar.StartBar(maxHealth, health, false);
    }
}
