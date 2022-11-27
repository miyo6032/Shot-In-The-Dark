using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Level_Objects
{
    public class TargetShirtColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void Start()
        {
            spriteRenderer.color = FrontEndServiceProvider.GetService<IColorService>().GetTargetColor();
        }
    }
}