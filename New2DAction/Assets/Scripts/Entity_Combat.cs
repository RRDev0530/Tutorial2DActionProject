using UnityEngine;

public class Entity_Combat : MonoBehaviour
{

    [Header("Combat Info")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRidus;
    [SerializeField] private LayerMask whatisTarget;
    [SerializeField] private float attackDamage;

    public void DoAttack()
    {
        GetDetectedColliders();

        foreach(var target in GetDetectedColliders())
        {
            IDamageable damageable = target.GetComponent<IDamageable>();
            damageable?.TakeDamage(attackDamage, transform);

        }
                  

    }

    public Collider2D[] GetDetectedColliders()
    {
        return Physics2D.OverlapCircleAll(attackPoint.position, attackRidus, whatisTarget);
    }
    
private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, attackRidus);
    }
}
