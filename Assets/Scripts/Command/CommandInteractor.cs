using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR.Haptics;

namespace Midterm
{
    public class CommandInteractor : Interactor
    {
        Queue<Command> commands = new Queue<Command>();

        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private GameObject pointerPrefab;
        [SerializeField] private Camera cam;

        private Command currentCommand;

        public override void Interact()
        {

            if (PlayerInput.Instance.moveToPressed)
            {

                Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2));

                if (Physics.Raycast(ray, out var hitInfo))
                {
                    if (hitInfo.transform.CompareTag("Ground"))
                    {
                        GameObject pointer = Instantiate(pointerPrefab);
                        pointer.transform.position = hitInfo.point;

                        commands.Enqueue(new MoveCommand(agent,hitInfo.point));
                    }
                }
            }

            if (PlayerInput.Instance.returnPressed)
            {
                commands.Clear();
                commands.Enqueue(new FollowCommand(agent,transform.position));
            }

            ProcessCommands();
        }

        void ProcessCommands()
        {
            if (currentCommand != null && !currentCommand.isComplete)
            {
                return;
            }

            if (commands.Count == 0)
            {
                return;
            }

            currentCommand = commands.Dequeue();
            currentCommand.Execute();
        }

    }
}
