using AlizeeEngine;

class CloseWindowSystem: ClodoBehaviour {

    public override void OnUpdate() {
    
        Entities.ForEach( (Input input) => {
            if (input.IsKeyPressed(Clavier.Touche.Escape)) {

                Entities.ForEach( (Window win) => {
                    win.Close();
                });

                World.CloseProgram();
            }
        });

    }

}