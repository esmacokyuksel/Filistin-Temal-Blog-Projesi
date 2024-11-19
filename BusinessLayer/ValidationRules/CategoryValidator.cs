using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CategoryValidator:AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("KATEGORİ ADINI BOŞ GEÇEMEZSİNİZ");
			RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("KATEGORİ AÇIKLAMASINI BOŞ GEÇEMEZSİNİZ");
			RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("LÜTFEN EN AZ 3 KARAKTERLİK KATEGORİ ADI GİRİŞİ YAPINIZ");
			RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("LÜTFEN EN FAZLA 50 KARAKTERLİK KATEGORİ ADI GİRİŞİ YAPINIZ");

		}
	}
}
