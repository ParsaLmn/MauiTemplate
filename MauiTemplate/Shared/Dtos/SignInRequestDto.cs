using System.ComponentModel.DataAnnotations;


namespace Shared.Dtos
{
    public class SignInRequestDto
    {
        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(General), ErrorMessageResourceName = nameof(General.UserNameRequired))]        
        //[Display(ResourceType = typeof(General), Name = (nameof(General.UserName)))]
        [Required]
        public string? UserName { get; set; }

        //[Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(General), ErrorMessageResourceName = nameof(General.PasswordRequired))]
        //[Display(ResourceType = typeof(General), Name = (nameof(General.Password)))]
        [Required]
        public string? Password { get; set; }
    }
}
