using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.UI;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Services.UI
{
    public class WindowProvider
    {
        private readonly Dictionary<WindowId, WindowConfig> _windowConfigs;

        public WindowProvider()
        {
            var windowsData = Resources.Load<WindowStaticData>("StaticData/UI/WindowStaticData");
            _windowConfigs = windowsData.Configs.ToDictionary(x => x.Id, x => x);
        }

        public WindowConfig GetWindow(WindowId id) =>
            _windowConfigs.TryGetValue(id, out var config) ? config : null;
    }
}