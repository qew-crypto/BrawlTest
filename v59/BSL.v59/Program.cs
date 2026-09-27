using BSL.v59.Core;

namespace BSL.v59;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var port = 9339;
        var portValue = Environment.GetEnvironmentVariable("PORT");
        if (!string.IsNullOrWhiteSpace(portValue) &&
            int.TryParse(portValue, out var parsedPort) &&
            parsedPort is >= 1000 and <= 65535)
        {
            port = parsedPort;
        }

        var gateway = new LaserTcpCentralGateway((ushort)port);
        if (!gateway.Start())
            throw new InvalidOperationException($"Could not listen on 0.0.0.0:{port}");

        var publicHost = Environment.GetEnvironmentVariable("PUBLIC_HOST") ?? "MeshBrawl.bothost.tech";
        var message = $"✅ BSL v59 запущен на BotHost\nАдрес: {publicHost}\nПорт: {port}/TCP\n\nredirectHost = {publicHost}\nredirectPort = {port}";
        Console.WriteLine(message);
        await SendTelegramAsync(message);

        await Task.Delay(Timeout.Infinite);
    }

    private static async Task SendTelegramAsync(string message)
    {
        var token = Environment.GetEnvironmentVariable("BOT_TOKEN");
        var chatId = Environment.GetEnvironmentVariable("TELEGRAM_CHAT_ID");
        if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(chatId))
        {
            Console.WriteLine("Telegram notification skipped: BOT_TOKEN or TELEGRAM_CHAT_ID is missing");
            return;
        }

        try
        {
            using var client = new HttpClient();
            using var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                ["chat_id"] = chatId,
                ["text"] = message
            });
            var response = await client.PostAsync($"https://api.telegram.org/bot{token}/sendMessage", content);
            if (!response.IsSuccessStatusCode)
                Console.WriteLine($"Telegram notification failed: {(int)response.StatusCode} {await response.Content.ReadAsStringAsync()}");
        }
        catch (Exception exception)
        {
            Console.WriteLine($"Telegram notification failed: {exception.Message}");
        }
    }
}
