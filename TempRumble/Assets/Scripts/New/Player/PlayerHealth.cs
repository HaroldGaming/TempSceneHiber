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
        health -= damage;
        healthBar.StartBar(maxHealth, health, true);
        Instantiate(damagePartical, transform.position, transform.rotation);//remove later
    }
}
