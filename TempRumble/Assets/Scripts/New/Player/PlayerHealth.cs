using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth;
    private int health;
    public bool invulnerable;


    void Start () {
        health = maxHealth;
	}
	
	void Update () {
	
	}
}
