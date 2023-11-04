using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target; // Change this from Transform to GameObject

    public float chaseRange = 10f;
    public float moveSpeed = 1.5f;
    public float contactRange = 1.0f; // Define the contact range for the enemy.
    public float attackCooldown = 2.0f; // Time to wait between attacks.
    
    public Material chasingMaterial; // Assign the red material in the Inspector.

    public int damageAmount = 5;

    private Material originalMaterial;
    private Renderer coneRenderer;
    private bool canAttack = true;

    void Start()
    {
        // Initialize the coneRenderer and originalMaterial.
        coneRenderer = GetComponent<Renderer>();
        originalMaterial = coneRenderer.material;
    }

    void Update()
    {
        if (target == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToPlayer <= chaseRange)
        {
            coneRenderer.material = chasingMaterial;
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Check if the enemy is in contact with the player and can attack.
            if (distanceToPlayer < contactRange && canAttack)
            {
                // Deal damage to the player.
                target.GetComponent<PlayerHealth>().TakeDamage(damageAmount);

                // Start the attack cooldown.
                StartCoroutine(AttackCooldown());
            }
        }
        else
        {
            coneRenderer.material = originalMaterial;
        }
    }

    IEnumerator AttackCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
