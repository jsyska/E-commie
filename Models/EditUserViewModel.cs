using E_commie.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_commie.Models
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }

        public IList<SelectListItem> Roles { get; set; }
    }
}