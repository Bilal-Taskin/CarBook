using CarBook.Application.Features.Mediator.Commands.ReviewCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidator
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapınız");
            RuleFor(x => x.RateValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyin");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Yorum için lütfen en az 50 karakter girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Yorum için lütfen en fazla 500 karakter girişi yapınız");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Yorum için lütfen en fazla 500 karakter girişi yapınız");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görselini boş geçmeyiniz");
        }
    }
}
