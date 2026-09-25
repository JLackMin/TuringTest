using UnityEngine;
using System.Collections.Generic;

namespace Midterm
{
    public class BlockDetection : MonoBehaviour
    {
        public BlockPuzzleDoor door; //Door will assign

        List<Collider> blocks = new List<Collider>();

        void OnTriggerEnter(Collider other)
        {
            if (!door) {return;}

            blocks.Add(other);
            door.Unlock(this);
        }

        void OnTriggerExit(Collider other)
        {
            blocks.Remove(other);
            
            if (blocks.Count == 0)
            {
                door.Lock(this);
            }
        }
    }
}
