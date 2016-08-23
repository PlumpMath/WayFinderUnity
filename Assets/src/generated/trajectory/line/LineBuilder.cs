using math;
using UnityEngine;
using Zenject;

namespace trajectory.line {
    public class LineBuilder : trajectory.TrajectoryBuilder {
        [Inject]math.WorldRect worldRect;
        [Inject]data.Speed speed;
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
            x1 = UnityEngine.Random.Range(worldRect.x0, worldRect.x1);
            x2 = Mathf.Clamp((x1 + Random.Range(-bias, bias)), worldRect.x0, worldRect.x1);
            return buildLine(x1, x2, t, worldRect, speed.value, odd);
        }


        public static trajectory.Trajectory buildLine(float x1, float x2, float t0, math.WorldRect worldRect, float s, bool odd) {
            var xSign = x1 > x2 ? -1 : 1;
            var ySign = odd ? 1 : -1;

            float dx = ( x2 - x1 );
            float dy = worldRect.height();
            float dxSq = ( dx * dx );
            float dySq = ( dy * dy );
            float sySq = ( ( ( s * s ) * dySq ) / (( dySq + dxSq )) );
            float sxSq = ( ( s * s ) - sySq );
            float pathLen = Mathf.Sqrt(dxSq + dySq);
            var period = new Range(t0, t0 + pathLen / s);
            var line = new LineTrajectory(x1, odd ? worldRect.y0 : worldRect.y1, xSign * Mathf.Sqrt(sxSq), ySign * Mathf.Sqrt(sySq), period);
            return line;
        }


    }
}


