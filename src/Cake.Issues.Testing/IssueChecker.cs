﻿namespace Cake.Issues.Testing
{
    using System;
    using Cake.Core.IO;

    /// <summary>
    /// Class for checking issues.
    /// </summary>
    public static class IssueChecker
    {
        /// <summary>
        /// Checks values of an issue.
        /// </summary>
        /// <param name="issueToCheck">Issue which should be checked.</param>
        /// <param name="expectedIssue">Description of the expected issue.</param>
        public static void Check(
            IIssue issueToCheck,
            IssueBuilder expectedIssue)
        {
            issueToCheck.NotNull(nameof(issueToCheck));
            expectedIssue.NotNull(nameof(expectedIssue));

            Check(
                issueToCheck,
                expectedIssue.Create());
        }

        /// <summary>
        /// Checks values of an issue.
        /// </summary>
        /// <param name="issueToCheck">Issue which should be checked.</param>
        /// <param name="expectedIssue">Description of the expected issue.</param>
        public static void Check(
            IIssue issueToCheck,
            IIssue expectedIssue)
        {
            issueToCheck.NotNull(nameof(issueToCheck));
            expectedIssue.NotNull(nameof(expectedIssue));

            Check(
                issueToCheck,
                expectedIssue.ProviderType,
                expectedIssue.ProviderName,
                expectedIssue.Run,
                expectedIssue.Identifier,
                expectedIssue.ProjectFileRelativePath?.ToString(),
                expectedIssue.ProjectName,
                expectedIssue.AffectedFileRelativePath?.ToString(),
                expectedIssue.Line,
                expectedIssue.EndLine,
                expectedIssue.Column,
                expectedIssue.EndColumn,
                expectedIssue.FileLink,
                expectedIssue.MessageText,
                expectedIssue.MessageHtml,
                expectedIssue.MessageMarkdown,
                expectedIssue.Priority,
                expectedIssue.PriorityName,
                expectedIssue.Rule,
                expectedIssue.RuleUrl);
        }

        /// <summary>
        /// Checks values of an issue.
        /// </summary>
        /// <param name="issue">Issue which should be checked.</param>
        /// <param name="providerType">Expected type of the issue provider.</param>
        /// <param name="providerName">Expected human friendly name of the issue provider.</param>
        /// <param name="run">Expected name of the run which reported the issue.</param>
        /// <param name="identifier">Expected identifier of the issue.</param>
        /// <param name="projectFileRelativePath">Expected relative path of the project file.
        /// <c>null</c> if the issue is not expected to be related to a project.</param>
        /// <param name="projectName">Expected project name.
        /// <c>null</c> or <see cref="string.Empty"/> if the issue is not expected to be related to a project.</param>
        /// <param name="affectedFileRelativePath">Expected relative path of the affected file.
        /// <c>null</c> if the issue is not expected to be related to a change in a file.</param>
        /// <param name="line">Expected line number.
        /// <c>null</c> if the issue is not expected to be related to a file or specific line.</param>
        /// <param name="endLine">Expected end of line range.
        /// <c>null</c> if the issue is not expected to be related to a file, specific line or range of lines.</param>
        /// <param name="column">Expected column.
        /// <c>null</c> if the issue is not expected to be related to a file or specific column.</param>
        /// <param name="endColumn">Expected end of column range.
        /// <c>null</c> if the issue is not expected to be related to a file, specific column or range of columns.</param>
        /// <param name="fileLink">Expected file link.
        /// <c>null</c> if the issue is not expected to have a file link.</param>
        /// <param name="messageText">Expected message in plain text format.</param>
        /// <param name="messageHtml">Expected message in HTML format.</param>
        /// <param name="messageMarkdown">Expected message in Markdown format.</param>
        /// <param name="priority">Expected priority.
        /// <c>null</c> if no priority is expected.</param>
        /// <param name="priorityName">Expected priority name.
        /// <c>null</c> or <see cref="string.Empty"/> if no priority is expected.</param>
        /// <param name="rule">Expected rule identifier.
        /// <c>null</c> or <see cref="string.Empty"/> if no rule identifier is expected.</param>
        /// <param name="ruleUrl">Expected URL containing information about the failing rule.
        /// <c>null</c> if no rule Url is expected.</param>
        public static void Check(
            IIssue issue,
            string providerType,
            string providerName,
            string run,
            string identifier,
            string projectFileRelativePath,
            string projectName,
            string affectedFileRelativePath,
            int? line,
            int? endLine,
            int? column,
            int? endColumn,
            Uri fileLink,
            string messageText,
            string messageHtml,
            string messageMarkdown,
            int? priority,
            string priorityName,
            string rule,
            Uri ruleUrl)
        {
            issue.NotNull(nameof(issue));

            if (issue.ProviderType != providerType)
            {
                throw new Exception(
                    $"Expected issue.ProviderType to be '{providerType}' but was '{issue.ProviderType}'.");
            }

            if (issue.ProviderName != providerName)
            {
                throw new Exception(
                    $"Expected issue.ProviderName to be '{providerName}' but was '{issue.ProviderName}'.");
            }

            if (issue.Run != run)
            {
                throw new Exception(
                    $"Expected issue.Run to be '{run}' but was '{issue.Run}'.");
            }

            if (issue.Identifier != identifier)
            {
                throw new Exception(
                    $"Expected issue.Identifier to be '{identifier}' but was '{issue.Identifier}'.");
            }

            if (issue.ProjectFileRelativePath == null)
            {
                if (projectFileRelativePath != null)
                {
                    throw new Exception(
                        $"Expected issue.ProjectFileRelativePath to be '{projectFileRelativePath}' but was 'null'.");
                }
            }
            else
            {
                if (issue.ProjectFileRelativePath.ToString() != new FilePath(projectFileRelativePath).ToString())
                {
                    throw new Exception(
                        $"Expected issue.ProjectFileRelativePath to be '{projectFileRelativePath}' but was '{issue.ProjectFileRelativePath}'.");
                }

                if (!issue.ProjectFileRelativePath.IsRelative)
                {
                    throw new Exception(
                        $"Expected issue.ProjectFileRelativePath to be a relative path");
                }
            }

            if (issue.ProjectName != projectName)
            {
                throw new Exception(
                    $"Expected issue.ProjectName to be '{projectName}' but was '{issue.ProjectName}'.");
            }

            if (issue.AffectedFileRelativePath == null)
            {
                if (affectedFileRelativePath != null)
                {
                    throw new Exception(
                        $"Expected issue.AffectedFileRelativePath to be '{affectedFileRelativePath}' but was 'null'.");
                }
            }
            else
            {
                if (issue.AffectedFileRelativePath.ToString() != new FilePath(affectedFileRelativePath).ToString())
                {
                    throw new Exception(
                        $"Expected issue.AffectedFileRelativePath to be '{affectedFileRelativePath}' but was '{issue.AffectedFileRelativePath}'.");
                }

                if (!issue.AffectedFileRelativePath.IsRelative)
                {
                    throw new Exception(
                        $"Expected issue.AffectedFileRelativePath to be a relative path");
                }
            }

            if (issue.Line != line)
            {
                throw new Exception(
                    $"Expected issue.Line to be '{line}' but was '{issue.Line}'.");
            }

            if (issue.EndLine != endLine)
            {
                throw new Exception(
                    $"Expected issue.EndLine to be '{endLine}' but was '{issue.EndLine}'.");
            }

            if (issue.Column != column)
            {
                throw new Exception(
                    $"Expected issue.Column to be '{column}' but was '{issue.Column}'.");
            }

            if (issue.EndColumn != endColumn)
            {
                throw new Exception(
                    $"Expected issue.EndColumn to be '{endColumn}' but was '{issue.EndColumn}'.");
            }

            if (issue.FileLink?.ToString() != fileLink?.ToString())
            {
                throw new Exception(
                    $"Expected issue.FileLink to be '{fileLink}' but was '{issue.FileLink}'.");
            }

            if (issue.MessageText != messageText)
            {
                throw new Exception(
                    $"Expected issue.MessageText to be '{messageText}' but was '{issue.MessageText}'.");
            }

            if (issue.MessageHtml != messageHtml)
            {
                throw new Exception(
                    $"Expected issue.MessageHtml to be '{messageHtml}' but was '{issue.MessageHtml}'.");
            }

            if (issue.MessageMarkdown != messageMarkdown)
            {
                throw new Exception(
                    $"Expected issue.MessageMarkdown to be '{messageMarkdown}' but was '{issue.MessageMarkdown}'.");
            }

            if (issue.Priority != priority)
            {
                throw new Exception(
                    $"Expected issue.Priority to be '{priority}' but was '{issue.Priority}'.");
            }

            if (issue.PriorityName != priorityName)
            {
                throw new Exception(
                    $"Expected issue.PriorityName to be '{priorityName}' but was '{issue.PriorityName}'.");
            }

            if (issue.Rule != rule)
            {
                throw new Exception(
                    $"Expected issue.Rule to be '{rule}' but was '{issue.Rule}'.");
            }

            if (issue.RuleUrl?.ToString() != ruleUrl?.ToString())
            {
                throw new Exception(
                    $"Expected issue.RuleUrl to be '{ruleUrl?.ToString()}' but was '{issue.RuleUrl?.ToString()}'.");
            }
        }
    }
}
