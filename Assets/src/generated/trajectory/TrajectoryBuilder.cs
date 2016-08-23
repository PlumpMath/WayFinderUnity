namespace trajectory {
    public interface TrajectoryBuilder {
        void init(float t, bool odd);
        trajectory.Trajectory roll();
    }
}


