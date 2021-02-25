using System;
using System.Collections.Generic;
using StarSeries.Interfaces;

namespace StarSeries
{
    public class SeriesRepositorio : IRepository<Series>
    {
        private List<Series> listaSerie = new List<Series>();
        public void Editar(int id , Series entidade)
        {
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            listaSerie.Add(entidade);
        }

        public void Atualiza(int id, Series objeto)
		{
			listaSerie[id] = objeto;
        }

        public List<Series> Lista()
        {
            return listaSerie;
        }

        public int ProxId()
        {
            return listaSerie.Count;
        }

        public Series RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}