using System;

namespace CadastroSeries
{
    public class Serie : EntidadeBase
    {
        // Atributos da classe
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private string Plataforma { get; set; }
        private int Temporadas { get; set; }
        private bool Excluido { get; set; }


        // Construtor
        public Serie(int id, Genero genero, string titulo, string descricao, int ano, string plataforma, int temporadas)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Plataforma = plataforma;
            this.Temporadas = temporadas;
            this.Excluido = false;
        }

        // Métodos

        public override string ToString()
        {
            string retorno ="";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "Plataforma: " + this.Plataforma + Environment.NewLine;
            retorno += "Temporadas: " + this.Temporadas + Environment.NewLine;
            retorno += "Excluído: "  + this.Excluido;
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