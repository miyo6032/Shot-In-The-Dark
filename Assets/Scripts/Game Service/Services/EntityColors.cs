using UnityEngine;

namespace Game_Service.Services
{
    [CreateAssetMenu(fileName = "EntityColors", menuName = "ScriptableObjects/EntityColors", order = 0)]
    public class EntityColors : ScriptableObject
    {
        public ColorDesc[] randomColors;
        public Color[] skinColors;
    }
}