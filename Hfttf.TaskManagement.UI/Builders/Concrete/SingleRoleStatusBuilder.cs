using Hfttf.TaskManagement.UI.Builders.Abstract;
using Hfttf.TaskManagement.UI.Models;

namespace Hfttf.TaskManagement.UI.Builders.Concrete
{
    public class SingleRoleStatusBuilder : StatusBuilder
    {
        public override Status GenerateStatus(AppUser activeUser, string roles)
        {
            Status status = new Status();
            if (activeUser.Roles.Contains(roles))
            {
                status.AccessStatus = true;
            }

            return status;
        }
    }
}