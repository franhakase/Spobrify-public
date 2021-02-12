namespace Spobrify
{
    public class Musica
    {
        public string Nome { get; set; }
        public string ID { get; set; }
        public string Thumb { get; set; }

        public Musica(string Nome, string ID, string Thumb = "")
        {
            this.Nome = Nome;
            this.ID = ID.Split('&')[0].Replace("/watch?v=", "");
            this.Thumb = Thumb;
        }
    }
}
