using AlizeeEngine;
using System.IO;
using System.Text.Json;

static class Loader {

    public static void loadScene(World world, string filename) {
        FileStream fs = File.OpenRead("res/data/" + filename + ".json");

        using (JsonDocument document = JsonDocument.Parse(fs)) {
            EntityBuilder entityBuilder = new EntityBuilder(world);
            JsonElement root = document.RootElement;

            JsonElement entitiesElement = root.GetProperty("entities");
            foreach (JsonElement entity in entitiesElement.EnumerateArray()) {
                entityBuilder.CreateEntity();

                /* Component: TileMap */
                if (entity.TryGetProperty("tileMap", out JsonElement tilemap)) {
                    string texFile = tilemap.GetProperty("file").GetString();
                    uint width = tilemap.GetProperty("width").GetUInt32();
                    uint height = tilemap.GetProperty("height").GetUInt32();
                    uint tileWidth = tilemap.GetProperty("tileWidth").GetUInt32();
                    uint tileHeight = tilemap.GetProperty("tileHeight").GetUInt32();
                    int[] tiles = new int[width * height];
                    int i = 0;
                    foreach (JsonElement tilesArray in tilemap.GetProperty("tiles").EnumerateArray()) {
                        tiles[i] = tilesArray.GetInt32();
                        i++;
                    }
                    AlizeeEngine.TileMap tileMap = new AlizeeEngine.TileMap();
                    tileMap.Load("res/textures/" + texFile + ".png", tileWidth, tileHeight, tiles, 0, 0, width, height);

                    entityBuilder.With(new TileMap {
                        Tiles = tileMap
                    });
                }

                /* Component: CurrentScene */
                if (entity.TryGetProperty("currentScene", out JsonElement currentScene)) {
                    entityBuilder.With(new CurrentScene {
                        SceneName = currentScene.GetProperty("name").GetString()
                    });
                }

                /* Component: Ambient */
                if (entity.TryGetProperty("ambient", out JsonElement ambient)) {
                    entityBuilder.With(new Ambient {
                        R = (float) ambient.GetProperty("r").GetDouble(),
                        G = (float) ambient.GetProperty("g").GetDouble(),
                        B = (float) ambient.GetProperty("b").GetDouble()
                    });
                }

                /* Component: Texture */
                if (entity.TryGetProperty("texture", out JsonElement texture)) {
                    string texFile = texture.GetProperty("file").GetString();
                    int x = texture.GetProperty("x").GetInt32();
                    int y = texture.GetProperty("y").GetInt32();
                    int width = texture.GetProperty("width").GetInt32();
                    int height = texture.GetProperty("height").GetInt32();

                    entityBuilder.With(new Texture(
                        texFile,
                        x,
                        y,
                        width,
                        height
                    ));
                }

                /* Component: Normal */
                if (entity.TryGetProperty("normal", out JsonElement normal)) {
                    string texFile = normal.GetProperty("file").GetString();

                    entityBuilder.With(new Normal {
                        Sprite = AssetManager.GetAssetSprite("res/textures/" + texFile + ".png"),
                        X = normal.GetProperty("x").GetInt32(),
                        Y = normal.GetProperty("y").GetInt32(),
                        Width = normal.GetProperty("width").GetInt32(),
                        Height = normal.GetProperty("height").GetInt32()
                    });
                }

                /* Component: Background */
                if (entity.TryGetProperty("background", out JsonElement background)) {
                    entityBuilder.With(new Background {
                        Speed = background.GetProperty("speed").GetInt32()
                    });
                }

                /* Component: Position */
                if (entity.TryGetProperty("position", out JsonElement position)) {
                    entityBuilder.With(new Position {
                        X = position.GetProperty("x").GetInt32(),
                        Y = position.GetProperty("y").GetInt32()
                    });
                }

                /* Component: Player */
                if (entity.TryGetProperty("player", out JsonElement player)) {
                    entityBuilder.With(new Player {
                        Speed = player.GetProperty("speed").GetInt32(),
                        Shoot = false,
                        ShootCooldown = (float) player.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0,
                        DestructionTimer = 0,
                        IsDestroy = false
                    });
                }

                /* Component: Vector2 */
                if (entity.TryGetProperty("vector2", out JsonElement vector2)) {
                    entityBuilder.With(new Vector2 {
                        X = vector2.GetProperty("x").GetInt32(),
                        Y = vector2.GetProperty("y").GetInt32()
                    });
                }

                /* Component: Collider */
                if (entity.TryGetProperty("collider", out JsonElement collider)) {
                    entityBuilder.With(new Collider {
                        X = collider.GetProperty("x").GetInt32(),
                        Y = collider.GetProperty("y").GetInt32(),
                        Width = collider.GetProperty("width").GetInt32(),
                        Height = collider.GetProperty("height").GetInt32(),
                        IsColliderOn = collider.GetProperty("colliderOn").GetBoolean()
                    });
                }

                /* Component: Ennemy */
                if (entity.TryGetProperty("ennemy", out JsonElement ennemy)) {
                    entityBuilder.With(new Ennemy {
                        Speed = ennemy.GetProperty("speed").GetInt32(),
                        Points = ennemy.GetProperty("points").GetInt32(),
                        HP = ennemy.GetProperty("hp").GetInt32()
                    });
                }

                /* Component: Fonceur */
                if (entity.TryGetProperty("fonceur", out JsonElement fonceur)) {
                    entityBuilder.With(new Fonceur());
                }

                /* Compoennt: FonceurOndulent */
                if (entity.TryGetProperty("fonceurOndulent", out JsonElement fonceurOndulent)) {
                    entityBuilder.With(new FonceurOndulent());
                }

                /* Component: Shooteur */
                if (entity.TryGetProperty("shooteur", out JsonElement shooteur)) {
                    entityBuilder.With(new Shooteur {
                        ShootCooldown = (float) shooteur.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0
                    });
                }

                /* Component: ShooteurOndulent */
                if (entity.TryGetProperty("shooteurOndulent", out JsonElement shooteurOndulent)) {
                    entityBuilder.With(new ShooteurOndulent {
                        ShootCooldown = (float) shooteurOndulent.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0
                    });
                }

                /* Component: Tourelle */
                if (entity.TryGetProperty("tourelle", out JsonElement tourelle)) {
                    entityBuilder.With(new Tourelle {
                        ShootCooldown = (float) tourelle.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0,
                        StaticX = tourelle.GetProperty("staticX").GetInt32(),
                        IsTop = tourelle.GetProperty("isTop").GetBoolean()
                    });
                }

                /* Component: Tour */
                if (entity.TryGetProperty("tour", out JsonElement tour)) {
                    entityBuilder.With(new Tour {
                        ShootCooldown = (float) tour.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0,
                        FromTop = tour.GetProperty("fromTop").GetBoolean()
                    });
                }

                /* Component: Moon */
                if (entity.TryGetProperty("moon", out JsonElement moon)) {
                    entityBuilder.With(new Moon {
                        ShootCooldown = (float) moon.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0,
                        StaticX = moon.GetProperty("staticX").GetInt32(),
                        isUp = false
                    });
                }

                /* Component: Meteore */
                if (entity.TryGetProperty("meteore", out JsonElement meteore)) {
                    entityBuilder.With(new Meteore {
                        FromTop = meteore.GetProperty("fromTop").GetBoolean()
                    });
                }

                /* Component: Furtif */
                if (entity.TryGetProperty("furtif", out JsonElement furtif)) {
                    entityBuilder.With(new Furtif {
                        ShootCooldown = (float) furtif.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0,
                        StaticX = furtif.GetProperty("staticX").GetInt32(),
                        isUp = false,
                        Disparition = true
                    });
                }

                /* Component: Mine */
                if (entity.TryGetProperty("mine", out JsonElement mine)) {
                    entityBuilder.With(new Mine {
                        Radius = (float) mine.GetProperty("radius").GetDouble(),
                        StaticX = mine.GetProperty("staticX").GetInt32()
                    });
                }

                /* Component: Spawner */
                if (entity.TryGetProperty("spawner", out JsonElement spawner)) {
                    entityBuilder.With(new Spawner {
                        SpawnCoolDown = (float) spawner.GetProperty("spawnCooldown").GetDouble(),
                        SpawnTimer = 0
                    });
                }

                /* Component: Sniper */
                if (entity.TryGetProperty("sniper", out JsonElement sniper)) {
                    entityBuilder.With(new Sniper {
                        ShootCooldown = (float) sniper.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0
                    });
                }

                /* Component: Observateur */
                if (entity.TryGetProperty("observateur", out JsonElement observateur)) {
                    entityBuilder.With(new Observateur {
                        StaticX = observateur.GetProperty("staticX").GetInt32(),
                        ShootCooldown = (float) observateur.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0
                    });
                }

                /* Component: Boss1 */
                if (entity.TryGetProperty("boss1", out JsonElement boss1)) {
                    entityBuilder.With(new Boss1 {
                        StaticX = boss1.GetProperty("staticX").GetInt32(),
                        isUp = false,
                        minY = boss1.GetProperty("minY").GetInt32(),
                        maxY = boss1.GetProperty("maxY").GetInt32()
                    });
                }

                /* Component: Boss1Top */
                if (entity.TryGetProperty("boss1Top", out JsonElement boss1Top)) {
                    entityBuilder.With(new Boss1Top {
                        OpeningCooldown = (float) boss1Top.GetProperty("openingCooldown").GetDouble(),
                        ClosingCoolDown = (float) boss1Top.GetProperty("closingCooldown").GetDouble(),
                        OpeningTimer = 0,
                        IsOpen = false
                    });
                }

                /* Component: Boss1Coeur */
                if (entity.TryGetProperty("boss1Coeur", out JsonElement boss1Coeur)) {
                    entityBuilder.With(new Boss1Coeur {
                        OpeningCooldown = (float) boss1Coeur.GetProperty("openingCooldown").GetDouble(),
                        ClosingCoolDown = (float) boss1Coeur.GetProperty("closingCooldown").GetDouble(),
                        OpeningTimer = 0,
                        IsOpen = false,
                        ShootCooldown = (float) boss1Coeur.GetProperty("shootCooldown").GetDouble(),
                        ShootTimer = 0
                    });
                }

                /* Component: Boss1Bottom */
                if (entity.TryGetProperty("boss1Bottom", out JsonElement boss1Bottom)) {
                    entityBuilder.With(new Boss1Bottom {
                        OpeningCooldown = (float) boss1Bottom.GetProperty("openingCooldown").GetDouble(),
                        ClosingCoolDown = (float) boss1Bottom.GetProperty("closingCooldown").GetDouble(),
                        OpeningTimer = 0,
                        IsOpen = false
                    });
                }

                /* Component: Boss1Mine */
                if (entity.TryGetProperty("boss1Mine", out JsonElement boss1Mine)) {
                    entityBuilder.With(new Boss1Mine {
                        OpeningCooldown = (float) boss1Mine.GetProperty("openingCooldown").GetDouble(),
                        ClosingCoolDown = (float) boss1Mine.GetProperty("closingCooldown").GetDouble(),
                        OpeningTimer = 0,
                        IsOpen = false,
                        minX = boss1Mine.GetProperty("minX").GetInt32(),
                        minY = boss1Mine.GetProperty("minY").GetInt32(),
                        maxX = boss1Mine.GetProperty("maxX").GetInt32(),
                        maxY = boss1Mine.GetProperty("maxY").GetInt32(),
                        ExplosionCooldown = (float) boss1Mine.GetProperty("explosionCooldown").GetDouble(),
                        ExplosionTimer = 0,
                    });
                }
            
                /* Component: MidBoss */
                if (entity.TryGetProperty("midBoss", out JsonElement midBoss)) {
                    entityBuilder.With(new MidBoss {
                        NextStage = midBoss.GetProperty("nextStage").GetString()
                    });
                }

                /* Component: ScrapScoring */
                if (entity.TryGetProperty("scrapScoring", out JsonElement scrapScoring)) {
                    entityBuilder.With(new ScrapScoring {
                        Scraps = 0
                    });
                }

                /* Component: bordure */
                if (entity.TryGetProperty("bordure", out JsonElement bordure)) {
                    string texFile = bordure.GetProperty("file").GetString();
                    string texNormalFile = bordure.GetProperty("fileNormal").GetString();
                    uint width = bordure.GetProperty("width").GetUInt32();
                    uint height = bordure.GetProperty("height").GetUInt32();
                    uint tileWidth = bordure.GetProperty("tileWidth").GetUInt32();
                    uint tileHeight = bordure.GetProperty("tileHeight").GetUInt32();

                    int texIntTop = bordure.GetProperty("texIntTop").GetInt32();
                    int texIntBottom = bordure.GetProperty("texIntBottom").GetInt32();

                    int positionX = bordure.GetProperty("positionX").GetInt32();

                    int[] tilesTop = new int[width];
                    for (int i = 0; i < tilesTop.Length; i++) {
                            tilesTop[i] = texIntTop;
                    }
                    int[] tilesBottom = new int[width];
                    for (int i = 0; i < tilesBottom.Length; i++) {
                            tilesBottom[i] = texIntBottom;
                    }
                    AlizeeEngine.TileMap tileMapTop = new AlizeeEngine.TileMap();
                    AlizeeEngine.TileMap tileMapBottom = new AlizeeEngine.TileMap();
                    tileMapTop.Load("res/textures/" + texFile + ".png", tileWidth, tileHeight, tilesTop, 0, 0, width, height);
                    tileMapBottom.Load("res/textures/" + texFile + ".png", tileWidth, tileHeight, tilesBottom, 0, 0, width, height);

                    /* TileMap Top */
                    new EntityBuilder(world).CreateEntity()
                        .With(new Border { Speed = 50 })
                        .With(new Position { X = positionX, Y = 0 })
                        .With(new Collider { X = 0, Y = 0, Width = (int) (width * tileWidth), Height = 16, IsColliderOn = true })
                        .With(new TileMap { Tiles = tileMapTop })
                        .Build();
                    
                    /* TileMap Bottom */
                    new EntityBuilder(world).CreateEntity()
                        .With(new Border { Speed = 50 })
                        .With(new Position { X = positionX, Y = 192 })
                        .With(new Collider { X = 0, Y = 0, Width = (int) (width * tileWidth), Height = 16, IsColliderOn = true })
                        .With(new TileMap { Tiles = tileMapBottom })
                        .Build();
                }

                /* Component: Animation */
                if (entity.TryGetProperty("animation", out JsonElement animation)) {
                    AnimationType type = AnimationType.Modulaire;

                    switch(animation.GetProperty("type").GetString()) {
                        case "oscillaire": type = AnimationType.Oscillaire; break;
                        case "modulaire": type = AnimationType.Modulaire; break;
                    }

                    entityBuilder.With(new Animation {
                        NbFrame = animation.GetProperty("nbFrame").GetInt32(),
                        NextFramePosition = animation.GetProperty("nextFramePosition").GetInt32(),
                        TimeByFrame = (float) animation.GetProperty("timeByFrame").GetDouble(),
                        CurrentTime = 0,
                        CurrentFrame = 0,
                        Type = type,
                        IsRight = true,
                        Lock = false
                    });
                }

                /* Component: Light */
                if (entity.TryGetProperty("light", out JsonElement light)) {
                    JsonElement color = light.GetProperty("color");
                    float r = (float) color.GetProperty("r").GetDouble();
                    float v = (float) color.GetProperty("v").GetDouble();
                    float b = (float) color.GetProperty("b").GetDouble();

                    entityBuilder.With(new Light {
                        Color = new SFML.Graphics.Glsl.Vec3(r, v, b),
                        Radius = light.GetProperty("radiusMin").GetInt32(),
                        MaxRadius = light.GetProperty("radiusMax").GetInt32(),
                        MinRadius = light.GetProperty("radiusMin").GetInt32(),
                        Increase = true,
                        Speed = light.GetProperty("speed").GetInt32()
                    });
                }

                /* Component: Decor */
                if (entity.TryGetProperty("decor", out JsonElement decor)) {
                    entityBuilder.With(new Decor {
                        Speed = decor.GetProperty("speed").GetInt32()
                    });
                }

                /* Component: Barriere */
                if (entity.TryGetProperty("barriere", out JsonElement barriere)) {
                    entityBuilder.With(new Barriere {
                        ActivationCooldown = (float) barriere.GetProperty("activationCooldown").GetDouble(),
                        ActivationTimer = 0
                    });
                }

                /* Component: DeplacementMenu */
                if (entity.TryGetProperty("deplacementMenu", out JsonElement deplacementMenu)) {
                    entityBuilder.With(new DeplacementMenu {
                        Position = 0,
                        NbElements = deplacementMenu.GetProperty("nbElements").GetInt32(),
                        NextCooldown = 0.1f,
                        NextTimer = 0
                    });
                }

                /* Component: Texte */
                if (entity.TryGetProperty("text", out JsonElement text)) {
                    AlizeeEngine.Text txt = new AlizeeEngine.Text(AssetManager.GetAssetFont("res/fonts/Zeldo.ttf"), text.GetProperty("contenu").GetString());
                    txt.Txt.CharacterSize = text.GetProperty("size").GetUInt32();
                    entityBuilder.With(new Text {
                        text = txt
                    });
                }

                /* Component: loadScene */
                if (entity.TryGetProperty("loadScene", out JsonElement loadScene)) {
                    entityBuilder.With(new LoadScene {
                        Id = loadScene.GetProperty("id").GetInt32(),
                        Scene = loadScene.GetProperty("newScene").GetString()
                    });
                }

                /* Component: HUD */
                if (entity.TryGetProperty("hud", out JsonElement hud)) {
                    entityBuilder.With(new HUD {
                        Cost = hud.GetProperty("cost").GetInt32(),
                        Actif = false,
                        Background = hud.GetProperty("background").GetBoolean(),
                        Bouclier = hud.GetProperty("bouclier").GetBoolean(),
                        TirMultiple = hud.GetProperty("tirMultiple").GetBoolean(),
                        Acceleration = hud.GetProperty("acceleration").GetBoolean(),
                        Drone = hud.GetProperty("drone").GetBoolean()
                    });
                }

                /* Component: NoShader */
                if (entity.TryGetProperty("noShader", out JsonElement noShader)) {
                    entityBuilder.With(new NoShader ());
                }

                /* Component: TileMapInfiniteParallex */
                if (entity.TryGetProperty("tileMapInfiniteParallex", out JsonElement tileMapInfiniteParallex)) {
                    entityBuilder.With(new TileMapInfiniteParallex ());
                }

                entityBuilder.Build();
            }

            JsonElement systemsElement = root.GetProperty("systems");
            foreach (JsonElement system in systemsElement.EnumerateArray()) {
                switch (system.GetString()) {
                    case "Input": world.AddSystem(new InputSystem()); break;
                    case "inputMenu": world.AddSystem(new InputMenuSystem()); break;
                    case "cursorMovement": world.AddSystem(new CursorMovementSystem()); break;
                    case "cursorLoading": world.AddSystem(new CursorLoadingSystem()); break;
                    case "selectorMovement": world.AddSystem(new SelectorMovementSystem()); break;
                    case "retourMenu": world.AddSystem(new RetourMenuSystem()); break;
                    case "closeWindow": world.AddSystem(new CloseWindowSystem()); break;
                    case "playerMovement": world.AddSystem(new PlayerMovementSystem()); break;
                    case "ennemyMovement": world.AddSystem(new EnnemyMovementSystem()); break;
                    case "tourelleMouvement": world.AddSystem(new TourelleMovementSystem()); break;
                    case "fonceurOndulentMovement": world.AddSystem(new FonceurOndulentMovementSystem()); break;
                    case "shooteurOndulentMovement": world.AddSystem(new ShooteurOndulentMovementSystem()); break;
                    case "moonMovement": world.AddSystem(new MoonMovementSystem()); break;
                    case "meteoreMovement": world.AddSystem(new MeteoreMovementSystem()); break;
                    case "furtifMovement": world.AddSystem(new FurtifMovementSystem()); break;
                    case "kamikazeMovement": world.AddSystem(new KamikazeMovementSystem()); break;
                    case "mineMovement": world.AddSystem(new MineMovementSystem()); break;
                    case "boss1Movement": world.AddSystem(new Boss1MovementSystem()); break;
                    case "observateurMovement": world.AddSystem(new ObservateurMovementSystem()); break;
                    case "scrapMovement": world.AddSystem(new ScrapMovementSystem()); break;
                    case "decorMovement": world.AddSystem(new DecorMovement()); break;
                    case "playerShoot": world.AddSystem(new PlayerShootSystem()); break;
                    case "spawnerAction": world.AddSystem(new SpawnerActionSystem()); break;
                    case "tourelleShoot": world.AddSystem(new TourelleShootSystem()); break;
                    case "tourShoot": world.AddSystem(new TourShootSystem()); break;
                    case "shooteurShoot": world.AddSystem(new ShooteurShootSystem()); break;
                    case "shooteurOndulentShoot": world.AddSystem(new ShooteurOndulentShootSystem()); break;
                    case "moonShoot": world.AddSystem(new MoonShootSystem()); break;
                    case "furtifShoot": world.AddSystem(new FurtifShootSystem()); break;
                    case "mineShoot": world.AddSystem(new MineShootSystem()); break;
                    case "sniperShoot": world.AddSystem(new SniperShootSystem()); break;
                    case "observateurShoot": world.AddSystem(new ObservateurShootSystem()); break;
                    case "boss1Shoot": world.AddSystem(new Boss1ShootSystem()); break;
                    case "decorAction": world.AddSystem(new DecorAction()); break;
                    case "playerMissile": world.AddSystem(new PlayerMissileSystem()); break;
                    case "ennemyMissile": world.AddSystem(new EnnemyMissileSystem()); break;
                    case "playerCollision": world.AddSystem(new PlayerCollisionSystem()); break;
                    case "ennemyCollision": world.AddSystem(new EnnemyCollisionSystem()); break;
                    case "particuleLife": world.AddSystem(new ParticuleLifeSystem()); break;
                    case "recuperationScrap": world.AddSystem(new RecuperationScrapSystem()); break;
                    case "playerShield": world.AddSystem(new PlayerShieldSystem()); break;
                    case "backgroundParallaxe": world.AddSystem(new BackgroundParallaxe()); break;
                    case "animation": world.AddSystem(new AnimationSystem()); break;
                    case "dynamicLight": world.AddSystem(new DynamicLightSystem()); break;
                    case "dynamicHUD": world.AddSystem(new DynamicHudSystem()); break;
                    case "jaugeDynamiquer": world.AddSystem(new jaugeDynamiqueSystem()); break;
                    case "shieldHUD": world.AddSystem(new ShieldHUDSystem()); break;
                    case "draw": world.AddSystem(new DrawSystem()); break;
                }
            }
        }

        fs.Close();
    }

}