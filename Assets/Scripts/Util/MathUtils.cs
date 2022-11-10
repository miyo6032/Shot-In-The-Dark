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
    }
}