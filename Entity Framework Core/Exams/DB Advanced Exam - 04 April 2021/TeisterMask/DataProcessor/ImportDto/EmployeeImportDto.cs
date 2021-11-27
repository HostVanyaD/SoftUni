namespace TeisterMask.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using TeisterMask.Shared;

    public class EmployeeImportDto
    {
        [Required]
        [MinLength(GlobalConstants.EmployeeUsernameMinLength)]
        [MaxLength(GlobalConstants.EmployeeUsernameMaxLength)]
        [RegularExpression(GlobalConstants.EmployeeUsernameRegex)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.EmployeePhoneRegex)]
        public string Phone { get; set; }

        public int[] Tasks { get; set; }
    }

//    [
//  {
//    "Username": "jstanett0",
//    "Email": "kknapper0@opera.com",
//    "Phone": "819-699-1096",
//    "Tasks": [
//      34,
//      32,
//      65,
//      30,
//      30,
//      45,
//      36,
//      67
//    ]
//},
}
