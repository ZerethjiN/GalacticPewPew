class Missile {
    public int Speed;
    public float MaxTime;
    public float CurrentTime;
}

class MissilePlayer: Missile {}

class MissileEnnemy: Missile {
    public bool FromMoon;
    public bool FromBoss1;
}