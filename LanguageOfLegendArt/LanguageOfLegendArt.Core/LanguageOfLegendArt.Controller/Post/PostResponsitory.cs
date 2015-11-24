using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.Post
{
    public class PostResponsitory : DataCenterInterfaceBase<Model.Post>
    {
        public PostResponsitory(IUnitOfWork unit)
            : base(unit)
        {

        }
    }
}