namespace AlizeeEngine {
    public class Font {

        public SFML.Graphics.Font Fnt { get; set; }

        public Font(string font) {
            this.Fnt = new SFML.Graphics.Font(font);
        }

    }
}