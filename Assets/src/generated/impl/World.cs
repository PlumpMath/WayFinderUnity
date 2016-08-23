using System.Collections.Generic;
using trajectory;
using Zenject;

namespace impl {
    public class World {
        public List<Trajectory> trajectories = new List<Trajectory>();
        [Inject] public impl.TrajectoryResolver trajectoryResolver;
        [Inject] public info.Stats stats;
        Queue<Trajectory> toRemove = new Queue<Trajectory>();

        public virtual void add(global::trajectory.Trajectory tr) {
            trajectories.Add(tr);
            stats.currentNumObjects = trajectories.Count;
            stats.totalNumObjects++;
        }

        public virtual void remove(global::trajectory.Trajectory tr) {
            trajectories.Remove(tr);
            stats.currentNumObjects = trajectories.Count;
        }

        public virtual void reset() {
            this.trajectories.Clear();
        }

        public virtual bool isValid(global::trajectory.Trajectory tr) {
            foreach (Trajectory other in trajectories) {
                if (trajectoryResolver.cross(tr, other)) {
                    return false;
                }
            }
            return true;
        }


        public virtual void update(float t) {
            foreach (Trajectory tr in trajectories) {
                if (tr.period.max() < t) {
                    toRemove.Enqueue(tr);
                }
            }
            while (toRemove.Count > 0) {
                trajectories.Remove(toRemove.Dequeue());
            }
        }
    }
}


