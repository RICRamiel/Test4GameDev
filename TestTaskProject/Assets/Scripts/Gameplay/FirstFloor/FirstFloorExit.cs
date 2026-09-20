using UnityEngine;
using Zenject;

namespace Gameplay.FirstFloor
{
    public class FirstFloorExit : MonoBehaviour
    {
        [Inject]
        private FirstFloorController _controller;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player"))
            {
                return;
            }

            _controller.InteractWithDoor();
        }
    }
}