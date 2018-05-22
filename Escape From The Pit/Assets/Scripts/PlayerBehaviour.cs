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
        //if the scene is scene 1 the player is automatically given full health
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetInt("Health", startHealth);
            playerHealth = startHealth;
        }
        else if (PlayerPrefs.HasKey("Health"))
        {
            //if it isn't level 1 the player is given their health from the player prefs carried over from the previous level
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
            //when the player is clicking play the audio source linked to it
            GetComponent<AudioSource>().Play();
            //when the player is clicking set isfiring to true so the animation will play
            GetComponent<Animator>().SetBool("isFiring", true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            //set isfiring to false so the animation stops
            GetComponent<Animator>().SetBool("isFiring", false);
        }

        if (playerHealth > 100)
        {
            //if the player health exceeds 100 bring it back down to the maximum
            playerHealth = 100;
            //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
            healthBar.value = playerHealth;
            SendHealthData();
        }
	}

    public void TakeDamage(int damage)
    {
        //when the player takes damage lower health and update the player prefs
        playerHealth = PlayerPrefs.GetInt("Health") - damage;
        PlayerPrefs.SetInt("Health", playerHealth);

        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(whitecolor());

        //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
        //adjust the size of the health bar to keep in time with the player losing health
        healthBar.value = playerHealth;
        SendHealthData();

        if (playerHealth <= 0)
        {
            //when the player loses all health invoke the die function
            Die();
        }
    }

    public void HealPlayer(int heal)
    {
        //when called heal the player by adding to the health player prefrence
        playerHealth = PlayerPrefs.GetInt("Health") + heal;
        SendHealthData();
        //healthBar.sizeDelta = new Vector2(playerHealth, healthBar.sizeDelta.y);
    }

    void Die()
    {
        //when invoked move to the game over screen
        SceneManager.LoadScene("Game Over");
    }

    void SendHealthData()
    {
        //update the player health 
        healthBar.value = playerHealth;
        if (OnUpdateHealth != null)
        {
            OnUpdateHealth(playerHealth);
        }
    }

    public string targetTag = "Weapon";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //when colliding with the new weapon destroy the current player
        if (collision.gameObject.tag == targetTag)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

}
