using System.Collections.Generic;

namespace PureSpawner.Infrastructure.Pausing
{
    public class PauseHandler
    {
        private readonly List<IPause> _handlers = new();

        public void Add(IPause handler) => _handlers.Add(handler);  
        public void Remove(IPause handler) => _handlers.Remove(handler);

        public void SetPause(bool isPaused)
        {
            foreach (var handler in _handlers)
                handler.SetPause(isPaused);
        }
    }
}