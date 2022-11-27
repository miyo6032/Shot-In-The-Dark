using Game_Service;
using Game_Service.Services;
using UnityEngine;

namespace Level_Objects
{
    public class RandomShirtColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        
        private void Start()
        {
            Color spriteRendererColor = FrontEndServiceProvider.GetService<IColorService>().GetRandomColor();
            spriteRenderer.color = new Color(spriteRendererColor.r, spriteRendererColor.g, spriteRendererColor.b, spriteRenderer.color.a);
        }
    }
}