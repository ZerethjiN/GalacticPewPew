using AlizeeEngine;

class Window {
    public Affichage affichage;

    public Window(uint width = 1024, uint height = 896, uint framerate = 60) {
        affichage = new Affichage();
        affichage.Taillefenetre(width, height);
        affichage.SetFramerateLimit(framerate);
    }

    public void LinkToWorld(World world) {
        affichage.WindowLinkWorld(world);
    }

    public void MoveView(float x, float y) {
        affichage.MoveView(x, y);
    }

    public void Close() {
        affichage.Close();
    }

    public void Clear() {
        affichage.Clear();
    }

    public void Display() {
        affichage.Display();
    }
}