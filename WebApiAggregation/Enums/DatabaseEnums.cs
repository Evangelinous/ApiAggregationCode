using System.ComponentModel;

namespace ApiAggregation.Enums;


public enum ConnectionTypes
{
    FTE = 1,
    PTE = 2,
    Contractor = 3,
    Vendor = 4,
    ExternalContractor = 5
}

public enum DefaultHomePages
{
    MyPeopleHub = 1,
    OKRs = 2,
    SuccessAndImpact = 3,
    EntireOrginazation = 4,
    Feeback360 = 5,
    Home = 6,
    GrowthAndTalent = 7
}

public enum FeedbackAreas
{
    Leadership = 1,
    Professionalism = 2,
    Teamwork = 3,
    Communication = 4,
    ProblemSolving = 5,
    ExecutionOverall = 6,
    SeniorityOverall = 7
}

public enum FinalGoalStatuses
{
    Attained = 1,
    PartiallyAttained = 2,
    Unattainded = 3,
    Cancelled = 4,
    NonRelevant = 5
}

public enum Frequencies
{
    Weekly = 1,
    BiWeekly = 2,
    Monthly = 3,
    BiMonthly = 4,
    Quarterly = 5,
    SemiAnnual = 6,
    Annual = 7,
    ContinuousOrRolling = 8,
    AdHoc = 9
}

public enum GoalTypes
{
    LibraryGoal = 1,
    Objective = 2,
    KeyResult = 3
}

public enum IndividualPermanentStatuses
{
    Active = 1,
    Retired = 2,
    Resignated = 3,
    Fired = 4
}

public enum IndividualTemporaryStatuses
{
    Active = 1,
    Sickleave = 2,
    LongTermVacation = 3
}

public enum Languages
{
    Greek = 1,
    English = 2,
    Spanish = 3,
    Polish = 4,
    French = 5,
    Netherlands = 6,
    Deutsche = 7
}

public enum Levels
{
    None = 000,
    Basic = 100,
    Intermediate = 200,
    Advanced = 300,
    Expert = 400
}

public enum LibraryGoalCategories
{
    [Description("Financial")]
    Financial = 1,

    [Description("Customer")]
    Customer = 2,

    [Description("Operational")]
    Operational = 3,

    [Description("Employee Development")]
    EmployeeDevelopment = 4,

    [Description("Date Innovation")]
    DateInnovation = 5
}

public enum LibraryGoalExpectedOutcomeTypes
{
    [Description("Key Performance Indicators")]
    KeyPerformanceIndicators = 1,

    [Description("Quality Measurement")]
    QualityMeasurement = 2,

    [Description("Behavioral Goal")]
    BehavioralGoal = 3,

    [Description("Project Milestone")]
    ProjectMilestone = 4,

    [Description("Long Term Strategic Goal")]
    LongTermStrategicGoal = 5,

    [Description("Business Priority Goal")]
    BusinessPriorityGoal = 6,

    [Description("Cost Reduction Or Cost Savings")]
    CostReductionOrCostSavings = 7,

    [Description("Customer Acquisition Or Retention")]
    CustomerAcquisitionOrRetention = 8,

    [Description("Market Share Growth")]
    MarketShareGrowth = 9,

    [Description("Revenue Growth")]
    RevenueGrowth = 10,

    [Description("Customer Satisfaction And Net Promoter Score")]
    CustomerSatisfactionAndNetPromoterScore = 11,

    [Description("Operational Efficiency And Process Improvement")]
    OperationalEfficiencyAndProcessImprovement = 12,

    [Description("Innovation And Ideation")]
    InnovationAndIdeation = 13,

    [Description("Environmental Sustainability")]
    EnvironmentalSustainability = 14,

    [Description("Compliance And Regulatory Adherence")]
    ComplianceAndRegulatoryAdherence = 15,

    [Description("Organization Culture")]
    OrganizationCulture = 16,

    [Description("Diversity Equity And Inclusion")]
    DiversityEquityAndInclusion = 17,

    [Description("Other")]
    Other = 18

}

public enum MessageTypes
{
    Announcement = 1,
    Reminder = 2,
    ActionsNeeded = 3,
    Note = 4
}

public enum MeasurementUnits
{
    [Description("Percentage")]
    Percentage = 1,

    [Description("Numeric")]
    Numeric = 2,

    [Description("Currency")]
    Currency = 3,

    [Description("Ranking")]
    Ranking = 4,

    [Description("Date Time")]
    DateTime = 5,

    [Description("Other")]
    Other = 6
}


public enum Modules
{
    Default = 0,
    Feedback = 1,
    IndividualsAndNotifications = 2,
    OKR = 3,
    SuccessAndImpact = 4,
    Talent = 5,
    Auditing = 6,
    Authentication = 7,
    FilesStorage = 8
}

public enum NotificationTriggeringEvents
{
    #region OKR

    [Description("New Objective")]
    NewObjective = 1,

    [Description("Edit Objective")]
    EditObjective = 2,

    [Description("Check-In Objective")]
    CheckInObjective = 3,

    [Description("Final Check-In Objective")]
    FinalCheckInObjective = 4,

    [Description("New KeyResult")]
    NewKeyResult = 5,

    [Description("Edit KeyResult")]
    EditKeyResult = 6,

    [Description("Check-In KeyResult")]
    CheckInKeyResult = 7,

    [Description("Final Check-In KeyResult")]
    FinalCheckInKeyResult = 8,

    #endregion OKR

    #region Feedback

    [Description("New Feedback Request")]
    NewFeedbackRequest = 9,

    [Description("New Feedback Response")]
    NewFeedbackResponse = 10,

    [Description("New Feedback Provided")]
    NewFeedbackProvided = 11,

    #endregion Feedback

    #region SuccessAndResult

    [Description("New Goal")]
    NewGoal = 12,

    [Description("Edit Goal")]
    EditGoal = 13,

    [Description("Archive Goal")]
    ArchiveGoal = 14,

    [Description("Edit Personal Improvement Plan")]
    EditPersonalImprovementPlan = 15,

    [Description("Personal Improvement Plan Kick-Off")]
    PersonalImprovementPlanKickOff = 16,

    [Description("Personal Improvement Plan Check-In")]
    PersonalImprovementPlanCheckIn = 17,

    [Description("New Performance Period")]
    NewPerformancePeriod = 18,

    [Description("Edit Performance Period")]
    EditPerformancePeriod = 19,

    [Description("Performance Period Kick-Off")]
    PerformancePeriodIndividualKickOff = 20,

    [Description("Edit Performance Period Individual")]
    EditPerformancePeriodIndividual = 30,

    [Description("Performance Period Check-In")]
    PerformancePeriodIndividualCheckIn = 21,

    #endregion SuccessAndResult

    #region Talent

    [Description("Personal Development Plan Started")]
    PersonalDevelopmentPlanStarted = 22,

    [Description("Career Acceleration Plan Started")]
    CareerAccelerationPlanStarted = 23,

    [Description("Individual/Manager Personal Development Plan Check-In")]
    IndividualManagerPersonalDevelopmentPlanCheckIn = 24,

    [Description("Individual/Manager Career Acceleration Plan Check-In")]
    IndividualManagerCareerAccelerationPlanCheckIn = 25,

    [Description("Interim Check-In Request for Personal Development Plan")]
    InterimCheckInRequestForPersonalDevelopmentPlan = 26,

    [Description("Interim Check-In Request for Career Acceleration Plan")]
    InterimCheckInRequestForCareerAccelerationPlan = 27,

    [Description("Edit Personal Development Plan")]
    EditPersonalDevelopmentPlan = 28,

    [Description("Edit Career Acceleration Plan")]
    EditCareerAccelerationPlan = 29

    #endregion Talent
}

public enum MessageTriggeringEvents
{
    AskForCheckInPIP = 1,
    AskForCheckInPPI = 2,
    AskForCheckInPDP = 3,
    AskForCheckInCAP = 4,
    AskForInterimCheckInPDP = 5,
    AskForInterimCheckInCAP = 6
}

public enum ObjectiveTypes
{
    [Description("Strategic Objective")]
    StrategicObjective = 1,

    [Description("Operational Objective")]
    OperationalObjective = 2,

    [Description("Financial Objective")]
    FinancialObjective = 3,

    [Description("Customer Centric Objective")]
    CustomerCentricObjective = 4,

    [Description("Product or Service Development")]
    ProductOrServiceDevelopment = 5,

    [Description("Employee and Team Development")]
    EmployeeAndTeamDevelopment = 6,

    [Description("Market Expansion Objective")]
    MarketExpansionObjective = 7,

    [Description("Sustainability and Corporate Responsibility")]
    SustainabilityAndCorporateResponsibility = 8,

    [Description("Innovation and Technology")]
    InnovationAndTechnology = 9,

    [Description("Quality and Process Improvement")]
    QualityAndAProcessImprovement = 10,

    [Description("Market Leadership Objective")]
    MarketLeadershipObjective = 11,

    [Description("Community and Social Impact")]
    CommunityAndSocialImpact = 12
}


public enum PDPAreaTypes
{
    SoftSkill = 1,
    HardSkill = 2,
    Competence = 3
}

public enum PDPObjectiveTypes
{
    DevelopNewSkillAndCompetences = 1,
    EnhanceExistingSkillsAndCompetences = 2,
    OnboardingPlanToANewRolePosition = 3,
    Other = 4
}

public enum CAPObjectiveTypes
{
    VerticalAdvancement = 1,
    HorizontalMove = 2,
    ExploreCareerChangeOptionsWithinOrganization = 3,
    DiversifySkillsCompetencesExperiences = 4,
    GrowWithinTheSameDiscipline = 5
}

public enum PeopleHubUserTypes
{
    Individual = 1,
    Manager = 2,
    HRBP = 3
}

public enum PriorityCodes
{
    None = 0
}

public enum ProgressStatuses
{
    [Description("Not Started")]
    NotStarted = 1,

    [Description("Started")]
    Started = 2,

    [Description("On Hold")]
    OnHold = 3,

    [Description("At Risk")]
    AtRisk = 4,

    [Description("Behind Schedule")]
    BehindSchedule = 5,

    [Description("Slightly Behind")]
    SlightlyBehind = 6,

    [Description("On Track")]
    OnTrack = 7,

    [Description("Exceeded")]
    Exceeded = 8,

    [Description("Cancelled")]
    Cancelled = 9,

    [Description("Completed")]
    Completed = 10,

    [Description("Archived")]
    Archived = 11,

    [Description("Not Achieved")]
    NotAchieved = 12,

    [Description("Partially Achieved")]
    PartiallyAchieved = 13,

    [Description("Achieved")]
    Achieved = 14,
}

public enum Ratings
{
    NeedsSignificantImprovement = 1,
    NeedsImprovement = 2,
    MeetsExpectations = 3,
    ExceedsExpectations = 4
}

public enum ViewedByCodes
{
    Everyone = 1,
    ManagersAndLeadersOfMyOrginazation = 2,
    MyDirectReports_ManagersOnly = 3,
    MyselfOnly = 4
}

public enum AvailableToCodes
{
    MySelfOnly = 1,
    MyDirectReportsOnlyManagersAndLeaders = 2,
    MyEntireOrganizationManagersAndLeaders = 3
}

public enum PerformancePeriodAvailableToCodes
{
    MySelfOnly = 1,
    MyEntireOrganizationManagersAndLeaders = 2,
    MyDirectReportsOnlyManagersAndLeaders = 3,
    EntireOrganizationManagersAndLeaders = 4,
}

public enum PerformancePeriodStateCode
{
    Start = 1,
    IndividualCheckIn = 2,
    ManagerCheckIn = 3,
    End = 4
}

public enum SkillsDevelopedByCodes
{
    OnTheJob = 1,
    Training = 2,
    Mentoring = 3,
    Combined = 4,
    Other = 5
}

public enum PrimaryActivityTypeCodes
{
    Mentoring = 1,
    EnternalAndInternalTraining = 2,
    SelfStudy = 3,
    LearnFromOthers = 4,
    StrachAssignmentAndOnTheJobLearning = 5
}

public enum PIPStateCodes
{
    [Description("Started")]
    Started = 1,

    [Description("Individual CheckIn")]
    IndividualCheckIn = 2,

    [Description("Manager CheckIn")]
    ManagerCheckIn = 3,

    [Description("Final Check In And Closed")]
    FinalCheckInAndClosed = 4
}

public enum PPIStateCodes
{
    [Description("Started")]
    Started = 1,

    [Description("Individual CheckIn")]
    IndividualCheckIn = 2,

    [Description("Manager CheckIn")]
    ManagerCheckIn = 3,

    [Description("Final Check In And Closed")]
    FinalCheckInAndClosed = 4
}

public enum PDPStateCodes
{
    [Description("Started")]
    Started = 1,

    [Description("Individual CheckIn")]
    IndividualCheckIn = 2,

    [Description("Manager CheckIn")]
    ManagerCheckIn = 3,

    [Description("Final Check In And Closed")]
    FinalCheckInAndClosed = 4,

    [Description("Interim CheckIn")]
    InterimCheckIn = 5
}

public enum CAPStateCodes
{
    [Description("Started")]
    Started = 1,

    [Description("Individual CheckIn")]
    IndividualCheckIn = 2,

    [Description("Manager CheckIn")]
    ManagerCheckIn = 3,

    [Description("Final Check In And Closed")]
    FinalCheckInAndClosed = 4,

    [Description("Interim CheckIn")]
    InterimCheckIn = 5
}

public enum Components
{
    CurrentPPI = 231,
    CheckInPPI = 232,
    CurrentPDP = 135,
    CurrentCAP = 136
}