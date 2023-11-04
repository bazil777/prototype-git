using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Initial health value
    public Material deathMaterial; // Reference to the material to use when health reaches 0
    public int maxHealth = 100; // The maximum health value

    private Renderer capsuleRenderer;
    private Material originalMaterial;

    private void Start()
    {
        capsuleRenderer = GetComponent<Renderer>(); // Fix the access to the Renderer component
        originalMaterial = capsuleRenderer.material;
    }

    // Method for taking damage
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0; // Ensure health doesn't go negative
            // Handle player death or other game logic here
            OnPlayerDeath();
        }
        UpdateMaterial();
    }

    // Method for healing
    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
        {
            health = maxHealth; // Cap health at the maximum value
        }
        UpdateMaterial();
    }

    // Change the material when health reaches 0
    private void OnPlayerDeath()
    {
        capsuleRenderer.material = deathMaterial;
        // You can add more death-related actions here
    }

    // Update the material to the original when health changes
    private void UpdateMaterial()
    {
        capsuleRenderer.material = originalMaterial;
    }

    // Method to increase health
    public void IncreaseHealth(int increaseAmount)
    {
        Heal(increaseAmount);
    }
}
