using DockerLab.Interface;
using DockerLab.Model;

namespace DockerLab.Service
{
    public class HeatSolverService : IHeatSolverService
    {
        private IHeatSolver _heatSolver;
        private HeatSettingsModel _settings;

        public HeatSolverService()
        {
            _settings = new();
        }

        public async Task UpdateSettings(DataDto data)
        {
            _settings = new(data);
        }

        public async Task<double[][][]> CalculateTemperature(bool isParallel)
        {
            if (!_settings.IsStable)
                return null;

            _heatSolver = isParallel ? new HeatSolverParallel(_settings) : new HeatSolver(_settings);

            return _heatSolver.CalculateTemperature(out double _);
        }

    }
}
