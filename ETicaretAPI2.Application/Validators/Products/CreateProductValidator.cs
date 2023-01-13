﻿using ETicaretAPI2.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI2.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(100)
                .MinimumLength(2)
                .WithMessage("Lütfen ürün adını 2 ile 100 karakter arasında bir değer giriniz");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen stok bilgisini boş geçmeyiniz.")
                .Must(s => s >= 0)
                .WithMessage("Stok bilgisi 0'dan küçük olamaz");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz")
                .Must(p => p >= 0)
                .WithMessage("Fiyat bilgisi 0'dan küçük olamaz");
        }
    }
}
