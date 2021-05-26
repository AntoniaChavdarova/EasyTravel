namespace EasyTravel.Services.Data
{
    using System.Threading.Tasks;

    using EasyTravel.Web.ViewModels.ContactForms;

    public interface IContactFormService
    {
        Task MakeContactFormAsync(ContactFormViewModel model, string userId);
    }
}
