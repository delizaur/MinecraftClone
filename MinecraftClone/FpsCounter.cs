using OpenTK.Windowing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone {
    internal class FpsCounter {

        private static int numFramesSinceLastSecond = 0;
        private static double timeSinceLastSecond = 0;

        public static void OnRenderFrame(FrameEventArgs e) {
            timeSinceLastSecond += e.Time;
            numFramesSinceLastSecond++;

            if (timeSinceLastSecond > 1) {
                timeSinceLastSecond = 0;
                Console.WriteLine("FPS: " + numFramesSinceLastSecond);
                numFramesSinceLastSecond = 0;
            }
        }

    }
}
