using UnityEngine;

namespace Game_Service
{
    public class FrontEndServiceProvider
    {
        private static GameServiceRegistry<IFrontEndService> Registry { get; set; }

        public static void RegisterServices(FrontEndServices frontEndServices)
        {
            Debug.Log("Registering frontend services...");
            GameServiceRegistry<IFrontEndService> gameServiceRegistry = new GameServiceRegistry<IFrontEndService>();
            gameServiceRegistry.StartRegistration();
            // gameServiceRegistry.RegisterService<IActionPanel, ActionPanel>(frontEndServices.ActionPanel);
            gameServiceRegistry.FinishRegistration();
            Registry = gameServiceRegistry;
        }

        public static T GetService<T>() where T : class, IFrontEndService
        {
            return Registry.Lookup<T>();
        }
    }

    public class FrontEndServices
    {
    }
}