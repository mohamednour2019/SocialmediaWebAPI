namespace SocialMedia.Core.ServicesInterfaces
{
    public interface IGenericService<TRequest,TResponse>
    {
        Task<TResponse> Perform(TRequest requestDto);
    }
}
