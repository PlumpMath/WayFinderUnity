using UnityEngine;
using Zenject;

public class InitializationUtils {

    public static TSystem InitSystem<TSystem>(DiContainer Container) where TSystem : SystemBase {
        Container.BindAllInterfacesAndSelf<TSystem>().To<TSystem>().AsSingle();
        return Container.Resolve<TSystem>();
    }

    public static void Mount(Transform parent, Transform child) {
        child.SetParent(parent);
        child.localPosition = Vector3.zero;
        child.localRotation = Quaternion.identity;
        child.localScale = Vector3.one;
    }
}
