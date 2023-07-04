using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Services.UI
{
    public class WindowService
    {
        private readonly Transform _uiRoot;
        private readonly WindowProvider _windowProvider;

        public WindowService(Transform uiRoot, WindowProvider windowProvider)
        {
            _uiRoot = uiRoot;
            _windowProvider = windowProvider;
        }

        public void Open(WindowId id)
        {
            var windowData = _windowProvider.GetWindow(id);
            var window = Object.Instantiate(windowData.Prefab, _uiRoot);
            window.Construct();
        }
    }
}