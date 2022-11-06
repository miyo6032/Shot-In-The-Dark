using System;
using System.Collections.Generic;

namespace Util
{
    public class Listener<T>
    {
        private List<Action<T>> listeners = new();

        public void AddEventListener(Action<T> listener)
        {
            listeners.Add(listener);
        }

        public void FireEvent(T data)
        {
            listeners?.ForEach(listener => listener(data));
        }
    }
}