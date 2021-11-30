using UnityEngine;
using UnityEngine.SceneManagement;

namespace FightShipArena.Assets.Scripts.Managers.GameManagement
{
    public delegate void SceneLoadedEventArgs(Scene scene, LoadSceneMode loadSceneMode);
    public delegate void SceneUnloadedEventArgs(Scene scene);

    public interface IUnitySceneManagerWrapper
    {
        public event SceneLoadedEventArgs SceneLoaded;
        public event SceneUnloadedEventArgs SceneUnloaded;
        AsyncOperation LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode);

        AsyncOperation UnloadSceneAsync(string sceneName);

    }
}