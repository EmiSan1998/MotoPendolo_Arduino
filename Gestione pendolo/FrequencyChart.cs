/*
FrequencyChart, extension method of the Chart class developed by Emiliano Sandri in 2018.
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace EmiSan1998.FrequencyChart
{
    static class FrequencyDistributionChart
    {
        /// <summary>
        /// This extension method of the class Chart ease the drawing of frequency distribution charts.
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="series">The name of the data series that will used to store the frequency data.</param>
        /// <param name="elements">List of all the elements that will be inclued in the chart.</param>
        /// <param name="columns">Number of columns in the chart.</param>
        /// <returns>The total number of elements.</returns>
        public static int FDupdate(this System.Windows.Forms.DataVisualization.Charting.Chart chart,String series,List<int> elements,int columns)
        {
            chart.Series[series].Points.Clear();
            if (elements.Any<int>())
            {
                int min, max; //Maximum and minimum values on the X axis
                int boundaryLeft, boundaryRight; //Boundaries of a given interval.
                int rp; //Number of elements that exists in a given interval.
                min = elements.Min();
                max = elements.Max() + columns - (elements.Max() - min) % columns;
                int intervallo = (max - min) / columns;
                for (int i = 0; i < columns; i++)
                {
                    rp = 0;
                    boundaryLeft = min + intervallo * i;
                    boundaryRight = boundaryLeft + intervallo;
                    elements.ForEach(delegate (int elemento)
                    {
                        if (elemento >= boundaryLeft && elemento < boundaryRight)
                        {
                            rp++;
                        }
                    });
                    chart.Series[series].Points.AddXY(boundaryLeft.ToString(), rp);
                }
            }
            chart.Update();
            return elements.Count();
        }
    }
}
