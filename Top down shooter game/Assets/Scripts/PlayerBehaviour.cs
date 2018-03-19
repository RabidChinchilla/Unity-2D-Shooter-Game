using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;

    public int health = 100;

    private Animator gunAnim;

	// Use this for initialization
	void Start () {
        gunAnim = GetComponent<Animator>();

        SendHealthData();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("Is Firing", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("Is Firing", false);
        }
	}

    public void TakeDamage(int damage)
    {
        health -= damage;

        SendHealthData();

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(health);
        }
    }
}
