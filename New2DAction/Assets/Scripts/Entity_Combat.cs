using UnityEngine;

public class Entity_Combat : MonoBehaviour
{

    [Header("Combat Info")]
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRidus;
    [SerializeField] private LayerMask whatisTarget;

    public void DoAttack()
    {
        GetDetectedColliders();

        foreach(var Target in GetDetectedColliders())
        {
            Entity_Health targetHealth = Target.GetComponent<Entity_Health>();
        
            targetHealth?.TakeDamage(10f, transform);
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
