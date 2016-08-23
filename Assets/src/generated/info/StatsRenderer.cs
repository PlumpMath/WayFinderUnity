namespace info {
    public interface StatsRenderer {

        void setSearchIterations(int v);

        void setFailedSearchesCount(int v);

        void setObjectHits(int v);

        void setTotalNumObjects(int v);

        void setCurrentNumObjects(int v);

        void setDelay(float v);
    }
}


