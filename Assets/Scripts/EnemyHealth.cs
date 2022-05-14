using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]float health = 100f;

    public void TakeDamage(float damage) {
        BroadcastMessage("OnDamageTaken");
        health -= damage;
        if(health <= 0) {
            Die();
        }
    }

    void Die() {
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<EnemyAI>().enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        Destroy(gameObject, 10f);
    }
}
