﻿using System;
using System.Linq;
using Newtonsoft.Json;

namespace Vsts.Cli
{
    public class Repository
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Project Project { get; set; }
        public string DefaultBranch { get; set; }
        public string RemoteUrl { get; set; }
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
        public string Visibility { get; set; }
    }

    public class ProjectResource
    {
        public int Count { get; set; }
        public Project[] value { get; set; }
    }

    public class RepositoryResource
    {
        public Repository[] Value { get; set; }
    }

    public class PullRequesetResource
    {
        public PullRequest[] Value { get; set; }
    }

    public class PullRequest
    {
        public Repository Repository { get; set; }
        public int PullRequestId { get; set; }
        public int CodeReviewId { get; set; }
        public string Status { get; set; }
        public CreatedBy CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SourceRefName { get; set; }
        public string TargetRefName { get; set; }
        public string MergeStatus { get; set; }
        public string MergeId { get; set; }
        public Lastmergesourcecommit LastMergeSourceCommit { get; set; }
        public Lastmergetargetcommit LastMergeTargetCommit { get; set; }
        public Lastmergecommit LastMergeCommit { get; set; }
        public Reviewer[] Reviewers { get; set; }
        public string Url { get; set; }
        public bool SupportsIterations { get; set; }
    }

    public class CreatedBy
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UniqueName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
    }

    public class Commit
    {
        public string CommitId { get; set; }
        public string Url { get; set; }
    }

    public class Lastmergesourcecommit : Commit
    {
    }

    public class Lastmergetargetcommit : Commit
    {
    }

    public class Lastmergecommit : Commit
    {
    }

    public class Reviewer
    {
        public string ReviewerUrl { get; set; }
        public int Vote { get; set; }
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UniqueName { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public bool IsContainer { get; set; }
    }


    public class WorkItemResource
    {
        public string QueryType { get; set; }
        public string QueryResultType { get; set; }
        public DateTime AsOf { get; set; }
        public Column[] Columns { get; set; }
        public Sortcolumn[] SortColumns { get; set; }
        public WorkItem[] WorkItems { get; set; }
    }

    public class Column
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class Sortcolumn
    {
        public Field Field { get; set; }
        public bool Descending { get; set; }
    }

    public class Field
    {
        public string ReferenceName { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

    public class WorkItem
    {
        public int id { get; set; }
        public string url { get; set; }
    }

    public class WorkItemSearchResource
    {
        public string Query { get; set; }
    }

    public class WorkItemDetailResource
    {
        public int Count { get; set; }
        public Value[] Value { get; set; }
    }

    public class Value
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public Fields Fields { get; set; }
        public string Url { get; set; }
    }

    public partial class Fields
    {
        [Newtonsoft.Json.JsonProperty("System.Id")]
        public int Id { get; set; }
        [Newtonsoft.Json.JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }
        [Newtonsoft.Json.JsonProperty("System.State")]
        public string State { get; set; }
        [Newtonsoft.Json.JsonProperty("System.AssignedTo")]
        public string AssignedTo { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string AssignedToName => AssignedTo?.Split('<').First().Trim();

        [Newtonsoft.Json.JsonProperty("System.Title")]
        public string Title { get; set; }
        [Newtonsoft.Json.JsonProperty("System.Description")]
        public string Description { get; set; }
        [Newtonsoft.Json.JsonProperty("System.CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [Newtonsoft.Json.JsonProperty("System.Tags")]
        public string Tags { get; set; }
    }

    public partial class Fields
    {
        public int WorkItemIdLength => Id.ToString().Length;
        public int StateLength => State.Length;
        public int AssignedToNameLength => string.IsNullOrWhiteSpace(AssignedToName) ? 0 : AssignedToName.Length;
        public int WorkItemTypeLength => string.IsNullOrWhiteSpace(WorkItemType) ? 0 : WorkItemType.Length;
    }

    //New work item
    public class NewWorkItemResource
    {
        public int Id { get; set; }
        public int Rev { get; set; }
        public WorkItemFields Fields { get; set; }
        [Newtonsoft.Json.JsonProperty("_links")]
        public Links Links { get; set; }
        public string Url { get; set; }
    }
    public class WorkItemFields
    {
        [Newtonsoft.Json.JsonProperty("System.AreaPath")]
        public string AreaPath { get; set; }
        [Newtonsoft.Json.JsonProperty("System.TeamProject")]
        public string TeamProject { get; set; }
        [Newtonsoft.Json.JsonProperty("System.IterationPath")]
        public string IterationPath { get; set; }
        [Newtonsoft.Json.JsonProperty("System.WorkItemType")]
        public string WorkItemType { get; set; }
        [Newtonsoft.Json.JsonProperty("System.State")]
        public string State { get; set; }
        [Newtonsoft.Json.JsonProperty("System.Reason")]
        public string Reason { get; set; }
        [Newtonsoft.Json.JsonProperty("System.CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [Newtonsoft.Json.JsonProperty("System.CreatedBy")]
        public string CreatedBy { get; set; }
        [Newtonsoft.Json.JsonProperty("System.ChangedDate")]
        public DateTime ChangedDate { get; set; }
        [Newtonsoft.Json.JsonProperty("System.ChangedBy")]
        public string ChangedBy { get; set; }
        [Newtonsoft.Json.JsonProperty("System.Title")]
        public string Title { get; set; }
        [Newtonsoft.Json.JsonProperty("Microsoft.VSTS.Common.StateChangeDate")]
        public DateTime StateChangeDate { get; set; }
        [Newtonsoft.Json.JsonProperty("Microsoft.VSTS.Common.Priority")]
        public int Priority { get; set; }
        [Newtonsoft.Json.JsonProperty("Microsoft.VSTS.Common.Severity")]
        public string Severity { get; set; }
        [Newtonsoft.Json.JsonProperty("Microsoft.VSTS.Common.ValueArea")]
        public string ValueArea { get; set; }
        [Newtonsoft.Json.JsonProperty("System.Description")]
        public string Description { get; set; }
    }

    public class Links
    {
        public Self Self { get; set; }
        public Workitemupdates WorkItemUpdates { get; set; }
        public Workitemrevisions WorkItemRevisions { get; set; }
        public Workitemhistory WorkItemHistory { get; set; }
        public Html Html { get; set; }
        public Workitemtype WorkItemType { get; set; }
        public Fields1 Fields { get; set; }
    }
    public class Self
    {
        public string Href { get; set; }
    }
    public class Workitemupdates
    {
        public string Href { get; set; }
    }
    public class Workitemrevisions
    {
        public string Href { get; set; }
    }
    public class Workitemhistory
    {
        public string Href { get; set; }
    }
    public class Html
    {
        public string Href { get; set; }
    }
    public class Workitemtype
    {
        public string Href { get; set; }
    }
    public class Fields1
    {
        public string Href { get; set; }
    }

    // Build Definition
    public class BuildDefinitionResource
    {
        public int count { get; set; }
        public BuildDefinition[] value { get; set; }
    }

    public class BuildDefinition
    {
        public BuildDefinitionLinks _links { get; set; }
        public string quality { get; set; }
        public Authoredby authoredBy { get; set; }
        public Queue queue { get; set; }
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string uri { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public int revision { get; set; }
        public DateTime createdDate { get; set; }
        public Project project { get; set; }
    }

    public class BuildDefinitionLinks
    {
        public Self self { get; set; }
        public Web web { get; set; }
        public Editor editor { get; set; }
    }

    public class Web
    {
        public string href { get; set; }
    }

    public class Editor
    {
        public string href { get; set; }
    }

    public class Authoredby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Queue
    {
        public int id { get; set; }
        public string name { get; set; }
        public Pool pool { get; set; }
    }

    public class Pool
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isHosted { get; set; }
    }

    // Build List
    public class BuildListResource
    {
        public int count { get; set; }
        public BuildListItem[] value { get; set; }
    }

    public partial class BuildListItem
    {
        public _Links _links { get; set; }
        public Plan[] plans { get; set; }
        public int id { get; set; }
        public string buildNumber { get; set; }
        public string status { get; set; }
        public string result { get; set; }
        public DateTime queueTime { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public string url { get; set; }
        public Definition definition { get; set; }
        public Project project { get; set; }
        public string uri { get; set; }
        public string sourceBranch { get; set; }
        public string sourceVersion { get; set; }
        public Queue queue { get; set; }
        public string priority { get; set; }
        public string reason { get; set; }
        public Requestedfor requestedFor { get; set; }
        public Requestedby requestedBy { get; set; }
        public DateTime lastChangedDate { get; set; }
        public Lastchangedby lastChangedBy { get; set; }
        public Orchestrationplan orchestrationPlan { get; set; }
        public Logs logs { get; set; }
        public BuildDefinitionRepository repository { get; set; }
        public bool keepForever { get; set; }
        public bool retainedByRelease { get; set; }
        public int buildNumberRevision { get; set; }
        public string parameters { get; set; }
    }

    public partial class BuildListItem
    {
        public ConsoleColor ConsoleColor => status.Equals("completed", StringComparison.OrdinalIgnoreCase)
            ? result.Equals("failed") ? ConsoleColor.Red : ConsoleColor.Green : ConsoleColor.Yellow;

        public int ResultNameLength => string.IsNullOrWhiteSpace(result) ? 1 : result.Length;
        public string ResultName(int max) => string.IsNullOrWhiteSpace(result) ? " ".PadRight(max) : result.PadRight(max);

        public string TimeReport =>
            status.Equals("completed", StringComparison.OrdinalIgnoreCase)
            ? (finishTime.Equals(DateTime.MinValue) ? " ".PadRight(16) : $"{finishTime.ToLocalTime():yyyy/MM/dd hh:mm}")
            : $"{GetTimeSpan(startTime).PadRight(16)}";

        private string GetTimeSpan(DateTime past)
        {
            if (status.Equals("notStarted", StringComparison.OrdinalIgnoreCase)) return " ";

            var timeSpan = (DateTime.UtcNow - past);

            var seconds = timeSpan.Seconds;
            int minutes = timeSpan.Minutes;

            if (minutes < 1 && seconds <= 60)
                return $"{seconds} seconds";

            return $"{minutes} min {seconds} sec";
        }

        public int StatusNameLength => string.IsNullOrWhiteSpace(status) ? 1 : status.Length;
        public int DefinitionNameLength => string.IsNullOrWhiteSpace(definition?.name) ? 1 : definition.name.Length;
        public int DefinitionIdLength => id.ToString().Length;
    }

    public class _Links
    {
        public Self self { get; set; }
        public Web web { get; set; }
        public Sourceversiondisplayuri sourceVersionDisplayUri { get; set; }
        public Timeline timeline { get; set; }
    }

    public class Sourceversiondisplayuri
    {
        public string href { get; set; }
    }

    public class Timeline
    {
        public string href { get; set; }
    }

    public class Definition
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string path { get; set; }
        public string type { get; set; }
        public int revision { get; set; }
        public Project project { get; set; }
    }

    public class Requestedfor
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Requestedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Lastchangedby
    {
        public string id { get; set; }
        public string displayName { get; set; }
        public string uniqueName { get; set; }
        public string url { get; set; }
        public string imageUrl { get; set; }
    }

    public class Orchestrationplan
    {
        public string planId { get; set; }
    }

    public class Logs
    {
        public int id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class BuildDefinitionRepository
    {
        public string id { get; set; }
        public string type { get; set; }
        public object clean { get; set; }
        public bool checkoutSubmodules { get; set; }
    }

    public class Plan
    {
        public string planId { get; set; }
    }

    //Timeline
    public class TimelineResource
    {
        public Record[] records { get; set; }
        public string lastChangedBy { get; set; }
        public DateTime lastChangedOn { get; set; }
        public string id { get; set; }
        public int changeId { get; set; }
        public string url { get; set; }
    }

    public partial class Record
    {
        public string id { get; set; }
        public string parentId { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public DateTime startTime { get; set; }
        public DateTime finishTime { get; set; }
        public object currentOperation { get; set; }
        public object percentComplete { get; set; }
        public string state { get; set; }
        public string result { get; set; }
        public object resultCode { get; set; }
        public int changeId { get; set; }
        public DateTime lastModified { get; set; }
        public string workerName { get; set; }
        public int order { get; set; }
        public Details details { get; set; }
        public int errorCount { get; set; }
        public int warningCount { get; set; }
        public object url { get; set; }
        public Log log { get; set; }
        public Task task { get; set; }
        public Issue[] issues { get; set; }
    }

    public partial class Record
    {
        public string resultSymbol => result.Equals("succeed", StringComparison.OrdinalIgnoreCase) ? "+" : result.Equals("skipped", StringComparison.OrdinalIgnoreCase) ? "=" : "x";


        public ConsoleColor ConsoleColor => state.Equals("completed", StringComparison.OrdinalIgnoreCase)
            ? result.Equals("failed") ? ConsoleColor.Red : ConsoleColor.Green : ConsoleColor.Yellow;
    }

    public class Details
    {
        public string id { get; set; }
        public int changeId { get; set; }
        public string url { get; set; }
    }

    public class Log
    {
        public int id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
    }

    public class Task
    {
        public string id { get; set; }
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Issue
    {
        public string type { get; set; }
        public string category { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string type { get; set; }
        public string code { get; set; }
        public string sourcepath { get; set; }
        public string linenumber { get; set; }
        public string columnnumber { get; set; }
        public string repo { get; set; }
    }

    //Logs

    public class LogResource
    {
        public int count { get; set; }
        public string[] value { get; set; }
    }

    // Pull request error
    public class PullRequestErrorResource
    {
        public string id { get; set; }
        public object innerException { get; set; }
        public string message { get; set; }
        public string typeName { get; set; }
        public string typeKey { get; set; }
        public int errorCode { get; set; }
        public int eventId { get; set; }
    }

    //Build definition queue

    public class BuildDefinitionQueueResource
    {
        [JsonProperty("Definition")]
        public DefinitionId definition { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string sourceBranch { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string parameters { get; set; }
    }

    public class DefinitionId
    {
        public int id { get; set; }
    }

}
