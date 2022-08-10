using Ordering.Application.Common.Models;

namespace Ordering.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
