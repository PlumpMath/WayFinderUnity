using System;
using math;
using UnityEngine;

namespace trajectory.circle {
    public class LeftArcTrajectory : trajectory.Trajectory {
        math.Range _period;
        public math.Range period {
            get {
                return _period;
            }
            set {
                _period = value;
            }
        }

        public float centerX;
        public float centerY;
        public float startAngle;
        public float angularSpeed;
        public float radius;

        public  LeftArcTrajectory(float x0, float y0, float radius, float angularSpeed, float startAngle, Range period) {
        centerX = x0;
        centerY = y0;
        this.radius = radius;
        this.startAngle = startAngle;
        this.angularSpeed = angularSpeed;
        this.period = period;
    }

        public virtual float getX(float t) {
            float angle = startAngle + (t - period.t1) * angularSpeed;
            return centerX + radius * Mathf.Sin(angle);
        }


        public virtual float getY(float t) {
            float angle = startAngle + (t - period.t1) * angularSpeed;
            return centerY + radius * Mathf.Cos(angle);
        }


        public virtual float getTbyY(float y) {
            float angle =
            (y > centerY)   ?
            2 * Mathf.PI - Mathf.Acos((y - centerY) / radius) - startAngle
            : Mathf.PI + Mathf.Acos((centerY - y) / radius) - startAngle;
            return (angle / angularSpeed) + period.t1;
        }
    }


}


