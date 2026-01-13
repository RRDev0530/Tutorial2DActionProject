using System.Collections;
using UnityEngine;

public class Entity_VFX : MonoBehaviour
{

    private SpriteRenderer sr;

    [Header("VFX")]
    [SerializeField] private Material onDamageVFXMaterial;
    [SerializeField] private float hitVFXDuration = 0.1f;
    private Material originalMaterial;
    private Coroutine onDamageVFXCoroutine;

    private void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;
    }

    private IEnumerator OnDamageVFXCo()
    {
        sr.material = onDamageVFXMaterial;
        
        yield return new WaitForSeconds(hitVFXDuration);
        sr.material = originalMaterial;

    }

    public void PlayHitVFX()
    {
        if(onDamageVFXCoroutine != null)
         StopCoroutine(onDamageVFXCoroutine);

        onDamageVFXCoroutine = StartCoroutine(OnDamageVFXCo());

    }
}
