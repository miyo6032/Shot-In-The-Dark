using UnityEngine;

namespace Lighting
{
    public class SpriteLight2D : LevelLight
    {
        [SerializeField] private SpriteRenderer sprite;
        public override void TurnOff()
        {
            sprite.color = Color.black;
            gameObject.SetActive(false);
        }
    }
}