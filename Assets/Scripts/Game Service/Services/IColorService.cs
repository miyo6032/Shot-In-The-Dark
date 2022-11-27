using UnityEngine;

namespace Game_Service.Services
{
    public interface IColorService : IFrontEndService
    {
        public string GetTargetColorDescription();
        public Color GetTargetColor();
        public Color GetRandomColor();
    }
}