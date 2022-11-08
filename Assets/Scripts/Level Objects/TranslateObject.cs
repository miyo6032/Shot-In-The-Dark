using UnityEngine;

namespace Level_Objects
{
    public class TranslateObject : MonoBehaviour
    {
        private Vector2 translation;

        public void Init(Vector2 trans)
        {
            translation = trans;
        }

        private void FixedUpdate()
        {
            transform.Translate(translation);
        }
    }
}
