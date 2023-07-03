using UnityEngine;

namespace CodeBase.Services.Input
{
    public class StandaloneInputService : IInputService
    {
        public Vector2 MovementAxis => new(UnityEngine.Input.GetAxis("Horizontal"), 0);
    }
}