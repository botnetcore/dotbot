﻿using Dotbot.Tests.Fakes;
using Dotbot.Tests.Fixtures;
using Xunit;

namespace Dotbot.Tests.Unit
{
    public sealed class MentionablePartTests
    {
        public sealed class TheHandleMentionMethod
        {
            [Fact]
            public void Should_Handle_Mention_For_Correctly_Formatted_Message()
            {
                // Given
                var sut = new FakeMentionablePart();
                var fixture = new ReplyContextFixture { Text = "@bot hello world!" };
                fixture.Bot.Username = "bot";

                // When
                var result = sut.Handle(fixture.Create());

                // Then
                Assert.True(result);
            }

            [Fact]
            public void Should_Not_Handle_Mention_For_Other_Users()
            {
                // Given
                var sut = new FakeMentionablePart();
                var fixture = new ReplyContextFixture { Text = "@bot hello world!" };
                fixture.Bot.Username = "botty";

                // When
                var result = sut.Handle(fixture.Create());

                // Then
                Assert.False(result);
            }
        }
    }
}
