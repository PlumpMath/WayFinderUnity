using System;
using System.Collections.Generic;

namespace trajectory {
    public class RandomTrajectoryBuilder : trajectory.TrajectoryBuilder {
        public trajectory.TrajectoryBuilder current;
        public List<TrajectoryBuilder> trajectoryBuilders = new List<TrajectoryBuilder>();

        public virtual void addBuilder(trajectory.TrajectoryBuilder trajectoryBuilder) {
            trajectoryBuilders.Add(trajectoryBuilder);
        }

        public virtual void init(float t, bool odd) {
            if (( this.trajectoryBuilders.Count == 0 )) {
                throw new Exception("RandomTraectoryBuilder requires at least one builder been added.");
            }
            current = trajectoryBuilders[UnityEngine.Random.Range(0, trajectoryBuilders.Count)];
            current.init(t, odd);
        }

        public virtual trajectory.Trajectory roll() {
            return current.roll();
        }

    }
}


