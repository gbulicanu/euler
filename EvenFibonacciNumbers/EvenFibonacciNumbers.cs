﻿/*
 * Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2,
 * the first 10 terms will be:
 *      1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
 * By considering the terms in the Fibonacci sequence whose values do not exceed four million,
 * find the sum of the even-valued terms.
 */
namespace EvenFibonacciNumbers
{
  using System;
  using Microsoft.VisualStudio.TestTools.UnitTesting;

  [TestClass]
  public class EvenFibonacciNumbers
  {
    [TestMethod]
    public void FibonacciRecursiveCase1()
    {
      var result = Fibonacci(0);
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void FibonacciRecursiveCase2()
    {
      var result = Fibonacci(6);
      Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void FibonacciIterativeCase1()
    {
      var result = FibonacciIterative(0);
      Assert.AreEqual(0, result);
    }

    [TestMethod]
    public void FibonacciIterativeCase2()
    {
      var result = FibonacciIterative(6);
      Assert.AreEqual(8, result);
    }

    [TestMethod]
    public void FibonacciRecursiveCase3()
    {
      var result = Fibonacci(34L);
      Assert.IsTrue(result > 4000000L);
    }

    [TestMethod]
    public void FibonacciIterativeCase3()
    {
      var result = FibonacciIterative(34L);
      Assert.IsTrue(result > 4000000L);
    }

    [TestMethod]
    public void FibonacciEvenSumCase1Recursive()
    {
      var result = FibonacciEvenSum(4000000L, Fibonacci);
      Console.WriteLine(result);
    }

    [TestMethod]
    public void FibonacciEvenSumCase1Iterative()
    {
      var result = FibonacciEvenSum(4000000L, FibonacciIterative);
      Console.WriteLine(result);
    }

    private long FibonacciEvenSum(long max, Func<long, long> fibonacciFunc)
    {
      long number = 1;
      long sum = 0;

      var fibonacci = fibonacciFunc(0);

      while (sum <= max)
      {
        fibonacci = Fibonacci(number);
        if (fibonacci % 2 == 0)
        {
          sum += fibonacci;
        }
        number++;
      }

      return sum;
    }

    private long Fibonacci(long number)
    {
      if (number == 0 || number == 1)
      {
        return number;
      }
      else
      {
        return Fibonacci(number - 2) + Fibonacci(number - 1);
      }
    }

    private long FibonacciIterative(long number)
    {
      long a = 0;
      long b = 1;
      for (int i = 0; i < number; i++)
      {
        long temp = a;
        a = b;
        b = temp + b;
      }
      return a;
    }
  }
}
