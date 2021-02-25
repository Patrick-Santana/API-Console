using System.Collections.Generic;
namespace StarSeries.Interfaces
{
    public interface IRepository <T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);

        void Exclui(int id);

        void Editar(int id, T entidade);

        int ProxId();

    }
}