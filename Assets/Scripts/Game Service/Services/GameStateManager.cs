using System;
using System.Collections.Generic;

namespace Game_Service.Services
{
    public class GameStateManager : IGameState
    {
        private readonly List<Action<GameState>> listeners = new();
        private GameState gameState;
        public GameState GameState
        {
            get => gameState;
            set
            {
                foreach (var listener in listeners)
                {
                    listener(value);
                }

                gameState = value;
            }
        }

        public void AddGameStateChangeListener(Action<GameState> listener)
        {
            listeners.Add(listener);
        }
    }

    public interface IGameState : IGameService
    {
        public GameState GameState { get; set; }
        public void AddGameStateChangeListener(Action<GameState> listener);
    }

    public enum GameState
    {
        Setup,
        EmpActivated,
        IsDark,
        TargetHit,
        BystanderHit,
        OutOfTime
    }
}