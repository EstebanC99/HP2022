namespace CuidadosModernos.CrossCutting.Global
{
    public abstract class EstadosTareaEmpleada
    {
        public EstadosTareaEmpleada()
        {

        }

        public const int SinAsignar = 1;

        public const int Asignada = 2;

        public const int RealizadaATiempo = 3;

        public const int RealizadaFueraDeTiempo = 4;

        public const int Incumplida = 5;
    }
}
