namespace AlizeeEngine {
    public class Text {
        public SFML.Graphics.Text Txt { get; set; }

        public Text(Font font, string text) {
            Txt = new SFML.Graphics.Text(text, font.Fnt);
        }
    }
}