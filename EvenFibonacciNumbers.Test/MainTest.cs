﻿/*
 * Even Fibonacci numbers - http://projecteuler.net/problem=2
 * 
 * Each new term in the Fibonacci sequence is generated by adding the previous two terms. By starting with 1 and 2,
 * the first 10 terms will be:
 *      1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
 * By considering the terms in the Fibonacci sequence whose values do not exceed four million,
 * find the sum of the even-valued terms.
 */
namespace EvenFibonacciNumbers.Test
{
  using Microsoft.VisualStudio.TestTools.UnitTesting;
  using System;

  [TestClass]
  public class MainTest
  {
    [TestMethod]
    public void FibonacciRecursiveGivenNumberEquals0ThenReturn0()
    {
      var actual = FibonacciRecursive(0);
      Assert.AreEqual(0, actual);
    }

    [TestMethod]
    public void FibonacciRecursiveGivenNumberEquals6ThenReturn8()
    {
      var actual = FibonacciRecursive(6);
      Assert.AreEqual(8, actual);
    }

    [TestMethod]
    public void FibonacciIterativeGivenNumberEquals0ThenReturn0()
    {
      var actual = FibonacciIterative(0);
      Assert.AreEqual(0, actual);
    }

    [TestMethod]
    public void FibonacciIterativeGivenNumberEquals6ThenReturn8()
    {
      var actual = FibonacciIterative(6);
      Assert.AreEqual(8, actual);
    }

    [TestMethod]
    public void FibonacciRecursiveGivenNumberEquals34ThenResultGreaterThan4Millions()
    {
      var actual = FibonacciRecursive(34L);
      Assert.IsTrue(actual > 4000000L);
    }

    [TestMethod]
    public void FibonacciIterativeGivenNumberEquals34ThenReturnIsGreaterThan4Millions()
    {
      var result = FibonacciIterative(34L);
      Assert.IsTrue(result > 4000000L);
    }

    [TestMethod]
    public void FibonacciEvenSumGivenMaxEquals4MillionAndFibonacciFuncEqualsFibonacciRecursiveThenOutput()
    {
      var actual = FibonacciEvenSum(4000000L, FibonacciRecursive);
      Console.WriteLine(actual);
    }

    [TestMethod]
    public void FibonacciEvenSumGivenMaxEquals4MillionAndFibonacciFuncEqualsFibonacciIterativeThenOutput()
    {
      var actual = FibonacciEvenSum(4000000L, FibonacciIterative);
      Console.WriteLine(actual);
    }

    private long FibonacciEvenSum(long max, Func<long, long> fibonacciFunc)
    {
      long number = 1;
      long sum = 0;

      var fibonacci = fibonacciFunc(0);

      while (sum <= max)
      {
        fibonacci = FibonacciRecursive(number);
        if (fibonacci % 2 == 0)
        {
          sum += fibonacci;
        }
        number++;
      }

      return sum;
    }

    private long FibonacciRecursive(long number)
    {
      if (number == 0 || number == 1)
      {
        return number;
      }
      else
      {
        return FibonacciRecursive(number - 2) + FibonacciRecursive(number - 1);
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
