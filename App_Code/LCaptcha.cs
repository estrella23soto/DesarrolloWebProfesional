using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

public class LCaptcha
{
    public Tuple<Image, string> GenerateCaptcha()
    {
        int width = 200;
        int height = 80;

        Bitmap bitmap = new Bitmap(width, height);
        Graphics graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        graphics.Clear(Color.White);

        Random random = new Random();
        string captchaText = GenerateRandomText(6); // Genera un texto aleatorio de 6 caracteres

        Font font = new Font("Arial", 30, FontStyle.Bold);
        SolidBrush brush = new SolidBrush(Color.Black);
        graphics.DrawString(captchaText, font, brush, 10, 10);

        // Agrega ruido al captcha
        for (int i = 0; i < 100; i++)
        {
            int x = random.Next(0, width);
            int y = random.Next(0, height);
            bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
        }

        // Agrega líneas al captcha
        for (int i = 0; i < 5; i++)
        {
            int x1 = random.Next(0, width);
            int y1 = random.Next(0, height);
            int x2 = random.Next(0, width);
            int y2 = random.Next(0, height);
            graphics.DrawLine(new Pen(Color.Gray), x1, y1, x2, y2);
        }

        graphics.Dispose();

        return new Tuple<Image, string>(bitmap, captchaText);
    }

    public string GenerateRandomText(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string result = new string(Enumerable.Repeat(chars, length)
            .Select(s => s[random.Next(s.Length)]).ToArray());
        return result;
    }
}
