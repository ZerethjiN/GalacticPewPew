using AlizeeEngine;

class MineShootSystem: ClodoBehaviour {

    private float valeurX;
    private float valeurY;

    private Entity newEnt;

    public override void OnUpdate() {

        Entities.ForEach( (Entity ent, Mine mine, Position posMine) => {
            if (posMine.X < 256) {
        
                Entities.Filter<Player>().ForEach( (Position posPly) => {
                    valeurX = System.Math.Abs(posMine.X - posPly.X);
                    valeurY = System.Math.Abs(posMine.Y - posPly.Y);

                    if (mine.Radius >= valeurX && mine.Radius >= valeurY) {
                        AddMissiles(posMine);
                        World.DropEnt(ent);
                    }
                });

            }
        });

    }

    private void AddMissiles(Position pos) {
        for (int i = 0; i < 8; i++) {
            newEnt = new Entity();
            World.AddEnt(newEnt);
            World.AddCmp<MissileEnnemy>(new MissileEnnemy { Speed = 200, MaxTime = (float) 1, CurrentTime = 0 }, newEnt);
            World.AddCmp<Position>(new Position { X = pos.X, Y = pos.Y }, newEnt);
            World.AddCmp<Collider>(new Collider { X = 0, Y = 0, Width = 16, Height = 16, IsColliderOn = true }, newEnt);
            World.AddCmp<Light>(new Light { Color = new SFML.Graphics.Glsl.Vec3(1.0f, 0.0f, 0.0f), Radius = 32, Speed = 0 }, newEnt);
            World.AddCmp<Texture>(new Texture("Missile", 80, 0, 16, 16), newEnt);

            switch (i) {
                case 0: World.AddCmp<Vector2>(new Vector2 { X = -1, Y = -1 }, newEnt); break;
                case 1: World.AddCmp<Vector2>(new Vector2 { X = 0, Y = -1 }, newEnt); break;
                case 2: World.AddCmp<Vector2>(new Vector2 { X = 1, Y = -1 }, newEnt); break;
                case 3: World.AddCmp<Vector2>(new Vector2 { X = 1, Y = 0 }, newEnt); break;
                case 4: World.AddCmp<Vector2>(new Vector2 { X = 1, Y = 1 }, newEnt); break;
                case 5: World.AddCmp<Vector2>(new Vector2 { X = 0, Y = 1 }, newEnt); break;
                case 6: World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 1 }, newEnt); break;
                case 7: World.AddCmp<Vector2>(new Vector2 { X = -1, Y = 0 }, newEnt); break;
            }
        }
    }

}