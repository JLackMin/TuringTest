using UnityEngine;

namespace Midterm
{
    public abstract class Command
    {
        public abstract void Execute();

        public abstract bool isComplete {get;}
    }
}
