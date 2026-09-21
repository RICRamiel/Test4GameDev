using Gameplay;
using UnityEngine;

public class NonConditionDoor : SceneTransitionDoor
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        Transition();
    }
}