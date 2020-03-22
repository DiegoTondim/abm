using ABM.Application;
using ABM.Application.Contracts;
using FluentAssertions;
using Xunit;

namespace ABM.Aplication.Tests
{
    public class DeclarationValidatorTests
    {
        [Fact]
        public void ShouldReturnCodeMinusOne()
        {
            var message = new InputContract
            {
                DeclarationList = new DeclarationContract[] {
                    new DeclarationContract{
                        Command = "TEST"
                    }
            }
            };

            var validator = new DeclarationValidator();
            var response = validator.Validate(message);

            response.Should().Be(-1);
        }

        [Fact]
        public void ShouldReturnCodeMinusTwo()
        {
            var message = new InputContract
            {
                DeclarationList = new DeclarationContract[] {
                    new DeclarationContract{
                        Command = "DEFAULT",
                        DeclarationHeader  = new DeclarationHeader{
                            SiteID = "SPA"
                        }
                    }
            }
            };

            var validator = new DeclarationValidator();
            var response = validator.Validate(message);

            response.Should().Be(-2);
        }

        [Fact]
        public void ShouldReturnCodeZero()
        {
            var message = new InputContract
            {
                DeclarationList = new DeclarationContract[] {
                    new DeclarationContract{
                        Command = "DEFAULT",
                        DeclarationHeader  = new DeclarationHeader{
                            SiteID = "DUB"
                        }
                    }
            }
            };

            var validator = new DeclarationValidator();
            var response = validator.Validate(message);

            response.Should().Be(0);
        }
    }
}
