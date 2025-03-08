namespace DockerLab.Model
{
    public class HeatSettingsModel
    {
        #region Свойства

        public int IDimSize => (int)(IParallepipedSize / H);

        public int JDimSize => (int)(JParallepipedSize / H);

        public int KDimSize => (int)(KParallepipedSize / H);

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

        // Условие устойчивости
        public bool IsStable => (Tau * Alfa * Alfa) / (H * H) < 0.125;

        #endregion

        #region Конструктор

        public HeatSettingsModel()
        {

        }

        public HeatSettingsModel(DataDto data)
        {
            IParallepipedSize = data.IParallepipedSize;
            JParallepipedSize = data.JParallepipedSize;
            KParallepipedSize = data.KParallepipedSize;
            Aboundary = data.Aboundary;
            AAboundary = data.AAboundary;
            Bboundary = data.Bboundary;
            BBboundary = data.BBboundary;
            Cboundary = data.Cboundary;
            CCboundary = data.CCboundary;
            H = data.H;
            Tau = data.Tau;
            Alfa = data.Alfa;
            MaxTime = data.MaxTime;
        }

        #endregion
    }
}
