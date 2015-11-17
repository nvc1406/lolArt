using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageOfLegendArt.Core.UnitOfWork;

namespace LanguageOfLegendArt.Core.LanguageOfLegendArt.Controller.PageDefault
{
    class PageDefaultResponsitory: DataCenterInterfaceBase<Model.PageDefault>
    {
        public PageDefaultResponsitory(IUnitOfWork unit)
            : base(unit)
        {
            
        }
    }
}
