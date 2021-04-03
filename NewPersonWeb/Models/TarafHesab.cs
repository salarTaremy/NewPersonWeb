using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewPersonWeb.Models
{
    public class TarafHesab
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [Display(Name = "نام", Description = "Description", Prompt = "نام")]
        public string Name { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        [Display(Name = "نام خانوادگی", Description = "Description", Prompt = "نام خانوادگی")]
        public string Famil { get; set; }
        [Required(ErrorMessage = "شماره شناسنامه الزامی است")]
        [Display(Name = "شماره شناسنامه", Description = "Description", Prompt = "شماره شناسنامه")]
        public string Sh_Sh { get; set; }
        [Required(ErrorMessage = "نام پدر الزامی است")]
        [Display(Name = "نام پدر", Description = "Description", Prompt = "نام پدر")]
        public string NamePedar { get; set; }
        public long? IdTafsilGroup { get; set; }
        public long? IdTafsil { get; set; }
        [MaxLength(10, ErrorMessage = "طول کد ملی باید 10 کاراکتر باشد")]
        [MinLength(10, ErrorMessage = "طول کد ملی باید 10 کاراکتر باشد")]
        [Required(ErrorMessage = "ورود کد ملی الزامی است")]
        [Display(Name = "کد ملی", Description = "Description", Prompt = "کد ملی")]
        [UIHint("UIHint")]
        public string Code_melli { get; set; }
        public string CodeEghtesadi { get; set; }
        [Display(Name = "تولد", Description = "Description", Prompt = "تولد")]
        public int? BirthDay { get; set; }
        public int? SodoorDate { get; set; }
        public long? Serial { get; set; }
        public long? IdMahalTavalod { get; set; }
        public long? IdMahalSodoor { get; set; }
        [Display(Name = "نام کامل", Description = "Description", Prompt = "نام کامل(غیر قابل تغییر)")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "ورود رمز عبور الزامی است")]
        [Display(Name = "رمز عبور", Description = "Description", Prompt = "رمز عبور")]
        [DataType(DataType.Password)]
        [UIHint("UIHint")]
        public string WebPassword { get; set; }

        [NotMapped]
        [Display(Name = "تکرار رمز عبور", Description = "Description", Prompt = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare("WebPassword")]
        public string ConfirmWebPassword { get; set; }

        [NotMapped]
        [Display(Name = "رمز فعلی", Description = "Description", Prompt = "رمز فعلی")]
        [DataType(DataType.Password)]
        public string ResetToken { get; set; }

        [NotMapped]
        public string ErrorMessageForLogin { get; set; }

        [NotMapped]
        public string SuccessMessage { get; set; }

        [NotMapped]
        [Display(Name = "تلفن همرا")]
        public string Mobile { get; set; }

        [NotMapped]
        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
