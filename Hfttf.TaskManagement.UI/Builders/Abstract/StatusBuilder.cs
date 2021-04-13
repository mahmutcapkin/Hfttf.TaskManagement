using Hfttf.TaskManagement.UI.Builders.Concrete;
using Hfttf.TaskManagement.UI.Models;

namespace Hfttf.TaskManagement.UI.Builders.Abstract
{
    public abstract class StatusBuilder
    {
        public abstract Status GenerateStatus(AppUser activeUser, string roles);
    }
}