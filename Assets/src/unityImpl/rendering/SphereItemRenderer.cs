using System.Collections.Generic;
using data;
using impl;
using math;
using renderer;
using src.generated.data;
using trajectory;
using UnityEngine;
using Zenject;

namespace unityImpl {
    public class SphereItemRenderer : MonoBehaviour, DebugRenderer {
        [Inject] RenderingConfig renderingConfig;
        [Inject] WorldRect worldRect;
        [Inject] UnitRadius  unitRadius;
        [Inject] World world;

        Vector3 hiddenPos = new Vector3(0,0, -20);
        List<Transform> views = new List<Transform>();
        List<Renderer> renderers = new List<Renderer>();
        List<Trajectory> collisions = new List<Trajectory>();
        float scale = 0.01f;


        void Start() {
            var view = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            GameObject.Destroy(view.GetComponent<Collider>());
            view.SetParent(transform);
            view.localScale = new Vector3(worldRect.width(), worldRect.height(), 1) * scale;
            view.localPosition = new Vector3(worldRect.width()/2, worldRect.height()/2,5000) * scale;
            transform.localPosition = new Vector3(-worldRect.width()/2, -worldRect.height()/2) * scale;
        }

        public void DrawCollision(trajectory.Trajectory tr1, trajectory.Trajectory tr2) {
            collisions.Add(tr1);
            collisions.Add(tr2);
        }


        public void update(float t) {
            int i;
            for (i = 0; i < world.trajectories.Count; i++ ) {
                Trajectory tr = world.trajectories[i];
                Transform view;
                if (i == views.Count) {
                    view = CreateView();
                    views.Add(view);
                    renderers.Add(view.GetComponent<Renderer>());
                } else {
                    view = views[i];
                }
                renderers[i].material = (collisions.IndexOf(tr) > -1) ? renderingConfig.collision : renderingConfig.normal;
                view.transform.localPosition = new Vector3(
                    scale * tr.getX(t),
                    scale *tr.getY(t),
                    10
                );
            }
            for (i++  ; i < views.Count; i++ ) {
                var view = views[i];
                view.transform.localPosition = hiddenPos;
            }
            collisions.Clear();
        }

        Transform CreateView() {
            var view = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
            GameObject.Destroy(view.GetComponent<Collider>());
            view.SetParent(transform);
            view.localScale = Vector3.one * scale * unitRadius.value * 2;
            return view;
        }


    }
}