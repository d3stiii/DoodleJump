using UnityEngine;

namespace CodeBase.UI.Windows
{
    public abstract class Window : MonoBehaviour
    {
        private void Start()
        {
            Initialize();
            SubscribeUpdates();
        }

        public void Construct()
        {
            
        }
        
        protected virtual void Initialize() { }
        protected virtual void SubscribeUpdates() { }
    }
}