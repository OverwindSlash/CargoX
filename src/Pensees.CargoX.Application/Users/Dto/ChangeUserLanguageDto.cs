using System.ComponentModel.DataAnnotations;

namespace Pensees.CargoX.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}