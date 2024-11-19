using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	
	public class AuthorValidator:AbstractValidator<Author>
	{
		public AuthorValidator()
		{
			RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar Adı boş geçilemez");
			RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Yazar Başlık Değeri boş geçilemez");
			RuleFor(x => x.AuthorImage).NotEmpty().WithMessage("Yazar Görseli Boş Geçilemez");
			RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Yazar Hakkında Kısmı Boş Geçilemez");

		}
	}
}
