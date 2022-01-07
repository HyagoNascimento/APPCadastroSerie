using System;

namespace DIO.Series
{
    public class Serie:EntidadeBase
    {
        //Atributos 
        private Genero Genero {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;} 
        private bool Excluido {get;set;}

        //Métodos (Construtor)

        public Serie(int Id, Genero genero, string titulo, string descricao, int ano){
            this.id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao ;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno +="Gênero: " + this.Genero + Environment.NewLine;
            retorno +="Título: " + this.Titulo + Environment.NewLine;
            retorno +="Descrição: " + this.Descricao + Environment.NewLine;
            retorno +="Ano: " + this.Ano + Environment.NewLine;
            retorno +="Excluida: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }
          public int retornaId()
        {
            return this.id;
        }
         public int retornaExcluido()
        {
            return this.Excluido;
        }
        
        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}