using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.Category
{
    public class CategoryResponsitory: DataCenterInterfaceBase<Model.Category>
    {
        public CategoryResponsitory(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}
