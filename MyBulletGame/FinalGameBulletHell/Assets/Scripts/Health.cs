using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public int startingHealth = 100;
    [ShowOnly] public int currentHealth;
    public int scoreOnDamage;
    public int scoreOnDeath;
    public Slider healthSlider;

	private LevelManager levelManager;

	private void Start()
	{
		levelManager = FindObjectOfType<LevelManager>();
	}

	private void OnValidate()
	{
		// zorgt er voor dat de current health het zelfde blijft als je begint
        currentHealth = startingHealth;
	}

	// zorgt er voor dat als de enemy of player object geraakt wordt 
	public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;

		// gaat dood als je minder dan 1 health hebt
        if (currentHealth <= 0)
        {
			levelManager.StartCoroutine(levelManager.GameOver(tag));
			Destroy(gameObject);
            ScoreManager.UpScore(scoreOnDeath);
        }
        else
        {
            ScoreManager.UpScore(scoreOnDamage);
        }
			
    }
}
