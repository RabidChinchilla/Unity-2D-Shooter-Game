using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int playerHealth;
    public int startHealth = 100;
    private Animator gunAnim;

	// Use this for initialization
	void Start () {
        gunAnim = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("Health", startHealth);
            playerHealth = startHealth;
        }
        else if (PlayerPrefs.HasKey("Health"))
        {
            playerHealth = PlayerPrefs.GetInt("Health");
        }
        else
        {
            PlayerPrefs.SetInt("Health", startHealth);
            playerHealth = startHealth;
        }
        
        SendHealthData();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>().Play();
            GetComponent<Animator>().SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().SetBool("isFiring", false);
        }
	}

    public void TakeDamage(int damage)
    {
        
        playerHealth = PlayerPrefs.GetInt("Health") - damage;
        PlayerPrefs.SetInt("Health", playerHealth);

        SendHealthData();

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    void SendHealthData()
    {
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(playerHealth);
        }
    }
}
