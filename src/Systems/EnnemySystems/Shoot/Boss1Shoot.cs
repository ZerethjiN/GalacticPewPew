using AlizeeEngine;

class Boss1ShootSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {
    
        /* Tir du boss */
        Entities.ForEach( (Boss1Coeur boss, Position pos) => {
            if (pos.X < 256) {
                if (!boss.IsOpen) {
                    boss.ShootTimer += Time.deltaTime;

                    if (boss.ShootTimer > boss.ShootCooldown) {
                        AddMissile(pos);
                        boss.ShootTimer = 0;
                    }
                }

                else {
                    boss.RapidShootTimer += Time.deltaTime;

                    if (boss.RapidShootTimer > 0.5) {
                        AddRapidMissile(pos);
                        boss.RapidShootTimer = 0;
                    }
                }
            }
        });

        /* Explosion du drone */
        Entities.ForEach( (Boss1Mine mine, Position pos, Texture tex, Collider col) => {
            if (pos.X < 256 && mine.Active) {
                mine.ExplosionTimer += Time.deltaTime;

                if (mine.ExplosionTimer > mine.ExplosionCooldown) {
                    tex.X = 192;
                    col.X = 0;
                    col.Y = 0;
                    col.Width = 48;
                    col.Height = 48;
                    mine.ExplosionTimer = 0;
                }

                else if (tex.X == 192 && mine.ExplosionTimer > 0.25) {
                    col.X = 16;
                    col.Y = 16;
                    col.Width = 16;
                    col.Height = 16;
                    tex.X = 96;
                }
            }
        });

    }

    private void AddMissile(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt);
        World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 300, MaxTime = (float) 0.5, CurrentTime = 0, FromBoss1 = true }, newEnt);
        World.AddCmp<Position>(new Position { X = pos.X - 220, Y = pos.Y + 16 }, newEnt);
        World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 192, Height = 16, IsColliderOn = true }, newEnt);
        World.AddCmp<Texture>(new Texture("Missile", 0, 16, 192, 16), newEnt);
        World.AddCmp<Vector2>(new Vector2 { X = 0, Y = 0 }, newEnt);
    }

    private void AddRapidMissile(Position pos) {
        for (int i = 0; i < 6; i++) {
            newEnt = new Entity();
            World.AddEnt(newEnt);
            World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 200, MaxTime = (float) 1, CurrentTime = 0 }, newEnt);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
            
            if (i >= 3)
                World.AddCmp<Position>(new Position { X = pos.X - 32, Y = pos.Y - 48 }, newEnt);
            else
                World.AddCmp<Position>(new Position { X = pos.X - 32, Y = pos.Y + 48 }, newEnt);

            if (i % 3 == 0) {
                World.AddCmp<Vector2>(new Vector2 { X = -1, Y = -1 }, newEnt);
                World.AddCmp<Texture>(new Texture("Missile", 48, 0, 16, 16), newEnt);
            } else if (i % 3 == 1) {
                World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 0 }, newEnt);
                World.AddCmp<Texture>(new Texture("Missile", 16, 0, 16, 16), newEnt);
            } else if (i % 3 == 2) {
                World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 1 }, newEnt);
                World.AddCmp<Texture>(new Texture("Missile", 32, 0, 16, 16), newEnt);
            }
        }
    }

}