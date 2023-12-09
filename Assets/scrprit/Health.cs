using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private string objectName = "UnnamedObject";
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider slider;

    [SerializeField] public GameObject deathEffectPrefab; // Assign your FX effect prefab in the Inspector
    [SerializeField] private bool effectTriggered = false;

   
   

    void Start()
    {
        currentHealth = maxHealth;

        // Check if the slider is not null before accessing it
        if (slider != null)
        {
            slider.value = maxHealth;
        }
       
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
        if (Input.GetKeyDown(KeyCode.O) && (objectName == "Player"))
        {
            TakeDamage(50);
        }
        if (Input.GetKeyDown(KeyCode.P) && (objectName == "Enemy"))
        {
            TakeDamage(50);
        }
      
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(objectName + " health: " + currentHealth);

        // Check if the slider is not null before accessing it
        if (slider != null)
        {
            slider.value = currentHealth;
        }

        if (currentHealth <= 0 && !effectTriggered)
        {
            Die();
           
        }

       
    }

    void Die()
    {
        Debug.Log(objectName + " has died.");

        if (objectName == "Player")
        {

           // TriggerFX();
            SceneManager.LoadScene("LoseScene");
        }
        else if (objectName == "Enemy")
        {
           // TriggerFX();
            SceneManager.LoadScene("WinScene");
        }
        HandleDeathEffect();
       
    }

    void HandleDeathEffect()
    {
        // Set the flag to indicate that the effect has been triggered
        effectTriggered = true;
        Debug.Log(effectTriggered);
        // Instantiate the death effect at the object's position
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position, Quaternion.identity);
        }
        
        Destroy(gameObject);
    }

}
