using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Points
{
    public class LosePoint : MonoBehaviour
    {
        private Transform _target;

        private void Update()
        {
            if (_target.position.y <= transform.position.y)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Construct(Transform target) => 
            _target = target;
    }
}