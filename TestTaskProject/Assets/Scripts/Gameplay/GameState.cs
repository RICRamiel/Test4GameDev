using UnityEngine;

namespace Gameplay
{
    public class GameState
    {
        public bool IsFirstFloorCompleted { get; private set; }

        public bool IsSecondFloorReturnRequired { get; private set; }

        public bool HasSecondFloorKey { get; private set; }

        public void CompleteFirstFloor()
        {
            IsFirstFloorCompleted = true;
        }

        public void RequireReturnToFirstFloor()
        {
            IsSecondFloorReturnRequired = true;
        }

        public void CollectSecondFloorKey()
        {
            HasSecondFloorKey = true;
        }
    }
}