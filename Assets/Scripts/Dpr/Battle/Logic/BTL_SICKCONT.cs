namespace Dpr.Battle.Logic
{
    public struct BTL_SICKCONT
    {
        public long raw;

        private const int raw_sz0 = 3;
        private const int raw_loc0 = 0;
        private const int raw_sz1 = 5;
        private const int raw_loc1 = 3;
        private const long raw_mask0 = 7;
        private const long raw_mask1 = 248;
        private const int turn_sz0 = 3;
        private const int turn_loc0 = 0;
        private const int turn_sz1 = 5;
        private const int turn_loc1 = 3;
        private const int turn_sz2 = 6;
        private const int turn_loc2 = 8;
        private const int turn_sz3 = 16;
        private const int turn_loc3 = 14;
        private const int turn_sz4 = 1;
        private const int turn_loc4 = 30;
        private const long turn_mask0 = 7;
        private const long turn_mask1 = 248;
        private const long turn_mask2 = 16128;
        private const long turn_mask3 = 1073725440;
        private const long turn_mask4 = 1073741824;
        private const int poke_sz0 = 3;
        private const int poke_loc0 = 0;
        private const int poke_sz1 = 5;
        private const int poke_loc1 = 3;
        private const int poke_sz2 = 6;
        private const int poke_loc2 = 8;
        private const int poke_sz3 = 16;
        private const int poke_loc3 = 14;
        private const int poke_sz4 = 1;
        private const int poke_loc4 = 30;
        private const long poke_mask0 = 7;
        private const long poke_mask1 = 248;
        private const long poke_mask2 = 16128;
        private const long poke_mask3 = 1073725440;
        private const long poke_mask4 = 1073741824;
        private const int permanent_sz0 = 3;
        private const int permanent_loc0 = 0;
        private const int permanent_sz1 = 5;
        private const int permanent_loc1 = 3;
        private const int permanent_sz2 = 6;
        private const int permanent_loc2 = 8;
        private const int permanent_sz3 = 16;
        private const int permanent_loc3 = 14;
        private const int permanent_sz4 = 1;
        private const int permanent_loc4 = 30;
        private const long permanent_mask0 = 7;
        private const long permanent_mask1 = 248;
        private const long permanent_mask2 = 16128;
        private const long permanent_mask3 = 1073725440;
        private const long permanent_mask4 = 1073741824;
        private const int poketurn_sz0 = 3;
        private const int poketurn_loc0 = 0;
        private const int poketurn_sz1 = 5;
        private const int poketurn_loc1 = 3;
        private const int poketurn_sz2 = 6;
        private const int poketurn_loc2 = 8;
        private const int poketurn_sz3 = 6;
        private const int poketurn_loc3 = 14;
        private const int poketurn_sz4 = 16;
        private const int poketurn_loc4 = 20;
        private const int poketurn_sz5 = 1;
        private const int poketurn_loc5 = 36;
        private const long poketurn_mask0 = 7;
        private const long poketurn_mask1 = 248;
        private const long poketurn_mask2 = 16128;
        private const long poketurn_mask3 = 1032192;
        private const long poketurn_mask4 = -1048576;
        private const long poketurn_mask5 = 16;

        public byte type
        {
            get { return (byte)((raw & raw_mask0) >> raw_loc0); }
            set { raw = (raw & ~raw_mask0) | (((long)value << raw_loc0) & raw_mask0); }
        }

        public byte causePokeID
        {
            get { return (byte)((raw & raw_mask1) >> raw_loc1); }
            set { raw = (raw & ~raw_mask1) | (((long)value << raw_loc1) & raw_mask1); }
        }

        public byte turn_type_turn
        {
            get { return (byte)((raw & turn_mask0) >> turn_loc0); }
            set { raw = (raw & ~turn_mask0) | (((long)value << turn_loc0) & turn_mask0); }
        }

        public byte turn_causePokeID
        {
            get { return (byte)((raw & turn_mask1) >> turn_loc1); }
            set { raw = (raw & ~turn_mask1) | (((long)value << turn_loc1) & turn_mask1); }
        }

        public byte turn_count
        {
            get { return (byte)((raw & turn_mask2) >> turn_loc2); }
            set { raw = (raw & ~turn_mask2) | (((long)value << turn_loc2) & turn_mask2); }
        }

        public ushort turn_param
        {
            get { return (ushort)((raw & turn_mask3) >> turn_loc3); }
            set { raw = (raw & ~turn_mask3) | (((long)value << turn_loc3) & turn_mask3); }
        }

        public bool turn_flag
        {
            get { return ((raw & turn_mask4) >> turn_loc4) != 0; }
            set { raw = (raw & ~turn_mask4) | (value ? turn_mask4 : 0); }
        }

        public byte poke_type_poke
        {
            get { return (byte)((raw & poke_mask0) >> poke_loc0); }
            set { raw = (raw & ~poke_mask0) | (((long)value << poke_loc0) & poke_mask0); }
        }

        public byte poke_causePokeID
        {
            get { return (byte)((raw & poke_mask1) >> poke_loc1); }
            set { raw = (raw & ~poke_mask1) | (((long)value << poke_loc1) & poke_mask1); }
        }

        public byte poke_ID
        {
            get { return (byte)((raw & poke_mask2) >> poke_loc2); }
            set { raw = (raw & ~poke_mask2) | (((long)value << poke_loc2) & poke_mask2); }
        }

        public ushort poke_param
        {
            get { return (ushort)((raw & poke_mask3) >> poke_loc3); }
            set { raw = (raw & ~poke_mask3) | (((long)value << poke_loc3) & poke_mask3); }
        }

        public bool poke_flag
        {
            get { return ((raw & poke_mask4) >> poke_loc4) != 0; }
            set { raw = (raw & ~poke_mask4) | (value ? poke_mask4 : 0); }
        }

        public byte permanent_type_perm
        {
            get { return (byte)((raw & permanent_mask0) >> permanent_loc0); }
            set { raw = (raw & ~permanent_mask0) | (((long)value << permanent_loc0) & permanent_mask0); }
        }

        public byte permanent_causePokeID
        {
            get { return (byte)((raw & permanent_mask1) >> permanent_loc1); }
            set { raw = (raw & ~permanent_mask1) | (((long)value << permanent_loc1) & permanent_mask1); }
        }

        public byte permanent_count_max
        {
            get { return (byte)((raw & permanent_mask2) >> permanent_loc2); }
            set { raw = (raw & ~permanent_mask2) | (((long)value << permanent_loc2) & permanent_mask2); }
        }

        public ushort permanent_param
        {
            get { return (ushort)((raw & permanent_mask3) >> permanent_loc3); }
            set { raw = (raw & ~permanent_mask3) | (((long)value << permanent_loc3) & permanent_mask3); }
        }

        public bool permanent_flag
        {
            get { return ((raw & permanent_mask4) >> permanent_loc4) != 0; }
            set { raw = (raw & ~permanent_mask4) | (value ? permanent_mask4 : 0); }
        }

        public byte poketurn_type_poketurn
        {
            get { return (byte)((raw & poketurn_mask0) >> poketurn_loc0); }
            set { raw = (raw & ~poketurn_mask0) | (((long)value << poketurn_loc0) & poketurn_mask0); }
        }

        public byte poketurn_causePokeID
        {
            get { return (byte)((raw & poketurn_mask1) >> poketurn_loc1); }
            set { raw = (raw & ~poketurn_mask1) | (((long)value << poketurn_loc1) & poketurn_mask1); }
        }

        public byte poketurn_count
        {
            get { return (byte)((raw & poketurn_mask2) >> poketurn_loc2); }
            set { raw = (raw & ~poketurn_mask2) | (((long)value << poketurn_loc2) & poketurn_mask2); }
        }

        public byte poketurn_pokeID
        {
            get { return (byte)((raw & poketurn_mask3) >> poketurn_loc3); }
            set { raw = (raw & ~poketurn_mask3) | (((long)value << poketurn_loc3) & poketurn_mask3); }
        }

        public ushort poketurn_param
        {
            get { return (ushort)((raw & poketurn_mask4) >> poketurn_loc4); }
            set { raw = (raw & ~poketurn_mask4) | (((long)value << poketurn_loc4) & poketurn_mask4); }
        }

        public bool poketurn_flag
        {
            get { return ((raw & poketurn_mask5) >> poketurn_loc5) != 0; }
            set { raw = (raw & ~poketurn_mask5) | (value ? poketurn_mask5 : 0); }
        }
    }
}
