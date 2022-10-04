using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Services;
using DataAccess.Entities;
using DataAccess;
using CustomExceptions;
namespace Testing
{
    public class AuthServiceTesting
    {
        /*
         *      Login Testing
         */
        [Fact]
        public void LoginFailsWithInvalidUsername()
        {

        }

        [Fact]
        public void LoginFailsWithInvalidPassword()
        {

        }

        [Fact]
        public void LoginSucceeds()
        {

        }

        /*
         *      Register Testing
         */
        [Fact]
        public void RegisterFailsWithDuplicateUsername()
        {

        }

        [Fact]
        public void RegisterFailsWithMissingPassword()
        {

        }
        [Fact]
        public void RegisterFailsWithMissingFirstName()
        {

        }
        [Fact]
        public void RegisterFailsWithMissingLastName()
        {

        }
        [Fact]
        public void RegisterFailsWithMissingUsername()
        {

        }
        /*
         *      Update Information Testing
         */


    }
}
