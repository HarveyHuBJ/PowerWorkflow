using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PowerWorkflow.Template
{
    public class MajorItems
    {
        /// <summary>
        /// 
        /// </summary>
        public string formRef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formRoleRef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pageRef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pageRoleRef { get; set; }
    }

    public class OptionalItems
    {
        /// <summary>
        /// 
        /// </summary>
        public List<string> forms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> pages { get; set; }
    }

    public class NodesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int index { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nodeId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nodeTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> variables { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public MajorItems majorItems { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public OptionalItems OptionalItems { get; set; }
    }

    public class RolesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string roleId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string roleName { get; set; }
    }

    public class ActionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string action { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string assignTo { get; set; }
    }

    public class FormsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string formId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formModel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ActionsItem> actions { get; set; }
    }

    public class PagesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string pageId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pageName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pagePath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string pageModel { get; set; }
    }

    public class ConditionsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string condition { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string goToEnd { get; set; }
    }

    public class TransmitItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string onAction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ConditionsItem> conditions { get; set; }
    }

    public class StateMachineItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string init { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string nodeRef { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<TransmitItem> transmit { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string threadId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string threadName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<NodesItem> nodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<RolesItem> roles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FormsItem> forms { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<PagesItem> pages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<StateMachineItem> stateMachine { get; set; }
    }



}