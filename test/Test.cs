using System;
using Xunit;

using Dante.Models;

namespace Dante.Tests
{
    public class Test
    {
        [Fact]
        public void CanShowDanteDT()
        {
            DateTime[] dates = {
                                new DateTime(2018, 10, 24, 3, 57, 32),
                                new DateTime(2018, 10, 17, 15, 57, 32),
                                new DateTime(2018, 9, 14, 4, 0, 0),
                                new DateTime(1992, 10, 17, 15, 57, 32)
                            };

            Assert.Equal("Today at 3:57 AM", dates[0].ToDanteDT());            
            Assert.Equal("Wednesday at 3:57 PM", dates[1].ToDanteDT());
            Assert.Equal("14 September at 4:00 AM", dates[2].ToDanteDT());
            Assert.Equal("17 October 1992 at 3:57 PM", dates[3].ToDanteDT());
        }
    }
}
