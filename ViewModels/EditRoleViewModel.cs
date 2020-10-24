using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace blog.ViewModels
{
    public class EditRoleViewModel
    {
        [Display(Name = "角色ID")]
        public string Id { get; set; }
        [Required(ErrorMessage = "角色名称是必填的")]
        [Display(Name = "角色名称")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();
    }
}