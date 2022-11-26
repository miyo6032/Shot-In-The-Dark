using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level_Objects
{
    public class RandomizeColor : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Color[] randomColors;

        private void Start()
        {
            var spriteRendererColor = randomColors[Random.Range(0, randomColors.Length)];
            spriteRenderer.color = new Color(spriteRendererColor.r, spriteRendererColor.g, spriteRendererColor.b, spriteRenderer.color.a);
        }
    }
}