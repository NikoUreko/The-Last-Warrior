using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = hitTransform.GetComponent<PlayerHealth>();
            if (playerHealth != null && !playerHealth.isDead)
            {
                Debug.Log("Hit Player");
                playerHealth.TakeDamage(15); 
            }
               
        }
        Destroy(gameObject);
    }
}
