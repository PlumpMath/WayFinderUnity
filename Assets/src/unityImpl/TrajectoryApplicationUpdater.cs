using impl;
using info;
using UnityEngine;
using Zenject;

namespace unityImpl {
    public class TrajectoryApplicationUpdater : SystemBase{
        [Inject] World world;
        [Inject] DebugSystem debugSystem;
        [Inject] TrajectorySpawner trajectorySpawner;
        [Inject] SphereItemRenderer sphereItemRenderer;
        [Inject] Stats stats;
        float t;
        public override void Update() {
            if (Input.GetKeyDown(KeyCode.R)) {
                Reset();
            }
            t+=Time.deltaTime;
            trajectorySpawner.update(t);
            world.update(t);
            debugSystem.update(t);
            sphereItemRenderer.update(t);
        }

        void Reset() {
            world.reset();
            stats.Reset();
        }
    }
}