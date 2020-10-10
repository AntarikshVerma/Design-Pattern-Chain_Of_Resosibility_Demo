using System;

namespace ChainOfResponsibility
{
    interface IChain
    {
        void Next(IChain nextChain);
        void Calculate(Number request);
    }

    class AddNumber : IChain
    {
        private IChain _nextChain;
        public void Calculate(Number request)
        {
            if (request.Action == "add")
            {
                Console.WriteLine($"Add{ request.Number1 + request.Number2}");
            }
            else
            {
                _nextChain.Calculate(request);
            }
        }

        public void Next(IChain nextChain)
        {
            _nextChain = nextChain;
        }
    }

    class SubNumber : IChain
    {
        private IChain _nextChain;
        public void Calculate(Number request)
        {
            if (request.Action == "sub")
            {
                Console.WriteLine($"subs{ request.Number1 - request.Number2}");
            }
            else
            {
                _nextChain.Calculate(request);
            }
        }

        public void Next(IChain nextChain)
        {
            _nextChain = nextChain;
        }
    }

    class MulNumber : IChain
    {
        private IChain _nextChain;
        public void Calculate(Number request)
        {
            if (request.Action == "mul")
            {
                Console.WriteLine($"mul -{ request.Number1 * request.Number2}");
            }
            else
            {
                _nextChain.Calculate(request);
            }
        }

        public void Next(IChain nextChain)
        {
            _nextChain = nextChain;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Number num = new Number()
            {
                Number1 = 8,
                Number2 = 7,
                Action = "mul"
            };
            IChain chain1 = new AddNumber();
            IChain chain2 = new SubNumber();
            IChain chain3 = new MulNumber();
            chain1.Next(chain2);
            chain2.Next(chain3);

            chain1.Calculate(num);
        }
    }


        class Number
        {
            public int Number1 { get; set; }
            public int Number2 { get; set; }
            public string Action { get; set; }

        }
    }
