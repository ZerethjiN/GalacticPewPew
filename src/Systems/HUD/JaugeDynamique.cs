using AlizeeEngine;

class jaugeDynamiqueSystem: ClodoBehaviour {

    public bool jaugeAuBout;
    private bool addJaugeTirMultiple;
    private bool addJaugeAcceleration;
    public Entity jaugeEnt;

    public override void OnUpdate() {

        Entities.ForEach( (Selector sel) => {
            if (sel.TirMultiple && Entities.TotalOf<Jauge>() == 0)
                addJaugeTirMultiple = true;

            if (sel.Acceleration && Entities.TotalOf<Jauge>() == 0)
                addJaugeAcceleration = true;
        });

        Entities.ForEach( (Entity ent, Jauge jauge, Texture tex) => {
            jauge.Timer += Time.deltaTime;

            if (jauge.Barre)
                tex.Width = 96 - (int) (jauge.Timer * 96 / jauge.Cooldown);

            if (jauge.Timer > jauge.Cooldown) {
                jaugeAuBout = true;
                jaugeEnt = ent;
            }
        });

        if (addJaugeTirMultiple) {
            AddJaugeTirMultiple();
            addJaugeTirMultiple = false;
        }
        
        if (addJaugeAcceleration) {
            AddAcceleration();
            addJaugeAcceleration = false;
        }

        if (jaugeAuBout) {
            World.DropEnt(jaugeEnt);
            Entities.ForEach( (Selector sel) => {
                sel.TirMultiple = false;
                sel.Acceleration = false;
            });
            jaugeAuBout = false;
        }
    }

    private void AddJaugeTirMultiple() {
        Entity entity;

        /* Barre interne */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = true, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 64, y: 48, width: 96), entity);
        World.AddCmp<Position>(new Position { X = 96, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);

        /* Barre contour */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = false, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 64, y: 32, width: 96), entity);
        World.AddCmp<Position>(new Position { X = 96, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);

        /* Sticker */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = false, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 16), entity);
        World.AddCmp<Position>(new Position { X = 64, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);
    }

    private void AddAcceleration() {
        Entity entity;

        /* Barre interne */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = true, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 64, y: 48, width: 96), entity);
        World.AddCmp<Position>(new Position { X = 96, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);

        /* Barre contour */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = false, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 64, y: 32, width: 96), entity);
        World.AddCmp<Position>(new Position { X = 96, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);

        /* Sticker */
        entity = new Entity();
        World.AddEnt(entity);
        World.AddCmp<Jauge>(new Jauge { Barre = false, Cooldown = 10, Timer = 0 }, entity);
        World.AddCmp<Texture>(new Texture("HUD", x: 32), entity);
        World.AddCmp<Position>(new Position { X = 64, Y = 0 }, entity);
        World.AddCmp<NoShader>(new NoShader(), entity);
    }

}