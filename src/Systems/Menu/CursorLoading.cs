using AlizeeEngine;

class CursorLoadingSystem: ClodoBehaviour {

    private LoadScene newScene;
    private bool reload = false;

    public override void OnUpdate() {

        Entities.ForEach( (DeplacementMenu menu) => {

            if (menu.Clicked) {
                
                Entities.ForEach( (LoadScene scene) => {
                    if (scene.Id == menu.Position) {
                        newScene = scene;
                        reload = true;
                    }
                });

            }

        });

        if (reload) {
            LoadNewScene();
            reload = true;
        }

    }

    private void LoadNewScene() {

        Entities.ForEach( ent => {
            if (!(ent.Contains<Window>() || ent.Contains<Input>() || ent.Contains<Selector>() || ent.Contains<Score>()))
                World.DropEnt(ent);
        });

        World.ClearSystems();

        Loader.loadScene(World, newScene.Scene);
    }

}