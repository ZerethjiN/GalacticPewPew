using AlizeeEngine;

class Texture {
    public Sprite Sprite;
    public int X;
    public int Y;
    public int Width;
    public int Height;

    public Texture(string texFile, int x = 0, int y = 0, int width = 16, int height = 16) {
        Sprite = AssetManager.GetAssetSprite("res/textures/" + texFile + ".png");
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }
}

class Normal {
    public Sprite Sprite;
    public int X;
    public int Y;
    public int Width;
    public int Height;
}