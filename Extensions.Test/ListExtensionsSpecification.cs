using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Extensions.Test
{
    [TestFixture]
    public class when_requesting_siblings_after_an_index
    {
        [Test]
        public void given_null_list_should_throw_argument_null_exception()
        {
            List<string> items = null;
            var index = 0;
            Action act = () => items.SiblingsAfter(index);
            act.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: list");
        }

        [Test]
        public void given_empty_list_should_throw_argument_exception()
        {
            var items = new List<string>();
            var index = 0;
            Action act = () => items.SiblingsAfter(index);
            act.ShouldThrow<IndexOutOfRangeException>();
        }

        [Test]
        public void given_list_with_less_items_than_current_index_should_throw_argument_null_exception()
        {
            var items = new List<string> {"a", "b", "c"};
            var index = 3;
            Action act = () => items.SiblingsAfter(index);
            act.ShouldThrow<IndexOutOfRangeException>();
        }

        [Test]
        public void given_list_with_items_and_current_index_is_equal_to_last_item_should_return_empty_list()
        {
            var items = new List<string> {"a", "b"};
            var index = 1;
            var remaining = items.SiblingsAfter(index);
            remaining.Should().BeEmpty();
        }

        [Test]
        public void given_list_with_items_should_return_items_after_the_index_given()
        {
            var items = new List<string> {"a", "b", "c", "d", "e"};
            var index = 2;
            var remaining = items.SiblingsAfter(index);
            remaining.Should().HaveCount(2);
            remaining.Should().Contain("d");
            remaining.Should().Contain("e");
        }
    }
}
