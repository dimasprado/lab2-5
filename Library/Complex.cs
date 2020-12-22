using System;

namespace Library
{
    public class Complex
    {
        public Complex(decimal real, decimal im)
        {
            Real = real;
            Im = im;
        }
        /// <summary>
        /// Действительная часть
        /// </summary>
        public decimal Real { get; private set; }
        /// <summary>
        /// Мнимая часть
        /// </summary>
        public decimal Im { get; private set; }
        /// <summary>
        /// Модуль комлексного числа 
        /// </summary>
        public decimal Modul { 
            get {
                return (decimal)Math.Sqrt((double)(Im * Im + Real * Real));
            } 
        }
        /// <summary>
        /// Агрумент комплексного числа
        /// </summary>
        public decimal Angle
        {
            get
            {
                return (decimal)Math.Atan2((double)Im, (double)Real);
            }
        }
        /// <summary>
        /// Комплексное число в экспоненциальной форме
        /// </summary>
        /// <returns>Комплексное число в экспоненциальной форме</returns>
        public string GetExp()
        {
            return $"{Modul}*e^({Angle}i)";
        }
        #region Операции с комплексными числами
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Im + b.Im);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Im - b.Im);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Real * b.Real - a.Im * b.Im, a.Im * b.Real + b.Im * a.Real);
        }
        #endregion
        #region Операции комлексными и действительными числами
        public static Complex operator +(Complex a, decimal b)
        {
            return new Complex(a.Real + b, a.Im);
        }
        public static Complex operator -(Complex a, decimal b)
        {
            return new Complex(a.Real - b, a.Im);
        }
        public static Complex operator *(Complex a, decimal b)
        {
            return new Complex(a.Real * b, a.Im * b);
        }
        #endregion
        /// <summary>
        /// Перегруженный метод ToString для красивого вывода числа
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string tmp = "";
            if(Real != 0)
            {
                tmp += Real.ToString();
            }
            if (Im < 0)
            {
                tmp += "-";
            }
            if(Im > 0 && Real != 0)
            {
                tmp += "+";
            }
            if (Im != 0)
            {
                tmp += Math.Abs(Im).ToString() + "i";
            }
            if(tmp == "")
            {
                tmp = "0";
            }
            return tmp;
        }
    }
}
