using DockerLab.Model;

namespace DockerLab.Service
{
    public abstract class HeatSolverBase
    {
        #region Поля

        protected double[][][] _u;

        protected double[][][] _uNew;

        protected int _iDim;

        protected int _jDim;

        protected int _kDim;

        protected double _initTime = 0;

        protected HeatSettingsModel _settings;

        #endregion

        #region Конструкторы

        public HeatSolverBase(HeatSettingsModel settings)
        {
            _settings = settings;

            _iDim = _settings.IDimSize;
            _jDim = _settings.JDimSize;
            _kDim = _settings.KDimSize;
        }

        #endregion

        #region Внутренние методы

        protected void CopyArray(double[][][] src, double[][][] dst)
        {
            for (int i = 0; i < _iDim; i++)
                for (int j = 0; j < _jDim; j++)
                    for (int k = 0; k < _kDim; k++)
                        dst[i][j][k] = src[i][j][k];
        }

        protected void InitializeTemperature()
        {
            _u = new double[_iDim][][];
            _uNew = new double[_iDim][][];

            Parallel.For(0, _iDim, i =>
            {
                _u[i] = new double[_jDim][];
                _uNew[i] = new double[_jDim][];
                for (int j = 0; j < _jDim; j++)
                {
                    _u[i][j] = new double[_kDim];
                    _uNew[i][j] = new double[_kDim];
                    for (int k = 0; k < _kDim; k++)
                    {
                        _u[i][j][k] = 0;
                        _uNew[i][j][k] = 0;
                    }
                }
            });

            int iMax = _iDim - 1;
            int jMax = _jDim - 1;
            int kMax = _kDim - 1;

            Parallel.For(0, _iDim, i =>
            {
                for (int j = 0; j < _jDim; j++)
                {
                    _u[i][j][0] = _settings.Aboundary;
                    _u[i][j][kMax] = _settings.AAboundary;
                }
            });

            Parallel.For(0, _iDim, i =>
            {
                for (int k = 0; k < _kDim; k++)
                {
                    _u[i][0][k] = _settings.CCboundary;
                    _u[i][jMax][k] = _settings.Cboundary;
                }
            });

            Parallel.For(0, _jDim, j =>
            {
                for (int k = 0; k < _kDim; k++)
                {
                    _u[0][j][k] = _settings.Bboundary;
                    _u[iMax][j][k] = _settings.BBboundary;
                }
            });

            CopyArray(_u, _uNew);
        }

        #endregion
    }
}
