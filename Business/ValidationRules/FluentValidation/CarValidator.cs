//using System;
//using Entities.Concrete;
//using FluentValidation;

//namespace Business.ValidationRules.FluentValidation
//{
//    public class CarValidator:AbstractValidator<Car>
//    {
//        public CarValidator()
//        {
//            RuleFor(c => c.Description).NotEmpty();
//            RuleFor(c => c.DailyPrice).GreaterThan(0);
//            //RuleFor(p => p.UnitPrice).GreaterThan(10).When(p => p.CategoryId == 1); //Kategori id'si 1 olan ürünler için unitprice değeri 10'dan büyük olmalıdır.
//            //RuleFor(p => p.Description).Must(StartWithA).WithMessage("Ürün isimleri A harfi ile başlamalı");
//        }

//        //private bool StartWithA(string arg)
//        //{
//        //    return arg.StartsWith("A");
//        //}
//    }
//}
