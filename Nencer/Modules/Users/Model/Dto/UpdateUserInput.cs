using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic;
using Nencer.Resources;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nencer.Modules.Users.Model.Dto
{
    public class UpdateUserInput
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
