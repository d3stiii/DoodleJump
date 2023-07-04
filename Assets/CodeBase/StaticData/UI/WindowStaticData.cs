using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.UI
{
    [CreateAssetMenu(menuName = "UI/Window Static Data", fileName = "WindowStaticData")]
    public class WindowStaticData : ScriptableObject
    {
        [SerializeField] private List<WindowConfig> _configs;
        public List<WindowConfig> Configs => _configs;
    }
}