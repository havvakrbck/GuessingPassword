using System;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int correctCode = random.Next(100, 1000); 

        int attempts = 0;

        while (attempts < 10) 
        {
            Console.WriteLine("Lütfen 3 basamaklı bir tahmin girin: ");
            string input = Console.ReadLine();

            if (input.Length != 3 || !int.TryParse(input, out int guess))
            {
                Console.WriteLine("Geçersiz giriş. 3 basamaklı bir sayı girin.");
                continue;
            }

            int[] guessArray = { guess / 100, (guess / 10) % 10, guess % 10 };
            int[] clues = CheckGuess(correctCode, guessArray);

            Console.WriteLine("İpucu: [Doğru numara, Doğru konum, Yanlış konum] => [" + clues[0] + ", " + clues[1] + ", " + clues[2] + "]");

            attempts++;

            if (clues[1] == 3) 
            {
                Console.WriteLine("Tebrikler! Şifreyi buldunuz.");
                break; 
            }
        }

        if (attempts >= 10)
        {
            Console.WriteLine("Üzgünüm, 10 deneme hakkınız bitti. Şifreyi bulamadınız. Doğru şifre: " + correctCode);
        }
    }

    static int[] CheckGuess(int correctCode, int[] guess)
    {
        int[] clues = { 0, 0, 0 };

        for (int i = 0; i < 3; i++)
        {
            int digit = (correctCode / (int)Math.Pow(10, 2 - i)) % 10;
            if (guess[i] == digit)
            {
                clues[1]++;
            }
            else if (correctCode.ToString().Contains(guess[i].ToString()))
            {
                clues[0]++;
            }
            else
            {
                clues[2]++;
            }
        }

        return clues;
    }
}
