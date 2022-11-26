using UnityEngine;

namespace Level_Objects
{
    public class HideableTarget : HideableVisual
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        [SerializeField] SpriteRenderer shirtRenderer;
        [SerializeField] SpriteRenderer pantsRenderer;
        
        public override void Hide(float alpha)
        {
            LightingHandler.SetReducedAlpha(spriteRenderer, alpha);
            LightingHandler.SetReducedAlpha(shirtRenderer, alpha);
            LightingHandler.SetReducedAlpha(pantsRenderer, alpha);
        }

        public override void Show()
        {
            LightingHandler.RestoreAlpha(spriteRenderer);
            LightingHandler.RestoreAlpha(shirtRenderer);
            LightingHandler.RestoreAlpha(pantsRenderer);
        }
    }
}