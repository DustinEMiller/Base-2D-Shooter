using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSpriteFeedback : Feedback
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private Material flashMaterial;
    [SerializeField] private Shader originalMaterialShader = null;

    private void Start()
    {
        originalMaterialShader = spriteRenderer.material.shader;
    }
    public override void CreateFeedback()
    {
        if (spriteRenderer.material.HasProperty("_MakeSolidColor") == false)
        {
            spriteRenderer.material.shader = flashMaterial.shader;
        }

        spriteRenderer.material.SetInt("_MakeSolidColor", 1);
        StartCoroutine(WaitBeforeChangingBack());
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMaterialShader;
    }

    IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(flashTime);
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        }
        else
        {
            spriteRenderer.material.shader = originalMaterialShader;
        }
    }
}
