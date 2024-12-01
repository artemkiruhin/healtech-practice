using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Front.Services.Jwt
{
    public interface IJwtTokenService
    {
        void SaveToken(string token);
        string ReadToken();
        void DeleteToken();
    }
}
