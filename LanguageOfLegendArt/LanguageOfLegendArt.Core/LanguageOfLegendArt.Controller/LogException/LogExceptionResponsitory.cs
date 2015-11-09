using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.LogException
{
    public class LogExceptionResponsitory: DataCenterInterfaceBase<Model.LogException>
    {
        public LogExceptionResponsitory(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}

