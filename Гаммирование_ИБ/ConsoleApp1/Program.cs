using System;

public class GammaEncryption
{
    public static string Encrypt(string text, string key)
    {
        string encryptedText = "";

        for (int i = 0; i < text.Length; i++)
        {
            // Получаем символы текста и ключа
            char textChar = text[i];
            char keyChar = key[i % key.Length];

            // Применяем операцию XOR для символа текста и ключа
            char encryptedChar = (char)(textChar ^ keyChar);

            // Добавляем зашифрованный символ к результату
            encryptedText += encryptedChar;
        }

        return encryptedText;
    }

    public static string Decrypt(string encryptedText, string key)
    {
        // Для расшифровки текста применяем ту же операцию XOR
        // используя тот же ключ
        return Encrypt(encryptedText, key);
    }

    public static void Main()
    {
        string text = "Hello, World!"; // Текст для шифрования
        string key = "secret"; // Ключ

        // Преобразуем текст и ключ в байтовые массивы, используя кодировку UTF-8
        byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(text);
        byte[] keyBytes = System.Text.Encoding.UTF8.GetBytes(key);

        // Шифруем текст
        byte[] encryptedBytes = new byte[textBytes.Length];
        for (int i = 0; i < textBytes.Length; i++)
        {
            encryptedBytes[i] = (byte)(textBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        // Преобразуем зашифрованные байты обратно в строку
        string encryptedText = System.Text.Encoding.UTF8.GetString(encryptedBytes);

        Console.WriteLine("Зашифрованный текст: " + encryptedText);

        // Расшифровываем текст
        byte[] decryptedBytes = new byte[encryptedBytes.Length];
        for (int i = 0; i < encryptedBytes.Length; i++)
        {
            decryptedBytes[i] = (byte)(encryptedBytes[i] ^ keyBytes[i % keyBytes.Length]);
        }

        // Преобразуем расшифрованные байты обратно в строку
        string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedBytes);

        Console.WriteLine("Расшифрованный текст: " + decryptedText);
    }
}
