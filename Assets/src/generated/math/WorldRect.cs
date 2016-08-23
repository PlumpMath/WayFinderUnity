namespace math {
    public class WorldRect {
        public float x0;
        public float x1;
        public float y0;
        public float y1;

        public WorldRect(float x0, float y0, float x1, float y1) {
            this.x0 = x0;
            this.x1 = x1;
            this.y0 = y0;
            this.y1 = y1;
        }

        public  virtual float width() {
            return  x1 - x0;
        }

        public virtual float height() {
            return ( y1 - y0 );
        }
    }
}


