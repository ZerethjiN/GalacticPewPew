using AlizeeEngine;

class SpawnerActionSystem: ClodoBehaviour {

    private Entity newEnt;

    public override void OnUpdate() {
        
        /* Spawn des ennemies */
        Entities.ForEach( (Spawner spawner, Position pos, Texture tex) => {
            if (pos.X > 0 && pos.X < 256) {
                spawner.SpawnTimer += Time.deltaTime;

                if (spawner.SpawnTimer > spawner.SpawnCoolDown) {
                    tex.X += 64;

                    AddMissileSpawner(pos);
                    spawner.SpawnTimer = 0;
                }

                else if (spawner.SpawnTimer > 0.5 && tex.X >= 64) {
                    tex.X -= 64;
                }
            }
        });

    }

    private void AddMissileSpawner(Position pos) {
        newEnt = new Entity();
        World.AddEnt(newEnt)
            .AddCmp<Ennemy>(new Ennemy { Speed = 100, Points = 50, HP = 1 }, newEnt)
            .AddCmp<Kamikaze>(new Kamikaze(), newEnt)
            .AddCmp<Position>(new Position { X = pos.X + 8, Y = pos.Y + 8}, newEnt)
            .AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt)
            .AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1f, 0.5f, 0.0f), MinRadius = 16, MaxRadius = 32, Speed = 5 }, newEnt)
            .AddCmp<Texture>(new Texture("Fonceur", 0, 0, 16, 16), newEnt)
            .AddCmp<Animation>(new Animation { NbFrame = 1, NextFramePosition = 16, TimeByFrame = 0.25f, Type = AnimationType.Oscillaire, IsRight = true }, newEnt);
    }

}