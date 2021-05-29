using AlizeeEngine;
using System;

class PlayerMovementSystem: ClodoBehaviour {

    private float squareMaBite = (float) (Math.Sqrt(2f) / 2f);

    public override void OnUpdate() {

        Entities.ForEach( (Position pos, Player player, Texture tex, Vector2 vec) => {
            Entities.ForEach( (Selector sel) => {
                if (vec.X != 0 && vec.Y != 0) {
                    if (vec.X > 0)
                        vec.X = squareMaBite;
                    else if (vec.X < 0)
                        vec.X = - squareMaBite;
                    
                    if (vec.Y > 0)
                        vec.Y = squareMaBite;
                    else if (vec.Y < 0)
                        vec.Y = - squareMaBite;
                }

                if (sel.Acceleration) {
                    if ((vec.X < 0 && pos.X > -16) || (vec.X > 0 && pos.X < 212))
                        pos.X += 2 * vec.X * player.Speed * Time.deltaTime;
                    if ((vec.Y < 0 && pos.Y > -16) || (vec.Y > 0 && pos.Y < 180))
                        pos.Y += 2 * vec.Y * player.Speed * Time.deltaTime;
                } else {
                    if ((vec.X < 0 && pos.X > -16) || (vec.X > 0 && pos.X < 212))
                        pos.X += vec.X * player.Speed * Time.deltaTime;
                    if ((vec.Y < 0 && pos.Y > -16) || (vec.Y > 0 && pos.Y < 176))
                        pos.Y += vec.Y * player.Speed * Time.deltaTime;
                }
            });

            if (vec.X > 0) {
                if (vec.Y > 0)
                    tex.Y = 336;
                else if (vec.Y < 0)
                    tex.Y = 288;
                else
                    tex.Y = 48;
            } else if (vec.X < 0) {
                if (vec.Y > 0)
                    tex.Y = 384;
                else if (vec.Y < 0)
                    tex.Y = 432;
                else
                    tex.Y = 96;
            } else if (vec.Y < 0) {
                tex.Y = 192;
            } else if (vec.Y > 0) {
                tex.Y = 144;
            } else {
                tex.Y = 0;
            }
        });

    }

}