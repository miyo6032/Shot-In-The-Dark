using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game_Service.Services
{
    public class ColorService : MonoBehaviour, IColorService
    {
        [SerializeField] private ColorDesc[] randomColors;
        private ColorDesc targetColor;
        private List<ColorDesc> colorsNotTarget;

        public void Init()
        {
            targetColor = randomColors[Random.Range(0, randomColors.Length)];
            Debug.Log(targetColor.name);
            colorsNotTarget = randomColors.ToList();
            colorsNotTarget.Remove(targetColor);
        }

        public string GetTargetColorDescription()
        {
            return targetColor.name;
        }

        public Color GetTargetColor()
        {
            return targetColor.color;
        }

        public Color GetRandomColor()
        {
            return colorsNotTarget[Random.Range(0, colorsNotTarget.Count)].color;
        }
    }
    
    [Serializable]
    public class ColorDesc
    {
        public Color color;
        public string name;
    }
}