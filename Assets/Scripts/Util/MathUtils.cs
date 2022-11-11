using UnityEngine;

namespace Util
{
    public static class MathUtils
    {
        public static Quaternion Get2DRotationFromDirection(Vector3 dir)
        {
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
        public static Vector2 CalculateShootDirection2D(Vector3 mousePos, Vector3 pos)
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 worldMousePos2d = worldMousePos;
            Vector2 pos2d = pos;
            return (worldMousePos2d - pos2d).normalized;
        }
    }
}