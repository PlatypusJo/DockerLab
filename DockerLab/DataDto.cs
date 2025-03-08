namespace DockerLab
{
    public class DataDto
    {
        // Размеры параллелепипеда в см
        public double IParallepipedSize { get; set; }

        public double JParallepipedSize { get; set; }

        public double KParallepipedSize { get; set; }

        // Границы
        public double Aboundary { get; set; }

        public double AAboundary { get; set; }

        public double Bboundary { get; set; }

        public double BBboundary { get; set; }

        public double Cboundary { get; set; }

        public double CCboundary { get; set; }

        // Шаги и коэффициент 
        public double H { get; set; }

        public double Tau { get; set; }

        public double Alfa { get; set; }

        public double MaxTime { get; set; }
    }
}
