using Zenject;

namespace info {
    public class Stats {
        [Inject] info.StatsRenderer statsRenderer;
        private int _totalNumObjects;
        public int totalNumObjects {
            get {
                return _totalNumObjects;
            }
            set {
                statsRenderer.setTotalNumObjects(value);
                _totalNumObjects = value;
            }
        }

        private int _currentNumObjects;
        public int currentNumObjects {
            get {
                return _currentNumObjects;
            }
            set {
                statsRenderer.setCurrentNumObjects(value);
                _currentNumObjects = value;
            }
        }

        private int _objectHits;
        public int objectHits {
            get {
                return _objectHits;
            }
            set {
                statsRenderer.setObjectHits(value);
                _objectHits = value;
            }
        }

        private int _searchIterations;
        public int searchIterations {
            get {
                return _searchIterations;
            }
            set {
                statsRenderer.setSearchIterations(value);
                _searchIterations = value;
            }
        }

        private int _searchesFailedCount;
        public int searchesFailedCount {
            get {
                return _searchesFailedCount;
            }
            set {
                statsRenderer.setFailedSearchesCount(value);
                _searchesFailedCount = value;
            }
        }


        private float _delay;
        public float delay {
            get {
                return _delay;
            }
            set {
                statsRenderer.setDelay(value);
                _delay = value;
            }
        }

        public void Reset() {
            totalNumObjects = 0;
            currentNumObjects = 0;
            objectHits = 0;
            searchesFailedCount = 0;
            delay = 0;
        }
    }
}


