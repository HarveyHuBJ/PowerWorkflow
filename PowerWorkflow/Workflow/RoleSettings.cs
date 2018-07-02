using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerWorkflow.Workflow
{
    public class RoleSettings
    {
        private IDictionary<Guid, IList<IUser>> innerData { get; set; }
            = new Dictionary<Guid, IList<IUser>>();

        public void Add(Guid roleId, IList<IUser> users)
        {
            innerData[roleId] = users;
        }

        public IList<IUser> GetUsers(Guid roleId)
        {
            if (innerData.ContainsKey(roleId))
            {
                return innerData[roleId];
            }
            return new List<IUser>();
        }

        public void AddUser(Guid roleId, IUser user)
        {
            IList<IUser> users = GetUsers(roleId);
            if (users.Count == 0)
            {
                users.Add(user);
                Add(roleId, users);
            }
            else
            {
                users.Add(user);
            }
        }

        public IList<Guid> GetRoleIds()
        {
            return innerData.Keys.ToList();
        }


        public IList<Guid> GetRoleIds(IUser user)
        {
            IList<Guid> result = new List<Guid>();
            foreach (var item in innerData)
            {
                if (item.Value.Any(p => p.Id == user.Id))
                {
                    result.Add(item.Key);
                }
            }

            return result;
        }
    }

    public interface IUser
    {
        Guid Id { get; }
        string UserName { get; }
    }
}
