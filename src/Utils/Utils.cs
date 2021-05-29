static class Utils {

    //// Intersect ////
    public static bool Intersect(Position pos1, Collider col1, Position pos2, Collider col2) {
        return ((pos2.X + col2.X) <= (pos1.X + col1.X  + col1.Width))
            && ((pos2.X + col2.X + col2.Width) >= (pos1.X + col1.X))
            && ((pos2.Y + col2.Y) <= (pos1.Y + col1.Y + col1.Height))
            && ((pos2.Y + col2.Y  + col2.Height) >= (pos1.Y + col1.Y));
    }

    //// IntersectX ////
    public static bool IntersectX(Position pos1, Collider col1, Position pos2, Collider col2) {
        return ((pos2.X + col2.X) <= (pos1.X + col1.Width))
            && ((pos2.X + col2.Width) >= (pos1.X + col1.X));
    }

    //// IntersectY ////
    public static bool IntersectY(Position pos1, Collider col1, Position pos2, Collider col2) {
        return ((pos2.Y + col2.Y) <= (pos1.Y + col1.Height))
            && ((pos2.Y + col2.Height) >= (pos1.Y + col1.Y));
    }

}