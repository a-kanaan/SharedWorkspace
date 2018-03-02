using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlikeAttributeConsoleApp
{
    public class PasswordChangeModel //: IValidatableObject
    {
        [Display(Name = "OldPassword", ResourceType = typeof(AppResource))]
        public string OldPassword { get; set; }

        [Display(Name = "NewPassword", ResourceType = typeof(AppResource))]
        [Unlike("OldPassword")]
        public string NewPassword { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    yield return Validator.
        //}
    }
}
