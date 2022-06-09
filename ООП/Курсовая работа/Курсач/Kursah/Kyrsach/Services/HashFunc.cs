using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Kyrsach
{
    public class HashFunc
    {
        public string GetHash(HashAlgorithm hashAlgorithm, string input)
        {
            // Преобразуйте входную строку в массив байтов и вычислите хэш.
            var data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Создайте новый Stringbuilder для сбора байтов
            // и создайте строку.
            var sBuilder = new StringBuilder();

            // Перебрать каждый байт хешированных данных
            // и отформатируйте каждый как шестнадцатеричную строку.
            for (var i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));

            // Вернуть шестнадцатеричную строку.
            return sBuilder.ToString();
        }

        // Сверить хэш со строкой
        public bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Хэшируйте ввод.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Создайте StringComparer и сравните хэши.
            var comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
    }
}