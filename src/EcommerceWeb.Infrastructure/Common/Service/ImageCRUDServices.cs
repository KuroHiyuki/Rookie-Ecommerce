using EcommerceWeb.Application.Common.Services;
using EcommerceWeb.Application.Products.Common.Response;
using EcommerceWeb.Domain.Entities;


namespace EcommerceWeb.Infrastructure.Common.Service
{
    public class ImageCRUDServices
    {
        private readonly IFileStorage _fileStorageService;

        public ImageCRUDServices(IFileStorage fileStorageService)
        {
            _fileStorageService = fileStorageService;
        }
        public async Task RemoveProductImages(Product existingProduct)
        {
            List<Task> imgDeleteTasks = new();
            foreach (var image in existingProduct.Images)
            {
                imgDeleteTasks.Add(_fileStorageService.DeleteFileAsync(image.Url));
            }

            await Task.WhenAll(imgDeleteTasks);
            existingProduct.Images.Clear();
        }

        public async Task<List<Image>> SaveProductImages(ProductRequest command)
        {
            List<Image> productImages = new List<Image>();
            List<Task<string>> imgSaveTasks = new();
            if (command.Images != null)
            {
                foreach (var image in command.Images)
                {
                    // Save image to storage and get the path
                    imgSaveTasks.Add(_fileStorageService.SaveFileAsync(image));
                }
            }

            await Task.WhenAll(imgSaveTasks);

            imgSaveTasks.ForEach(task =>
            {
                var productImage = new Image()
                {
                    Url = task.Result
                };
                productImages.Add(productImage);
            });
            return productImages;
        }
    }
}
