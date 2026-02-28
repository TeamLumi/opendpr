namespace Dpr.Battle.Logic
{
    public struct PokeTypePair
    {
        public ushort value;

        public PokeTypePair(ushort value)
        {
            this.value = value;
        }

        public static PokeTypePair Make(byte type1, byte type2, byte type_ex)
        {
        	return type1 & 0x1f | (type2 & 0x1f) << 5 | (type_ex & 0x1f) << 10;
        }

        public static PokeTypePair MakePure(byte type)
        {
        	return type & 0x1f | (type & 0x1f) << 5 | 0x4800;
        }

        public static byte GetType1(PokeTypePair pair)
        {
        	return (byte)(pair & 0x1f);
        }

        public static byte GetType2(PokeTypePair pair)
        {
        	return (byte)(pair >> 5 & 0x1f);
        }

        public static byte GetTypeEx(PokeTypePair pair)
        {
        	return (byte)(pair >> 10 & 0x1f);
        }

        public static void Split(PokeTypePair pair, out byte type1, out byte type2, out byte typeEx)
        {
        	type1 = (byte)pair & 0x1f;
        	type2 = (byte)((pair & 0xffff) >> 5) & 0x1f;
        	typeEx = (byte)((pair & 0xffff) >> 10) & 0x1f;
        }

        public static bool IsMatch(PokeTypePair pair, byte type)
        {
        	if (type != 0x12) {
        	  if ((pair & 0x1f) == (uint)type) {
        	    return true;
        	  }
        	  if ((pair >> 5 & 0x1f) == (uint)type) {
        	    return true;
        	  }
        	  if ((pair >> 10 & 0x1f) == (uint)type) {
        	    return true;
        	  }
        	}
        	return false;
        }

        public static bool IsPure(PokeTypePair pair, bool includeExType = true)
        {
        	var uVar3 = pair ^ pair >> 5;
        	var bVar1 = (bool)((uVar3 & 0x1f) == 0 & (includeExType ^ 1));
        	var bVar2 = bVar1;
        	if ((uVar3 & 0x1f) == 0) {
        	  bVar2 = (pair & 0x7c00) == 0x4800;
        	}
        	if (((includeExType ^ 1) & 1) == 0) {
        	  bVar1 = bVar2;
        	}
        	return bVar1;
        }

        public static PokeTypePair Replace(PokeTypePair pair, byte targetType, byte newType)
        {
        	targetType = (byte)(targetType & 0xff);
        	var uVar1 = newType;
        	if ((pair & 0x1f) != targetType) {
        	  uVar1 = pair;
        	}
        	var uVar2 = newType;
        	if (((pair & 0xffff) >> 5 & 0x1f) != targetType) {
        	  uVar2 = pair >> 5 & 0x7ff;
        	}
        	if (((pair & 0xffff) >> 10 & 0x1f) != targetType) {
        	  newType = (byte)(pair >> 10 & 0x3f);
        	}
        	return uVar1 & 0x1f | (uVar2 & 0x1f) << 5 | (newType & 0x1f) << 10;
        }

        public static bool IsAnyTypeExist(PokeTypePair pair)
        {
        	if (((pair & 0x1f) == 0x12) && ((pair & 0x3e0) == 0x240)) {
        	  return (pair & 0x7c00) != 0x4800;
        	}
        	return true;
        }

        public static implicit operator ushort(PokeTypePair pair)
        {
            return pair.value;
        }

        public static explicit operator PokeTypePair(ushort value)
        {
            return new PokeTypePair(value);
        }
    }
}