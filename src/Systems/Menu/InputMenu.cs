using AlizeeEngine;
using SFML.Window;

class InputMenuSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Window win) => {
            win.affichage.DispatchEvents();
            if (win.affichage.HasFocus()) {

                Entities.ForEach( (Input input) => {
                    
                    /* Appuis des touches du menu */
                    Entities.ForEach( (DeplacementMenu cursor) => {
                        cursor.NextTimer += Time.deltaTime;

                        if (cursor.NextTimer > cursor.NextCooldown) {

                            if (input.IsKeyPressed(Clavier.Touche.Z) && cursor.Position > 0)
                                cursor.Position--;
                            else if (input.IsKeyPressed(Clavier.Touche.S) && cursor.Position < cursor.NbElements)
                                cursor.Position++;

                            cursor.Clicked = input.IsKeyPressed(Clavier.Touche.Enter);

                            Joystick.Update();
                            if (Joystick.IsConnected(0)) {
                                if (Joystick.GetAxisPosition(0, Joystick.Axis.PovY) > 25 && cursor.Position > 0) {
                                    cursor.Position--;
                                } else if (Joystick.GetAxisPosition(0, Joystick.Axis.PovY) < -25 && cursor.Position < cursor.NbElements) {
                                    cursor.Position++;
                                }

                                cursor.Clicked = Joystick.IsButtonPressed(0, 1);
                            }

                            cursor.NextTimer = 0;
                        }

                    });

                });

            }
        });

    }

}