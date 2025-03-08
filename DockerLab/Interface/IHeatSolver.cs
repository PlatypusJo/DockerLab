using DockerLab.Model;

namespace DockerLab.Interface
{
    public interface IHeatSolver
    {
        double[][][] CalculateTemperature(out double executionTime);
    }
}
