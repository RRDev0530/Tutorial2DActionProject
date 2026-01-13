using System.Collections;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{

    private Entity_VFX onDamageVFX;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();

    [Header("Knockback info")]
    [SerializeField]private float knockbackDuration = 0.3f;
    [SerializeField]private Vector2 knockbackForce;
    [SerializeField]private Vector2 heavy_knockbackForce;
    [SerializeField]private float knockbackDamageThreshold = 20f;

    private Coroutine knockbackCourintine;

    [SerializeField] private float MaxHP;
    private float currentHP;
    private bool isDead;
    private void Awake()
    {
        onDamageVFX = GetComponent<Entity_VFX>();
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {         
        ReduceHealth(damage);
        onDamageVFX?.PlayHitVFX();
        PlayKnockback();

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private IEnumerator OnKnockBackCo(float damage, Transform damageDealer)
    {
        rb.linearVelocity = CalculateKnockBackForce(damage,damageDealer);

        yield return new WaitForSeconds(knockbackDuration);
        rb.linearVelocity = Vector2.zero;

    }

    private Vector2 CalculateKnockBackForce(float damage, Transform damageDealer)
    {
        float direction = transform.position.x > damageDealer.position.x ? 1 : -1;
        Vector2 knockbackF = damage / MaxHP >= knockbackDamageThreshold ? knockbackForce : heavy_knockbackForce;

        return knockbackF * direction;

    }

    private void PlayKnockback()
    {
        if(knockbackCourintine != null)
        {
            StopCoroutine(knockbackCourintine);
        }

        StartCoroutine(OnKnockBackCo(currentHP, transform));
    }


    private void ReduceHealth(float damage)
    {
        if(isDead) 
            return;

        MaxHP -= damage;
        Debug.Log(transform.name + " took " + damage + " damage. Remaining Health: " + MaxHP);

    }

    private void Die()
    {
        isDead = true;
        Debug.Log(transform.name + " is dead.");
    }

}
