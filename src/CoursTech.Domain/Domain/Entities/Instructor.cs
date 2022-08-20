using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Instructor
    {
        public Guid InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                if (MailAddress.TryCreate(value , out _))
                    _email = value;
                else
                    throw new InvalidOperationException("passed value seems to be not in email address manner");
            }
        }
        string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if (Regex.IsMatch(value , @"^[\+\s\d]+$"))
                    _phoneNumber = value;
                else
                    throw new InvalidOperationException("passed value seems to be not in phone number manner");
            }
        }
        public string PhotoName { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
