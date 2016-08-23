using math;
using UnityEngine;
using Zenject;

namespace trajectory.circle {
    public class CircleBuilder : trajectory.TrajectoryBuilder {
        [Inject]public math.WorldRect worldRect;
        [Inject]public data.Speed speed;
        public float t;
        public float x1;
        public float x2;
        public bool odd;

        public virtual void init(float t, bool odd) {
            this.t = t;
            this.odd = odd;
        }


        public float bias;

        public virtual trajectory.Trajectory roll() {
            var r = worldRect.width();
            var diagAng = Mathf.Asin(worldRect.height() / r);
            var horOffsetLimit = r - r * Mathf.Cos(diagAng);
            float xMin = worldRect.x0 + r;
            float xMax = worldRect.x0 + 2 * r - horOffsetLimit;
            float x0 = UnityEngine.Random.Range(xMin, xMax);
            float y0 = UnityEngine.Random.Range(worldRect.y0, worldRect.y1);
            float speedSign = odd ? 1 : -1;
            float angSpeed = speedSign * speed.value / r;
            var period = new Range(t, t + 10);
            float yInWorldRectSpace = y0 - worldRect.y0;

            float startAngle = odd ?
            Mathf.PI + Mathf.Acos((yInWorldRectSpace) / r) :
            (Mathf.PI * 3 / 2) + Mathf.Asin( (worldRect.height() - yInWorldRectSpace) / r);

            var tr = new LeftArcTrajectory(x0, y0, r, angSpeed, startAngle, period);
            tr.period.t2 = odd ?
            tr.getTbyY(worldRect.y1):
            tr.getTbyY(worldRect.y0);
            return tr;
        }

    }
}


