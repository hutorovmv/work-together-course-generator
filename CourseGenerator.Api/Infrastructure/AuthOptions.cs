using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Infrastructure
{
    /// <summary>
    /// Клас, що містить в собі властивості, 
    /// необхідні для генерації токена.
    /// </summary>
    public class AuthOptions
    {
        /// <summary>
        /// Постачальник токена.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Споживач токена.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Ключ для шифрування.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Час, протягом якого дійсний токен.
        /// </summary>
        public int Lifetime { get; set; }

        /// <summary>
        /// Генерує ключ для шифрування та дешифрування токена.
        /// </summary>
        /// <returns>Повертає симетричний ключ шифрування <see cref="SymmetricSecurityKey"/>.</returns>
        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
