using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.User.GetUserProfile;
public interface IGetUserProfileUseCase
{
    Task<ResponseUserProfileJson> Execute();
}
