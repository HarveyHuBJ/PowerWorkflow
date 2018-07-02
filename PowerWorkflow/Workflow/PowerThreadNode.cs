using PowerWorkflow.Workflow.Events;
using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadNode : PowerThreadBaseObject
    {
        private PowerThreadContext context = null;

        //public event PowerThreadNodeGoNextEvent GoNext;
        //public event PowerThreadNodeSaveFormEvent SaveForm;
        //public event PowerThreadNodeTerminateEvent Terminate;

        public PowerThreadNode(string name, PowerThreadContext context) : base(name)
        {
            this.context = context;
        }

        /// <summary>
        ///  注册默认缺省表单
        /// </summary>
        /// <param name="form"></param>
        public void RegisterDefaultForm(PowerThreadForm form)
        {
            this.DefaultForm = form;
            this.DefaultForm.Actions.GoNext += this.GoNext;
            this.DefaultForm.Actions.SaveForm += this.SaveForm;
            this.DefaultForm.Actions.Terminate += this.Terminate;
            this.DefaultForm.Actions.SetVariable += this.SetContextVariable;
            this.DefaultForm.Actions.GetVariable += this.GetContextVariable;
        }

        /// <summary>
        ///  注册默认缺省数据显示页
        /// </summary>
        /// <param name="view"></param>
        public void RegisterDefaultView(PowerThreadView view)
        {
            this.DefaultView = view;
        }

        /// <summary>
        /// 获取上下文变量的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GetContextVariable(object sender, PowerThreadNodeGetVariableEventEventArgs args)
        {
            args.Value = context.PowerThread.GetVariable(args.VariableName, args.VariableType);
        }

        /// <summary>
        /// 设置流程的上下文变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SetContextVariable(object sender, PowerThreadNodeSetVariableEventEventArgs args)
        {
            context.PowerThread.SetVariable(args.VariableName, args.Value);
        }

        /// <summary>
        ///  终止流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Terminate(object sender, PowerThreadNodeTerminateEventArgs args)
        {
            context.PowerThread.TerminateThreadAtNode(this);
        }

        /// <summary>
        /// 暂存表单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SaveForm(object sender, PowerThreadNodeSaveFormEventArgs args)
        {
        }

        /// <summary>
        /// 流程行进到下一个环节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GoNext(object sender, PowerThreadNodeGoNextEventArgs args)
        {
            context.PowerThread.GoNextNode(this);
        }

        /// <summary>
        /// Power Thread 的节点上定义的各个角色
        /// </summary>
        public PowerThreadRoleBox RoleBox { get; set; }

        /// <summary>
        /// Power Thread 的Node上， Responsible角色使用的默认的Form
        /// </summary>
        public PowerThreadForm DefaultForm { get; set; }

        /// <summary>
        /// Power Thread 的Node上， 各个角色使用的默认的View
        /// </summary>
        public PowerThreadView DefaultView { get; set; }

        /// <summary>
        /// Power Thread 的Node上， 给特殊的角色指定可以提交数据的Form， 但不能改变流程走向
        /// </summary>
        public Dictionary<PowerThreadRole, PowerThreadForm> SideForms { get; set; }

        /// <summary>
        /// Power Thread 的Node上， 给特殊的角色指定可以查看数据的View
        /// </summary>
        public Dictionary<PowerThreadRole, PowerThreadView> SideViews { get; set; }

        /// <summary>
        ///  是否流程终止节点
        /// </summary>
        public bool IsEnd { get; internal set; }
    }
}