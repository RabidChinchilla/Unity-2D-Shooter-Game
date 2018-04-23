using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour {

    private int health;
    private string gameInfo = "";
    private Rect boxRect = new Rect(10, 10, 300, 20);
    void OnEnable()
    {
        PlayerBehaviour.OnUpdateHealth += HandleonUpdateHealth;
    }
    void OnDisable()
    {
        PlayerBehaviour.OnUpdateHealth -= HandleonUpdateHealth;
    }
    void Start()
    {
        UpdateUI();
    }
    void HandleonUpdateHealth(int newHealth)
    {
        health = newHealth;
        UpdateUI();
    }

    void UpdateUI()
    {
        gameInfo = "Health: " + health.ToString();
    }
    void OnGUI()
    {
        GUI.Box(boxRect, gameInfo);
    }
}
