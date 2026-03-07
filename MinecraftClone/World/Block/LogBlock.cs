using MinecraftClone.World.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.Block {
    internal class LogBlock : BaseBlock {

        public override string Name() => "log";

        public override State GetDefaultState() => new LogState { axis = AxisProperty.Y };

        public override BlockTextureData GetTextureData(BlockState state) {
            var axis = state.GetStateAs<LogState>().axis;
            var outside = (1, 14);
            var inside = (2, 14);
            if (axis == AxisProperty.Y) {
                return new BlockTextureData {
                    top = inside,
                    bottom = inside,
                    left = outside,
                    right = outside,
                    front = outside,
                    back = outside,
                };
            } else if (axis == AxisProperty.X) { // there's a chance X and Z are reversed but atm idc
                return new BlockTextureData {
                    front = inside,
                    back = inside,
                    top = outside,
                    bottom = outside,
                    left = outside,
                    right = outside,
                };
            } else {
                return new BlockTextureData {
                    left = inside,
                    right = inside,
                    top = outside,
                    bottom = outside,
                    back = outside,
                    front = outside,
                };
            }
        }

        public class LogState : State {

            public AxisProperty axis;

            public override State Deserialize(short serialized) => new LogState {
                axis = (AxisProperty)serialized,
            }; 

            public override short Serialize() => (short)axis;
        }

    }
}
