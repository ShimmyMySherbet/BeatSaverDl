using System;

namespace BeatSaverDl.Models
{
    public class WorkingHandle : IDisposable
    {
        public WorkingWatcher Watcher { get; }

        public WorkingHandle(WorkingWatcher watcher)
        {
            Watcher = watcher;
        }

        private bool Disposed = false;

        public void Dispose()
        {
            if (Disposed)
            {
                return;
            }
            Disposed = true;
            Watcher.NotifyFinished(this);
        }
    }
}