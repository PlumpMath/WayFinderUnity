using generated.data;
using UnityEngine;
using Zenject;

namespace impl {
    public class TrajectorySpawner {
        public const int SEARCH_ITER_LIMIT = 50;
        [Inject] impl.World world;
        [Inject] trajectory.TrajectoryBuilder trajectoryBuilder;
        [Inject] info.Stats stats;
        [Inject] SpawningConfig spawningConfig;
        public bool odd;
        float nextSpawn = 0;

        public void update(float t) {
            if (t > nextSpawn) {
                spawningConfig.delay = Mathf.Max(spawningConfig.delay - spawningConfig.delayDecrement, spawningConfig.minDelay);
                nextSpawn = t + spawningConfig.delay;
                var tr = choose(t);
                if (tr != null) {
                    world.add(tr);
                }
            }
        }

        public virtual trajectory.Trajectory choose(float t) {
            trajectoryBuilder.init(t, odd);
            var i = 0;
            var tr = trajectoryBuilder.roll();
            while (!world.isValid(tr)) {
                i++;
                if (i > SEARCH_ITER_LIMIT) {
                    stats.searchesFailedCount++;
                    return null;
                }
                tr = trajectoryBuilder.roll();
            }
            stats.searchIterations = i;
            odd = !odd;
            return tr;
        }
    }
}


