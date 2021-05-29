using AlizeeEngine;

class BackgroundParallaxe: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (Background back, Texture tex, Position pos) => {
            if (pos.X < -(tex.Width + 48))
                pos.X = 256;

            pos.X -= back.Speed * Time.deltaTime;
        });

        Entities.ForEach( (Border bor, Position pos) => {
            pos.X -= bor.Speed * Time.deltaTime;
        });

        Entities.Filter<TileMap, TileMapInfiniteParallex>().ForEach( (Position pos) => {
            pos.X -= (float) (25f * Time.deltaTime);

            if (pos.X < -16)
                pos.X = 0;
        });

    }

}