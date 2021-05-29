using SFML.Graphics;
using SFML.System;

namespace AlizeeEngine {
    public class TileMap: Transformable, Drawable {
        public VertexArray Vertices = new VertexArray();
        public Texture Tileset;
        public int[] TilesArray;
        public uint TileWidth;

        void Drawable.Draw(RenderTarget target, RenderStates states) {
            states.Transform *= Transform;
            states.Texture = Tileset.Tex;
            target.Draw(Vertices, states);
        }

        public void Load(string tileset, uint tileWidth, uint tileHeight, int[] tiles, int x, int y, uint width, uint height) {
            Tileset = AssetManager.GetAssetSprite(tileset).Texture;
            TilesArray = tiles;
            TileWidth = tileWidth;

            Vertices.PrimitiveType = PrimitiveType.Quads;

            uint nbTile = 0;
            for (uint i = 0; i < width * height; i++)
                nbTile += 4;

            Vertices.Resize(nbTile);

            for (uint i = 0; i < width; i++) {
                for (uint j = 0; j < height; j++) {
                    int tileNumber = tiles[i + j * width];

                    if (tileNumber != 0) {
                        int tu = tileNumber % (int) (Tileset.Size.X / tileWidth);
                        int tv = tileNumber / (int) (Tileset.Size.X / tileWidth);

                        uint index = (i + j * width) * 4;

                        Vertices[index + 0] = new Vertex(new Vector2f(x + (i * tileWidth), y + (j * tileHeight)), new Vector2f(tu * tileWidth, tv * tileHeight));
                        Vertices[index + 1] = new Vertex(new Vector2f(x + ((i + 1) * tileWidth), y + (j * tileHeight)), new Vector2f((tu + 1) * tileWidth, tv * tileHeight));
                        Vertices[index + 2] = new Vertex(new Vector2f(x + ((i + 1) * tileWidth), y + ((j + 1) * tileHeight)), new Vector2f((tu + 1) * tileWidth, (tv + 1) * tileHeight));
                        Vertices[index + 3] = new Vertex(new Vector2f(x + (i * tileWidth), y + ((j + 1) * tileHeight)), new Vector2f(tu * tileWidth, (tv + 1) * tileHeight));
                    }
                }
            }
        }
    }
}