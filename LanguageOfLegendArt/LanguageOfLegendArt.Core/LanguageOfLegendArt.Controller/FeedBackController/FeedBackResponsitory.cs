using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.FeedBackController
{
    public class FeedBackResponsitory: DataCenterInterfaceBase<Model.FeedBack>
    {
        public FeedBackResponsitory(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}
