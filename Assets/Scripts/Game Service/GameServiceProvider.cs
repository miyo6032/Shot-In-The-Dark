using Game_Service.Services;
using UnityEngine;

namespace Game_Service
{
    public static class GameServiceProvider
    {
        private static GameServiceRegistry<IGameService> Registry { get; set; }

        public static void RegisterServices(BackendServices backendServices)
        {
            Debug.Log("Registering backend services...");
            GameServiceRegistry<IGameService> gameServiceRegistry = new GameServiceRegistry<IGameService>();
            gameServiceRegistry.StartRegistration();
            gameServiceRegistry.RegisterService<IGameState, GameStateManager>(backendServices.GameStateManager);
            gameServiceRegistry.FinishRegistration();
            Registry = gameServiceRegistry;
        }

        public static T GetService<T>() where T : class, IGameService
        {
            return Registry.Lookup<T>();
        }
    }

    public class BackendServices
    {
        public BackendServices(GameStateManager gameStateManager)
        {
            GameStateManager = gameStateManager;
        }

        public GameStateManager GameStateManager { get; }
    }
}