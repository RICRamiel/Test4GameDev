using UnityEngine;

namespace Gameplay
{
    public class GameState
    {
        
        public bool IsFirstFloorCompleted { get; private set; }

        public void CompleteFirstFloor()
        {
            IsFirstFloorCompleted = true;
        }
        
    }
}