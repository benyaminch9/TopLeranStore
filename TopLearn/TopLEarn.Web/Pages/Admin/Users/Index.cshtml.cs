using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopLearn.Core.DTOs;
using TopLearn.Core.Services.Interfaces;

namespace TopLEarn.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        private IUserServices _userServices;

        public IndexModel(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet()
        {
            UserForAdminViewModel = _userServices.GetUsers();
        }
    }
}
