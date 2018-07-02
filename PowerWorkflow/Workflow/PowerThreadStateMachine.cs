﻿using PowerWorkflow.Enums;
using PowerWorkflow.Workflow.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadStateMachine
    {
        /// <summary>
        /// 节点到节点的自然转换
        /// </summary>
        public List<Transmission> Transmissions { get; set; }
        public PowerThreadNode StartNode
        {
            get
            {
                if (!Transmissions.Any())
                {
                    throw new InvalidPowerThreadStateMachine();
                }
                return Transmissions.First(p => p.FromNode.IsStart).FromNode;
            }
        }

        public void Next(PowerThreadContext context, PowerThreadNode fromNode)
        {
            if (context.IsCurrentNode(fromNode) == false)
            {
                throw new InvalidThreadActionException("Not actived thread node!");
            }

            if (fromNode.Equals(PowerThreadDefaultNodes.DefaultEndNode))
            {
                throw new InvalidTransmissionSinceThreadAlreadyEnd();
            }

            var toNode = GetNextNode(context, fromNode);

            if (toNode != null)
            {
                context.PowerThread.SetCurrentNode(toNode);
                if (toNode.IsEnd)
                {
                    context.PowerThread.SetState(PowerThreadState.End);
                }
                else if (IsMissFound(toNode))
                {
                    context.PowerThread.SetState(PowerThreadState.ErrorMissFoundNode);
                }
                else
                {
                    context.PowerThread.SetState(PowerThreadState.Processing);
                }

            }
            else
            {
                // 如果找不到下一个节点， 也认为其结束。 
                context.PowerThread.SetState(PowerThreadState.End);
            }
        }

        private bool IsMissFound(PowerThreadNode toNode)
        {
            return toNode.Name == "[MissFoundNode]";
        }

        public void TerminateThread(PowerThreadContext context, PowerThreadNode fromNode)
        {
            context.PowerThread.SetState(PowerThreadState.Terminated);
        }

        private PowerThreadNode GetNextNode(PowerThreadContext context, PowerThreadNode fromNode)
        {
            var transmission = Transmissions.FirstOrDefault(p => p.FromNode.ObjectId == fromNode.ObjectId);

            if (transmission == null)
            {
                return PowerThreadDefaultNodes.DefaultEndNode;
            }

            foreach (var item in transmission.Conditions)
            {
                if (item.IsSatisified(context))
                {
                    return item.ToNode;
                }
            }

            // 
            return PowerThreadDefaultNodes.MissFoundNode;

        }
    }

    public class Transmission
    {

        public Transmission()
        {
            Conditions = new List<TransmissionCondition>();
        }

        public Transmission(PowerThreadNode from, PowerThreadNode to)
        {
            this.FromNode = from;
            Conditions = new List<TransmissionCondition>() {
                new TransmissionCondition{ ToNode = to }
            };
        }
        public PowerThreadNode FromNode { get; set; }
        public IList<PowerThreadNode> ToNodes { get { return Conditions.Select(p => p.ToNode).ToList(); } }

        public IList<TransmissionCondition> Conditions { get; set; } = new List<TransmissionCondition>();
    }

    public class TransmissionCondition
    {

        public virtual bool IsSatisified(PowerThreadContext context)
        {
            return true;
        }
        public PowerThreadNode ToNode { get; set; }


    }

    public class VariableTransmissionCondition : TransmissionCondition
    {


        public string VariableExpression { get; set; }



        public bool IsSatisified(PowerThreadContext context)
        {
            // TODO:  test from context variables;
            return true;
        }
    }


}