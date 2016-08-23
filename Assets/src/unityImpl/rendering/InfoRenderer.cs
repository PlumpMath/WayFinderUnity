using info;
using UnityEngine.UI;
using UnityEngine;

namespace src.unityImpl.rendering {
    public class InfoRenderer : MonoBehaviour, StatsRenderer{

        public Text searchIterations;
        public Text searchesFailedCount;
        public Text objectHits;
        public Text totalNumObjects;
        public Text currentNumObjects;

        public void setFailedSearchesCount(int v) {
            searchesFailedCount.text = v.ToString();
        }

        public void setSearchIterations(int v) {
            searchIterations.text = v.ToString();
        }

        public void setTotalNumObjects(int v) {
            totalNumObjects.text = v.ToString();
        }

        public void setDelay(float v) {
        }

        public void setObjectHits(int v) {
            objectHits.text = v.ToString();
        }

        public void setCurrentNumObjects(int v) {
            currentNumObjects.text = v.ToString();
        }
    }
}