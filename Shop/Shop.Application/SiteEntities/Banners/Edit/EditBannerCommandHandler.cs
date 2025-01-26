using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Common.Application;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Banners.Edit;

public class EditBannerCommandHandler:IBaseCommandHandler<EditBannerCommand>
{
    public EditBannerCommandHandler(IBannerRepository repository, IFileService fileService)
    {
        _repository = repository;
        _fileService = fileService;
    }
    private readonly IBannerRepository _repository;
    private readonly IFileService _fileService;
    public async Task<OperationResult> Handle(EditBannerCommand request, CancellationToken cancellationToken)
    {
        var banner = await _repository.GetTracking(request.Id);
        if (banner == null)
            return OperationResult.NotFound();
        var imageName = banner.ImageName;
        var oldImage = banner.ImageName;
        if (request.ImageFile != null) imageName = await _fileService
            .SaveFileAndGenerateName(request.ImageFile, Directories.BannerImages);

        banner.Edit(request.Link , imageName , request.Position);

       DeleteOldImage(request.ImageFile , oldImage);
        return OperationResult.Success();
    }
    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.SliderImages, oldImage);
        }
    }
}