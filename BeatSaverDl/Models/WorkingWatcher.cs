using System;
using System.Collections.Generic;
using System.Linq;

namespace BeatSaverDl.Models
{
    public class WorkingWatcher
    {
        private List<WorkingHandle> Handles = new List<WorkingHandle>();
        private Action<bool> UpdateMethod;
        private bool _IsActive = false;

        public WorkingWatcher(Action<bool> updateMethod)
        {
            UpdateMethod = updateMethod;
        }

        public WorkingHandle Register()
        {
            var h = new WorkingHandle(this);
            lock (Handles)
                Handles.Add(h);
            UpdateState();
            return h;
        }

        public void NotifyFinished(WorkingHandle handle)
        {
            lock (Handles)
            {
                if (Handles.Contains(handle))
                {
                    Handles.Remove(handle);
                }
            }
            UpdateState();
        }

        private void UpdateState()
        {
            bool active;
            lock (Handles)
                active = Handles.Any();

            if (active != _IsActive)
            {
                _IsActive = active;
                UpdateMethod(active);
            }
        }
    }
}