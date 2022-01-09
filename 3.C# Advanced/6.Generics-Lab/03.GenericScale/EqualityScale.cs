using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        private readonly T Left;
        private readonly T Right;
        public EqualityScale(T left, T right)
        {
            this.Left = left;
            this.Right = right;
        }

        public bool AreEqual()
        {
            if (true)
            {
                return Left.Equals(Right);
            }
        }
    }
}
