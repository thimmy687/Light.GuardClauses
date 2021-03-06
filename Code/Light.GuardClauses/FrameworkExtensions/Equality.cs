﻿using System;
using System.Collections.Generic;

namespace Light.GuardClauses.FrameworkExtensions
{
    /// <summary>
    ///     The Equality class contains static methods that help create hash codes and check the equality of values with calls to GetHashCode and Equals.
    /// </summary>
    public static class Equality
    {
        /// <summary>
        ///     This prime number is used as an initial hash code value when calculating hash codes. Its value is 1322837333.
        /// </summary>
        public const int FirstPrime = 1322837333;

        /// <summary>
        ///     The second prime number (397) used for hash code generation. It is applied using the following calculation:
        ///     <c>hash = hash * SecondPrime + value.GetHashCode();</c> when the corresponding value is not null.
        ///     It is the same value that ReSharper (2017.2.1) uses for hash code generation.
        /// </summary>
        public const int SecondPrime = 397;

        /// <summary>
        ///     Creates a hash code from the two specified values. It is implemented according to the guidelines of this Stack Overflow answer: http://stackoverflow.com/a/263416/1560623.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="value1" />.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="value2" />.</typeparam>
        /// <param name="value1">The first value to compute the hash code from.</param>
        /// <param name="value2">The second value to compute the hash code from.</param>
        /// <returns>The computed hash code.</returns>
        public static int CreateHashCode<T1, T2>(T1 value1, T2 value2)
        {
            unchecked
            {
                var hash = FirstPrime;
                if (value1 != null) hash = hash * SecondPrime + value1.GetHashCode();
                if (value2 != null) hash = hash * SecondPrime + value2.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        ///     Creates a hash code from the three specified values. It is implemented according to the guidelines of this Stack Overflow answer: http://stackoverflow.com/a/263416/1560623.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="value1" />.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="value2" />.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="value3" />.</typeparam>
        /// <param name="value1">The first value to compute the hash code from.</param>
        /// <param name="value2">The second value to compute the hash code from.</param>
        /// <param name="value3">The third value to compute the hash code from.</param>
        /// <returns>The computed hash code.</returns>
        public static int CreateHashCode<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
        {
            unchecked
            {
                var hash = FirstPrime;
                if (value1 != null) hash = hash * SecondPrime + value1.GetHashCode();
                if (value2 != null) hash = hash * SecondPrime + value2.GetHashCode();
                if (value3 != null) hash = hash * SecondPrime + value3.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        ///     Creates a hash code from the four specified values. It is implemented according to the guidelines of this Stack Overflow answer: http://stackoverflow.com/a/263416/1560623.
        /// </summary>
        /// <typeparam name="T1">The type of <paramref name="value1" />.</typeparam>
        /// <typeparam name="T2">The type of <paramref name="value2" />.</typeparam>
        /// <typeparam name="T3">The type of <paramref name="value3" />.</typeparam>
        /// <typeparam name="T4">The type of <paramref name="value4" />.</typeparam>
        /// <param name="value1">The first value to compute the hash code from.</param>
        /// <param name="value2">The second value to compute the hash code from.</param>
        /// <param name="value3">The third value to compute the hash code from.</param>
        /// <param name="value4">The forth value to compute the hash code from.</param>
        /// <returns>The computed hash code.</returns>
        public static int CreateHashCode<T1, T2, T3, T4>(T1 value1, T2 value2, T3 value3, T4 value4)
        {
            unchecked
            {
                var hash = FirstPrime;
                if (value1 != null) hash = hash * SecondPrime + value1.GetHashCode();
                if (value2 != null) hash = hash * SecondPrime + value2.GetHashCode();
                if (value3 != null) hash = hash * SecondPrime + value3.GetHashCode();
                if (value4 != null) hash = hash * SecondPrime + value4.GetHashCode();
                return hash;
            }
        }

        /// <summary>
        ///     Creates a hash code from the specified values. It is implemented according to the guidelines of this Stack Overflow answer: http://stackoverflow.com/a/263416/1560623.
        /// </summary>
        /// <typeparam name="T">The type of values used to create the hash code.</typeparam>
        /// <param name="values">The values used to create the hash code.</param>
        /// <returns>The computed hash code.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values" /> is null.</exception>
        public static int CreateHashCode<T>(params T[] values)
        {
            unchecked
            {
                var hash = FirstPrime;
                for (var i = 0; i < values.Length; ++i)
                {
                    var currentValue = values[i];
                    if (currentValue != null)
                        hash = hash * SecondPrime + currentValue.GetHashCode();
                }
                return hash;
            }
        }

        /// <summary>
        ///     Creates a hash code from the specified values. It is implemented according to the guidelines of this Stack Overflow answer: http://stackoverflow.com/a/263416/1560623.
        /// </summary>
        /// <typeparam name="T">The type of values used to create the hash code.</typeparam>
        /// <param name="values">The values used to create the hash code.</param>
        /// <returns>The computed hash code.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values" /> is null.</exception>
        public static int CreateHashCode<T>(IEnumerable<T> values)
        {
            unchecked
            {
                var hash = FirstPrime;
                if (values is IReadOnlyList<T> list)
                {
                    for (var i = 0; i < list.Count; ++i)
                    {
                        var currentValue = list[i];
                        if (currentValue != null)
                            hash = hash * SecondPrime + currentValue.GetHashCode();
                    }
                    return hash;
                }

                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (var @object in values)
                {
                    if (@object != null)
                        hash = hash * SecondPrime + @object.GetHashCode();
                }
                return hash;
            }
        }

        /// <summary>
        ///     Checks that the specified values are equal. Uses the specified equality comparer calling GetHashCode and Equals.
        /// </summary>
        /// <typeparam name="T">The type of the values to be compared.</typeparam>
        /// <param name="equalityComparer">The equality comparer used for comparison.</param>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <returns>True if both values are considered equal, else false.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="equalityComparer" /> is null.</exception>
        public static bool EqualsWithHashCode<T>(this IEqualityComparer<T> equalityComparer, T first, T second)
        {
            equalityComparer.MustNotBeNull(nameof(equalityComparer));

            return equalityComparer.GetHashCode(first) == equalityComparer.GetHashCode(second) &&
                   equalityComparer.Equals(first, second);
        }

        /// <summary>
        ///     Checks if the specified object is equal to the other object. Performs null reference checking and afterwards calls
        ///     GetHashCode and Equals to determine equality. If you are dealing with value types, please use <see cref="EqualsValueWithHashCode{T}" />
        ///     instead as no null checks are performed in that method.
        /// </summary>
        /// <typeparam name="T">The reference type of the items to be compared.</typeparam>
        /// <param name="value">The first value to be compared.</param>
        /// <param name="other">The second value to be compared.</param>
        /// <returns>True if both hash codes are equal and Equals returns true, else false.</returns>
        public static bool EqualsWithHashCode<T>(this T value, T other) where T : IEquatable<T>
        {
            if (value == null) return other == null;
            if (other == null) return false;

            return value.GetHashCode() == other.GetHashCode() && value.Equals(other);
        }

        /// <summary>
        ///     Checks if the specified value is equal to the other value. Calls GetHashCode and Equals to determine equality.
        /// </summary>
        /// <typeparam name="T">The value type of the items to be compared.</typeparam>
        /// <param name="value">The first value to be compared.</param>
        /// <param name="other">The second value to be compared.</param>
        /// <returns>True if both hash codes are equal and Equals returns true, else false.</returns>
        public static bool EqualsValueWithHashCode<T>(this T value, T other) where T : struct, IEquatable<T>
        {
            return value.GetHashCode() == other.GetHashCode() && value.Equals(other);
        }
    }
}