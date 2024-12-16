using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace HomePro.Data.Services

public class DummyEmailSender : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        Console.WriteLine($"Email sent to: {email}, Subject: {subject}");
        return Task.CompletedTask;
    }
}
