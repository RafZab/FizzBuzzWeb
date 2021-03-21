using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FizzBuzz.Scripts
{
    public class FizzbuzzApp
    {
        [Range(1, 1000)]
        public int Number { get; set; }

        public string Result { get; set; }

        public DateTime Date { get; set; }

        public void CheckDisivibility()
        {
            var sb = new System.Text.StringBuilder();
            bool isDisivibility = false;

            if (CheckDisivibility(Number, 3))
            {
                sb.Append("Fizz");
                isDisivibility = true;
            }
            if (CheckDisivibility(Number, 5))
            {
                sb.Append("Buzz");
                isDisivibility = true;
            }
            if (!isDisivibility)
            {
                sb.Append(Number);
            }

            Date = DateTime.Now;
            Result = sb.ToString();
        }

        private bool CheckDisivibility(int number, int by)
        {
            if (number % by == 0)
                return true;
            return false;
        }

    }
}
