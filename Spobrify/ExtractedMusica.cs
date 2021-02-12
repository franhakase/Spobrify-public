namespace Spobrify
{
   public class ExtractedMusica
    {
        public string Nome { get; set; }
        public string URL { get; set; }
        public string Thumb { get; set; }
        public ExtractedMusica(string Nome, string URL, string Thumb)
        {
            this.Nome = Nome;
            this.URL = URL;
            this.Thumb = Thumb;
        }
    }

}
