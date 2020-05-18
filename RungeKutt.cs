using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Population
{
    class RungeKutt
    {
        public double U1 { get; set; }

        public double U2 { get; set; }

        public double U3 { get; set; }

        public double alpha1 { get; set; }
        public double omega1 { get; set; }
        public double beta1 { get; set; }
        public double alpha2 { get; set; }
        public double omega2 { get; set; }
        public double beta2 { get; set; }
        public double gamma1 { get; set; }
        public double gamma2 { get; set; }

        //Правые части
        public double f1(double t, double u1, double u2, double u3) 
        {
            return u1 * (alpha1 - u1 - omega1 * u2 - beta1 * u3);
        }
        double f2(double t, double u1, double u2, double u3)
        {
            return u2 * (alpha2 - omega2 * u1 - u2 - beta2 * u3);
        }
        double f3(double t, double u1, double u2, double u3)
        {
            return u3 * (-1 + gamma1 * u1 + gamma2 * u2);
        }

        private double K1, L1, K2, L2, K3, L3, K4, L4,N1, N2, N3, N4;
        public void rk4(double t, double u1, double u2, double u3, double h)
        {
            K1 = h * f1(t, u1, u2, u3);
            L1 = h * f2(t, u1, u2, u3);
            N1 = h * f3(t, u1, u2, u3);
            K2 = h * f1(t + h / 2, u1 + K1 / 2, u2 + L1 / 2, u3 + N1 / 2);
            L2 = h * f2(t + h / 2, u1 + K1 / 2, u2 + L1 / 2, u3 + N1 / 2);
            N2 = h * f3(t + h / 2, u1 + K1 / 2, u2 + L1 / 2, u3 + N1 / 2);
            K3 = h * f1(t + h / 2, u1 + K2 / 2, u2 + L2 / 2, u3 + N2 / 2);
            L3 = h * f2(t + h / 2, u1 + K2 / 2, u2 + L2 / 2, u3 + N2 / 2);
            N3 = h * f3(t + h / 2, u1 + K2 / 2, u2 + L2 / 2, u3 + N2 / 2);
            K4 = h * f1(t + h, u1 + K3, u2 + L3, u3 + N3);
            L4 = h * f2(t + h, u1 + K3, u2 + L3, u3 + N3);
            N4 = h * f3(t + h, u1 + K3, u2 + L3, u3 + N3);
            U1 = u1 + (K1 + 2 * K2 + 2 * K3 + K4) / 6;
            U2 = u2 + (L1 + 2 * L2 + 2 * L3 + L4) / 6;
            U3 = u3 + (N1 + 2 * N2 + 2 * N3 + N4) / 6;
           

        }
    }
}
