using Lime.Domain;
using MessageAPI.Controllers;
using System;
using Xunit;

namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void GetAll()
        {


        }

        //GOES THROUGH
        [Theory]
        [InlineData(90)]
        [InlineData(122)]
        [InlineData(208)]
        public void GetById(int expected)
        {
            MailMessageRepository msg = new MailMessageRepository();
            MailMessage actual = msg.GetById(expected); 
            Assert.Equal(expected, actual.Id);

        }

        //GOES THROUGH
        [Fact]
        public void Delete()
        {
            MailMessageRepository msg = new MailMessageRepository();
            int idToBeRemoved = 90;
            bool expected = true;
            Assert.Equal(expected, msg.Delete(idToBeRemoved));

            MailMessage expectedDoubleCheck = null;
            Assert.Equal(expectedDoubleCheck, msg.GetById(idToBeRemoved));
        }

        [Fact]
        public void Find()
        {

        }
    }
}
