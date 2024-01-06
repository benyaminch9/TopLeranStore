using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopLearn.Web.Models.User
{
    public class Role
    {
        [Key] 
        public int RoleId { get; set; }

        [Display(Name ="")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(200,ErrorMessage = "{0} نمی تواند بیشتر از {1} کارکتر باشد")]
        public int RoleTitle { get; set; }

        #region Relations

        public virtual List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
