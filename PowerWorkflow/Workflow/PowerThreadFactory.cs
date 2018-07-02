using PowerWorkflow.Description;
using System;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadFactory
    {
        public PowerThreadDefinition CreateThreadDefinition(Root root)
        {
            PowerThreadDefinition result = new PowerThreadDefinition();
            return result;
        }

        public PowerThread BuildPowerThread(PowerThreadDefinition powerThreadDefinition, string name)
        {
            PowerThread result = new PowerThread(name);
            result.Nodes = BuildNodes(powerThreadDefinition);
            result.Roles = BuildRoles(powerThreadDefinition);
            result.Forms = BuildForms(powerThreadDefinition);
            result.Variables = BuildVariables(powerThreadDefinition);
            result.StateMachine = BuildStateMachine(powerThreadDefinition);

            return result;
        }

        public void InitialThreadInstance(PowerThread instance)
        {
            instance.SetState(Enums.PowerThreadState.Initial);
        }

        public void DriveThreadInstance(PowerThreadNode node,
            PowerThreadRole role,
            PowerThreadAction action,
            PowerThreadForm form,
            PowerThreadEntity entity)
        {
        }


        private PowerThreadStateMachine BuildStateMachine(PowerThreadDefinition powerThreadDefinition)
        {
            throw new NotImplementedException();
        }

        private IList<PowerVariable> BuildVariables(PowerThreadDefinition powerThreadDefinition)
        {
            throw new NotImplementedException();
        }

        private IList<PowerThreadForm> BuildForms(PowerThreadDefinition powerThreadDefinition)
        {
            throw new NotImplementedException();
        }

        private IList<PowerThreadRole> BuildRoles(PowerThreadDefinition powerThreadDefinition)
        {
            throw new NotImplementedException();
        }

        private IList<PowerThreadNode> BuildNodes(PowerThreadDefinition powerThreadDefinition)
        {
            throw new NotImplementedException();
        }
    }
}