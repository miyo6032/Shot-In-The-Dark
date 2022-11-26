using Level_Objects;
using UnityEditor;
using UnityEngine;

namespace Game_Service.Front_End_Services
{
    public interface ILightingService : IFrontEndService
    {
        public void RegisterSpriteToHide(HideableVisual spriteRenderer);
        public void ShowSpritesInRadius(Vector3 pos, float radius);
    }
}