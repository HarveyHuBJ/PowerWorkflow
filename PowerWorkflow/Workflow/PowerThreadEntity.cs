using System;
using System.Collections.Generic;
using System.Dynamic;

namespace PowerWorkflow.Workflow
{
    /// <summary>
    /// 实体对象， 用来提交数据用
    /// 每个表单会绑定一个实体
    /// </summary>
    public class PowerThreadEntity : PowerThreadBaseObject
    {

        public ExpandoObject Data { get;  set; }

        public PowerThreadEntity(Guid objectId, string name) : base(objectId, name)
        {
             
        }
    }
}