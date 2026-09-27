using BSL.v59.Core;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BSL.v59;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var gamePort = ReadPort("GAME_PORT", 9339);
        var healthPort = ReadPort("PORT", 3000);

        var gateway = new LaserTcpCentralGateway((ushort)gamePort);
        if (!gateway.Start())
            throw new InvalidOperationException($"Could not listen on 0.0.0.0:{gamePort}");

        _ = RunHealthServerAsync(healthPort);

        var message =
            $"✅ BSL v59 запущен на BotHost\n" +
            $"Локальный игровой порт: {gamePort}/TCP\n" +
            $"Проверка состояния: {healthPort}/HTTP\n\n" +
            "Для клиента используйте публичный адрес и порт TCP-туннеля.";
        Console.WriteLine(message);
        await SendTelegramAsync(message);

        await Task.Delay(Timeout.Infinite);
    }

    private static int ReadPort(string variable, int fallback)
    {
        var value = Environment.GetEnvironmentVariable(variable);
        return !string.IsNullOrWhiteSpace(value) &&
               int.TryParse(value, out var port) &&
               port is >= 1000 and <= 65535
            ? port
            : fallback;
    }

    private static async Task RunHealthServerAsync(int port)
    {
        var listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"Health endpoint listening on 0.0.0.0:{port}");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = Task.Run(async () =>
            {
                using (client)
                {
                    var body = Encoding.UTF8.GetBytes("BSL v59 is running\n");
                    var header = Encoding.ASCII.GetBytes(
                        "HTTP/1.1 200 OK\r\n" +
                        "Content-Type: text/plain; charset=utf-8\r\n" +
                        $"Content-Length: {body.Length}\r\n" +
                        "Connection: close\r\n\r\n");

                    var stream = client.GetStream();
                    await stream.WriteAsync(header);
                    await stream.WriteAsync(body);
                }
            });
        }
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
