namespace GeneralChat.Server.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nickname")]
        public string Nickname { get; set; }
        //[Display(Name = "Name")]
        //public string Name { get; set; }
        //[Display(Name = "Last Name")]
        //public string LastName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}