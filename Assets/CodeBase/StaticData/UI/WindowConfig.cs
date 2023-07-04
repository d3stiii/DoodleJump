using System;
using CodeBase.UI.Windows;

namespace CodeBase.StaticData.UI
{
    [Serializable]
    public class WindowConfig
    {
        public WindowId Id;
        public Window Prefab;
    }
}