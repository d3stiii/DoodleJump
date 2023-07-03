using UnityEngine;

namespace CodeBase.Services.Input
{
    public class MobileInputService : IInputService
    {
        public Vector2 MovementAxis => UnityEngine.Input.acceleration;
    }
}