namespace AlizeeEngine {
    public abstract class ClodoBehaviour {
        public Query Query { get; internal set; } = new Query();
        public World World { get; internal set; }
        public ListEntity Entities => World.Entities;

        public virtual void OnCreate() {}
        public abstract void OnUpdate();
    }
}