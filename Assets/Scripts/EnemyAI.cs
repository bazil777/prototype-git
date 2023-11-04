using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject target;  // Change this from Transform to GameObject

    public float chaseRange = 10f;
    public float moveSpeed = 1.5f;
    public Material chasingMaterial;  // Assign the red material in the Inspector.

    private Material originalMaterial;
    private Renderer coneRenderer;

    void Start()
    {
        // Initialize the coneRenderer and originalMaterial.
        coneRenderer = GetComponent<Renderer>();
        originalMaterial = coneRenderer.material;
    }

    void Update()
    {
        if (target == null) return; // Check if the target is valid (not null).

        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        if (distanceToPlayer <= chaseRange)
        {
            // Change the material color to red.
            coneRenderer.material = chasingMaterial;

            // Calculate the direction towards the player.
            Vector3 direction = (target.transform.position - transform.position).normalized;

            // Move the enemy towards the player.
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Reset the material color to the original color.
            coneRenderer.material = originalMaterial;
        }
    }
}
