using System.Collections;
using UnityEngine;

public class Entity_Health : MonoBehaviour
{

    private Entity_VFX onDamageVFX;
    protected Entity entity;

    [Header("Knockback info")]
    [SerializeField]private float knockbackDuration = 0.3f;
    [SerializeField]private Vector2 knockbackForce = new Vector2(3f,2f);
    [SerializeField]private Vector2 knockbackForce_Heavy = new Vector2(6f, 3f);
    [SerializeField]private float knockbackDamageThreshold = 0.2f;

    [SerializeField] private float MaxHP;
    private float currentHP;
    private bool isDead;
    protected bool isDeadAnimFinished;
    private void Awake()
    {
        onDamageVFX = GetComponent<Entity_VFX>();
        entity = GetComponent<Entity>();

        currentHP = MaxHP;
    }

    public virtual void TakeDamage(float damage, Transform damageDealer)
    {         
        ReduceHealth(damage);
        onDamageVFX?.PlayHitVFX();
        entity.RecieveKnockback(CalculateKnockback(damage, damageDealer), knockbackDuration);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    

    private Vector2 CalculateKnockback(float damage, Transform damageDealer)
    {

        Vector2 knockback = damage / MaxHP <= knockbackDamageThreshold ? knockbackForce : knockbackForce_Heavy;
        knockback.x *= damageDealer.position.x < transform.position.x ? 1 : -1;

        return knockback;

    }

    private void ReduceHealth(float damage)
    {
        if(isDead) 
            return;

        currentHP -= damage;

    }

    public virtual void Die()
    {
        isDead = true;
        
    }

    public void DeadAnimFinished()
    {
       isDeadAnimFinished = true;
    }

}
