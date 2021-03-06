﻿using System;
using FluentAssertions;
using Light.GuardClauses.Exceptions;
using Light.GuardClauses.Tests.CustomMessagesAndExceptions;
using Xunit;

namespace Light.GuardClauses.Tests.StringAssertionsTests
{
    public sealed class MustEndWithTests : ICustomMessageAndExceptionTestDataProvider
    {
        [Theory(DisplayName = "MustEndWith for strings must throw a StringException when the string does not end with the specified text (case-sensitivity respected).")]
        [InlineData("Wello", "Horld!")]
        [InlineData("This should end", "End")]
        [InlineData("A mind needs books as a sword needs a whetstone, if it is to keep its edge.", "keep its ledge.")]
        public void StringEndsDiffer(string @string, string endText)
        {
            Action act = () => @string.MustEndWith(endText, nameof(@string));

            act.ShouldThrow<StringException>()
               .And.Message.Should().Contain($"{nameof(@string)} must end with \"{endText}\", but you specified {@string}.");
        }

        [Theory(DisplayName = "MustEndWith for strings must not throw an exception when the string ends with the specified text (case-sensitivity respected).")]
        [InlineData("This is the end", "is the end")]
        [InlineData("Hello", "lo")]
        [InlineData("Can a man still be brave if he's afraid?", "he's afraid?")]
        public void StringEndsEqual(string @string, string endText)
        {
            var result = @string.MustEndWith(endText);

            result.Should().BeSameAs(@string);
        }

        [Theory(DisplayName = "MustEndWith for strings must throw an ArgumentNullException when either paramter or text is null.")]
        [InlineData(null, "Foo")]
        [InlineData("Foo", null)]
        public void StringArgumentNull(string @string, string endText)
        {
            Action act = () => @string.MustEndWith(endText);

            act.ShouldThrow<ArgumentNullException>();
        }

        void ICustomMessageAndExceptionTestDataProvider.PopulateTestDataForCustomExceptionAndCustomMessageTests(CustomMessageAndExceptionTestData testData)
        {
            testData.Add(new CustomExceptionTest(exception => "That is the only time a man can be brave".MustEndWith("afraid", exception: exception)))
                    .Add(new CustomMessageTest<StringException>(message => "Foo".MustEndWith("Bar", message: message)));
        }
    }
}