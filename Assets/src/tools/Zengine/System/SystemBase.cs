using UnityEngine;
using Zenject;

public class SystemBase : ITickable, SystemInterface {
    bool enabled = true;

    public bool IsEnabled() {
        return enabled;
    }

    public virtual void Enable() {
        enabled = true;
    }

    public virtual void Disable() {
        enabled = false;
    }

    public void Tick() {
        if (enabled) Update();
    }

    public virtual void Update() {
    }

}