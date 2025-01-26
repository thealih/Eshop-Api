using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Services.Common.Application;
using Shop.Application._Utilities;
using Shop.Domain.SiteEntities.Repository;

namespace Shop.Application.SiteEntities.Sliders.Edit;

public class EditSliderCommandHandler : IBaseCommandHandler<EditSliderCommand>
{
   
    private readonly IFileService _fileService;
    private readonly ISliderRepository _repository;
    public EditSliderCommandHandler(IFileService fileService, ISliderRepository repository)
    {
        _fileService = fileService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditSliderCommand request, CancellationToken cancellationToken)
    {
        var slider = await _repository.GetTracking(request.Id);
        if (slider == null)
            return OperationResult.NotFound();
        var imageName = slider.ImageName;
        var oldimage = slider.ImageName;
        if (request.ImageFile != null) imageName = await _fileService
            .SaveFileAndGenerateName(request.ImageFile, Directories.SliderImages);

        slider.Edit(request.Title,request.Link,imageName);

        DeleteOldImage(request.ImageFile , oldimage);
        return OperationResult.Success();
    }

    private void DeleteOldImage(IFormFile? imageFile, string oldImage)
    {
        if (imageFile !=null)
        {
            _fileService.DeleteFile(Directories.SliderImages,oldImage);
        }
    }
}