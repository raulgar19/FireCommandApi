using FireCommandModels.Services.Interfaces;

namespace FireCommandApi.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly IConfiguration configuration;
        private readonly HttpClient httpClient;

        public TelegramService(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.httpClient = new HttpClient();
        }

        public async Task SendTelegramMessageAsync(string message)
        {
            string botToken = this.configuration["TelegramBot:Token"];
            string chatId = this.configuration["TelegramBot:ChatId"];

            if (string.IsNullOrEmpty(botToken) || string.IsNullOrEmpty(chatId))
            {
                throw new InvalidOperationException("Credenciales incorrectas");
            }

            string url = $"https://api.telegram.org/bot{botToken}/sendMessage?chat_id={chatId}&text={System.Uri.EscapeDataString(message)}&parse_mode=Markdown";

            await this.httpClient.GetAsync(url);
        }
    }
}
