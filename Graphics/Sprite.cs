using SFML.Graphics;
using SFML.System;

namespace AlizeeEngine {
    public class Sprite {

        public SFML.Graphics.Sprite Sprt { get; set; }
        public Texture Texture;

        public Sprite() {
            this.Sprt = new SFML.Graphics.Sprite();
        }

        public void SetPosition(int x, int y, int width, int height) {
            Sprt.Position = new Vector2f(x + width / 2, y + height / 2);
            Sprt.Origin = new Vector2f(width / 2, height / 2);
        }

        public void SetTextureRect(int x, int y, int width, int height) {
            Sprt.TextureRect = new IntRect(x, y, width, height);
        }

        public void SetRotation(float rotation) {
            Sprt.Rotation = rotation;
        }

        public void SetTexture(Texture texture) {
            Sprt.Texture = texture.Tex;
            Texture = texture;
        }

    }
}