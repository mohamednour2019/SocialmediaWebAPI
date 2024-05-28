using SocialMedia.Core.Domain.Entities;
using SocialMedia.Core.Domain.RepositoriesInterfaces;
using SocialMedia.Core.DTO_S.RequestDto_S;
using SocialMedia.Core.ServicesInterfaces.AzureBlobInterfaces;
using SocialMedia.Core.ServicesInterfaces.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services.UserServices
{
    public class AddCoverPictureService : IAddCoverPictureService
    {
        private IUploadImageServie _uploadImageServie;
        private IGenericRepository<User> _userRepository;
        private IUnitOfWork _unitOfWork;
        public AddCoverPictureService(IUploadImageServie uploadImageServie
            , IUnitOfWork unitOfWork
            , IGenericRepository<User> genericRepository)
        {
            _uploadImageServie = uploadImageServie;
            _userRepository = genericRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<ResponseModel<string>> Perform(AddUserImageRequestDto requestDto)
        {
            string ImageUrl = null;
            try
            {
                ImageUrl = await _uploadImageServie.UploadImage(requestDto.Image);
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong");
            }
            try
            {
                User user = await _userRepository.FindAsync(requestDto.UserId);
                user.CoverPictureUrl = ImageUrl;
            }
            catch (Exception ex)
            {
                throw new Exception("something went wrong");
            }

            await _unitOfWork.SaveChangeAsync();
            return new ResponseModel<string>()
            {
                Success = true,
                Message = new List<string>
                {"profile picture has been added!"}
                ,
                Data = ImageUrl
            };

        }
    }
}
