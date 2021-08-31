using System;
using System.IO;
using Core.Utilities.Helpers.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.Concrete
{
    public class ImageHelper : IImageHelper
    {

        private static string defaultCarImageName = "defaultCarImage.png";
        private static string defaultCarImagePath = Path.Combine("uploadedImages", defaultCarImageName);

        public IResult Delete(string imagePath)
        {

            
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
                return new SuccessResult("Dosya başarıyla silindi");
            }
            else
            {
                return new ErrorResult("Dosya silinirken bir hata oluştu.Dosya mevcut değil");
            }
        }

        public IDataResult<string> GetDefaultCarImage()
        {
            return new SuccessDataResult<string>(defaultCarImagePath,"Başarılı");
        }

        public IResult Update(IFormFile file, string imagePath)
        {
            if (System.IO.File.Exists(imagePath))
            {
                var uploadResult = Upload(file);
                if (uploadResult.Success)
                {
                    if (imagePath != defaultCarImagePath)
                    {
                        Delete(imagePath);
                    }
                }
                return new SuccessResult("Dosya başarıyla güncellendi");
            }
            return new ErrorResult("Dosya güncellenirken bir hata oluştu");
        }

        public IDataResult<string> Upload(IFormFile file)
        {

            try
            {
                if (!Directory.Exists("wwwroot/uploadedImages"))
                {
                    Directory.CreateDirectory("wwwroot/uploadedImages");
                }

                string fileExtension = Path.GetExtension(file.FileName);
                string fileGuid = Guid.NewGuid().ToString();
                string fileName = $"{fileGuid}{fileExtension}";

                 var pathForStream = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploadedImages", fileName);
                var path = Path.Combine("uploadedImages", fileName);


                using (var stream = new FileStream(pathForStream, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return new SuccessDataResult<string>(path,"Dosya başarıyla yüklendi");
            }
            catch (Exception ex)
            {
                    return new ErrorDataResult<string>(null,"Dosya yüklenirken bir hata oluştu :" + ex);
            }

        }
    }
}
