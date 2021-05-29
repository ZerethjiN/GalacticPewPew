using AlizeeEngine;

class TourelleShootSystem: ClodoBehaviour {

    public override void OnUpdate() {

        /* Tir des tourelles */
        Entities.ForEach( (Tourelle Tourelle, Position pos, Texture tex, Animation anim) => {
            if (pos.X > -256 && pos.X < 512) {
                Tourelle.ShootTimer += Time.deltaTime;

                if (Tourelle.ShootTimer > Tourelle.ShootCooldown) {
                    tex.X = 48;
                    anim.Lock = true;

                    AddMissileTourelles(pos);
                    Tourelle.ShootTimer = 0;
                }

                /* Clignotement des tourelles apres tir */
                else if (Tourelle.ShootTimer > 0.25 && tex.X == 48) {
                    tex.X = anim.CurrentFrame * anim.NextFramePosition + anim.NextFramePosition;
                    anim.Lock = false;
                }
            }
        });

    }

    private void AddMissileTourelles(Position pos) {
        for (int i = 0; i < 4; i++) {
            Entity entity = new Entity();
            World.AddEnt(entity);
            World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0 }, entity);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entity);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, entity);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, entity);

            switch(i) {
                case 0:
                    World.AddCmp<Texture>(new Texture("Missile", 32, 0, 16, 16 ), entity);
                    World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 1 }, entity);
                    break;

                case 1:
                    World.AddCmp<Texture>(new Texture("Missile", 48, 0, 16, 16), entity);
                    World.AddCmp<Vector2>(new Vector2 { X = -1, Y = -1 }, entity);
                    break;
                
                case 2:
                    World.AddCmp<Texture>(new Texture("Missile", 48, 0, 16, 16), entity);
                    World.AddCmp<Vector2>(new Vector2 { X = 1, Y = 1 }, entity);
                    break;

                case 3:
                    World.AddCmp<Texture>(new Texture("Missile", 32, 0, 16, 16), entity);
                    World.AddCmp<Vector2>(new Vector2 { X = 1, Y = -1 }, entity);
                    break;
            }
        }
    }

}