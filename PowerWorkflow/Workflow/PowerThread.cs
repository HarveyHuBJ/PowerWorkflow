using PowerWorkflow.Enums;
using PowerWorkflow.Workflow.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerWorkflow.Workflow
{
    public class PowerThread : PowerThreadBaseObject
    {
        public PowerThread(Guid objectId, string name) : base(objectId, name)
        {
            this.Context = new PowerThreadContext(this);
        }

        public PowerThreadContext Context { get; set; }

        public IList<PowerThreadNode> Nodes
        {
            get; set;
        }

        public IList<PowerThreadRole> Roles
        {
            get; set;
        }

        internal void SetCurrentNode(PowerThreadNode toNode)
        {
            //  if (IsContained(toNode))
            {
                CurrentNode = toNode;
            }
        }

        private bool IsContained(PowerThreadNode node)
        {
            bool result = this.Nodes.Any(p => p.ObjectId == node.ObjectId);
            return result;
        }

        public void StartWith(
            RoleSettings roleSettings,
            Dictionary<string, string> varialbes)
        {
            this.SetRoleSettings(roleSettings);
            this.SetVariables(varialbes);

            this.StateMachine.Next(Context, PowerThreadDefaultNodes.DefaultStartNode);
            this.SetState(PowerThreadState.Processing);
        }

        private void SetVariables(Dictionary<string, string> varialbes)
        {
            this.Variables = varialbes.Select(
                                            p => new PowerVariable(p.Key)
                                            {
                                                Value = p.Value
                                            })
                                      .ToList();
        }

        private bool SetRoleSettings(RoleSettings roleSettings)
        {
            bool result = true;

            foreach (var role in this.Roles)
            {
                if (!roleSettings.GetUsers(role.ObjectId).Any())
                {
                    result = false;
                    break;
                }
            }

            if (result)
            {
                this.RoleSettings = roleSettings;
            }
            return result;
        }

        internal void SetState(PowerThreadState state)
        {
            this.State = state;
        }

        public IList<PowerThreadForm> Forms
        {
            get; set;
        }

        public IList<PowerThreadView> Views
        {
            get; set;
        }

        public IList<PowerVariable> Variables
        {
            get; set;
        }

        public PowerThreadStateMachine StateMachine { get; set; }
        public PowerThreadState State { get; private set; }
        public PowerThreadNode CurrentNode { get; set; }
        public RoleSettings RoleSettings { get; private set; }

        public void GoNextNode(PowerThreadNode fromNode)
        {
            // todo
            StateMachine.Next(Context, fromNode);
        }

        public void GoNextNode()
        {
            if (CurrentNode == null)
            {
                throw new InvalidThreadActionException("Current node is null!");
            }
            else
            {
                StateMachine.Next(Context, CurrentNode);
            }
        }

        public void TerminateThreadAtNode(PowerThreadNode fromNode)
        {
            StateMachine.TerminateThread(Context, fromNode);
        }

        public object GetVariable(string variableName, Type variableType)
        {
            var variable = this.Variables.FirstOrDefault(p => p.VariableName == variableName);
            if (variable != null)
            {
                return variable.Value;
            }

            return Activator.CreateInstance(variableType, null);
        }

        public void SetVariable(string variableName, object value)
        {
            var variable = this.Variables.FirstOrDefault(p => p.VariableName == variableName);
            if (variable != null)
            {
                variable.Value = value;
            }
            else
            {
                variable = new PowerVariable(variableName) { Value = value };
                this.Variables.Add(variable);
            }
        }
    }
}