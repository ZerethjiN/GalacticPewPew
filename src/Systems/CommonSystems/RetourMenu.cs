using AlizeeEngine;

class RetourMenuSystem: ClodoBehaviour {

    private bool reload;

    public override void OnUpdate() {

        Entities.ForEach( (Input input) => {
            if (input.IsKeyPressed(Clavier.Touche.Escape))
                ThrowWorldEntities();
        });

        if (reload) {
            Loader.loadScene(World, "menu");
            reload = false;
        }

    }

    private void ThrowWorldEntities() {
        Entities.ForEach( ent => {
            if (!(ent.Contains<Window>() || ent.Contains<Input>() || ent.Contains<Selector>() || ent.Contains<Score>()))
                World.DropEnt(ent);
        });

        World.ClearSystems();

        reload = true;
    }

}