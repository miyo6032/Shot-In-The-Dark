using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Level_Objects
{
    public class TargetSkinColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void Start()
        {
            spriteRenderer.color = FrontEndServiceProvider.GetService<IColorService>().GetTargetSkinColor();
        }
    }
}