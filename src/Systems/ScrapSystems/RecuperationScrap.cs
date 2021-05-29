using AlizeeEngine;

class RecuperationScrapSystem: ClodoBehaviour {

    public override void OnCreate() {
        Query
            .AddQuery().Filter<Scrap>().With<Position, Collider>()
            .AddQuery().Filter<Player>().With<Collider, Position, ScrapScoring>();
    }

    public override void OnUpdate() {
        
        Entities.Filter<Scrap>().ForEach( (Entity ent, Position posScrap, Collider colScrap) => {
            
            Query[1].ForEach( (ScrapScoring scrapScore, Position posply, Collider colPly) => {
                performCollision(colScrap, posScrap, colPly, posply, scrapScore, ent);
            });

        });

    }

    private void performCollision(Collider col1, Position pos1, Collider col2, Position pos2, ScrapScoring scoring, Entity ent) {
        if (!Utils.Intersect(pos1, col1, pos2, col2))
            return;

        scoring.Scraps++;

        Entity entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Texture>(new Texture("Scrap", x: 16, width: 32, height: 32), entity);
        World.AddCmp<Position>(new Position { X = pos1.X - 16, Y = pos1.Y - 16 }, entity);
        World.AddCmp<Particule>(new Particule { MaxTime = (float) 0.2, MidTime = (float) 0.1, CurrentTime = 0, newTexturePosition = 48 }, entity);
        World.AddCmp<Light>(new Light {
                Color = new SFML.Graphics.Glsl.Vec3(0, 0.5f, 1f),
                Radius = 32,
                MaxRadius = 48,
                MinRadius = 32,
                Speed = 5,
                Increase = true
        }, entity);

        World.DropEnt(ent);
    }

}