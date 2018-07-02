using System;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadContext
    {
        public PowerThreadContext(PowerThread powerThread)
        {
            this.PowerThread = powerThread;
        }
        public PowerThread PowerThread { get; internal set; }

        internal bool IsCurrentNode(PowerThreadNode fromNode)
        {
            throw new NotImplementedException();
        }
    }
}