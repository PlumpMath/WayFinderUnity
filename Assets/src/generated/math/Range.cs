using UnityEngine;
namespace math {

    public class Range {
        public float t1;
        public float t2;

        public Range(float t1, float t2) {
            this.t1 = t1;
            this.t2 = t2;
        }
        public float min() {
            return Mathf.Min(t1, t2);
        }

        public float max() {
            return Mathf.Max(t1, t2);
        }
        public void Set(float t1, float t2) {
            this.t1 = t1;
            this.t2 = t2;
        }
        /// ������������� t1 � ������������ �� rangeOne.t1 other.t1
        /// t2 �  ����������� ��  rangeOne.t2 other.t2
        /// ���������� true ���� ��������� ������������
        public bool SetCross(Range rangeOne, Range other) {
            t1 = Mathf.Max(rangeOne.min(), other.min());
            t2 = Mathf.Min(rangeOne.max(), other.max());
            return ( t1 < t2 );
        }
    }
}


