using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.User
{
    public class UserResponsitory : DataCenterInterfaceBase<Model.User>
    {
        public UserResponsitory(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}
