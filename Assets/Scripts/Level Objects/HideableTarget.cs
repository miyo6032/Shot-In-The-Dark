using UnityEngine;

namespace Level_Objects
{
    public class HideableTarget : HideableVisual
    {
        [SerializeField] SpriteRenderer spriteRenderer;
        public override void Hide(float alpha)
        {
            LightingHandler.SetReducedAlpha(spriteRenderer, alpha);
        }

        public override void Show()
        {
            LightingHandler.RestoreAlpha(spriteRenderer);   
        }
    }
}