using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PowerWorkflow.Workflow
{
    [DebuggerDisplay("{Name}-{ObjectId}")]
    [Serializable]
    public abstract class PowerThreadBaseObject
    {
        public PowerThreadBaseObject(Guid objectId, string name)
        {
            this.Name = name;
            this.ObjectId = objectId;
        }

        /// <summary>
        ///  在Description中规定的对象Id
        /// </summary>
        public Guid ObjectId { get; protected set; }

        public string Name { get; private set; }

        protected Guid CreateId()
        {
            return Guid.NewGuid();
        }


        public override string ToString()
        {
            return this.ObjectId.ToString();
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PowerThreadBaseObject))
            {
                return false;
            }
            var item = (PowerThreadBaseObject)obj;

            return item.GetType() == this.GetType() &&
                item.ObjectId == this.ObjectId;
        }

        public override int GetHashCode()
        {
            return this.ObjectId.GetHashCode();
        }
    }
}
