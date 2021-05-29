namespace AlizeeEngine {
    public class Texture {
        public SFML.Graphics.Texture Tex { get; set; }

        public Texture(string texture) {
            this.Tex = new SFML.Graphics.Texture(texture);
        }

        public SFML.System.Vector2u Size {
            get => Tex.Size;
        }
    }
}