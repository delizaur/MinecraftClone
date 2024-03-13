using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone {
    internal class RegistryObject<T> {
        public int id;
        public T obj;

        public static implicit operator T(RegistryObject<T> registryObject) {
            return registryObject.obj;
        }
    }
}
