namespace PetStore.Importer
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {
        private static Random random = new Random();

        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        public static int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return random.Next(min, max + 1);
        }

        public static string GetRandomString(int minLength = 0, int maxLenght = int.MaxValue / 2)
        {
            var length = random.Next(minLength, maxLenght);

            var result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(Alphabet[random.Next(0, Alphabet.Length)]);
            }

            return result.ToString();
        }

        public static DateTime GetRandomDateTime(DateTime? before = null, DateTime? after = null)
        {
            var minDate = after ?? new DateTime(2010, 1, 1, 0, 0, 0);
            var maxDate = before ?? DateTime.Now.AddDays(-60);

            var second = GetRandomNumber(minDate.Second, maxDate.Second);
            var minute = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var hour = GetRandomNumber(minDate.Hour, maxDate.Hour);
            var day = GetRandomNumber(minDate.Day, maxDate.Day);
            var month = GetRandomNumber(minDate.Month, maxDate.Month);
            var year = GetRandomNumber(minDate.Year, maxDate.Year);

            // TODO: bug fix;
            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hour, minute, second);
        }
    }
}
