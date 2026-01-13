using UnityEngine;

public class Entity_AnimationTrigger : MonoBehaviour
{

    private Entity entity;
    private Entity_Combat entityCombat;

    private void Awake()
    {     
        entity = GetComponentInParent<Entity>();
        entityCombat = GetComponentInParent<Entity_Combat>();
    }

    private void AnimationEvent_AttackFinishedTrigger()
    {
        entity.SetAnimationFinished();
    }

    private void AnimationEvent_HitFrameTrigger()
    {
        entityCombat.DoAttack();
    }


}
