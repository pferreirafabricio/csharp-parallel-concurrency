namespace GracefulCancellation;

public class TextGenerationService
{
    public async Task GenerateTextFileAsync(string path, int lengthMb, CancellationToken token)
    {
        using var writer = new StreamWriter(path);

        var buffer = new char[128];
        var length = lengthMb * 1024 * 1024 / buffer.Length;

        for (int i = 0; i < length; i++)
        {
            FillRandomText(buffer);
            await writer.WriteAsync(buffer, token);
        }
    }

    /// <summary>
    /// Fills the given character array with random text.
    /// </summary>
    /// <param name="buffer">The character array to fill with random text.</param>
    /// <remarks>
    /// The random text is generated using a set of characters that includes uppercase letters, lowercase letters, digits, and newline characters.
    /// </remarks>
    public void FillRandomText(char[] buffer)
    {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789\n";
        Random random = new();

        for (int i = 0; i < buffer.Length; i++)
            buffer[i] = chars[random.Next(chars.Length)];
    }
}
