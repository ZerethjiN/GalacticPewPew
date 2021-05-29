using AlizeeEngine;

class CursorMovementSystem: ClodoBehaviour {

    public override void OnUpdate() {

        Entities.ForEach( (DeplacementMenu cursor, Position posCur) => {
            Entities.Filter<LoadScene>().ForEach( (Position pos, Texture tex) => {
                if (pos.Y == 92 + cursor.Position * 32)
                    tex.Y = 64;
                else
                    tex.Y = 32;
            });
        });

    }

}