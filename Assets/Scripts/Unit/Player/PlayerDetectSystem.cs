using UnityEngine;

namespace Player
{
    public class PlayerDetectSystem : MonoBehaviour
    {
        [field: SerializeField] private Player Player { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6) Player.LostTarget();         
        }

    }
}

