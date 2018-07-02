using PowerWorkflow.Enums;
using PowerWorkflow.Workflow.Exceptions;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadStateMachine
    {
        public void Next(PowerThreadContext context, PowerThreadNode fromNode)
        {
            if (context.IsCurrentNode(fromNode) == false)
            {
                throw new InvalidThreadActionException("Not actived thread node!");
            }

            var toNode = GetNextNode(context, fromNode);

            if (toNode != null)
            {
                if (toNode.IsEnd)
                {
                    context.PowerThread.SetState(PowerThreadState.End);
                }
                else
                    context.PowerThread.SetCurrentNode(toNode);
            }
            else
            {
            }
        }

        public void TerminateThread(PowerThreadContext context, PowerThreadNode fromNode)
        {
            context.PowerThread.SetState(PowerThreadState.Terminated);
        }

        private PowerThreadNode GetNextNode(PowerThreadContext context, PowerThreadNode fromNode)
        {
            // 1 假设什么都不考虑， 直接根据序号排

            // 2 假设有条件的跳转

            // 3
            return new PowerThreadNode("fake", context);
        }
    }
}