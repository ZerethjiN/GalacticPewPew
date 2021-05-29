using System.Collections.Generic;

namespace AlizeeEngine {
    public static class AssetManager {

        private static Dictionary<string, Sprite> assetsSprite;
        private static Dictionary<string, Font> assetsFont;

        static AssetManager() {
            assetsSprite = new Dictionary<string, Sprite>();
            assetsFont = new Dictionary<string, Font>();
        }

        public static Sprite GetAssetSprite(string texture) {
            if (!assetsSprite.ContainsKey(texture)) {
                Sprite sprt = new Sprite();
                sprt.SetTexture(new Texture(texture));
                assetsSprite.Add(texture, sprt);
            }
            return assetsSprite[texture];
        }

        public static Font GetAssetFont(string font) {
            if (!assetsFont.ContainsKey(font)) {
                assetsFont.Add(font, new Font(font));
            }
            return assetsFont[font];
        }

    }
}