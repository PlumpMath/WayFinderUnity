using data;
using generated.data;
using impl;
using info;
using math;
using renderer;
using src.generated.data;
using src.unityImpl.rendering;
using trajectory;
using trajectory.circle;
using trajectory.line;
using UnityEngine;
using Zenject;

namespace unityImpl {
    public class TrajectoriesInstaller : MonoInstaller{
        [SerializeField]
        public Speed speed;
        [SerializeField]
        public UnitRadius unitRadius;
        [SerializeField]
        public RenderingConfig renderingConfig;
        [SerializeField]
        public SpawningConfig spawningConfig;
        public SphereItemRenderer sphereItemRenderer;
        public InfoRenderer infoRenderer;


        public override void InstallBindings() {
            Container.BindInstance<SpawningConfig>(spawningConfig);
            Container.BindInstance<RenderingConfig>(renderingConfig);
            Container.BindInstance<Speed>(speed);
            Container.BindInstance<UnitRadius>(unitRadius);
            Container.BindInstance<StatsRenderer>(infoRenderer);
            var worldRect = new math.WorldRect(unitRadius.value,0,800 - unitRadius.value*2 ,450);
            Container.Bind<Stats>().To<Stats>().AsSingle();
            Container.Bind<TrajectoryResolver>().AsSingle();
            Container.Bind<World>().AsSingle();
            Container.BindInstance<WorldRect>(worldRect);
            Container.Bind<DebugSystem>().To<DebugSystem>().AsSingle();
            // Вот здесь можно как угодно фантазировать на предмет вариантов траекторий, которые будут спаунится, вероятности и пр.
            var builder = new RandomTrajectoryBuilder();
            builder.addBuilder(Container.Instantiate<LineBuilder>());
            builder.addBuilder(Container.Instantiate<CircleBuilder>());
            Container.BindInstance<TrajectoryBuilder>(builder);
            Container.Bind<TrajectorySpawner>().To<TrajectorySpawner>().AsSingle();
            Container.BindInstance<SphereItemRenderer>(sphereItemRenderer);
            Container.BindInstance<DebugRenderer>(sphereItemRenderer);
            InitializationUtils.InitSystem<TrajectoryApplicationUpdater>(Container);
        }
    }
}