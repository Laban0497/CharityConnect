using CharityConnect.Application.DTOs.Payments;

namespace CharityConnect.Application.Interfaces
{
    public interface IPaymentService
    {
        Task<string> InitiateStkPushAsync(StkPushRequestDTO dto);
        Task HandleCallbackAsync(string jsonPayload); // for callback
    }
}
