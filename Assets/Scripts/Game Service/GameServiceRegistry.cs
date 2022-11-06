using System;
using System.Collections.Concurrent;

namespace Game_Service
{
    public class GameServiceRegistry<TS>
    {
        private readonly ConcurrentDictionary<string, object> services = new();
        private bool registering = true;

        public void RegisterService<TInterface, TImplementation>(TImplementation gameService) where TInterface : TS where TImplementation : TInterface
        {
            if (!registering)
            {
                throw new Exception("Cannot register after registry has been completed");
            }

            var name = typeof(TInterface).Name;
            if (services.ContainsKey(name))
            {
                throw new Exception($"{name} has already been registered");
            }

            services[name] = gameService;
        }

        public T Lookup<T>() where T : class, TS
        {
            if (registering)
            {
                throw new Exception("Cannot access services during registration stage");
            }
            
            var name = typeof(T).Name;
            if (!services.ContainsKey(name))
            {
                throw new Exception($"No service registered for {name}");
            }

            return (T) services[name];
        }

        public void FinishRegistration()
        {
            registering = false;
        }

        public void StartRegistration()
        {
            services.Clear();
            registering = true;
        }
    }
}