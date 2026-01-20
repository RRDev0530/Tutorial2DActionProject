using UnityEngine;

public class Chest : MonoBehaviour, IDamageable
{
    private Animator anim => GetComponentInChildren<Animator>();
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    private Entity_VFX vfx => GetComponent<Entity_VFX>();

    [Header("Open Details")]
    [SerializeField] private Vector2 knockback;

    public void TakeDamage(float damage, Transform damageDealer)
    {
        vfx.PlayHitVFX();

        anim.SetBool("openchest", true);
        rb.linearVelocity = knockback;
        rb.angularVelocity = Random.Range(-200f, 200f);

    }
}
