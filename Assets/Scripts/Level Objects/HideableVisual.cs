using UnityEngine;

namespace Level_Objects
{
    public abstract class HideableVisual : MonoBehaviour
    {
        public abstract void Hide(float alpha);
        public abstract void Show();
    }
}