using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerWorkflow.Workflow
{
    public abstract class PowerThreadBaseObject
    {
        public PowerThreadBaseObject(string name)
        {
            this.Name = name;
            this.ObjectId = CreateId();
        }
        public Guid ObjectId { get; protected set; }

        public string Name { get; private set; }
        protected Guid CreateId()
        {
            return Guid.NewGuid();
        }

    }
}
