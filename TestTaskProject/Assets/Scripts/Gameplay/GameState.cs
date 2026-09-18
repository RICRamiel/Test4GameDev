using UnityEngine;

namespace Gameplay
{
    public class GameState
    {
        private int FirstFloorCollected = 0;
        public bool IsFirstFloorCompleted { get; private set; }

        public void CompleteFirstFloor()
        {
            IsFirstFloorCompleted = true;
        }

        public void CollectItem()
        {
            Debug.Log(FirstFloorCollected);
            FirstFloorCollected += 1;
            if (FirstFloorCollected >= 3)
            {
                CompleteFirstFloor();
            }
        }
    }
}