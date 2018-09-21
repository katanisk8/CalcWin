using DataAccess.Data;

namespace CalcWin.BusinessLogic.ControllersLogic
{
    public class SettingsLogic : ISettingsLogic
    {
        private readonly ApplicationDbContext _db;

        public SettingsLogic(ApplicationDbContext context)
        {
            _db = context;
        }

        public void Do()
        {

        }
    }
}
