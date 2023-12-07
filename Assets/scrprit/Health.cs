using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public string objectName = "UnnamedObject";
    public int maxHealth = 100;
    public int currentHealth;
    public float damageTimer = 0f;  // Timer to track time since the last damage
    public float timeToHeal = 10f; // Time required to trigger healing

    public Slider slider;

    void Start()
    {
        currentHealth = maxHealth;
        slider.value = maxHealth;
    }

    private void Update()
    {
        // Input handling for testing scene transitions
        if (Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene("LoseScene");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene("WinScene");
        }
        if (Input.GetKeyDown(KeyCode.O)&& (objectName == "Player"))
        {
            TakeDamage(50);
        }
        if (Input.GetKeyDown(KeyCode.P)&& (objectName == "Enemy"))
        {
            TakeDamage(50);
        }

        // Timer logic
        if (currentHealth < maxHealth)
        {
            damageTimer += Time.deltaTime;

            // Check if it's time to heal
            if (damageTimer >= timeToHeal)
            {
                Heal(2); // Adjust the amount to heal as needed
                damageTimer = 0f; // Reset the timer after healing
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(objectName + " health: " + currentHealth);
        slider.value = currentHealth;

        // Reset the timer when taking damage
        damageTimer = 0f;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int healAmount)
    {
        currentHealth = Mathf.Min(currentHealth + healAmount, maxHealth);
        Debug.Log(objectName + " healed. Current health: " + currentHealth);
        slider.value = currentHealth;
    }

    void Die()
    {
        Debug.Log(objectName + " has died.");

        if (objectName == "Player")
        {
            SceneManager.LoadScene("LoseScene");
        }
        else if (objectName == "Enemy")
        {
            SceneManager.LoadScene("WinScene");
        }

        Destroy(gameObject);
    }
}
