using Platformer;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth = 3;
    public Slider slider;

    public GameManager gameManager;

    private bool isDead;

    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if (health <= 0 && !isDead) 
        {
            isDead = true;
            audioManager.PlaySFX(audioManager.death);
            gameManager.gameOver();
            Destroy(gameObject);
        }
    }

}
