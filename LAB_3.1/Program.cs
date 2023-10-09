namespace LAB_3._1
{
    class Parent
    {
        protected double pole1;
        protected double pole2;

        public Parent(double pole1, double pole2)
        {
            this.pole1 = pole1;
            this.pole2 = pole2;
        }

        public virtual void Print()
        {
            Console.WriteLine($"Вартiсть за 1 кв. м: {pole1}");
            Console.WriteLine($"Площа квартири: {pole2}");
        }

        public virtual double Metod()
        {
            return pole1 * pole2;
        }
    }

    class Child1 : Parent
    {
        private int pole3;
        private int pole4;

        public Child1(double pole1, double pole2, int pole3, int pole4) : base(pole1, pole2)
        {
            this.pole3 = pole3;
            this.pole4 = pole4;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Поверх: {pole3}");
            Console.WriteLine($"Кiлькiсть поверхiв в будинку: {pole4}");
        }

        public override double Metod()
        {
            double baseCost = base.Metod();

            baseCost *= 1.01;

            if (pole3 == 1 || pole3 == pole4)
            {
                baseCost -= 1000;
            }

            return baseCost;
        }
    }

    class Child2 : Parent
    {
        private double pole5;

        public Child2(double pole1, double pole2, double pole5) : base(pole1, pole2)
        {
            this.pole5 = pole5;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Вiдстань до центру в км: {pole5}");
        }

        public override double Metod()
        {
            double baseCost = base.Metod();

            if (pole5 < 10)
            {
                baseCost *= 1.03;
            }
            else
            {
                baseCost -= 0.001 * pole5;
            }

            return baseCost;
        }
    }

    class Program
    {
        static void Main()
        {
            Parent parentFlat = new Parent(1200, 80);
            Child1 centerFlat = new Child1(1700, 95, 4, 12);
            Child2 suburbFlat = new Child2(900, 110, 15);

            Console.WriteLine("Батькiвська квартира:");
            parentFlat.Print();
            Console.WriteLine($"Вартiсть квартири: {parentFlat.Metod()}");

            Console.WriteLine("\nКвартира в центрi:");
            centerFlat.Print();
            Console.WriteLine($"Вартiсть квартири: {centerFlat.Metod()}");

            Console.WriteLine("\nКвартира в передмiстi:");
            suburbFlat.Print();
            Console.WriteLine($"Вартiсть квартири: {suburbFlat.Metod()}");
        }
    }
}