using System.Collections.Generic;
using trajectory;
using Zenject;

namespace impl {
    public class DebugSystem : SystemBase {
        [Inject]
        public info.Stats stats;
        [Inject]
        public impl.World world;
        [Inject]
        public renderer.DebugRenderer debugRenderer;
        [Inject]
        public data.UnitRadius unitRadius;
        [Inject]
        public math.WorldRect worldRect;
        List<Trajectory> detected = new List<Trajectory>();


        public virtual void update(float t) {
            var i = 0;
            var trajectories = world.trajectories;
            while (i < trajectories.Count) {
                var tr = trajectories[i];
                var j = i + 1;
                while (j < trajectories.Count) {
                    var tr2 = trajectories[j];
                    var dx = tr2.getX(t) - tr.getX(t);
                    var dy = tr2.getY(t) - tr.getY(t);
                    var intersects = (dx * dx + dy * dy) < (unitRadius.value * unitRadius.value * 4);
                    if (intersects) {
                        if (detected.IndexOf(tr) < 0) {
                            detected.Add(tr);
                            stats.objectHits++;
                        }
                        debugRenderer.DrawCollision(tr, tr2);
                    }
                    j++;
                }
                i++;
            }
        }
    }
}


