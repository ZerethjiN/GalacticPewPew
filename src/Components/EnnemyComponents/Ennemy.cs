class Ennemy {
    public int Speed;
    public int Points;
    public int HP;
}

class Fonceur {}

class FonceurOndulent {}

class Kamikaze {}

class Shooteur {
    public float ShootCooldown;
    public float ShootTimer;
}

class ShooteurOndulent {
    public float ShootCooldown;
    public float ShootTimer;
}

class Tourelle {
    public float ShootCooldown;
    public float ShootTimer;
    public int StaticX;
    public bool IsTop;
}

class Tour {
    public float ShootCooldown;
    public float ShootTimer;
    public bool FromTop;
}

class Moon {
    public float ShootCooldown;
    public float ShootTimer;
    public int StaticX;
    public bool isUp;
}

class Meteore {
    public bool FromTop;
}

class Furtif {
    public float ShootCooldown;
    public float ShootTimer;
    public int StaticX;
    public bool isUp;
    public bool Disparition;
}

class Mine {
    public float Radius;
    public int StaticX;
}

class Spawner {
    public float SpawnCoolDown;
    public float SpawnTimer;
}

class Sniper {
    public float ShootCooldown;
    public float ShootTimer;
}

class Observateur {
    public int StaticX;
    public float ShootCooldown;
    public float ShootTimer;
}

class MurDeGlace {}

class Boss1 {
    public int StaticX;
    public bool isUp;
    public int minY;
    public int maxY;
    public bool IsOpen;
}

class Boss1Mine {
    public int minX;
    public int maxX;
    public int minY;
    public int maxY;

    public float ExplosionCooldown;
    public float ExplosionTimer;

    public bool Active;

    public float OpeningCooldown;
    public float ClosingCoolDown;
    public float OpeningTimer;
    public bool IsOpen;
}

class Boss1Top {
    public float OpeningCooldown;
    public float ClosingCoolDown;
    public float OpeningTimer;
    public bool IsOpen;
}

class Boss1Bottom {
    public float OpeningCooldown;
    public float ClosingCoolDown;
    public float OpeningTimer;
    public bool IsOpen;
}

class Boss1Coeur {
    public float OpeningCooldown;
    public float ClosingCoolDown;
    public float OpeningTimer;
    public bool IsOpen;

    public float ShootCooldown;
    public float ShootTimer;

    public float RapidShootTimer;

    public bool IsToucher;
    public float ToucherTimer = 0f;
    public float ToucherCooldown = 0.1f;
}