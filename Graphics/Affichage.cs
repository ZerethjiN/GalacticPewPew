using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace AlizeeEngine {
    public class Affichage {

        public RenderWindow window;
        public View view;

        public float Width {
            get => view.Size.X;
        }

        public float Height {
            get => view.Size.Y;
        }

        public bool IsOpen {
            get => window.IsOpen;
        }

        // Creer un fenetre avec Taille, Titre et Vue.
        public Affichage() {
            window = new RenderWindow(new VideoMode(256 * 3, 224 * 3), "Titre");
            view = new View(new FloatRect(0, 0, 256, 224));

            #if (VSYNC)
                window.SetVerticalSyncEnabled(true);
            #endif
        }

        public void Taillefenetre(uint width, uint height) {
            window.Size = new Vector2u(width, height);
        }

        public void SetFramerateLimit(uint framerate) {
            window.SetFramerateLimit(framerate);
        }

        // Deplace la vue de la fenetre.
        public void MoveView(float x, float y) {
            view.Reset(new FloatRect(x, y, Width, Height));
            window.SetView(view);
        }

        // Ferme la fenetre.
        public void Close() {
            window.Close();
        }

        // Efface l'affichage de la fenetre.
        public void Clear() {
            window.Clear();
        }

        // Dessine un sprite dans la fenetre.
        public void Draw(Sprite sprite) {
            window.Draw(sprite.Sprt);
        }

        public void Draw(TileMap tileMap) {
            window.Draw(tileMap);
        }

        public void Draw(Text text) {
            window.Draw(text.Txt);
        }

        // Reaffichage de la fenetre.
        public void Display() {
            window.Display();
        }

        // Dispatch les inputs de la fenetre.
        public void DispatchEvents() {
            window.DispatchEvents();
        }

        // Verifie si la fenetre est focus.
        public bool HasFocus() {
            return window.HasFocus();
        }

        public void WindowLinkWorld(World world) {

            window.Closed += ( sender, eventArgs ) => {
                Close();
                world.CloseProgram();
            };

            window.Resized += ( sender, eventArgs ) => {
                if ((224f / eventArgs.Height) < (256f / eventArgs.Width)) {
                    view.Viewport = new FloatRect(0, (0 - 256f) / (eventArgs.Width - 256f), 1, (0 - 256f) / (eventArgs.Width - 256f));
                } else {
                    view.Viewport = new FloatRect((0 - 224f) / (eventArgs.Height - 224f), 0, (0 - 224f) / (eventArgs.Height - 224f), 1);
                }

                window.SetView(view);
            };
        }

    }
}