namespace Pml.PokePara
{
    public static class SerializedPokemonExtensions
    {
        public static void Serialize_Full(this PokemonParam self, ref SerializedPokemonFull buffer)
        {
            buffer.CreateWorkIfNeed();
            self.Serialize_Full(buffer.buffer);
        }

        public static void Deserialize_Full(this PokemonParam self, in SerializedPokemonFull serializedData)
        {
            self.Deserialize_Full(serializedData.buffer);
        }

        public static void Serialize_Core(this PokemonParam self, ref SerializedPokemonCore buffer)
        {
            buffer.CreateWorkIfNeed();
            self.Serialize_Core(buffer.buffer);
        }

        public static void Deserialize_Core(this PokemonParam self, in SerializedPokemonCore serializedData)
        {
            self.Deserialize_Core(serializedData.buffer);
        }
    }
}