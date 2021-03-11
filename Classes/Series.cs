using System;

namespace AppSimples
{
    public class Series : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Series( int id, Genre genre, string title, string description, int year)
        {
            this.ID = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = Year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string returnString = "";
            returnString += "Gênero: " + this.Genre + Environment.NewLine;
            returnString += "Título: " + this.Title + Environment.NewLine;
            returnString += "Descrição: " + this.Description + Environment.NewLine;
            returnString += "Ano de Início: " + this.Year + Environment.NewLine;
            return returnString;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnID()
        {
            return this.ID;
        }

        public void Erase()
        {
            this.Deleted = true;
        }
    }
}