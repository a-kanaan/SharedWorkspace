using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnlikeAttributeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new PasswordChangeModel();
            model.OldPassword = "1234";
            model.NewPassword = "1234";

            var list = new List<ValidationResult>();
            if(!Validator.TryValidateObject(model, 
                new ValidationContext(model, null, null), list, true))
            {
                Console.WriteLine("Some errors found");
                foreach (var item in list) Console.WriteLine(item.ErrorMessage);
            }
        }
    }
}
