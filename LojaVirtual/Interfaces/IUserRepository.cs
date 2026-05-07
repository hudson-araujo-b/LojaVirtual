using LojaVirtual.Models;

namespace LojaVirtual.Interfaces
{
    public interface IUserRepository
    {
        LoginViewModel? Validar(string Email, string Senha);
    }
}
