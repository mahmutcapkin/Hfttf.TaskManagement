using Hfttf.TaskManagement.UI.Builders.Abstract;
using Hfttf.TaskManagement.UI.Models;

namespace Hfttf.TaskManagement.UI.Builders.Concrete
{
    public class StatusBuilderDirector
    {
        private StatusBuilder builder;
        public StatusBuilderDirector(StatusBuilder builder)
        {
            this.builder = builder;
        }

        public Status GenerateStatus(AppUser activeUser, string roles)
        {
            return builder.GenerateStatus(activeUser, roles);
        }


    }
}