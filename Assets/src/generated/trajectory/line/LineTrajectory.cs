using math;

namespace trajectory.line {
    public class LineTrajectory : trajectory.Trajectory {
        math.Range _period;

        public math.Range period {
            get {
                return _period;
            }
            set {
                _period = value;
            }
        }

        public float startX;
        public float startY;
        public float speedX;
        public float speedY;

        public LineTrajectory(float x0, float y0, float speedX, float speedY, Range period) {
            startX = x0;
            startY = y0;
            this.speedX = speedX;
            this.speedY = speedY;
            this.period = period;
        }

        public virtual float getX(float t) {
            return startX + (t - period.t1) * speedX;
        }

        public virtual float getY(float t) {
            return startY + (t - period.t1) * speedY;
        }

        public virtual float getTbyY(float y) {
            return period.t1 + (y - startY) / speedY;
        }

    }
}


