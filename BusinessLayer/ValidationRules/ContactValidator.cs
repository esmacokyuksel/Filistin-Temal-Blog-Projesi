using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class ContactValidator:AbstractValidator<Contact>
	{
		public ContactValidator()
		{
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail boş geçilemez");
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsimboş geçilemez");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş geçilemez");
			RuleFor(x => x.Message).NotEmpty().WithMessage("mESAJ içeriği boş geçilemez");

		}
	}
}
