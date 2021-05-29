namespace AlizeeEngine {
    public static class Time {

        public static float deltaTime { get; internal set; }
        public static float frameCount { get; internal set; }

        private static float timer;
        private static int nbFrame;

        internal static void FrameCounter() {
            timer += deltaTime;
            nbFrame++;

            if (timer >= 1) {
                System.Console.WriteLine("FPS : " + nbFrame);
                timer = 0;
                nbFrame = 0;
            }
        }

    }
}