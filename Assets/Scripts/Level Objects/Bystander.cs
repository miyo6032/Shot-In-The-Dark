using System;
using Game_Service;
using Game_Service.Front_End_Services;
using UnityEngine;

namespace Level_Objects
{
    public class Bystander : MonoBehaviour
    {
        [SerializeField] SpriteRenderer spriteRenderer;

        private void Start()
        {
            FrontEndServiceProvider.GetService<ILightingService>().RegisterSpriteToHide(spriteRenderer);
        }
    }
}