using CodeBase.Services.Data;
using UnityEngine;

namespace CodeBase.UI.Windows
{
    public abstract class Window : MonoBehaviour
    {
        protected DataService DataService;

        private void Start()
        {
            Initialize();
        }

        public void Construct(DataService dataService)
        {
            DataService = dataService;
        }
        
        protected virtual void Initialize() { }
    }
}