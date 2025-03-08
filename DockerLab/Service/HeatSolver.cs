using DockerLab.Interface;
using DockerLab.Model;
using System.Diagnostics;
using System.Runtime;
using System.Text;

namespace DockerLab.Service
{
    public class HeatSolver : HeatSolverBase, IHeatSolver
    {
        #region Конструктор

        public HeatSolver(HeatSettingsModel settings) : base(settings) { }

        #endregion

        #region Методы

        public double[][][] CalculateTemperature(out double executionTime)
        {
            InitializeTemperature();
            double coeff = (_settings.Tau * _settings.Alfa * _settings.Alfa) / _settings.H * _settings.H;
            Stopwatch timer = new();
            timer.Start();

            for (double t = _initTime; t < _settings.MaxTime; t += _settings.Tau)
            {
                for (int i = 1; i < _iDim - 1; i++)
                    for (int j = 1; j < _jDim - 1; j++)
                        for (int k = 1; k < _kDim - 1; k++)
                            _uNew[i][j][k] = _u[i][j][k] + coeff *
                                (_u[i + 1][j][k] + _u[i - 1][j][k] + _u[i][j + 1][k] +
                                _u[i][j - 1][k] + _u[i][j][k + 1] + _u[i][j][k - 1] - 6 * _u[i][j][k]);

                CopyArray(_uNew, _u);
            }

            timer.Stop();
            executionTime = timer.Elapsed.TotalMilliseconds / 1000;

            return _u;
        }

        #endregion
    }
}
