using System.Linq;

namespace KH4
{
    /// <summary>
    /// Класс для проверки надежности паролей (создан в процессе TDD)
    /// </summary>
    public class PasswordValidator
    {
        /// <summary>
        /// Проверяет, является ли пароль надежным
        /// Требования:
        /// 1. Длина не менее 8 символов
        /// 2. Содержит хотя бы одну цифру
        /// 3. Содержит хотя бы одну букву
        /// </summary>
        /// <param name="password">Проверяемый пароль</param>
        /// <returns>True - если пароль надежный, False - если нет</returns>
        public bool IsPasswordStrong(string password)
        {
            // Проверка на null или пустую строку
            if (string.IsNullOrEmpty(password))
                return false;

            // Проверка минимальной длины
            bool hasMinLength = password.Length >= 8;

            // Проверка наличия хотя бы одной цифры
            bool hasDigit = password.Any(char.IsDigit);
            bool hasLetter = password.Any(char.IsLetter);

            // Пароль считается надежным, если выполнены все условия
            return hasMinLength && hasDigit && hasLetter;
        }
    }
}
