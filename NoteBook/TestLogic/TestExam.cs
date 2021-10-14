using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Logic;

namespace TestLogic
{
    public class TestExam
    {
        [Fact]
        public void TestContrainte()
        {
            Exam e = new Exam();

            Assert.Throws<Exception>(() => { e.Coef = -1; });
            Assert.Throws<Exception>(() => { e.Note = -1; });
            Assert.Throws<Exception>(() => { e.Note = 21; });
            Assert.Throws<Exception>(() => { e.Module = null; });

            Assert.Equal(DateTime.Now.ToShortDateString(), e.DateExam.ToShortDateString());

            Assert.Equal(1, e.Coef);

            Assert.True(e.IsAbsent);

            Assert.Equal(0, e.Note);
        }
    }
}
