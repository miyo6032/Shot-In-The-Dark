﻿using UnityEngine;

namespace Game_Service.Services
{
    public interface IGamePauseService : IGameService
    {
        public void PauseGame();
        public void UnpauseGame();
    }

    public class GamePauseService : IGamePauseService
    {
        public void PauseGame()
        {
            Time.timeScale = 0f;
        }

        public void UnpauseGame()
        {
            Time.timeScale = 1;
        }
    }
}