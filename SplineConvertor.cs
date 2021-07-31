using System;
using System.Collections.Generic;

/*
Created on June 2, 2019
Bezier Spline to Catmull-Rom Spline and Vice-Versa Conversion

@author: Soroosh Tayebi Arasteh <soroosh.arasteh@fau.de>
https://github.com/starasteh/
*/

namespace sorooshTest
{
    public class SplineConvertor
    {
        public SplineConvertor()
        {
        }

        static public List<double> Catmullrom2BezierAndViceVersa(List<double> inputPoints, double taw, string mode)
        {
            // Inspired by the explanation on: https//pomax.github.io/bezierinfo/#catmullconv

            List<double> result = new List<double>();

            if (mode == "C2B") // if you want to convert from Catmull-Rom control points to Bezier Control points.
            {
                result.Add(inputPoints[2]);
                result.Add(inputPoints[3]);
                result.Add(inputPoints[2] + (inputPoints[4] - inputPoints[0]) / (6 * taw));
                result.Add(inputPoints[3] + (inputPoints[5] - inputPoints[1]) / (6 * taw));
                result.Add(inputPoints[4] - (inputPoints[6] - inputPoints[2]) / (6 * taw));
                result.Add(inputPoints[5] - (inputPoints[7] - inputPoints[3]) / (6 * taw));
                result.Add(inputPoints[4]);
                result.Add(inputPoints[5]);
            }
            else if (mode == "B2C") // if you want to convert from Bezier control points to Catmull-Rom Control points.
            {
                result.Add(inputPoints[6] + 6 * (inputPoints[0] - inputPoints[2]));
                result.Add(inputPoints[7] + 6 * (inputPoints[1] - inputPoints[3]));
                result.Add(inputPoints[0]);
                result.Add(inputPoints[1]);
                result.Add(inputPoints[6]);
                result.Add(inputPoints[7]);
                result.Add(inputPoints[0] + 6 * (inputPoints[6] - inputPoints[4]));
                result.Add(inputPoints[1] + 6 * (inputPoints[7] - inputPoints[5]));
            }
            return result;
        }

        static public List<double> main()
        {
            Console.WriteLine("Please enter C2B if you want to convert from Catmull-Rom control points to Bezier Control points \n" +
                              "and enter B2C if you would like to do the other way around:");
            List<double> inputPoints = new List<double>();

            var mode = Console.ReadLine();
            double taw = 0; // Initializing the tension factor of Catmull-Rom curve.
            if (mode == "C2B")
            {
                Console.WriteLine("Please enter your tension factor:");
                taw = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine("Please enter all your points in order ( 8 coordinates: p0x, p0y, p1x, p1y, etc.)");
            for (int i = 0; i < 8; i++)
            {
                var a = Convert.ToDouble(Console.ReadLine());
                inputPoints.Add(a);
            }

            List<double> outputPoints = Catmullrom2BezierAndViceVersa(inputPoints, taw, mode);
            return outputPoints;
        }
    }
}
