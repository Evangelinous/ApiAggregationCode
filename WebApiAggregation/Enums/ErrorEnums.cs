namespace ApiAggregation.Enums;

public enum ErrorTypes
{
    ValidationError = 1,
    BusinessError = 2,
    SystemError = 3,
    AuthenticationError = 4
}

public enum ErrorCodes
{
    Default,

    //NOT VALID
    PageNumber_NotValid,
    PageSize_NotValid,
    SortingDirection_NotValid,
    SortingProperty_NotValid,

    EnumValue_NotValid,
    ReviewFrequency_NotValid,
    PrimaryActivityType_NotValid,
    ExpectedLevel_NotValid,
    SkillsDevelopedBy_NotValid,
    Level_NotValid,
    PDPObjectiveType_NotValid,
    PDPAreaType_NotValid,
    ExistingLevel_NotValid,
    CAPObjectiveType_NotValid,
    ObjectiveType_NotValid,
    MeasurementUnit_NotValid,
    ProgressStatus_NotValid,
    ListView_NotValid,
    LibraryGoalExpectedOutcomeType_NotValid,
    PeopleHubUILanguage_NotValid,
    PeopleHubUIDefaultHomePage_NotValid,
    MessageType_NotValid,
    CheckInFrequency_NotValid,
    GoalType_NotValid,
    AvailableTo_NotValid,
    NotificationTriggeringEvent_NotValid,
    Module_NotValid,
    Priority_NotValid,

    IndividualOverallProgressStatus_NotValid,
    ManagerOverallProgressStatus_NotValid,
    IndividualAreaProgressStatus_NotValid,
    ManagerAreaProgressStatus_NotValid,
    InterimOverallProgressStatus_NotValid,
    IndividualDevelopmentFocusOverallProgressStatus_NotValid,
    ManagerDevelopmentFocusOverallProgressStatus_NotValid,
    InterimDevelopmentFocusOverallProgressStatus_NotValid,
    IndividualAreaOverallProgressStatus_NotValid,
    ManagerAreaOverallProgressStatus_NotValid,
    InterimAreaOverallProgressStatus_NotValid,
    EndStatus_NotValid,

    IndividualDevelopmentActivityOverallProgressStatus_NotValid,
    IndividualDevelopmentActivityCurrentLevel_NotValid,
    IndividualDevelopmentActivityComments_Mandatory,
    ManagerDevelopmentActivityOverallProgressStatus_NotValid,
    ManagerDevelopmentActivityCurrentLevel_NotValid,
    ManagerDevelopmentActivityComments_Mandatory,
    InterimDevelopmentActivityOverallProgressStatus_NotValid,
    InterimDevelopmentActivityCurrentLevel_NotValid,
    InterimDevelopmentActivityComments_Mandatory,

    IndividualTeamForMessages_NotValid,
    ComponentID_NotValid,
    SecretValue_NotValid,
    CheckInRequest_NotValid,

    IndividualID_NullOrEmpty,
    Email_NullOrEmpty,

    //MANDATORY

    IndividualComments_Mandatory,
    IndividualFocusesComments_Mandatory,
    IndividualDevelopmentFocusComments_Mandatory,
    IndividualAreaComments_Mandatory,
    ManagerComments_Mandatory,
    ManagerFocusesComments_Mandatory,
    ManagerDevelopmentFocusComments_Mandatory,
    ManagerAreaComments_Mandatory,
    InterimComments_Mandatory,
    InterimFocusesComments_Mandatory,
    InterimDevelopmentFocusComments_Mandatory,
    InterimAreaComments_Mandatory,
    FinalCheckInAchievedDate_Mandatory,
    FinalCheckInEndStatus_Mandatory,
    AtLeastOneArea_Mandatory,
    AtLeastOneObjective_Mandatory,
    AtLeastOneDevelopmentFocus_Mandatory,
    AtLeastOneDevelopmentActivity_Mandatory,
    AtLeastOneGoal_Mandatory,
    CheckInID_Mandatory,

    //NOT FOUND
    Individual_NotFound,
    Individuals_NotFound,
    Objective_NotFound,
    KeyResult_NotFound,
    Feedback_NotFound,
    LibraryGoal_NotFound,
    PerformancePeriod_NotFound,
    PerformancePeriodIndividual_NotFound,
    PerformancePeriodsIndividual_NotFound,
    PersonalImprovementPlan_NotFound,
    CareerAccelerationPlan_NotFound,
    PersonalDevelopmentPlan_NotFound,
    Message_NotFound,
    CheckIn_NotFound,

    //KICK OFF - ADD
    CanBeKickedOffByHierarchicalManagerOrHRBP,
    CanBeAddedByOwnerOrManager,
    CanBeAddedByMembersOrObjectiveOwnerAndManager,

    //EDIT
    CanBeEditedByHierarchicalManagerOrHRBP,
    CanBeEditedByIndividualOrHierchicalManager,
    CanBeEditedByMembersOrHRBP,
    CanBeEditedByMembersOrObjectiveOwnerAndManagerOrHRBP,
    CanBeEditedByOwnerOrOwnerHierarchicalManagerOrHRBP,

    CannotEditArea,
    CannotEditAndDeleteArea,
    CannotEditDevelopmentArea,
    CannotEditAndDeleteDevelopmentArea,
    CannotEditGoal,
    CannotEditAndDeleteGoal,
    CannotEditObjective,
    CannotEditAndDeleteObjective,
    CannotEditDevelopmentFocus,
    CannotEditAndDeleteDevelopmentFocus,
    CannotEditDevelopmentActivity,
    CannotEditAndDeleteDevelopmentActivity,
    CannotEditSkillAndStrength,
    CannotEditAndDeleteSkillAndStrength,
    CannotEditNextRole,
    CannotEditAndDeleteNextRole,
    CannotEditPreviousRole,
    CannotEditAndDeletePreviousRole,

    CannotEditWithOpenCheckIn,
    SupportingTeamCanEditOnlySupportingTeam,

    //CHECK IN
    CanBeCheckedInByIndividualOrHierarchicalManager,
    CanBeCheckedInByMembers,
    CanBeCheckedInByMembersOrObjectiveOwnerAndManager,

    CanBeCheckedInFinalByOwnerOrManager,
    CanBeCheckedInFinalObjectiveOrKeyResultOwnersAndManagers,
    CanBeCheckedInFinalByHierarchicalManager,
    CanBeCheckedInFinalWithClosedKeyResults,

    CanBeCheckedInIndividualByIndividual,
    CanBeCheckedInManagerByHierarchicalManager,
    CanBeCheckedInInterimByRequestedIndividual,

    CheckInCanBeCompletedOnlyByAHierarchicalManager,

    //DELETE
    CannotDeleteArea, 
    CannotDeleteDevelopmentArea,
    CannotDeleteGoal,
    CannotDeleteObjective,
    CannotDeleteDevelopmentFocus,
    CannotDeleteDevelopmentActivity,
    CannotDeleteSkillAndStrength,
    CannotDeleteNextRole,
    CannotDeletePreviousRole,

    //CLOSE
    CanBeClosedByOwnerOrOwnerHierarchicalManagerOrHRBP,

    //ASK FOR CHECK IN
    CanBeAskedForInterimCheckInByHierarchicalManager,
    CanBeAskedForCheckInByHierarchicalManager,
    PersonalImprovementPlan_CannotAskIndividualToCheckIn,

    //DATES

    StartDateMustBeBetweenObjectiveStartAndEndDates,
    EndDateMustBeBetweenObjectiveStartAndEndDates,
    MilestoneDateMustBeBetweenKeyResultStartAndEndDates,

    EndDateMustBeGreaterOfStartDate,
    EndDateMustBeGreaterOrEqualToToday,
    EndDateMustBeGreaterOrEqualToStartDate,
    FinalReviewDateMustBeGreaterOrEqualToStartDate,
    AchievedDateMustBeBetweenLastCheckInDateAndToday,

    CheckInDateMustBeBetweenStartAndEndDate,
    CheckInDateMustBeGreaterOrEqualToStartDate,
    CheckInDateMustBeBeforeOrEqualToToday,
    CheckInDateMustBeGreaterOrEqualToPreviousCheckInDate,
    FinalCheckInDateMustBeGreaterOrEqualToCheckInDate,
    FinalCheckInDateMustBeGreaterOfStartDate,

    //RANDOM

    AlreadyArchived,
    AlreadyClosed,
    AlreadyRead,
    AlreadyFinalised,
    AlreadyAskedForInterimCheckIn,
    AlreadyHasAnActive,

    CheckInMissingAreas,
    CheckInMissingGoals,
    CheckInMissingDevelopmentFocuses,
    CheckInMissingDevelopmentActivities,

    OpenCheckInProcessExists,
    NoOpenCheckInProcessExists,
    NoOpenInterimCheckInProcessExists,
    OnlyLastCheckInCanBeUpdated,
    OnlyOpenCheckInCanBeUpdated,
    InterimCheckInAlreadyCompleted,




    //NOT SORTED YET

    Individual_NotSubordinate,
    Notifications_NotOwnedByIndividual,
    OnlyHierarchicalManagersAndHRBPCanSeeIndividualHistorical,
    Feedback_OnlyResponserRequestorAndHRBPHasAccess,
    Feedback_RequestorIDCantBeInResponsersIDsList,
    Feedback_RequestorIDCantGivehimshelfFeedback,
    HasOpenPerformancePeriodsIndividuals,
    Object_NotAvailableForIndividual,
    IndividualsGroup_NotAvailableForIndividual,
    EntireOrganizationOptionAvailableToHRBP,
    ManagersAndLeadersOptionAvailableToHRBP,
    PerformancePeriod_AvailableToOptionNotAvailableForManager,
    PerformancePeriod_AvailableToOptionNotAvailableForHRBPWithoutSubordinates,
    LibraryGoal_NotAvailableToAddAsGoalForIndividual,
    Objective_NotAvailableToAddAsGoalForIndividual,
    KeyResult_NotAvailableToAddAsGoalForIndividual,


    //500-600 SYSTEM ERROR CODES

    GeneralSystemError,

    FilesStorage_CouldNotRetrieveUrlDetails,
    FilesStorage_CouldNotUploadFile,
    FilesStorage_CouldNotDeleteFile,
    FilesStorage_CouldNotUpdateDatabase,

    RefreshToken_NotRetrieved,
    Auditing_NotCompleted,

    Audit_NotCreated,
    Feedbacks_NotCreated,
    KeyResult_NotCreated,
    KeyResultsMilestones_NotCreated,
    Objective_NotCreated,
    LibraryGoal_NotCreated,
    PerformancePeriodIndividual_NotCreated,
    PerformancePeriodIndividualGoal_NotCreated,
    PersonalImprovementPlan_NotCreated,
    CareerAccelerationPlan_NotCreated,
    PersonalDevelopmentPlan_NotCreated,
    Message_NotCreated,
    CheckIn_NotCreated,

    Individual_NotUpdated,
    Notifications_NotUpdated,
    Objective_NotUpdated,
    KeyResult_NotUpdated,
    LibraryGoal_NotUpdated,
    PerformancePeriod_NotUpdated,
    Message_NotUpdated,
    PersonalImprovementPlan_NotUpdated,
    Feedbacks_NotUpdated,


    Objective_NotArchived,
    Objectives_NotArchived,
    KeyResult_NotArchived,
    KeyResults_NotArchived,
    LibraryGoal_NotClosed,
    PerformancePeriod_NotClosed,
    PerformnacePeriods_NotArchived,
    PerformancePeriodIndividuals_NotArchived,

    Audit_NotDeleted,
    Notifications_NotDelete,


    //900 AUTHENTICATION-AUTHORIZATION ERROR CORES

    SessionID_Invalid,
    RefreshToken_Expired,
    SamlAssertion_Invalid,
    RefreshToken_NotProvided,
    RefreshToken_Invalid,
    SessionID_NotProvided,
    Individual_NotActive

}
