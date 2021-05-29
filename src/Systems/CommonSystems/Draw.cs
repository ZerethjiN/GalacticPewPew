using AlizeeEngine;
using SFML.Graphics;
using SFML.Graphics.Glsl;

class DrawSystem: ClodoBehaviour {

    private Shader shader = new Shader("res/shaders/PointLight.vert", null, "res/shaders/NormalLightning.frag");
    private Shader shaderHUD = new Shader("res/shaders/PointLight.vert", null, "res/shaders/TextureSimple.frag");
    private SFML.Graphics.Texture normal = new SFML.Graphics.Texture("res/textures/Normal.png");

    private float[] lightRadius;
    private Vec3[] lightColor;
    private Vec3[] lightPos;
    private int i;

    public override void OnUpdate() {

        /* Lumiere dynamique */
        lightRadius = new float[Entities.TotalOf<Light>()];
        lightColor = new Vec3[Entities.TotalOf<Light>()];
        lightPos = new Vec3[Entities.TotalOf<Light>()];
        i = 0;
        Entities.Without<NoShader>().ForEach( (Light lgt, Position pos, Texture tex) => {
            if (pos.X <= 256 + tex.Width) {
                lightRadius[i] = lgt.Radius;
                lightColor[i] = lgt.Color;
                lightPos[i] = new Vec3(pos.X + tex.Width / 2, pos.Y + tex.Height / 2, 1);
                i++;
            }
        });
        shader.SetUniform("nbLight", i);
        shader.SetUniformArray("lightRadius", lightRadius);
        shader.SetUniformArray("lightColor", lightColor);
        shader.SetUniformArray("lightPos", lightPos);

        /* Lumiere d'ambiance */
        Entities.ForEach( (Ambient amb) => {
            shader.SetUniform("ambient", new Vec3(amb.R, amb.G, amb.B));
        });

        Entities.ForEach( (Window win) => {

            win.Clear();

            /* background */
            Entities.Without<Border, Decor>().ForEach( (TileMap tileMap, Position pos) => {
                shader.SetUniform("texture", tileMap.Tiles.Tileset.Tex);
                shader.SetUniform("normalTexture", normal);

                tileMap.Tiles.Position = new SFML.System.Vector2f(pos.X, pos.Y);

                win.affichage.window.Draw(tileMap.Tiles, new RenderStates(shader));
            });

            /* foreground in game */
            Entities.ForEach( (Position pos, Texture tex) => {
                if (256 >= pos.X && 0 <= pos.X + tex.Width) {
                    tex.Sprite.SetPosition((int) pos.X, (int) pos.Y, tex.Width, tex.Height);
                    tex.Sprite.SetTextureRect(tex.X, tex.Y, tex.Width, tex.Height);

                    shader.SetUniform("texture", tex.Sprite.Texture.Tex);
                    shader.SetUniform("normalTexture", normal);

                    win.affichage.window.Draw(tex.Sprite.Sprt, new RenderStates(shader));
                }
            });

            /* Bordure de map */
            Entities.Filter<Border>().ForEach( (TileMap tileMap, Position pos) => {
                shader.SetUniform("texture", tileMap.Tiles.Tileset.Tex);
                shader.SetUniform("normalTexture", normal);

                tileMap.Tiles.Position = new SFML.System.Vector2f(pos.X, pos.Y);

                win.affichage.window.Draw(tileMap.Tiles, new RenderStates(shader));
            });

            Entities.Filter<Decor>().ForEach( (TileMap tileMap, Position pos) => {
                shader.SetUniform("texture", tileMap.Tiles.Tileset.Tex);
                shader.SetUniform("normalTexture", normal);

                tileMap.Tiles.Position = new SFML.System.Vector2f(pos.X, pos.Y);

                win.affichage.window.Draw(tileMap.Tiles, new RenderStates(shader));
            });

            /* Elements HUD */
            Entities.Filter<NoShader>().ForEach( (Position pos, Texture tex) => {
                if (win.affichage.Width >= pos.X && -16 <= pos.X) {
                    tex.Sprite.SetPosition((int) pos.X, (int) pos.Y, tex.Width, tex.Height);
                    tex.Sprite.SetTextureRect(tex.X, tex.Y, tex.Width, tex.Height);

                    shader.SetUniform("texture", tex.Sprite.Texture.Tex);

                    win.affichage.window.Draw(tex.Sprite.Sprt, new RenderStates(shaderHUD));
                }
            });

            Entities.ForEach( (Text text, Position pos) => {
                text.text.Txt.Position = new SFML.System.Vector2f(pos.X, pos.Y);
                win.affichage.Draw(text.text);
            });

            Entities.ForEach( (Position pos, ScrapScoring score) => {
                AlizeeEngine.Text text = new AlizeeEngine.Text(AssetManager.GetAssetFont("res/fonts/Zeldo.ttf"), " " + score.Scraps.ToString());
                text.Txt.CharacterSize = 12;
                text.Txt.Position = new SFML.System.Vector2f(0, 208);
                win.affichage.Draw(text);
            });

            win.Display();

        });
    
    }

}