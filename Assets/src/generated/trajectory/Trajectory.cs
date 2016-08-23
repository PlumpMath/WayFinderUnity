namespace trajectory {
    public interface Trajectory  {
        math.Range period {get;set;}
        float getX(float t);
        float getY(float t);
        float getTbyY(float y);
    }
}


