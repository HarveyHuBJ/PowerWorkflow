using System.Collections.Generic;

namespace PowerWorkflow.Workflow
{
    public class PowerThreadRoleBox
    {

        public PowerThreadRole ResponsibleRole { get; set; }

        public IList<PowerThreadRole> SideRoles { get; set; }

        //public IList<PowerThreadRole> AccountableRole { get; set; }

        //public IList<PowerThreadRole> ConsultedRole { get; set; }

        //public IList<PowerThreadRole> InformedRole { get; set; }
    }
}