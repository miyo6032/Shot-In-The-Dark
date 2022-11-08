using System;

namespace Game_Service.Services
{
    public interface IGameTimer : IGameService
    {
        public void SetTimer(float time, Action action, Func<float, string> message);
        public void StopTimer();
    }
}