using System;
namespace StereoFramework.GameApp
{
    public enum Event
    {
        Quit,
        Startup,
        Initializing,
        InitializingComplete,
        PostInitializing,
        PostInitializationComplete,
        SystemInitialized,
        LoadingContent,
        GameLoaded,
        UnloadingContent,
        UnloadingContentComplete,
        StartSceneSet,
        ChangingScene,
        SceneChangeComplete,
        UnloadingScene,
        SceneUnloaded,
        CameraCreated,
        StartingUpdateLoop,
        StartingDrawLoop,
    }
}
