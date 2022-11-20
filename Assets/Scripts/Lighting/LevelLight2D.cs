using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Lighting
{
    public class LevelLight2D : LevelLight
    {
        public override void TurnOff()
        {
            gameObject.SetActive(false);
        }
    }
}