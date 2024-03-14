using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {
    
    public enum BoolProperty {
        True, False
    }

    public static class BoolPropertyExtensions
    {
        public static bool AsBool(this BoolProperty boolProperty) {
            return boolProperty == BoolProperty.True;
        }

        public static BoolProperty Toggle(this BoolProperty boolProperty) {
            if (boolProperty == BoolProperty.True) {
                boolProperty = BoolProperty.False;
            } else {
                boolProperty = BoolProperty.True;
            }
            return boolProperty;
        }
    }

    public enum AxisProperty {
        X, Y, Z
    }

}
