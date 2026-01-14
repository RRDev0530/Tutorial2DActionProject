using UnityEngine;

public class Entity_AnimationTrigger : MonoBehaviour
{

    private Entity entity;
    private Entity_Combat entityCombat;
    private Entity_Health entityHealth;

    private void Awake()
    {     
        entity = GetComponentInParent<Entity>();
        entityCombat = GetComponentInParent<Entity_Combat>();
        entityHealth = GetComponentInParent<Entity_Health>();
    }

    private void AnimationEvent_AttackFinishedTrigger()
    {
        entity.SetAnimationFinished();
    }

    private void AnimationEvent_HitFrameTrigger()
    {
        entityCombat.DoAttack();
    }

    private void AnimationEvent_DeadFinishedTrigger()
    {
        entityHealth.DeadAnimFinished();
    }

}
