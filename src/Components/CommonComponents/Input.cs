using AlizeeEngine;

class Input {
    public Clavier clavier = new Clavier();

    public bool IsKeyPressed(Clavier.Touche touche) {
        return clavier.IsKeyPressed(touche);
    }
}