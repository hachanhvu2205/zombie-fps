using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField]float damage = 25f;
    [SerializeField]GameObject damageDisplay;
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        damageDisplay.SetActive(false);
    }

    public void AttackHitEvent() {
        if(target == null) return;
        target.TakeDamage(damage);
        StartCoroutine(DamageDisplay());
    }

    IEnumerator DamageDisplay() {
        damageDisplay.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        damageDisplay.SetActive(false);
    }
}
