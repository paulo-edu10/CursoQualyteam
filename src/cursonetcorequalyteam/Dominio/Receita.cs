using System;

namespace cursonetcorequalyteam.Dominio
{
    public class Receita
    {
        const int LimiteDeCaractereDoTitulo = 10;
        public Receita(){}
        public Receita(string titulo, string descricao, string ingredientes, string preparacao, string urlDaImagem)
        {
            if(!CaracteresDoTituloEhValido(titulo))
                throw new Exception("Erro");


            Titulo = titulo;
            Descricao = descricao;
            Ingredientes = ingredientes;
            Preparacao = preparacao;
            UrlDaImagem = urlDaImagem;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string  Ingredientes { get; set; }
        public string Preparacao { get; set; }
        public string  UrlDaImagem { get; set; }

        public bool CaracteresDoTituloEhValido(string titulo)
        {
            return titulo.Length > 0 && titulo.Length <= LimiteDeCaractereDoTitulo;
        }

        public void Update(string titulo, string descricao)
        {
            if(!CaracteresDoTituloEhValido(titulo))
                throw new Exception("Erro");

            Titulo = titulo;
            Descricao = descricao;
        }
    }
}