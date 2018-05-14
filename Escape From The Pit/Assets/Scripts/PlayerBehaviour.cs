using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerBehaviour : MonoBehaviour {

    public delegate void UpdateHealth(int newHealth);
    public static event UpdateHealth OnUpdateHealth;
    public int playerHealth;
    public int startHealth = 100;
    private Animator gunAnim;
    public Slider healthBar;

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
        healthBar.value = playerHealth;
        //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
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

        if (playerHealth > 100)
        {
            playerHealth = 100;
            //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
            healthBar.value = playerHealth;
            SendHealthData();
        }
	}

    public void TakeDamage(int damage)
    {
        
        playerHealth = PlayerPrefs.GetInt("Health") - damage;
        PlayerPrefs.SetInt("Health", playerHealth);

        //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
        healthBar.value = playerHealth;
        SendHealthData();

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    public void HealPlayer(int heal)
    {
        playerHealth = PlayerPrefs.GetInt("Health") + heal;
        SendHealthData();
        //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
    }

    void Die()
    {
        SceneManager.LoadScene("Game Over");
    }

    void SendHealthData()
    {
        healthBar.value = playerHealth;
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(playerHealth);
        }
    }
}
