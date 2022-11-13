using UnityEditor;
using UnityEngine;

namespace Game_Service.Front_End_Services
{
    public interface ILightingService : IFrontEndService
    {
        public void RegisterSpriteToHide(SpriteRenderer spriteRenderer);
    }
}