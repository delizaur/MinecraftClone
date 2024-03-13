using OpenTK.Mathematics;

namespace MinecraftClone.World {

    // Each tuple is a coordinate in the texture atlas. (0, 0) is bottom left
    // TODO: that is bad, is it flipped?
    public class BlockTextureData {

        public (int, int) top;
        public (int, int) bottom;
        public (int, int) left;
        public (int, int) right;
        public (int, int) front;
        public (int, int) back;
        
        public Dictionary<Faces, List<Vector2>> ToUVs() {
            float scaling = 1 / Constants.TEXTURE_ATLAS_WIDTH;
            // top left corner, top right corner, bottom right corner, bottom left corner
            return new Dictionary<Faces, List<Vector2>>() {
                { Faces.FRONT, FromTupleToUV(front) },
                { Faces.BACK, FromTupleToUV(back) },
                { Faces.LEFT, FromTupleToUV(left) },
                { Faces.RIGHT, FromTupleToUV(right) },
                { Faces.TOP, FromTupleToUV(top) },
                { Faces.BOTTOM, FromTupleToUV(bottom) },
            };
        }

        private List<Vector2> FromTupleToUV((int, int) tuple) {
            float scaling = 1f / Constants.TEXTURE_ATLAS_WIDTH;
            return new List<Vector2>() {
                new Vector2((tuple.Item1+1f)/16f, (tuple.Item2+1)/16f),
                new Vector2(tuple.Item1/16f, (tuple.Item2+1f)/16f),
                new Vector2(tuple.Item1/16f, tuple.Item2/16f),
                new Vector2((tuple.Item1+1f)/16f, tuple.Item2/16f)
            };
        }
    }
}