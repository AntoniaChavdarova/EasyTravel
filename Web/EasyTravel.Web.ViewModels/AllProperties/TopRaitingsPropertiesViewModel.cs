namespace EasyTravel.Web.ViewModels.AllProperties
{
    using System.Linq;

    using AutoMapper;
    using EasyTravel.Data.Models;
    using EasyTravel.Services.Mapping;

    public class TopRaitingsPropertiesViewModel : PropertyBaseViewModel, IMapFrom<Property>, IHaveCustomMappings
    {
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Property, TopRaitingsPropertiesViewModel>()
                .ForMember(x => x.AverageRaiting, opt =>
                     opt.MapFrom(x => x.Ratings.Count() == 0 ? 0 : x.Ratings.Average(v => v.Value)));
        }
    }
}
