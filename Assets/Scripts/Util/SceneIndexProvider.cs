using UnityEngine;

namespace Util
{
    [CreateAssetMenu(fileName = "Scene Index Provider", menuName = "ScriptableObjects/SceneIndexProvider", order = 0)]
    public class SceneIndexProvider : ScriptableObject
    {
        [SerializeField] private int sceneIndex;
        public int Index => sceneIndex;
    }
}