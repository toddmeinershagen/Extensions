using System;
using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Test
{
    [TestFixture]
    public class ArrayOfStringExtensionsSpecification
    {
        private string _separator = ",";
        private string _testValue1 = "testValue1";
        private string _testValue2 = "testValue2";
        private string _testValue3 = "testValue3";
        private string _testValue4 = "testValue4";
        private string _testValue5 = "testValue5";
        private string[] _values;

        [SetUp]
        public void SetUp()
        {
            _values = new[] { _testValue1, _testValue2, _testValue3, _testValue4, _testValue5 };
        }

        [Test]
        public void given_start_and_end_index_should_return_concatenation_of_elements_that_fall_within_the_range()
        {       
            _values.Concat(1, 2).Should().Be(string.Concat(_testValue2, _testValue3));
        }

        [Test]
        public void given_start_and_end_index_and_separator_should_return_concatenation_of_elements_that_fall_within_the_range_with_separators()
        {
            _values.Concat(2, 3, _separator).Should().Be(string.Concat(_testValue3, _separator, _testValue4));
        }

        [Test]
        public void given_start_index_should_return_concatenation_of_elements_between_start_index_and_end_of_array()
        {
            _values.Concat(2).Should().Be(string.Concat(_testValue3, _testValue4, _testValue5));
        }

        [Test]
        public void given_start_index_and_separator_should_return_concatenation_of_elements_between_start_index_and_end_of_array_with_separators()
        {
            _values.Concat(3, _separator).Should().Be(string.Concat(_testValue4, _separator, _testValue5));
        }

        [Test]
        public void given_no_parameters_should_return_concatenation_of_all_elements_in_array()
        {
            _values.Concat().Should().Be(string.Concat(_testValue1, _testValue2, _testValue3, _testValue4, _testValue5));
        }

        [Test]
        public void given_separator_should_return_concatenation_of_all_elements_in_array_with_separators()
        {
            _values.Concat(_separator).Should().Be(string.Concat(_testValue1, _separator, _testValue2, _separator, _testValue3, _separator, _testValue4, _separator, _testValue5));
        }

        [Test]
        public void given_start_index_less_than_existing_indexes_should_throw_index_out_of_range_exception()
        {
            Action action = () => _values.Concat(-1);
            action.ShouldThrow<IndexOutOfRangeException>().WithMessage("'startIndex' was out of the range of acceptable values for this list.");
        }

        [Test]
        public void given_end_index_greater_than_existing_indexes_should_throw_index_out_of_range_exception()
        {
            Action action = () => _values.Concat(1, 6);
            action.ShouldThrow<IndexOutOfRangeException>().WithMessage("'endIndex' was out of the range of acceptable values for this list.");
        }

        [Test]
        public void given_start_index_greater_than_end_index_should_throw_index_out_of_range_exception()
        {
            Action action = () => _values.Concat(4, 1);
            action.ShouldThrow<IndexOutOfRangeException>().WithMessage("'startIndex' cannot be greater than 'endIndex'.");
        }
    }
}
