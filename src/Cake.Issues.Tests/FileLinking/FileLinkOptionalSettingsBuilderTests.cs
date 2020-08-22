﻿namespace Cake.Issues.Tests.FileLinking
{
    using System;
    using System.Collections.Generic;
    using Cake.Issues.FileLinking;
    using Cake.Issues.Testing;
    using Shouldly;
    using Xunit;

    public sealed class FileLinkOptionalSettingsBuilderTests
    {
        public sealed class TheCtor
        {
            [Fact]
            public void Should_Throw_If_Builder_Is_Null()
            {
                // Given
                Func<IIssue, IDictionary<string, string>, Uri> builder = null;

                // When
                var result = Record.Exception(() => new FileLinkOptionalSettingsBuilder(builder));

                // Then
                result.IsArgumentNullException("builder");
            }
        }

        public sealed class TheWithRootPathMethod
        {
            [Fact]
            public void Should_Not_Throw_If_RootPath_Is_Null()
            {
                // Given
                string rootPath = null;

                // When
                var result =
                    new AzureDevOpsFileLinkSettingsBuilder(new Uri("https://github.com"))
                        .Branch("master")
                        .WithRootPath(rootPath);

                // Then
                result.ShouldNotBeNull();
            }

            [Fact]
            public void Should_Throw_If_RootPath_Is_Empty()
            {
                // Given
                var rootPath = string.Empty;

                // When
                var result =
                    Record.Exception(() =>
                        new AzureDevOpsFileLinkSettingsBuilder(new Uri("https://github.com"))
                            .Branch("master")
                            .WithRootPath(rootPath));

                // Then
                result.IsArgumentOutOfRangeException("rootPath");
            }

            [Fact]
            public void Should_Throw_If_RootPath_Is_WhiteSpace()
            {
                // Given
                var rootPath = " ";

                // When
                var result =
                    Record.Exception(() =>
                        new AzureDevOpsFileLinkSettingsBuilder(new Uri("https://github.com"))
                            .Branch("master")
                            .WithRootPath(rootPath));

                // Then
                result.IsArgumentOutOfRangeException("rootPath");
            }

            [Theory]
            [InlineData("foo\tbar")]
            public void Should_Throw_If_RootPath_Is_Invalid(string rootPath)
            {
                // Given

                // When
                var result =
                    Record.Exception(() =>
                        new AzureDevOpsFileLinkSettingsBuilder(new Uri("https://github.com"))
                            .Branch("master")
                            .WithRootPath(rootPath));

                // Then
                result.IsArgumentException("rootPath");
            }
        }
    }
}