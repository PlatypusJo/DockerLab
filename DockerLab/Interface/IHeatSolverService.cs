namespace DockerLab.Interface
{
    public interface IHeatSolverService
    {
        Task UpdateSettings(DataDto data);
        Task<double[][][]> CalculateTemperature(bool isParallel);
    }
}
