using AlizeeEngine;

class SniperShootSystem: ClodoBehaviour {

    private Vector2 vector = new Vector2();
    private Entity entMarqueur;
    private Entity newEnt;

    public override void OnUpdate() {

        /* Tir des Furtifs */
        Entities.ForEach( (Entity ent, Sniper sniper, Position pos, Texture tex) => {
            if (pos.X > 0 && pos.X < 512) {
                sniper.ShootTimer +=  Time.deltaTime;

                /* Tir vers le marqueur */
                if (sniper.ShootTimer > sniper.ShootCooldown) {

                    Entities.Filter<Marqueur>().ForEach( (Position posMarqueur) => {
                        vector.X = (float) System.Math.Cos(posMarqueur.X - pos.X);
                        vector.Y = (float) System.Math.Sin(posMarqueur.Y - pos.Y);
                    });
                    
                    tex.X = 0;

                    AddMissile(pos);
                    World.DropEnt(entMarqueur);
                    sniper.ShootTimer = 0;
                }

                else if (sniper.ShootTimer > sniper.ShootCooldown/4 && tex.X == 0) {
                    tex.X = 16;
                }

                /* Placement du marqueur */
                else if (sniper.ShootTimer > sniper.ShootCooldown/2 && tex.X == 16) {

                    Entities.Filter<Player>().ForEach( (Position posPly) => {
                        AddMarqueur(posPly);
                    });
                    
                    tex.X = 32;
                }

                else if (sniper.ShootTimer > sniper.ShootCooldown/4*3 && tex.X == 32) {
                    tex.X = 48;
                }
            }
        });

    }

    private void AddMissile(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt);
        World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = 0.5f, CurrentTime = 0 }, newEnt);
        World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, newEnt);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt);
        World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
        World.AddCmp<Texture>(new Texture("Missile", 16, 0, 16, 16), newEnt);
        World.AddCmp<Vector2>(new Vector2 { X = vector.X, Y = vector.Y }, newEnt);
    }

    private void AddMarqueur(Position pos) {
        entMarqueur = new Entity();
        World.AddEnt(entMarqueur);
        World.AddCmp<Marqueur>(new Marqueur(), entMarqueur);
        World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, entMarqueur);
        World.AddCmp<Texture>(new Texture("Missile", 96, 0, 16, 16), entMarqueur);
    }

}