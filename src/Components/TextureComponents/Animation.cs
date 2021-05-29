enum AnimationType {
    Oscillaire,
    Modulaire
}

class Animation {
    public int NbFrame;
    public int CurrentFrame;
    public float TimeByFrame;
    public float CurrentTime;
    public int NextFramePosition;
    public AnimationType Type;
    public bool IsRight;
    public bool Lock;
}