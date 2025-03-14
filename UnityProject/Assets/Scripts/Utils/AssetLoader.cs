using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Foundation.Utils
{
    public class AssetLoader
    {
        private static AssetLoader s_AssetLoader;

        public static AssetLoader GetInstance()
        {
            if (s_AssetLoader == null)
                s_AssetLoader = new AssetLoader();
            return s_AssetLoader;
        }
        
        public Foundation.UI.UIViewController LoadUI<T>() where T : Foundation.UI.UIViewController
        {
            // 临时处理
            return GameObject.Instantiate(Resources.Load<T>(string.Format("UI/{0}", typeof(T).Name.Replace("Controller", String.Empty))));
        }
    }
}