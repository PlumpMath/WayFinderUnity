using math;
using Zenject;

namespace impl {
    public class TrajectoryResolver {
        [Inject] data.UnitRadius unitRadius;
        [Inject] data.Speed speed;
        [Inject] renderer.DebugRenderer debugRenderer;
        public float timeStep;
        [Inject] void init() {
            this.timeStep = ( unitRadius.value / speed.value );
        }

        Range rangeA = new Range(0, 0);
        Range rangeB = new Range(0, 0);
        Range sharedRange = new Range(0, 0);

        public virtual bool cross(trajectory.Trajectory tra, trajectory.Trajectory trb) {
            bool shareTime = sharedRange.SetCross(tra.period, trb.period);
            if (!shareTime) return false;
            rangeA.Set(tra.getY(sharedRange.t1), tra.getY(sharedRange.t2));
            rangeA.t1 -= unitRadius.value;
            rangeA.t2 += unitRadius.value;
            rangeB.Set(trb.getY(sharedRange.t1), trb.getY(sharedRange.t2));
            rangeB.t1 -= unitRadius.value;
            rangeB.t2 += unitRadius.value;
            bool crosses = sharedRange.SetCross(rangeA, rangeB);

            if (!crosses) return false;
            var t = tra.getTbyY(sharedRange.t2);
            var t2 = tra.getTbyY(sharedRange.t1);
            if (t > t2) {
                var tt = t;
                t = t2;
                t2 = tt;
            }
            while (t < t2) {
                rangeA.Set(tra.getX(t) - unitRadius.value, tra.getX(t) + unitRadius.value);
                rangeB.Set(trb.getX(t) - unitRadius.value, trb.getX(t) + unitRadius.value);
                bool shareX = sharedRange.SetCross(rangeA, rangeB);
                if (shareX) {
                    return true;
                }
                t += timeStep;
            }
            return false;
        }
    }
}


