using AlizeeEngine;

namespace Chieng {
    class Program {
        static void Main() {
            /* Creation du jeu */
            World world = new World();

            /* Ajout de la fenetre */
            Window win = new Window((uint) (256*3), (uint) (224*3), 60);
            win.MoveView(0, 0);
            win.LinkToWorld(world);

            new EntityBuilder(world)
                .CreateEntity()
                .With(win)
                .Build();

            /* Ajout du Clavier */
            new EntityBuilder(world)
                .CreateEntity()
                .With(new Input())
                .Build();

            /* Chargement de la scene */
            Loader.loadScene(world, "menu");

            /* Ajout du score */
            new EntityBuilder(world)
                .CreateEntity()
                .With(new Score { Points = 0 })
                .Build();

            new EntityBuilder(world)
                .CreateEntity()
                .With(new Position { X = 96, Y = 0 })
                .With(new Selector { Selection = Selection.TirSimple, Bouclier = false })
                .Build();

            /* Lancement du jeu */
            world.Run();
        }
    }
}