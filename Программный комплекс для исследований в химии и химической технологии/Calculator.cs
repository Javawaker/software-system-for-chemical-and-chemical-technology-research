using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Calculator
    {
        public static double length { get; set; }
        public static double width { get; set; }
        public static double depth { get; set; }
        public static double density { get; set; }
        public static double heatCapacity { get; set; }
        public static double meltingTemperature { get; set; }
        public static double capSpeed { get; set; }
        public static double temperature { get; set; }
        public static double stepCanal { get; set; }
        public static double consistencyRatio { get; set; }
        public static double viscosityCoefficient { get; set; }
        public static double reductionTemperature { get; set; }
        public static double flowIndex { get; set; }
        public static double heatTransferCoefficient { get; set; }


        public static double CalcQGamma(double H, double W, double mu, double Vu, double n)
        {
            return H * W * mu * Math.Pow(Vu / H, (n + 1));
        }
        public static double CalcQAlpha(double a, double W, double b, double Tu, double Tr)
        {
            return a * W * (Math.Pow(b, -1) - Tu + Tr);
        }
        public static double CalcF(double depth, double width)
        {
            return 0.125 * Math.Pow(depth / width, 2) - 0.625 * depth / width + 1;
        }
        public static double CalcQCh(double width, double depth, double capSpeed, double f)
        {
            return (width * depth * capSpeed / 2) * f;
        }
        public static double CalcFirstPart(double viscosityCoefficient, double qy, double width, double heatTransferCoefficient, double qa)
        {
            return (viscosityCoefficient * qy + width * heatTransferCoefficient) / (viscosityCoefficient * qa);
        }
        public static double CalcSecondPart(double density, double heatCapacity, double qch)
        {
            return density * heatCapacity * qch;
        }
        public static double CalcThirdPart(double meltingTemperature, double reductionTemperature, double qa, double z, double SecondPartCalc)
        {
            return meltingTemperature - reductionTemperature - qa * z / SecondPartCalc;
        }
        public static double CalcTemperature(double reductionTemperature, double viscosityCoefficient, double FirstPartCalc, double qa, double z, double SecondPartCalc, double ThirdPartCalc)
        {
            return Math.Round(reductionTemperature + (1 / viscosityCoefficient) * Math.Log(FirstPartCalc * (1 - Math.Exp(-viscosityCoefficient * qa * z / SecondPartCalc)) + Math.Exp(viscosityCoefficient * ThirdPartCalc)), 2);
        }
        public static double CalcViscosity(double consistencyRatio, double viscosityCoefficient, double Temperature, double reductionTemperature, double capSpeed, double depth, double flowIndex)
        {
            return Math.Round(consistencyRatio * Math.Exp(-viscosityCoefficient * (Temperature - reductionTemperature)) * Math.Pow(capSpeed / depth, flowIndex - 1), 2);
        }
        public static double CalcEfficiency(double density, double width, double depth, double capSpeed, double f)
        {
            return Math.Round(density * ((width * depth * capSpeed / 2) * f) * 3600, 2);
        }
    }
    public class Indicators
    {
        public static double efficiencyCanal { get; set; }
        public static double temperatureProduct { get; set; }
        public static double viscosityProduct { get; set; }

    }
    public class PlotData
    {
        public static List<double> coordinateCanalPlot = new List<double>();
        public static List<double> temperatureProductPlot = new List<double>();
        public static List<double> viscosityProductPlot = new List<double>();

    }

    public class PlotExperiment
    {
        public static List<double> par = new List<double>();
        public static List<double> efficiencyPlotExperiment = new List<double>();
        public static List<double> temperaturePlotExperiment = new List<double>();
        public static List<double> viscosityPlotExperiment = new List<double>();
        public static double minPar;
        public static double maxPar;
        public static string varPar;

    }
}
