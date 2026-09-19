using UnityEngine;
using Zenject;

namespace Gameplay.SecondFloor
{
    public class SecondFloorDoor : MonoBehaviour
    {
        [Inject]
        private SecondFloorController _controller;

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