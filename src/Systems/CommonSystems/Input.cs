using AlizeeEngine;
using SFML.Window;

class InputSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Window win) => {
            win.affichage.DispatchEvents();
            if (win.affichage.HasFocus()) {

                Entities.ForEach( (Input input) => {
                    PlayerInput(input);
                    SelectorInput(input);

                    Joystick.Update();
                    if (Joystick.IsConnected(0)) {
                        PlayerInputJoystick(input);
                        SelectorinputJoystick(input);
                    }
                });

            }
        });

    }

    private void PlayerInput(Input input) {
        Entities.ForEach( (Player player, Vector2 velocity) => {
            velocity.X = 0;
            velocity.Y = 0;
            player.Shoot = false;

            if (input.IsKeyPressed(Clavier.Touche.Z))
                velocity.Y = -1;
            if (input.IsKeyPressed(Clavier.Touche.S))
                velocity.Y = 1;
            if (input.IsKeyPressed(Clavier.Touche.Q))
                velocity.X = -1;
            if (input.IsKeyPressed(Clavier.Touche.D))
                velocity.X = 1;

            if (input.IsKeyPressed(Clavier.Touche.Enter))
                player.Shoot = true;
        });
    }

    private void SelectorInput(Input input) {
        Entities.ForEach( (Selector sel) => {
            sel.Selection = Selection.TirSimple;

            if (input.IsKeyPressed(Clavier.Touche.Num2))
                sel.Selection = Selection.TirMultiple;

            else if (input.IsKeyPressed(Clavier.Touche.Num3))
                sel.Selection = Selection.Acceleration;

            else if (input.IsKeyPressed(Clavier.Touche.Num4))
                sel.Selection = Selection.Bouclier;
            
            else if (input.IsKeyPressed(Clavier.Touche.Num5))
                sel.Selection = Selection.Drone;
        });
    }

    private void PlayerInputJoystick(Input input) {
        Entities.ForEach( (Player player, Vector2 velocity) => {
            velocity.X = 0;
            velocity.Y = 0;

            if (Joystick.GetAxisPosition(0, Joystick.Axis.PovX) > 25)
                velocity.X = 1;
            if (Joystick.GetAxisPosition(0, Joystick.Axis.PovX) < -25)
                velocity.X = -1;
            if (Joystick.GetAxisPosition(0, Joystick.Axis.PovY) < -25)
                velocity.Y = 1;
            if (Joystick.GetAxisPosition(0, Joystick.Axis.PovY) > 25)
                velocity.Y = -1;

            if (!player.Shoot)
                player.Shoot = Joystick.IsButtonPressed(0, 4);
            
            if (!player.Shoot)
                player.Shoot = Joystick.IsButtonPressed(0, 5);
        });
    }

    private void SelectorinputJoystick(Input input) {
        Entities.ForEach( (Selector sel) => {
            if (Joystick.IsButtonPressed(0, 2))
                sel.Selection = Selection.TirMultiple;
            
            else if (Joystick.IsButtonPressed(0, 1))
                sel.Selection = Selection.Acceleration;
            
            else if (Joystick.IsButtonPressed(0, 0))
                sel.Selection = Selection.Bouclier;

            else if (Joystick.IsButtonPressed(0, 3))
                sel.Selection = Selection.Drone;
        });
    }

}