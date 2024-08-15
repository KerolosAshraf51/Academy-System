using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            Course Coursefromrequest = (Course)validationContext.ObjectInstance;
            ITIContext context = new ITIContext();
            Course course = context.courses.FirstOrDefault(c => c.Name == value.ToString() && c.Dept_id==Coursefromrequest.Dept_id);
            if (course == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Name Already Exist");
            }
        }
    }
    }
