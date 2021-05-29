using System;

namespace AlizeeEngine {
    internal enum LateCommandType {
        AddEnt,
        AddCmp,
        DropEnt,
        DropCmp,
        CloseProgram,
        AddSystem,
        ClearSystems
    }

    internal struct LateCommand {
        public LateCommandType Type;
        public Entity Ent;
        public Object Cmp;
        public Type CmpType;
        public ClodoBehaviour Sys;
    }
}