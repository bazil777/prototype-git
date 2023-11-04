using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damageAmount = 10; // Damage amount the player's attack deals.
    public float maxAttackRange = 5.0f; // Maximum attack range.

    void Update()
    {
        // Check for player input to attack (F or f key).
        if (Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.F))

        {
            Attack();
        }
    }

    void Attack()
    {
        // Create a ray in the forward direction.
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Check if the ray hits something within the max attack range.
        if (Physics.Raycast(ray, out hit, maxAttackRange))
        {
            // Check if the hit object has an EnemyAI component.
            EnemyAI enemy = hit.collider.GetComponent<EnemyAI>();

            if (enemy != null)
            {
                // Deal damage to the enemy.
                enemy.TakeDamage(damageAmount);
            }
        }
    }
}
