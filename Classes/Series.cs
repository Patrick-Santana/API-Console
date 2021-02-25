using System;
namespace StarSeries
{
    public class Series:EntidadeBase
    {
        private string Titulo {get; set;}

        private Genero Genero { get; set;}

        private int Ano {get; set;}

        private string Sinopse {get; set;}

        private bool Excluido{get; set;}

        public Series(int id, string  titulo, Genero genero, string sinopse, int ano)
        {
            this.Id = id;
            this.Sinopse = sinopse;
            this.Ano = ano;
            this.Titulo = titulo;
            this.Genero = genero;
            this.Excluido = false;
        }

        public override string ToString()
        {

            string retorno = " ";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Sinopse + Environment.NewLine;
            retorno += "Ano de Inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}