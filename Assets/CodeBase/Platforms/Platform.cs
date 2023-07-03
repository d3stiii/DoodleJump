using CodeBase.Player;
using UnityEngine;

namespace CodeBase.Platforms
{
    public class Platform : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerMovement>(out var playerMovement) && CanGiveForce(other))
                playerMovement.Jump();
        }

        private bool CanGiveForce(Collider2D collider) =>
            collider.attachedRigidbody.velocity.y < 0 &&
            collider.transform.position.y - collider.bounds.size.y / 2 > transform.position.y;
    }
}