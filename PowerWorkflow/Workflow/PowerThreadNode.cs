using PowerWorkflow.Workflow.Events;
using System;
using Newtonsoft;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Dynamic;

namespace PowerWorkflow.Workflow
{
    [Serializable]
    public class PowerThreadNode : PowerThreadBaseObject
    {
        #region fields and properties
        private PowerThreadContext context = null;

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
        public bool IsEnd { get; set; }
        public bool IsStart { get; set; }
        #endregion   
        public PowerThreadNode(Guid objectId, string name) : base(objectId, name)
        {
        }

        public void SetContext(PowerThreadContext context)
        {
            this.context = context;
        }

        #region events
        /// <summary>
        /// 获取上下文变量的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GetContextVariable(object sender, PowerThreadNodeGetVariableEventArgs args)
        {
            args.Value = context?.PowerThread.GetVariable(args.VariableName, args.VariableType);
        }

        /// <summary>
        /// 设置流程的上下文变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SetContextVariable(object sender, PowerThreadNodeSetVariableEventArgs args)
        {
            context?.PowerThread.SetVariable(args.VariableName, args.Value);
        }

        /// <summary>
        ///  终止流程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Terminate(object sender, PowerThreadNodeTerminateEventArgs args)
        {
            context?.PowerThread.TerminateThreadAtNode(this);
        }

        /// <summary>
        /// 暂存表单数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SaveForm(object sender, PowerThreadNodeSaveFormEventArgs args)
        {
            PowerThreadForm form = (PowerThreadForm)sender;

            var formData = args.Entity;

            PersistData(context, form, formData);
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
        /// 加载当前节点信息， 并显示Form / View 相关内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name=""></param>
        private void LoadForm(object sender, PowerThreadNodeLoadEventArgs args)
        {
            PowerThreadForm form = (PowerThreadForm)sender;

            LoadFormData(context, form);

        }
        #endregion

        #region methods
        /// <summary>
        ///  注册默认表单
        /// </summary>
        /// <param name="form"></param>
        public void RegisterDefaultForm(PowerThreadForm form)
        {
            this.DefaultForm = form;
            this.DefaultForm.GoNext += this.GoNext;
            this.DefaultForm.LoadForm += this.LoadForm;
            this.DefaultForm.SaveForm += this.SaveForm;
            //this.DefaultForm.Terminate += this.Terminate;
            //this.DefaultForm.SetVariable += this.SetContextVariable;
            //this.DefaultForm.GetVariable += this.GetContextVariable;
        }

        /// <summary>
        ///  注册默认数据显示页
        /// </summary>
        /// <param name="view"></param>
        public void RegisterDefaultView(PowerThreadView view)
        {
            this.DefaultView = view;
        }

        /// <summary>
        /// 渲染对应的forms和views
        ///   
        /// 只有当前节点是current node， 才会有form渲染
        /// 只渲染当前role 对应的form
        /// </summary>
        /// <returns></returns>
        public string RenderPage()
        {
            throw new NotImplementedException();

            /*
             form 数据的提交通过标准的ajax API 
             form 如果要加载一些特殊的数据， 也可以ajax请求指定的api

             form 提交的数据 以jObject的格式， 保存到view model中
             form 中的表格数据处理？
             form 中上传文件的处理？
             */
        }
        public void LoadNode()
        {

            DefaultForm.Load();
            //  DefaultView.Load();

            //foreach (var form in SideForms.Values)
            //{
            //    form.Load();
            //}


            //foreach (var view in SideViews.Values)
            //{
            //    //view.Load();
            //}
        }

        #endregion

        #region Data access from data layer

        private void PersistData(
            PowerThreadContext context
            , PowerThreadForm form
            , PowerThreadEntity formData)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            if (formData == null)
            {
                throw new ArgumentNullException(nameof(formData));
            }

            throw new NotImplementedException();
        }

        private void LoadFormData(
            PowerThreadContext context
            , PowerThreadForm form
            )
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (form == null)
            {
                throw new ArgumentNullException(nameof(form));
            }

            var json = string.Format("{{Content:\"my content of {0}\"}}", form.Name);

            form.BindingViewModel.Data =
                JsonConvert.DeserializeObject<ExpandoObject>(json);
        }

        #endregion

    }
}