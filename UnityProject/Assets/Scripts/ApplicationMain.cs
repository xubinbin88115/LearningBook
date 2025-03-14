using System.Collections;
using System.Collections.Generic;
using Foundation.UI;
using Foundation.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ApplicationMain 
{
    [RuntimeInitializeOnLoadMethod]
    static void OnMain()
    {
        GameObject uguiRoot = new GameObject("UGUI");

        GameObject uiCameraObj = new GameObject("UICamera");
        uiCameraObj.transform.SetParent(uguiRoot.transform);
        Camera uiCamera = uiCameraObj.AddComponent<Camera>();
        uiCamera.clearFlags = CameraClearFlags.Depth;
        // uiCamera.cullingMask = LayerMask.GetMask("UI");
        uiCamera.orthographic = true;
        uiCamera.depth = 100;

        GameObject uiRoot = new GameObject("UIRoot");
        uiRoot.transform.SetParent(uguiRoot.transform);
        Canvas canvas = uiRoot.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = uiCamera;

        var rootViewController = uiRoot.AddComponent<UIViewController>();

        CanvasScaler scaler = uiRoot.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(2960, 1440);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 1.0f;

        uiRoot.AddComponent<GraphicRaycaster>();

        GameObject eventSystemObj = new GameObject("EventSystem");
        eventSystemObj.transform.SetParent(uguiRoot.transform);
        eventSystemObj.AddComponent<EventSystem>();
        eventSystemObj.AddComponent<StandaloneInputModule>();
        
        // 创建一个导航页面
        GameObject navigateUI = new GameObject("NavigateUI");
        var navigationController = navigateUI.AddComponent<UINavigationController>();
        rootViewController.PushViewController(navigationController);
        
        // 加载第一个页面
        UIViewController viewController = AssetLoader.GetInstance().LoadUI<MainUIController>();
        navigationController.PushViewController(viewController);
    }
}
